using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows;
using System.Windows.Controls;
using System.Windows.Data;
using System.Windows.Documents;
using System.Windows.Input;
using System.Windows.Media;
using System.Windows.Media.Imaging;
using System.Windows.Navigation;
using System.Windows.Shapes;
using System.Runtime.InteropServices;
using System.Windows.Interop;
using System.Threading;

namespace ClickThru
{
    /// <summary>
    /// Interaction logic for MainWindow.xaml
    /// </summary>
    public partial class MainWindow : Window
    {
        private bool Through = false;

        [DllImport("user32.dll")]
        [return: MarshalAs(UnmanagedType.Bool)]
        internal static extern bool GetCursorPos(ref Win32Point pt);

        [StructLayout(LayoutKind.Sequential)]
        internal struct Win32Point
        {
            public Int32 X;
            public Int32 Y;
        };

        public static Point GetMousePosition()
        {
            Win32Point w32Mouse = new Win32Point();
            GetCursorPos(ref w32Mouse);
            return new Point(w32Mouse.X, w32Mouse.Y);
        }

        public MainWindow()
        {
            InitializeComponent();


            Thread globalMouseListener = new Thread(() =>
            {
                while (true)
                {
                    Point p1 = GetMousePosition();
                    bool mouseInControl = false;

                    Point p2 = new Point();
                    Rect r = new Rect();

                    Dispatcher.BeginInvoke(new Action(() =>
                    {
                            // Get control position relative to window
                            p2 = mySquare.TransformToAncestor(this).Transform(new Point(0, 0));

                            // Add window position to get global control position
                            r.X = p2.X + this.Left;
                        r.Y = p2.Y + this.Top;

                            // Set control width/height
                            r.Width = mySquare.Width;
                        r.Height = mySquare.Height;

                        if (r.Contains(p1))
                        {
                            mouseInControl = true;
                        }

                        if (mouseInControl && !Through)
                        {
                            MouseThru(true);
                        }
                        else if (!mouseInControl && Through)
                        {
                            MouseThru(false);
                        }
                    }));


                    Thread.Sleep(5);
                }
            });

            globalMouseListener.Start();

        }

        public const int WS_EX_TRANSPARENT = 0x00000020; public const int GWL_EXSTYLE = (-20);

        [DllImport("user32.dll")]
        public static extern int GetWindowLong(IntPtr hwnd, int index);

        [DllImport("user32.dll")]
        public static extern int SetWindowLong(IntPtr hwnd, int index, int newStyle);


        private void MouseThru(bool Thru)
        {
            // Get this window's handle         
            IntPtr hwnd = new WindowInteropHelper(this).Handle;
            // Change the extended window style to include WS_EX_TRANSPARENT         
            int extendedStyle = GetWindowLong(hwnd, GWL_EXSTYLE);

            if (Thru)
            {
                SetWindowLong(hwnd, GWL_EXSTYLE, extendedStyle | WS_EX_TRANSPARENT);
            }
            else
            {
                SetWindowLong(hwnd, GWL_EXSTYLE, extendedStyle & ~WS_EX_TRANSPARENT);
            }
            Through = Thru;
        }

        protected override void OnSourceInitialized(EventArgs e)
        {
            base.OnSourceInitialized(e);
            var hwnd = new WindowInteropHelper(this).Handle;


        }
    }

}

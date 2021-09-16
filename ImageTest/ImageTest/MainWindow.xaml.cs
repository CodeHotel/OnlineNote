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
using System.Drawing;
using System.Drawing.Imaging;
using System.IO;
using System.Windows.Forms;
using System.Windows.Interop;
using System.Windows.Threading;

namespace ImageTest
{
    /// <summary>
    /// Interaction logic for MainWindow.xaml
    /// </summary>
    public partial class MainWindow : Window
    {
        public MainWindow()
        {
            InitializeComponent();
        }

        private void button_Click(object sender, RoutedEventArgs e)
        {
            Dispatcher.Invoke(new Action(() => { CaptureRect.StrokeThickness = 0; }), DispatcherPriority.Send, null);
            Dispatcher.Invoke(new Action(() => { }), DispatcherPriority.SystemIdle, null);
            ScCap((int)CaptureRect.PointFromScreen(new System.Windows.Point(0d, 0d)).X,
(int)CaptureRect.PointFromScreen(new System.Windows.Point(0d, 0d)).Y,
(int)CaptureRect.Width,
(int)CaptureRect.Height, 3);




        }


        public Bitmap ScCap(int locx, int locy, int sizex, int sizey, int excludepts)
        {
            PresentationSource source = PresentationSource.FromVisual(this);
            //Dispatcher.Invoke(new Action(() => { }), DispatcherPriority.ContextIdle, null);
            var wpfActiveScreen = System.Windows.Forms.Screen.FromHandle(new System.Windows.Interop.WindowInteropHelper(this).Handle);
            Bitmap localBmp = new Bitmap(sizex, sizey, System.Drawing.Imaging.PixelFormat.Format32bppArgb);
            IntPtr bmptr; BitmapSource bmpsource;
            using (Graphics g = Graphics.FromImage(localBmp))
            {

                g.CopyFromScreen(wpfActiveScreen.Bounds.X-locx, wpfActiveScreen.Bounds.Y-locy, 0, 0, localBmp.Size, CopyPixelOperation.SourceCopy);
                CaptureRect.StrokeThickness = 3;
                if (localBmp != null)
                {
                    bmptr = localBmp.GetHbitmap();
                    bmpsource = Imaging.CreateBitmapSourceFromHBitmap(bmptr, IntPtr.Zero, Int32Rect.Empty, BitmapSizeOptions.FromEmptyOptions());
                    DisplayRect.Fill = new ImageBrush(bmpsource);

                    /*SaveFileDialog sfd = new SaveFileDialog();
                    sfd.Filter = "JPG File(*.jpg) | *.jpg";
                    if (sfd.ShowDialog() == System.Windows.Forms.DialogResult.OK)
                    {
                        localBmp.Save(sfd.FileName);
                    }*/
                }
                
            }
            
            return localBmp;
        }
    }
}

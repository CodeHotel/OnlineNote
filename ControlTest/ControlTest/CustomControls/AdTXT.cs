using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows;
using System.Windows.Controls;
using System.Windows.Input;
using System.Windows.Shapes;

namespace ControlTest.CustomControls
{
    class AdTXT:Control
    {
        private bool mousedown;
        private double ox1;
        private double oy1;
        private double ox2;
        private double oy2;
        private double cpx;
        private double cpy;
        #region 구성요소 레퍼런스 변수선언
        private TextBox innerbox;
        private Line LUp;
        private Line LDown;
        private Line LRight;
        private Line LLeft;
        private Rectangle NE;
        private Rectangle SW;
        private Rectangle NW;
        private Rectangle SE;
        private Rectangle UP;
        private Rectangle DOWN;
        private Rectangle RIGHT;
        private Rectangle LEFT;
        #endregion
        static AdTXT()
        {
            DefaultStyleKeyProperty.OverrideMetadata(typeof(AdTXT), new FrameworkPropertyMetadata(typeof(AdTXT)));
        }

        public bool Selected()
        {
            return true;
        }
        #region mousehover 이벤트처리함수
        private void Square_MouseEnter_NWSE(object sender, MouseEventArgs e)
        {
            Cursor = Cursors.SizeNWSE;
        }
        private void Square_MouseLeave_NWSE(object sender, MouseEventArgs e)
        {
            Cursor = Cursors.Arrow;
            if (mousedown) { NWMove(sender, e); }
        }

        private void Square_MouseEnter_NESW(object sender, EventArgs e)
        {
            Cursor = Cursors.SizeNESW;
        }
        private void Square_MouseLeave_NESW(object sender, EventArgs e)
        {
            Cursor = Cursors.Arrow;
        }

        private void Square_MouseEnter_NS(object sender, EventArgs e)
        {
            Cursor = Cursors.SizeNS;
        }
        private void Square_MouseLeave_NS(object sender, EventArgs e)
        {
            Cursor = Cursors.Arrow;
        }

        private void Square_MouseEnter_WE(object sender, EventArgs e)
        {
            Cursor = Cursors.SizeWE;
        }
        private void Square_MouseLeave_WE(object sender, EventArgs e)
        {
            Cursor = Cursors.Arrow;
        }
        #endregion
        #region 크기조정 이벤트처리함수
        private void NWDown(object sender, MouseEventArgs e)
        {
            mousedown = true;
            Mouse.Capture(Window.GetWindow(this), CaptureMode.SubTree);
            cpx = e.GetPosition(null).X;
            cpy = e.GetPosition(null).Y;

            ox1 = innerbox.Margin.Left;
            oy1 = innerbox.Margin.Top;

            ox2 = ox1 + innerbox.Width;
            oy2 = oy1 + innerbox.Height;

        }
        private void NWMove(object sender, MouseEventArgs e)
        {
            if (!mousedown) return;
            double vectorX = ox1 - cpx;
            double vectorY = oy1 - cpy;
            Thickness newMargin = new Thickness(e.GetPosition(null).X + vectorX, e.GetPosition(null).Y + vectorY, 0, 0);
            innerbox.Margin = newMargin;

            innerbox.Width = ox2 - newMargin.Left;
            innerbox.Height = oy2 - newMargin.Top;

            NW.Margin = new Thickness(innerbox.Margin.Left - 5, innerbox.Margin.Top - 5, 0, 0);
            SE.Margin = new Thickness(innerbox.Margin.Left + innerbox.Width - 5, innerbox.Margin.Top + innerbox.Height - 5, 0, 0);
            UP.Margin = new Thickness(innerbox.Margin.Left + innerbox.Width / 2 - 5, innerbox.Margin.Top - 5, 0, 0);
            DOWN.Margin = new Thickness(innerbox.Margin.Left + innerbox.Width / 2 - 5, innerbox.Margin.Top + innerbox.Height - 5, 0, 0);
            LEFT.Margin = new Thickness(innerbox.Margin.Left - 5, innerbox.Margin.Top + innerbox.Height / 2 - 5, 0, 0);
            RIGHT.Margin = new Thickness(innerbox.Margin.Left + innerbox.Width - 5, innerbox.Margin.Top + innerbox.Height / 2 - 5, 0, 0);
            NE.Margin = new Thickness(innerbox.Margin.Left + innerbox.Width - 5, innerbox.Margin.Top - 5, 0, 0);
            SW.Margin = new Thickness(innerbox.Margin.Left - 5, innerbox.Margin.Top + innerbox.Height - 5, 0, 0);

            LUp.X1 = innerbox.Margin.Left; LUp.Y1 = innerbox.Margin.Top; LUp.X2 = innerbox.Margin.Left + innerbox.Width; LUp.Y2 = innerbox.Margin.Top;
            LDown.X1 = innerbox.Margin.Left; LDown.Y1 = innerbox.Margin.Top + innerbox.Height; LDown.X2 = innerbox.Margin.Left + innerbox.Width; LDown.Y2 = innerbox.Margin.Top + innerbox.Height;
            LLeft.X1 = innerbox.Margin.Left; LLeft.Y1 = innerbox.Margin.Top; LLeft.X2 = innerbox.Margin.Left; LLeft.Y2 = innerbox.Margin.Top + innerbox.Height;
            LRight.X1 = innerbox.Margin.Left + innerbox.Width; LRight.Y1 = innerbox.Margin.Top; LRight.X2 = innerbox.Margin.Left + innerbox.Width; LRight.Y2 = innerbox.Margin.Top + innerbox.Height;
            


        }
        private void NWUp(object sender, MouseEventArgs e)
        {
            mousedown = false;
            Mouse.Capture(null);
        }
        #endregion


        public override void OnApplyTemplate()
        {

            #region 레퍼런스 변수에 각 구성요소 등록
            LUp = Template.FindName("LUp", this) as Line;
            LDown = Template.FindName("LDown", this) as Line;
            LLeft = Template.FindName("LLeft", this) as Line;
            LRight = Template.FindName("LRight", this) as Line;

            innerbox = Template.FindName("InnerBox", this) as TextBox;

            NE = Template.FindName("NE", this) as Rectangle;
            NW = Template.FindName("NW", this) as Rectangle;
            SE = Template.FindName("SE", this) as Rectangle;
            SW = Template.FindName("SW", this) as Rectangle;
            UP = Template.FindName("UP", this) as Rectangle;
            DOWN = Template.FindName("DOWN", this) as Rectangle;
            RIGHT = Template.FindName("RIGHT", this) as Rectangle;
            LEFT = Template.FindName("LEFT", this) as Rectangle;
            #endregion


            #region 각 구성요소 이벤트 델리게이트에 이벤트 처리기 등록
            if (NW != null)
            {
                (NW as Rectangle).MouseEnter += Square_MouseEnter_NWSE;
                (NW as Rectangle).MouseLeave += Square_MouseLeave_NWSE;
                (NW as Rectangle).MouseDown += NWDown;
                (NW as Rectangle).MouseMove += NWMove;
                (NW as Rectangle).MouseUp += NWUp;
            }
            if (SE != null)
            {
                (SE as Rectangle).MouseEnter += Square_MouseEnter_NWSE;
                (SE as Rectangle).MouseLeave += Square_MouseLeave_NWSE;
            }
            if (UP != null)
            {
                (UP as Rectangle).MouseEnter += Square_MouseEnter_NS;
                (UP as Rectangle).MouseLeave += Square_MouseLeave_NS;
            }
            if (DOWN != null)
            {
                (DOWN as Rectangle).MouseEnter += Square_MouseEnter_NS;
                (DOWN as Rectangle).MouseLeave += Square_MouseLeave_NS;
            }
            if (LEFT != null)
            {
                (LEFT as Rectangle).MouseEnter += Square_MouseEnter_WE;
                (LEFT as Rectangle).MouseLeave += Square_MouseLeave_WE;
            }
            if (RIGHT != null)
            {
                (RIGHT as Rectangle).MouseEnter += Square_MouseEnter_WE;
                (RIGHT as Rectangle).MouseLeave += Square_MouseLeave_WE;
            }
            if (NE != null)
            {
                (NE as Rectangle).MouseEnter += Square_MouseEnter_NESW;
                (NE as Rectangle).MouseLeave += Square_MouseLeave_NESW;
            }
            if (SW != null)
            {
                (SW as Rectangle).MouseEnter += Square_MouseEnter_NESW;
                (SW as Rectangle).MouseLeave += Square_MouseLeave_NESW;
            }
            #endregion

            base.OnApplyTemplate();
        }

    }
}

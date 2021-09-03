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
        
        public enum HTarget { NE, SW, NW, SE, UP, DOWN, RIGHT, LEFT, LINE, NONE }
        private HTarget ClickMode = HTarget.NONE;
        public bool selected;
        #region 벡터계산 중간변수
        private double ox1;
        private double oy1;
        private double ox2;
        private double oy2;
        private double cpx;
        private double cpy;
        #endregion

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
        private void Square_MouseLeave(object sender, MouseEventArgs e)
        {
            if (e.LeftButton == MouseButtonState.Pressed)
            {
                switch (ClickMode)
                {
                    case HTarget.NW:
                        NWMove(sender, e);
                        break;
                    case HTarget.SE:
                        SEMove(sender, e);
                        break;
                    case HTarget.NE:
                        NEMove(sender, e);
                        break;
                    case HTarget.SW:
                        SWMove(sender, e);
                        break;
                    case HTarget.UP:
                        UPMove(sender, e);
                        break;
                    case HTarget.DOWN:
                        DOWNMove(sender, e);
                        break;
                    case HTarget.LEFT:
                        LEFTMove(sender, e);
                        break;
                    case HTarget.RIGHT:
                        RIGHTMove(sender, e);
                        break;
                    default:
                        break;
                }
            }
            else
            {
                ClickMode = HTarget.NONE;
                Mouse.Capture(null);
                Cursor = Cursors.Arrow;
            }
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


        #region MouseDown함수
        private void NEMouseDown(object sender, MouseEventArgs e)
        {
            selected = true;
            ClickMode = HTarget.NE;
            cpx = e.GetPosition(null).X;
            cpy = e.GetPosition(null).Y;

            ox1 = innerbox.Margin.Left;
            oy1 = innerbox.Margin.Top;

            ox2 = ox1 + innerbox.Width;
            oy2 = oy1 + innerbox.Height;

        }
        private void SEMouseDown(object sender, MouseEventArgs e)
        {
            selected = true;
            ClickMode = HTarget.SE;
            cpx = e.GetPosition(null).X;
            cpy = e.GetPosition(null).Y;

            ox1 = innerbox.Margin.Left;
            oy1 = innerbox.Margin.Top;

            ox2 = ox1 + innerbox.Width;
            oy2 = oy1 + innerbox.Height;

        }
        private void NWMouseDown(object sender, MouseEventArgs e)
        {
            selected = true;
            ClickMode = HTarget.NW;
            cpx = e.GetPosition(null).X;
            cpy = e.GetPosition(null).Y;

            ox1 = innerbox.Margin.Left;
            oy1 = innerbox.Margin.Top;

            ox2 = ox1 + innerbox.Width;
            oy2 = oy1 + innerbox.Height;

        }
        private void SWMouseDown(object sender, MouseEventArgs e)
        {
            selected = true;
            ClickMode = HTarget.SW;
            cpx = e.GetPosition(null).X;
            cpy = e.GetPosition(null).Y;

            ox1 = innerbox.Margin.Left;
            oy1 = innerbox.Margin.Top;

            ox2 = ox1 + innerbox.Width;
            oy2 = oy1 + innerbox.Height;

        }
        private void UPMouseDown(object sender, MouseEventArgs e)
        {
            Mouse.Capture(this, CaptureMode.SubTree);
            selected = true;
            ClickMode = HTarget.UP;
            cpx = e.GetPosition(null).X;
            cpy = e.GetPosition(null).Y;

            ox1 = innerbox.Margin.Left;
            oy1 = innerbox.Margin.Top;

            ox2 = ox1 + innerbox.Width;
            oy2 = oy1 + innerbox.Height;

        }
        private void DOWNMouseDown(object sender, MouseEventArgs e)
        {
            selected = true;
            ClickMode = HTarget.DOWN;
            cpx = e.GetPosition(null).X;
            cpy = e.GetPosition(null).Y;

            ox1 = innerbox.Margin.Left;
            oy1 = innerbox.Margin.Top;

            ox2 = ox1 + innerbox.Width;
            oy2 = oy1 + innerbox.Height;

        }
        private void LEFTMouseDown(object sender, MouseEventArgs e)
        {
            selected = true;
            ClickMode = HTarget.LEFT;
            cpx = e.GetPosition(null).X;
            cpy = e.GetPosition(null).Y;

            ox1 = innerbox.Margin.Left;
            oy1 = innerbox.Margin.Top;

            ox2 = ox1 + innerbox.Width;
            oy2 = oy1 + innerbox.Height;

        }
        private void RIGHTMouseDown(object sender, MouseEventArgs e)
        {
            selected = true;
            ClickMode = HTarget.RIGHT;
            cpx = e.GetPosition(null).X;
            cpy = e.GetPosition(null).Y;

            ox1 = innerbox.Margin.Left;
            oy1 = innerbox.Margin.Top;

            ox2 = ox1 + innerbox.Width;
            oy2 = oy1 + innerbox.Height;

        }
        private void LINEMouseDown(object sender, MouseEventArgs e)
        {
            selected = true;
            ClickMode = HTarget.LINE;
            cpx = e.GetPosition(null).X;
            cpy = e.GetPosition(null).Y;

            ox1 = innerbox.Margin.Left;
            oy1 = innerbox.Margin.Top;

            ox2 = ox1 + innerbox.Width;
            oy2 = oy1 + innerbox.Height;

        }
        #endregion

        #region 크기조정 이벤트처리함수
        private void NWMove(object sender, MouseEventArgs e)
        {
            if (ClickMode != HTarget.NW) return;
            double iw = ox2 - ox1 - e.GetPosition(null).X + cpx;
            double ih = oy2 - oy1 - e.GetPosition(null).Y + cpy;

            if (iw >= 20) { innerbox.Width = iw; } else { iw = 20; }
            if (ih >= 20) { innerbox.Height = ih; } else { ih = 20; }

            Thickness newMargin = new Thickness(ox2 - iw, oy2 - ih, 0, 0);
            innerbox.Margin = newMargin;

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
        private void SEMove(object sender, MouseEventArgs e)
        {
            if (ClickMode != HTarget.SE) return;
            double iw = ox2 - ox1 + e.GetPosition(null).X - cpx;
            double ih = oy2 - oy1 + e.GetPosition(null).Y - cpy;

            if (iw >= 20) { innerbox.Width = iw; } else { iw = 20; }
            if (ih >= 20) { innerbox.Height = ih; } else { ih = 20; }

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
        private void NEMove(object sender, MouseEventArgs e)
        {
            if (ClickMode != HTarget.NE) return;
            double iw = ox2 - ox1 + e.GetPosition(null).X - cpx;
            double ih = oy2 - oy1 - e.GetPosition(null).Y + cpy;
            if (iw >= 20) { innerbox.Width = iw; } else { iw = 20; }
            if (ih >= 20) { innerbox.Height = ih; } else { ih = 20; }


            Thickness newMargin = new Thickness(ox1, oy2 - ih, 0, 0);
            innerbox.Margin = newMargin;

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
        private void SWMove(object sender, MouseEventArgs e)
        {
            if (ClickMode != HTarget.SW) return;
            double iw = ox2 - ox1 - e.GetPosition(null).X + cpx;
            double ih = oy2 - oy1 + e.GetPosition(null).Y - cpy;
            if (iw >= 20) { innerbox.Width = iw; } else { iw = 20; }
            if (ih >= 20) { innerbox.Height = ih; } else { ih = 20; }

            Thickness newMargin = new Thickness(ox2 - iw, oy1, 0, 0);
            innerbox.Margin = newMargin;

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

        private void UPMove(object sender, MouseEventArgs e)
        {
            if (ClickMode != HTarget.UP) return;
            double ih = oy2 - oy1 - e.GetPosition(null).Y + cpy;
            if (ih >= 20) { innerbox.Height = ih; } else { ih = 20; }

            Thickness newMargin = new Thickness(ox1, oy2 - ih, 0, 0);
            innerbox.Margin = newMargin;

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
        private void DOWNMove(object sender, MouseEventArgs e)
        {
            if (ClickMode != HTarget.DOWN) return;
            double ih = oy2 - oy1 + e.GetPosition(null).Y - cpy;
            if (ih >= 20) { innerbox.Height = ih; } else { ih = 20; }

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
        private void LEFTMove(object sender, MouseEventArgs e)
        {
            if (ClickMode != HTarget.LEFT) return;
            double iw = ox2 - ox1 - e.GetPosition(null).X + cpx;
            if (iw >= 20) { innerbox.Width = iw; } else { iw = 20; }
            Thickness newMargin = new Thickness(ox2-iw, oy1, 0, 0);
            innerbox.Margin = newMargin;
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
        private void RIGHTMove(object sender, MouseEventArgs e)
        {
            if (ClickMode != HTarget.RIGHT) return;
            double iw = ox2 - ox1 + e.GetPosition(null).X - cpx;
            if (iw >= 20) { innerbox.Width = iw; } else { iw = 20; }
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

        #endregion

        private void TxtMouseUp(object sender, MouseEventArgs e)
        {
            ClickMode = HTarget.NONE;
            Mouse.Capture(null);
        }



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
                (NW as Rectangle).MouseLeave += Square_MouseLeave;
                (NW as Rectangle).MouseDown += NWMouseDown;
                (NW as Rectangle).MouseMove += NWMove;
                (NW as Rectangle).MouseUp += TxtMouseUp;
            }
            if (SE != null)
            {
                (SE as Rectangle).MouseEnter += Square_MouseEnter_NWSE;
                (SE as Rectangle).MouseLeave += Square_MouseLeave;
                (SE as Rectangle).MouseDown += SEMouseDown;
                (SE as Rectangle).MouseMove += SEMove;
                (SE as Rectangle).MouseUp += TxtMouseUp;
            }
            if (UP != null)
            {
                (UP as Rectangle).MouseEnter += Square_MouseEnter_NS;
                (UP as Rectangle).MouseLeave += Square_MouseLeave;
                (UP as Rectangle).MouseDown += UPMouseDown;
                (UP as Rectangle).MouseMove += UPMove;
                (UP as Rectangle).MouseUp += TxtMouseUp;
            }
            if (DOWN != null)
            {
                (DOWN as Rectangle).MouseEnter += Square_MouseEnter_NS;
                (DOWN as Rectangle).MouseLeave += Square_MouseLeave;
                (DOWN as Rectangle).MouseDown += DOWNMouseDown;
                (DOWN as Rectangle).MouseMove += DOWNMove;
                (DOWN as Rectangle).MouseUp += TxtMouseUp;
            }
            if (LEFT != null)
            {
                (LEFT as Rectangle).MouseEnter += Square_MouseEnter_WE;
                (LEFT as Rectangle).MouseLeave += Square_MouseLeave;
                (LEFT as Rectangle).MouseDown += LEFTMouseDown;
                (LEFT as Rectangle).MouseMove += LEFTMove;
                (LEFT as Rectangle).MouseUp += TxtMouseUp;
            }
            if (RIGHT != null)
            {
                (RIGHT as Rectangle).MouseEnter += Square_MouseEnter_WE;
                (RIGHT as Rectangle).MouseLeave += Square_MouseLeave;
                (RIGHT as Rectangle).MouseDown += RIGHTMouseDown;
                (RIGHT as Rectangle).MouseMove += RIGHTMove;
                (RIGHT as Rectangle).MouseUp += TxtMouseUp;
            }
            if (NE != null)
            {
                (NE as Rectangle).MouseEnter += Square_MouseEnter_NESW;
                (NE as Rectangle).MouseLeave += Square_MouseLeave;
                (NE as Rectangle).MouseDown += NEMouseDown;
                (NE as Rectangle).MouseMove += NEMove;
                (NE as Rectangle).MouseUp += TxtMouseUp;
            }
            if (SW != null)
            {
                (SW as Rectangle).MouseEnter += Square_MouseEnter_NESW;
                (SW as Rectangle).MouseLeave += Square_MouseLeave;
                (SW as Rectangle).MouseDown += SWMouseDown;
                (SW as Rectangle).MouseMove += SWMove;
                (SW as Rectangle).MouseUp += TxtMouseUp;
            }
            #endregion

            base.OnApplyTemplate();
        }

    }
}

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
    public class AdTXT:Control
    {
        
        public enum HTarget { NE, SW, NW, SE, UP, DOWN, RIGHT, LEFT, LINE, NONE }
        public enum SelectMode { TXT, MOV, NON }
        public HTarget ClickMode = HTarget.NONE;
        private SelectMode Selected = SelectMode.TXT;
        public SelectMode PreviousSel = SelectMode.TXT;

        #region 벡터계산 중간변수
        private double ox1;
        private double oy1;
        private double ox2;
        private double oy2;
        private double cpx;
        private double cpy;
        private double ix1;
        private double ix2;
        private double iy1;
        private double iy2;
        private bool construct = false;
        #endregion

        #region 구성요소 레퍼런스 변수선언
        public TextBox innerbox;
        public Line LUp;
        public Line LDown;
        public Line LRight;
        public Line LLeft;
        public Rectangle NE;
        public Rectangle SW;
        public Rectangle NW;
        public Rectangle SE;
        public Rectangle UP;
        public Rectangle DOWN;
        public Rectangle RIGHT;
        public Rectangle LEFT;
        public Line RN;
        public Line RE;
        public Line RW;
        public Line RS;
        #endregion
        static AdTXT()
        {
            DefaultStyleKeyProperty.OverrideMetadata(typeof(AdTXT), new FrameworkPropertyMetadata(typeof(AdTXT)));
        }
        public void init(double x1, double y1, double x2, double y2)
        {
            ix1 = x1; ix2 = x2; iy1 = y1; iy2 = y2; construct = true;
        }
        private void Manual_Relocate(double x1, double y1, double x2, double y2)
        {

            innerbox.Margin = new Thickness(x1, y1, 0, 0);
            innerbox.Height = y2 - y1; innerbox.Width = x2 - x1;

            NW.Margin = new Thickness(x1 - 5, y1 - 5, 0, 0);
            UP.Margin = new Thickness((x1 + x2) / 2 - 5, y1 - 5, 0, 0);
            NE.Margin = new Thickness(x2 - 5, y1 - 5, 0, 0);
            LEFT.Margin = new Thickness(x1 - 5, (y1 + y2) / 2 - 5, 0, 0);
            RIGHT.Margin = new Thickness(x2 - 5, (y1 + y2) / 2 - 5, 0, 0);
            SW.Margin = new Thickness(x1 - 5, y2 - 5, 0, 0);
            DOWN.Margin = new Thickness((x1 + x2) / 2 - 5, y2 - 5, 0, 0);
            SE.Margin = new Thickness(x2 - 5, y2 - 5, 0, 0);

            LUp.X1 = RN.X1 = x1; LUp.X2 = RN.X2 = x2; LUp.Y1 = LUp.Y2 = RN.Y1 = RN.Y2 = y1;
            LDown.X1 = RS.X1 = x1; LDown.X2 = RS.X2 = x2; LDown.Y1 = LDown.Y2 = RS.Y1 = RS.Y2 = y2;
            LLeft.X1 = LLeft.X2 = RW.X1 = RW.X2 = x1; LLeft.Y1 = RW.Y1 = y1; LLeft.Y2 = RW.Y2 = y2;
            LRight.X1 = LRight.X2 = RE.X1 = RE.X2 = x2; LRight.Y1 = RE.Y1 = y1; LRight.Y2 = RE.Y2 = y2;

        }


        #region mousehover 이벤트처리함수
        private void Leave_Regulator(object sender, MouseEventArgs e)
        {
            if (e.LeftButton == MouseButtonState.Pressed && ClickMode != HTarget.NONE)
            {
                Movement_Regulator(sender, e);
            }
            else
            {
                ClickMode = HTarget.NONE;
                Cursor = Cursors.Arrow;
            }
        }
        private void Square_MouseEnter_NWSE(object sender, MouseEventArgs e)
        {
            Cursor = Cursors.SizeNWSE;
        }
        private void Line_MouseEnter(object sender, MouseEventArgs e)
        {
            Cursor = Cursors.SizeAll;
        }
        private void Square_MouseEnter_NESW(object sender, EventArgs e)
        {
            Cursor = Cursors.SizeNESW;
        }
        private void Square_MouseEnter_NS(object sender, EventArgs e)
        {
            Cursor = Cursors.SizeNS;
        }
        private void Square_MouseEnter_WE(object sender, EventArgs e)
        {
            Cursor = Cursors.SizeWE;
        }
        #endregion

        #region MouseDown함수
        private void LineMouseDown(object sender, MouseEventArgs e)
        {
            SelVarChange = SelectMode.MOV;
            ClickMode = HTarget.LINE;
            cpx = e.GetPosition(null).X;
            cpy = e.GetPosition(null).Y;
            ox1 = innerbox.Margin.Left;
            oy1 = innerbox.Margin.Top;
        }

        private void NEMouseDown(object sender, MouseEventArgs e)
        {
            SelVarChange = SelectMode.MOV;
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
            SelVarChange = SelectMode.MOV;
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
            SelVarChange = SelectMode.MOV;
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
            SelVarChange = SelectMode.MOV;
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
            SelVarChange = SelectMode.MOV;
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
            SelVarChange = SelectMode.MOV;
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
            SelVarChange = SelectMode.MOV;
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
            SelVarChange = SelectMode.MOV;
            ClickMode = HTarget.RIGHT;
            cpx = e.GetPosition(null).X;
            cpy = e.GetPosition(null).Y;

            ox1 = innerbox.Margin.Left;
            oy1 = innerbox.Margin.Top;

            ox2 = ox1 + innerbox.Width;
            oy2 = oy1 + innerbox.Height;

        }
        #endregion

        #region 크기조정 이벤트처리함수
        public void Movement_Regulator(object sender, MouseEventArgs e)
        {
            if (e.LeftButton != MouseButtonState.Pressed)
            {
                return;
            }
            Thickness newMargin;
            double iw, ih;
            switch (ClickMode)
            {
                case HTarget.LINE:
                    newMargin = new Thickness(ox1 + e.GetPosition(null).X - cpx, oy1 + e.GetPosition(null).Y - cpy, 0, 0);
                    innerbox.Margin = newMargin;
                    break;
                case HTarget.NW:
                    iw = ox2 - ox1 - e.GetPosition(null).X + cpx;
                    ih = oy2 - oy1 - e.GetPosition(null).Y + cpy;
                    if (iw >= 20) { innerbox.Width = iw; } else { iw = 20; }
                    if (ih >= 20) { innerbox.Height = ih; } else { ih = 20; }
                    newMargin = new Thickness(ox2 - iw, oy2 - ih, 0, 0);
                    innerbox.Margin = newMargin;
                    break;
                case HTarget.UP:
                    ih = oy2 - oy1 - e.GetPosition(null).Y + cpy;
                    if (ih >= 20) { innerbox.Height = ih; } else { ih = 20; }
                    newMargin = new Thickness(ox1, oy2 - ih, 0, 0);
                    innerbox.Margin = newMargin;
                    break;
                case HTarget.NE:
                    iw = ox2 - ox1 + e.GetPosition(null).X - cpx;
                    ih = oy2 - oy1 - e.GetPosition(null).Y + cpy;
                    if (iw >= 20) { innerbox.Width = iw; } else { iw = 20; }
                    if (ih >= 20) { innerbox.Height = ih; } else { ih = 20; }
                    newMargin = new Thickness(ox1, oy2 - ih, 0, 0);
                    innerbox.Margin = newMargin;
                    break;
                case HTarget.LEFT:
                    iw = ox2 - ox1 - e.GetPosition(null).X + cpx;
                    if (iw >= 20) { innerbox.Width = iw; } else { iw = 20; }
                    newMargin = new Thickness(ox2 - iw, oy1, 0, 0);
                    innerbox.Margin = newMargin;
                    break;
                case HTarget.RIGHT:
                    iw = ox2 - ox1 + e.GetPosition(null).X - cpx;
                    if (iw >= 20) { innerbox.Width = iw; } else { iw = 20; }
                    break;
                case HTarget.SW:
                    iw = ox2 - ox1 - e.GetPosition(null).X + cpx;
                    ih = oy2 - oy1 + e.GetPosition(null).Y - cpy;
                    if (iw >= 20) { innerbox.Width = iw; } else { iw = 20; }
                    if (ih >= 20) { innerbox.Height = ih; } else { ih = 20; }
                    newMargin = new Thickness(ox2 - iw, oy1, 0, 0);
                    innerbox.Margin = newMargin;
                    break;
                case HTarget.DOWN:
                    ih = oy2 - oy1 + e.GetPosition(null).Y - cpy;
                    if (ih >= 20) { innerbox.Height = ih; } else { ih = 20; }
                    break;
                case HTarget.SE:
                    iw = ox2 - ox1 + e.GetPosition(null).X - cpx;
                    ih = oy2 - oy1 + e.GetPosition(null).Y - cpy;
                    if (iw >= 20) { innerbox.Width = iw; } else { iw = 20; }
                    if (ih >= 20) { innerbox.Height = ih; } else { ih = 20; }
                    break;

                default:
                    break;
            }
            NW.Margin = new Thickness(innerbox.Margin.Left - 5, innerbox.Margin.Top - 5, 0, 0);
            SE.Margin = new Thickness(innerbox.Margin.Left + innerbox.Width - 5, innerbox.Margin.Top + innerbox.Height - 5, 0, 0);
            UP.Margin = new Thickness(innerbox.Margin.Left + innerbox.Width / 2 - 5, innerbox.Margin.Top - 5, 0, 0);
            DOWN.Margin = new Thickness(innerbox.Margin.Left + innerbox.Width / 2 - 5, innerbox.Margin.Top + innerbox.Height - 5, 0, 0);
            LEFT.Margin = new Thickness(innerbox.Margin.Left - 5, innerbox.Margin.Top + innerbox.Height / 2 - 5, 0, 0);
            RIGHT.Margin = new Thickness(innerbox.Margin.Left + innerbox.Width - 5, innerbox.Margin.Top + innerbox.Height / 2 - 5, 0, 0);
            NE.Margin = new Thickness(innerbox.Margin.Left + innerbox.Width - 5, innerbox.Margin.Top - 5, 0, 0);
            SW.Margin = new Thickness(innerbox.Margin.Left - 5, innerbox.Margin.Top + innerbox.Height - 5, 0, 0);

            LUp.X1 = RN.X1 = innerbox.Margin.Left; LUp.Y1 = RN.Y1 = innerbox.Margin.Top; LUp.X2 = RN.X2 = innerbox.Margin.Left + innerbox.Width; LUp.Y2 = RN.Y2 = innerbox.Margin.Top;
            LDown.X1 = RS.X1 = innerbox.Margin.Left; LDown.Y1 = RS.Y1 = innerbox.Margin.Top + innerbox.Height; LDown.X2 = RS.X2 = innerbox.Margin.Left + innerbox.Width; LDown.Y2 = RS.Y2 = innerbox.Margin.Top + innerbox.Height;
            LLeft.X1 = RW.X1 = innerbox.Margin.Left; LLeft.Y1 = RW.Y1 = innerbox.Margin.Top; LLeft.X2 = RW.X2 = innerbox.Margin.Left; LLeft.Y2 = RW.Y2 = innerbox.Margin.Top + innerbox.Height;
            LRight.X1 = RE.X1 = innerbox.Margin.Left + innerbox.Width; LRight.Y1 = RE.Y1 = innerbox.Margin.Top; LRight.X2 = RE.X2 = innerbox.Margin.Left + innerbox.Width; LRight.Y2 = RE.Y2 = innerbox.Margin.Top + innerbox.Height;
        }
        #endregion

        //텍스트 Enter 줄바꿈 처리함수
        private void TextKeyDown(object sender, KeyEventArgs e)
        {
            if (e.Key == Key.Enter)
            {
                int CaretTmp = innerbox.CaretIndex;
                innerbox.Text = innerbox.Text.Substring(0, innerbox.CaretIndex) + "\n" + innerbox.Text.Substring(innerbox.CaretIndex);
                //innerbox.Focus();
                innerbox.Select(CaretTmp + 1, 0);
            }
            
        }

        private void TextClick(object sender, RoutedEventArgs e)
        {
            SelVarChange = SelectMode.TXT;
        }

        //MouseUp 이벤트 처리함수
        public void TxtMouseUp(object sender, MouseEventArgs e)
        {
            if (ClickMode == HTarget.UP)
            {
                Movement_Regulator(sender, e);
                Cursor = Cursors.Arrow;
                Cursor = Cursors.SizeNS;
               // Mouse.Capture(null);
            }
            ClickMode = HTarget.NONE;
            
            //Cursor = Cursors.Arrow;
            //Mouse.Capture(null);
        }


        public void CtrlsShown(SelectMode PrevMode, SelectMode NewMode)
        {
            switch (NewMode)
            {
                case SelectMode.NON:
                    #region 외곽 숨기기
                    NE.Visibility = Visibility.Hidden;
                    SW.Visibility = Visibility.Hidden;
                    SE.Visibility = Visibility.Hidden;
                    NW.Visibility = Visibility.Hidden;
                    UP.Visibility = Visibility.Hidden;
                    DOWN.Visibility = Visibility.Hidden;
                    LEFT.Visibility = Visibility.Hidden;
                    RIGHT.Visibility = Visibility.Hidden;
                    RN.Visibility = Visibility.Hidden;
                    RE.Visibility = Visibility.Hidden;
                    RW.Visibility = Visibility.Hidden;
                    RS.Visibility = Visibility.Hidden;
                    #endregion
                    #region 각 구성요소 이벤트 델리게이트에 이벤트 처리기 등록 해제
                    if (innerbox != null)
                    {
                        (innerbox as TextBox).MouseMove -= Leave_Regulator;
                        (innerbox as TextBox).KeyDown -= TextKeyDown;
                        (innerbox as TextBox).MouseDown -= TextClick;
                    }
                    if (LUp != null)
                    {
                        (LUp as Line).MouseEnter -= Line_MouseEnter;
                        (LUp as Line).MouseDown -= LineMouseDown;
                        (LUp as Line).MouseMove -= Movement_Regulator;
                    }
                    if (LDown != null)
                    {
                        (LDown as Line).MouseEnter -= Line_MouseEnter;
                        (LDown as Line).MouseDown -= LineMouseDown;
                        (LDown as Line).MouseMove -= Movement_Regulator;
                    }
                    if (LRight != null)
                    {
                        (LRight as Line).MouseEnter -= Line_MouseEnter;
                        (LRight as Line).MouseDown -= LineMouseDown;
                        (LRight as Line).MouseMove -= Movement_Regulator;
                    }
                    if (LLeft != null)
                    {
                        (LLeft as Line).MouseEnter -= Line_MouseEnter;
                        (LLeft as Line).MouseDown -= LineMouseDown;
                        (LLeft as Line).MouseMove -= Movement_Regulator;
                    }

                    if (NW != null)
                    {
                        (NW as Rectangle).MouseEnter -= Square_MouseEnter_NWSE;
                        (NW as Rectangle).MouseDown -= NWMouseDown;
                        (NW as Rectangle).MouseMove -= Movement_Regulator;
                    }
                    if (SE != null)
                    {
                        (SE as Rectangle).MouseEnter -= Square_MouseEnter_NWSE;
                        (SE as Rectangle).MouseDown -= SEMouseDown;
                        (SE as Rectangle).MouseMove -= Movement_Regulator;
                    }
                    if (UP != null)
                    {
                        (UP as Rectangle).MouseEnter -= Square_MouseEnter_NS;
                        (UP as Rectangle).MouseDown -= UPMouseDown;
                        (UP as Rectangle).MouseMove -= Movement_Regulator;
                    }
                    if (DOWN != null)
                    {
                        (DOWN as Rectangle).MouseEnter -= Square_MouseEnter_NS;
                        (DOWN as Rectangle).MouseDown -= DOWNMouseDown;
                        (DOWN as Rectangle).MouseMove -= Movement_Regulator;
                    }
                    if (LEFT != null)
                    {
                        (LEFT as Rectangle).MouseEnter -= Square_MouseEnter_WE;
                        (LEFT as Rectangle).MouseDown -= LEFTMouseDown;
                        (LEFT as Rectangle).MouseMove -= Movement_Regulator;
                    }
                    if (RIGHT != null)
                    {
                        (RIGHT as Rectangle).MouseEnter -= Square_MouseEnter_WE;
                        (RIGHT as Rectangle).MouseDown -= RIGHTMouseDown;
                        (RIGHT as Rectangle).MouseMove -= Movement_Regulator;
                    }
                    if (NE != null)
                    {
                        (NE as Rectangle).MouseEnter -= Square_MouseEnter_NESW;
                        (NE as Rectangle).MouseDown -= NEMouseDown;
                        (NE as Rectangle).MouseMove -= Movement_Regulator;
                    }
                    if (SW != null)
                    {
                        (SW as Rectangle).MouseEnter -= Square_MouseEnter_NESW;
                        (SW as Rectangle).MouseDown -= SWMouseDown;
                        (SW as Rectangle).MouseMove -= Movement_Regulator;
                    }
                    #endregion
                    if (innerbox.IsFocused)
                    {
                        //FocusManager.SetFocusedElement(FocusManager.GetFocusScope(innerbox), null);
                        //Keyboard.ClearFocus();
                    }
                    break;
                case SelectMode.MOV:
                    //FocusManager.SetFocusedElement(FocusManager.GetFocusScope(innerbox), null);
                    //Keyboard.ClearFocus();
                    switch (PrevMode)
                    {
                        case SelectMode.TXT:
                            break;
                        case SelectMode.NON:
                            #region 외곽 보이기
                            NE.Visibility = Visibility.Visible;
                            SW.Visibility = Visibility.Visible;
                            SE.Visibility = Visibility.Visible;
                            NW.Visibility = Visibility.Visible;
                            UP.Visibility = Visibility.Visible;
                            DOWN.Visibility = Visibility.Visible;
                            LEFT.Visibility = Visibility.Visible;
                            RIGHT.Visibility = Visibility.Visible;
                            RN.Visibility = Visibility.Visible;
                            RE.Visibility = Visibility.Visible;
                            RW.Visibility = Visibility.Visible;
                            RS.Visibility = Visibility.Visible;
                            #endregion
                            #region 각 구성요소 이벤트 델리게이트에 이벤트 처리기 등록
                            if (innerbox != null)
                            {
                                (innerbox as TextBox).MouseMove += Leave_Regulator;
                                (innerbox as TextBox).KeyDown += TextKeyDown;
                                (innerbox as TextBox).MouseDown += TextClick;
                            }
                            if (LUp != null)
                            {
                                (LUp as Line).MouseEnter += Line_MouseEnter;
                                (LUp as Line).MouseDown += LineMouseDown;
                                (LUp as Line).MouseMove += Movement_Regulator;
                            }
                            if (LDown != null)
                            {
                                (LDown as Line).MouseEnter += Line_MouseEnter;
                                (LDown as Line).MouseDown += LineMouseDown;
                                (LDown as Line).MouseMove += Movement_Regulator;
                            }
                            if (LRight != null)
                            {
                                (LRight as Line).MouseEnter += Line_MouseEnter;
                                (LRight as Line).MouseDown += LineMouseDown;
                                (LRight as Line).MouseMove += Movement_Regulator;
                            }
                            if (LLeft != null)
                            {
                                (LLeft as Line).MouseEnter += Line_MouseEnter;
                                (LLeft as Line).MouseDown += LineMouseDown;
                                (LLeft as Line).MouseMove += Movement_Regulator;
                            }

                            if (NW != null)
                            {
                                (NW as Rectangle).MouseEnter += Square_MouseEnter_NWSE;
                                (NW as Rectangle).MouseDown += NWMouseDown;
                                (NW as Rectangle).MouseMove += Movement_Regulator;
                            }
                            if (SE != null)
                            {
                                (SE as Rectangle).MouseEnter += Square_MouseEnter_NWSE;
                                (SE as Rectangle).MouseDown += SEMouseDown;
                                (SE as Rectangle).MouseMove += Movement_Regulator;
                            }
                            if (UP != null)
                            {
                                (UP as Rectangle).MouseEnter += Square_MouseEnter_NS;
                                (UP as Rectangle).MouseDown += UPMouseDown;
                                (UP as Rectangle).MouseMove += Movement_Regulator;
                            }
                            if (DOWN != null)
                            {
                                (DOWN as Rectangle).MouseEnter += Square_MouseEnter_NS;
                                (DOWN as Rectangle).MouseDown += DOWNMouseDown;
                                (DOWN as Rectangle).MouseMove += Movement_Regulator;
                            }
                            if (LEFT != null)
                            {
                                (LEFT as Rectangle).MouseEnter += Square_MouseEnter_WE;
                                (LEFT as Rectangle).MouseDown += LEFTMouseDown;
                                (LEFT as Rectangle).MouseMove += Movement_Regulator;
                            }
                            if (RIGHT != null)
                            {
                                (RIGHT as Rectangle).MouseEnter += Square_MouseEnter_WE;
                                (RIGHT as Rectangle).MouseDown += RIGHTMouseDown;
                                (RIGHT as Rectangle).MouseMove += Movement_Regulator;
                            }
                            if (NE != null)
                            {
                                (NE as Rectangle).MouseEnter += Square_MouseEnter_NESW;
                                (NE as Rectangle).MouseDown += NEMouseDown;
                                (NE as Rectangle).MouseMove += Movement_Regulator;
                            }
                            if (SW != null)
                            {
                                (SW as Rectangle).MouseEnter += Square_MouseEnter_NESW;
                                (SW as Rectangle).MouseDown += SWMouseDown;
                                (SW as Rectangle).MouseMove += Movement_Regulator;
                            }
                            #endregion
                            break;
                    }
                    break;
                case SelectMode.TXT:
                    switch (PrevMode)
                    {
                        case SelectMode.MOV:
                            break;
                        case SelectMode.NON:
                            #region 외곽 보이기
                            NE.Visibility = Visibility.Visible;
                            SW.Visibility = Visibility.Visible;
                            SE.Visibility = Visibility.Visible;
                            NW.Visibility = Visibility.Visible;
                            UP.Visibility = Visibility.Visible;
                            DOWN.Visibility = Visibility.Visible;
                            LEFT.Visibility = Visibility.Visible;
                            RIGHT.Visibility = Visibility.Visible;
                            RN.Visibility = Visibility.Visible;
                            RE.Visibility = Visibility.Visible;
                            RW.Visibility = Visibility.Visible;
                            RS.Visibility = Visibility.Visible;
                            #endregion
                            #region 각 구성요소 이벤트 델리게이트에 이벤트 처리기 등록
                            if (innerbox != null)
                            {
                                (innerbox as TextBox).MouseMove += Leave_Regulator;
                                (innerbox as TextBox).KeyDown += TextKeyDown;
                                (innerbox as TextBox).MouseDown += TextClick;
                            }
                            if (LUp != null)
                            {
                                (LUp as Line).MouseEnter += Line_MouseEnter;
                                (LUp as Line).MouseDown += LineMouseDown;
                                (LUp as Line).MouseMove += Movement_Regulator;
                            }
                            if (LDown != null)
                            {
                                (LDown as Line).MouseEnter += Line_MouseEnter;
                                (LDown as Line).MouseDown += LineMouseDown;
                                (LDown as Line).MouseMove += Movement_Regulator;
                            }
                            if (LRight != null)
                            {
                                (LRight as Line).MouseEnter += Line_MouseEnter;
                                (LRight as Line).MouseDown += LineMouseDown;
                                (LRight as Line).MouseMove += Movement_Regulator;
                            }
                            if (LLeft != null)
                            {
                                (LLeft as Line).MouseEnter += Line_MouseEnter;
                                (LLeft as Line).MouseDown += LineMouseDown;
                                (LLeft as Line).MouseMove += Movement_Regulator;
                            }

                            if (NW != null)
                            {
                                (NW as Rectangle).MouseEnter += Square_MouseEnter_NWSE;
                                (NW as Rectangle).MouseDown += NWMouseDown;
                                (NW as Rectangle).MouseMove += Movement_Regulator;
                            }
                            if (SE != null)
                            {
                                (SE as Rectangle).MouseEnter += Square_MouseEnter_NWSE;
                                (SE as Rectangle).MouseDown += SEMouseDown;
                                (SE as Rectangle).MouseMove += Movement_Regulator;
                            }
                            if (UP != null)
                            {
                                (UP as Rectangle).MouseEnter += Square_MouseEnter_NS;
                                (UP as Rectangle).MouseDown += UPMouseDown;
                                (UP as Rectangle).MouseMove += Movement_Regulator;
                            }
                            if (DOWN != null)
                            {
                                (DOWN as Rectangle).MouseEnter += Square_MouseEnter_NS;
                                (DOWN as Rectangle).MouseDown += DOWNMouseDown;
                                (DOWN as Rectangle).MouseMove += Movement_Regulator;
                            }
                            if (LEFT != null)
                            {
                                (LEFT as Rectangle).MouseEnter += Square_MouseEnter_WE;
                                (LEFT as Rectangle).MouseDown += LEFTMouseDown;
                                (LEFT as Rectangle).MouseMove += Movement_Regulator;
                            }
                            if (RIGHT != null)
                            {
                                (RIGHT as Rectangle).MouseEnter += Square_MouseEnter_WE;
                                (RIGHT as Rectangle).MouseDown += RIGHTMouseDown;
                                (RIGHT as Rectangle).MouseMove += Movement_Regulator;
                            }
                            if (NE != null)
                            {
                                (NE as Rectangle).MouseEnter += Square_MouseEnter_NESW;
                                (NE as Rectangle).MouseDown += NEMouseDown;
                                (NE as Rectangle).MouseMove += Movement_Regulator;
                            }
                            if (SW != null)
                            {
                                (SW as Rectangle).MouseEnter += Square_MouseEnter_NESW;
                                (SW as Rectangle).MouseDown += SWMouseDown;
                                (SW as Rectangle).MouseMove += Movement_Regulator;
                            }
                            #endregion
                            break;
                    }
                    break;
            }
        }
        

        public SelectMode SelVarChange
        {
            get { return Selected; }
            set {
                if (value != Selected)
                {
                    PreviousSel = Selected;
                    Selected = value;
                    CtrlsShown(PreviousSel, Selected);
                }
            }
        }


        //구동함수
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

            RN = Template.FindName("RN", this) as Line;
            RW = Template.FindName("RW", this) as Line;
            RE = Template.FindName("RE", this) as Line;
            RS = Template.FindName("RS", this) as Line;

            #endregion
            this.MouseUp += TxtMouseUp;
            this.MouseLeave += Leave_Regulator;
            //this.LostFocus += TxtLostFocus;
            //this.GotFocus += TxtGainedFocus;
            #region 각 구성요소 이벤트 델리게이트에 이벤트 처리기 등록
            if (innerbox != null)
            {
                (innerbox as TextBox).MouseMove += Leave_Regulator;
                (innerbox as TextBox).KeyDown += TextKeyDown;
                (innerbox as TextBox).GotFocus += TextClick;
                innerbox.Focus();
            }
            if (LUp != null)
            {
                (LUp as Line).MouseEnter += Line_MouseEnter;
                (LUp as Line).MouseDown += LineMouseDown;
                (LUp as Line).MouseMove += Movement_Regulator;
            }
            if (LDown != null)
            {
                (LDown as Line).MouseEnter += Line_MouseEnter;
                (LDown as Line).MouseDown += LineMouseDown;
                (LDown as Line).MouseMove += Movement_Regulator;
            }
            if (LRight != null)
            {
                (LRight as Line).MouseEnter += Line_MouseEnter;
                (LRight as Line).MouseDown += LineMouseDown;
                (LRight as Line).MouseMove += Movement_Regulator;
            }
            if (LLeft != null)
            {
                (LLeft as Line).MouseEnter += Line_MouseEnter;
                (LLeft as Line).MouseDown += LineMouseDown;
                (LLeft as Line).MouseMove += Movement_Regulator;
            }

            if (NW != null)
            {
                (NW as Rectangle).MouseEnter += Square_MouseEnter_NWSE;
                (NW as Rectangle).MouseDown += NWMouseDown;
                (NW as Rectangle).MouseMove += Movement_Regulator;
            }
            if (SE != null)
            {
                (SE as Rectangle).MouseEnter += Square_MouseEnter_NWSE;
                (SE as Rectangle).MouseDown += SEMouseDown;
                (SE as Rectangle).MouseMove += Movement_Regulator;
            }
            if (UP != null)
            {
                (UP as Rectangle).MouseEnter += Square_MouseEnter_NS;
                (UP as Rectangle).MouseDown += UPMouseDown;
                (UP as Rectangle).MouseMove += Movement_Regulator;
            }
            if (DOWN != null)
            {
                (DOWN as Rectangle).MouseEnter += Square_MouseEnter_NS;
                (DOWN as Rectangle).MouseDown += DOWNMouseDown;
                (DOWN as Rectangle).MouseMove += Movement_Regulator;
            }
            if (LEFT != null)
            {
                (LEFT as Rectangle).MouseEnter += Square_MouseEnter_WE;
                (LEFT as Rectangle).MouseDown += LEFTMouseDown;
                (LEFT as Rectangle).MouseMove += Movement_Regulator;
            }
            if (RIGHT != null)
            {
                (RIGHT as Rectangle).MouseEnter += Square_MouseEnter_WE;
                (RIGHT as Rectangle).MouseDown += RIGHTMouseDown;
                (RIGHT as Rectangle).MouseMove += Movement_Regulator;
            }
            if (NE != null)
            {
                (NE as Rectangle).MouseEnter += Square_MouseEnter_NESW;
                (NE as Rectangle).MouseDown += NEMouseDown;
                (NE as Rectangle).MouseMove += Movement_Regulator;
            }
            if (SW != null)
            {
                (SW as Rectangle).MouseEnter += Square_MouseEnter_NESW;
                (SW as Rectangle).MouseDown += SWMouseDown;
                (SW as Rectangle).MouseMove += Movement_Regulator;
            }
            #endregion

            if (construct) Manual_Relocate(ix1, iy1, ix2, iy2);
            base.OnApplyTemplate();
        }

    }
}

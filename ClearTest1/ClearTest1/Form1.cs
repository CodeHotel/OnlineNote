using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace ClearTest1
{
    public enum ClickType { None, txtResizeUp, txtResizeDown, txtResizeLeft, txtResizeRight, txtMove, txtResizeNW, txtResizeNE, txtResizeSW, txtResizeSE  };
    public partial class Form1 : Form
    {
        private const int resizeBoxHalfSize = 10;
        ClickType clickMode;
        private bool mouseDown;
        private Point lastLocation;
        private Point txtDeviation;
        private Size txtOriginSize;
        public Form1()
        {
            clickMode = ClickType.None;
            //this.SetStyle(ControlStyles.SupportsTransparentBackColor, true);
            InitializeComponent();
            //this.BackColor = Color.Transparent;
        }

        private void txt1_MouseDown(object sender, MouseEventArgs e)
        {
            byte xType = 0;
            byte yType = 0;
            mouseDown = true;
            this.Capture = true;
            switch (e.X-this.textBox1.Location.X)
            {
                case int n when (n < 0 - resizeBoxHalfSize): xType = 0; break;
                case int n when (0 - resizeBoxHalfSize <= n && n < 0 + resizeBoxHalfSize): xType = 1; break;
                case int n when (0 + resizeBoxHalfSize <= n && n < this.textBox1.Size.Width / 2 - resizeBoxHalfSize): xType = 2; break;
                case int n when (this.textBox1.Size.Width / 2 - resizeBoxHalfSize <= n && n < this.textBox1.Size.Width / 2 + resizeBoxHalfSize): xType = 3; break;
                case int n when (this.textBox1.Size.Width / 2 + resizeBoxHalfSize <= n && n < this.textBox1.Size.Width - resizeBoxHalfSize): xType = 4; break;
                case int n when (this.textBox1.Size.Width - resizeBoxHalfSize <= n && n < this.textBox1.Size.Width + resizeBoxHalfSize): xType = 5; break;
                case int n when (this.textBox1.Size.Width + resizeBoxHalfSize < n): xType = 6; break;
                default: xType = 0; break;
            }

            switch (e.Y-this.textBox1.Location.Y)
            {
                case int n when (n < 0 - resizeBoxHalfSize): yType = 0; break;
                case int n when (0 - resizeBoxHalfSize <= n && n < 0 + resizeBoxHalfSize): yType = 1; break;
                case int n when (0 + resizeBoxHalfSize <= n && n < this.textBox1.Size.Height / 2 - resizeBoxHalfSize): yType = 2; break;
                case int n when (this.textBox1.Size.Height / 2 - resizeBoxHalfSize <= n && n < this.textBox1.Size.Height / 2 + resizeBoxHalfSize): yType = 3; break;
                case int n when (this.textBox1.Size.Height / 2 + resizeBoxHalfSize <= n && n < this.textBox1.Size.Height - resizeBoxHalfSize): yType = 4; break;
                case int n when (this.textBox1.Size.Height - resizeBoxHalfSize <= n && n < this.textBox1.Size.Height + resizeBoxHalfSize): yType = 5; break;
                case int n when (this.textBox1.Size.Height + resizeBoxHalfSize < n): yType = 6; break;
                default: yType = 0; break;
            }
            txtOriginSize = this.textBox1.Size;
            //동서남북, 꼭지점일 경우 각 경우에 맞는 크기조정 작업 부여
            if (xType == 1 && yType == 1) { clickMode = ClickType.txtResizeNW; }
            else if (xType == 3 && yType == 1) { clickMode = ClickType.txtResizeUp; }
            else if (xType == 5 && yType == 1) { clickMode = ClickType.txtResizeNE; }
            else if (xType == 1 && yType == 3) { clickMode = ClickType.txtResizeLeft; }
            else if (xType == 5 && yType == 3) { clickMode = ClickType.txtResizeRight; }
            else if (xType == 1 && yType == 5) { clickMode = ClickType.txtResizeSW; }
            else if (xType == 3 && yType == 5) { clickMode = ClickType.txtResizeDown; }
            else if (xType == 5 && yType == 5) { clickMode = ClickType.txtResizeSE; }

            //위 경우에 해당되지 않으면서 변에 해당될 경우 이동 작업 부여
            else if ((xType == 2 && yType == 1) || (xType == 4 && yType == 1) ||
                (xType == 1 && yType == 2) || (xType == 5 && yType == 2) ||
                (xType == 1 && yType == 4) || (xType == 5 && yType == 4) ||
                (xType == 2 && yType == 5) || (xType == 4 && yType == 5)) { clickMode = ClickType.txtMove; }
            //어디에도 해당되지 않으면 명령 취소
            else { clickMode = ClickType.None; }
            lastLocation = this.textBox1.Location;
            txtDeviation = new Point(e.X - this.textBox1.Location.X, e.Y - this.textBox1.Location.Y);
            this.Capture = false;
        }

        private void txt1_MouseMove(object sender, MouseEventArgs e)
        {
            this.Capture = true;
            if (mouseDown)
            {

                switch (clickMode)
                {
                    case ClickType.None:
                        this.Capture = false;
                        return;
                    case ClickType.txtMove:
                        this.textBox1.Location = new System.Drawing.Point(e.X - txtDeviation.X, e.Y - txtDeviation.Y);
                        break;
                    case ClickType.txtResizeRight:
                        this.textBox1.Size = new Size(e.X-this.textBox1.Location.X-txtDeviation.X+txtOriginSize.Width,txtOriginSize.Height);
                        break;
                    case ClickType.txtResizeDown:
                        this.textBox1.Size = new Size(txtOriginSize.Width, e.Y - this.textBox1.Location.Y - txtDeviation.Y + txtOriginSize.Height);
                        break;
                    case ClickType.txtResizeSE:
                        this.textBox1.Size = new Size(e.X - this.textBox1.Location.X - txtDeviation.X + txtOriginSize.Width, e.Y - this.textBox1.Location.Y - txtDeviation.Y + txtOriginSize.Height);
                        break;

                    case ClickType.txtResizeNW:
                        this.textBox1.SetBounds(e.X - txtDeviation.X, e.Y - txtDeviation.Y,
                            txtOriginSize.Width - e.X + lastLocation.X + txtDeviation.X,
                            txtOriginSize.Height - e.Y + lastLocation.Y + txtDeviation.Y
                            );
                        break;
                    case ClickType.txtResizeUp:
                        this.textBox1.SetBounds(lastLocation.X, e.Y - txtDeviation.Y,
                            txtOriginSize.Width,
                            txtOriginSize.Height - e.Y + lastLocation.Y + txtDeviation.Y
                            );
                        break;
                    case ClickType.txtResizeLeft:
                        this.textBox1.SetBounds(e.X - txtDeviation.X, lastLocation.Y,
                            txtOriginSize.Width - e.X + lastLocation.X + txtDeviation.X,
                            txtOriginSize.Height
                            );
                        break;
                    case ClickType.txtResizeSW:
                        this.textBox1.SetBounds(e.X - txtDeviation.X, lastLocation.Y,
                            txtOriginSize.Width - e.X + lastLocation.X + txtDeviation.X,
                            txtOriginSize.Height + e.Y - lastLocation.Y - txtDeviation.Y
                            );
                        break;
                    case ClickType.txtResizeNE:
                        this.textBox1.SetBounds(lastLocation.X, e.Y - txtDeviation.Y,
                            txtOriginSize.Width + e.X - lastLocation.X - txtDeviation.X,
                            txtOriginSize.Height - e.Y + lastLocation.Y + txtDeviation.Y
                            );
                        break;
                }
            }

        }
        private void txt1_MouseUp(object sender, MouseEventArgs e)
        {
            mouseDown = false;
            this.Capture = false;
            clickMode = ClickType.None;
        }
    }
}

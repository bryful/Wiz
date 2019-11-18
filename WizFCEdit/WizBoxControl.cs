using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Drawing;
using System.Data;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using System.Drawing.Drawing2D;

namespace WizFCEdit
{
    public partial class WizBoxControl : Control
    {
        private WizBox wb = new WizBox();
        public int SiseMargin
        {
            get { return wb.LeftMargin; }
            set
            {
                wb.LeftMargin = value;
                wb.RightMargin = value;
                this.Invalidate();
            }
        }
        public int TopMargin
        {
            get { return wb.TopMargin; }
            set
            {
                int v = value;
                if (v < 0) v = 0;
                wb.TopMargin = v;
                this.Invalidate();
            }
        }
        public int BottomMargin
        {
            get { return wb.BottomMargin; }
            set
            {
                int v = value;
                if (v < 0) v = 0;
                wb.BottomMargin = v;
                this.Invalidate();
            }
        }
        public int Corner
        {
            get { return wb.Corner; }
            set
            {
                int v = value;
                if (v < 0) v = 0;
                wb.Corner = v;
                this.Invalidate();
            }
        }
        public int LineWidth
        {
            get { return wb.LineWidth; }
            set
            {
                int v = value;
                if (v < 0) v = 0;
                wb.LineWidth = v;
                this.Invalidate();
            }
        }
        // ************************************************************
        public WizBoxControl()
        {
            InitializeComponent();
            this.SetStyle(
                ControlStyles.DoubleBuffer |
                ControlStyles.UserPaint |
                ControlStyles.AllPaintingInWmPaint,
                true);
        }
        // ************************************************************
        protected override void InitLayout()
        {
            base.InitLayout();
            this.BackColor = Color.Black;
            this.ForeColor = Color.White;
        }
        // ************************************************************
        protected override void OnPaint(PaintEventArgs e)
        {
            base.OnPaint(e);
            wb.Graphics = e.Graphics;
            wb.Size = this.ClientSize;
            wb.Back = this.BackColor;
            wb.Fore = this.ForeColor;
            wb.DrawFrame();

        }
        // ************************************************************
        protected override void OnSizeChanged(EventArgs e)
        {
            base.OnSizeChanged(e);
            wb.Size = this.ClientSize;
            this.Invalidate();
        }

    }
}

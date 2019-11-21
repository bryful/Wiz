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
    public class WizButton : Button
    {
        WizBox wb = new WizBox();
        enum STAT
        {
            NONE=0,
            PUSHED
        }
        private bool m_IsDrawWaku = true;
        public bool IsDrawWaku
        {
            get { return m_IsDrawWaku; }
            set
            {
                m_IsDrawWaku = value;
                this.Invalidate();
            }
        }
        STAT m_stat = STAT.NONE;
        public WizButton() : base()
        {
            this.SetStyle(
              ControlStyles.DoubleBuffer |
              ControlStyles.UserPaint |
              ControlStyles.AllPaintingInWmPaint,
              true);
            this.BackColor = Color.Black;
            this.ForeColor = Color.White;
            this.Font = new Font(this.Font.FontFamily, 9);

            wb.TopMargin = 1;
            wb.LeftMargin = 1;
            wb.RightMargin = 1;
            wb.BottomMargin = 1;
            wb.Corner = 3;
            wb.LineWidth = 2;

        }
        protected override void OnMouseLeave(EventArgs e)
        {
            base.OnMouseLeave(e);
            m_stat = STAT.NONE;
            this.Invalidate();
        }
        protected override void OnMouseDown(MouseEventArgs e)
        {
            base.OnMouseDown(e);
            m_stat = STAT.PUSHED;
            this.Invalidate();
        }
        protected override void OnMouseUp(MouseEventArgs mevent)
        {
            base.OnMouseUp(mevent);
            m_stat = STAT.NONE;
            this.Invalidate();
        }
        //----------------------------------------------------------------------
        protected override void OnPaint(PaintEventArgs e)
        {
            //base.OnPaint(e);
            Graphics g = e.Graphics;
            SolidBrush sb = new SolidBrush(this.ForeColor);
            StringFormat sf = new StringFormat();
            sf.Alignment = StringAlignment.Center;
            sf.LineAlignment = StringAlignment.Center;
            try
            {
                wb.Graphics = g;
                wb.Size = this.Size;
                switch (m_stat)
                {
                    case STAT.PUSHED:
                        wb.ForeColor = this.BackColor;
                        wb.BackColor = this.ForeColor;
                        break;
                    case STAT.NONE:
                        wb.ForeColor = this.ForeColor;
                        wb.BackColor = this.BackColor;
                        break;
                }
                if (m_IsDrawWaku == true)
                {
                    wb.DrawFrame();
                }
                else
                {
                    wb.FillFrame();
                }
                switch (m_stat)
                {
                    case STAT.PUSHED:
                        sb.Color = this.BackColor;
                        break;
                    case STAT.NONE:
                        if (this.Enabled == false)
                        {
                            sb.Color = Color.DarkGray;

                        }
                        else
                        {
                            sb.Color = this.ForeColor;
                        }
                        break;
                }
                g.DrawString(this.Text, this.Font, sb, this.ClientRectangle, sf);
            }
            finally
            {
                sb.Dispose();
                sf.Dispose();
            }

        }
    }
}

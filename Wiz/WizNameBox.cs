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

namespace WizEdit
{
    public class WizNameBox : Control
    {
        #region state
        private WizNesState m_state = null;
        public WizNesState WizNesState
        {
            get { return m_state; }
            set
            {
                m_state = value;
                if (m_state!=null)
                {
                    m_state.ChangeCurrentChar += M_state_ChangeCurrentChar;
                    m_state.FinishedLoadFile += M_state_FinishedLoadFile;
                }
            }
        }

        private void M_state_FinishedLoadFile(object sender, EventArgs e)
        {
            this.Invalidate();
        }

        private void M_state_ChangeCurrentChar(object sender, CurrentCharEventArgs e)
        {
            this.Invalidate();
        }
        #endregion

        // *********************************************************************
        public WizNameBox()
        {

        }
        // *********************************************************************
        protected override void InitLayout()
        {
            base.InitLayout();
            this.BackColor = Color.Black;
            this.ForeColor = Color.White;
            this.Size = new Size(150, 24);
            this.MaximumSize = this.Size;
            this.MinimumSize = this.Size;
        }
        // *********************************************************************
        protected override void OnPaint(PaintEventArgs e)
        {
            base.OnPaint(e);
            SolidBrush sb = new SolidBrush(this.BackColor);
            Pen p = new Pen(Color.DarkGray);
            p.Width = 2;
            StringFormat sf = new StringFormat();
            sf.Alignment = StringAlignment.Near;
            sf.LineAlignment = StringAlignment.Center;
            Graphics g = e.Graphics;
            try
            {
                Rectangle rct = new Rectangle(0, 0, this.Size.Width, this.Size.Height);
                g.FillRectangle(sb,rct);

                g.DrawRectangle(p, rct);

                if (m_state != null)
                {
                    string cn = m_state.CharName;
                    if (cn != "")
                    {
                        sb.Color = this.ForeColor;
                        g.DrawString(cn, this.Font, sb, rct, sf);
                    }
                }
            }
            finally
            {
                sb.Dispose();
                p.Dispose();
                sf.Dispose();
            }



        }
        // *********************************************************************
    }
}

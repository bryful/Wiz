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
    public class WizMP : Control
    {
        MagicPoint m_magic = new MagicPoint();
        MagicPoint m_priest = new MagicPoint();
        private bool m_IsDrawFrame = false;
        public bool IsDrawFrame
        {
            get { return m_IsDrawFrame; }
            set { m_IsDrawFrame = value; this.Invalidate(); }
        }

        private const int LineCount = 2; 
        private int m_LineHeight = 20;
        public int LineHeight
        {
            get { return m_LineHeight; }
            set { m_LineHeight = value; this.Invalidate(); }
        }
        public WizMP()
        {
            this.ForeColor = Color.White;
            this.BackColor = Color.Black;
        }

        #region state
        private WizNesState m_state = null;
        public WizNesState WizNesState
        {
            get { return m_state; }
            set
            {
                m_state = value;
                if (m_state != null)
                {
                    m_state.ChangeCurrentChar += M_state_ChangeCurrentChar;
                    m_state.FinishedLoadFile += M_state_FinishedLoadFile;
                }
                GetInfo();
            }
        }
        private void M_state_FinishedLoadFile(object sender, EventArgs e)
        {
            GetInfo();
        }

        private void M_state_ChangeCurrentChar(object sender, CurrentCharEventArgs e)
        {
            GetInfo();
        }
        #endregion

        // *************************************************************************
        public void GetInfo()
        {
            if (m_state != null)
            {
                m_magic = m_state.CharMagic;
                m_priest = m_state.CharPriest;

            }
            this.Invalidate();

        }
        // *************************************************************************
        protected override void OnPaint(PaintEventArgs e)
        {
            Graphics g = e.Graphics;
            //base.OnPaint(e);
            SolidBrush sb = new SolidBrush(this.BackColor);
            StringFormat sf = new StringFormat();
            sf.LineAlignment = StringAlignment.Center;
            sf.Alignment = StringAlignment.Near;
            Pen pn = new Pen(this.ForeColor);
            pn.Width = 2;
            try
            {
                Rectangle rct = new Rectangle(0, 0, this.Width, this.Height);
                g.FillRectangle(sb, rct);

                if (m_IsDrawFrame == true)
                {
                    pn.Color = Color.DarkGray;
                    g.DrawRectangle(pn, rct);
                    g.DrawLine(pn, 0, m_LineHeight, this.Width, m_LineHeight);
                }
                sb.Color = this.ForeColor;
                string s = String.Format("M  {0:X}/ {1:X}/ {2:X}/ {3:X}/ {4:X}/ {5:X}/ {6:X}",
                    m_magic.MaxP[0],
                    m_magic.MaxP[1],
                    m_magic.MaxP[2],
                    m_magic.MaxP[3],
                    m_magic.MaxP[4],
                    m_magic.MaxP[5],
                    m_magic.MaxP[6]
                    );
                rct = new Rectangle(0, 0, this.Width, m_LineHeight);
                g.DrawString(s, this.Font, sb, rct, sf);
                s = String.Format("P  {0:X}/ {1:X}/ {2:X}/ {3:X}/ {4:X}/ {5:X}/ {6:X}",
                    m_priest.MaxP[0],
                    m_priest.MaxP[1],
                    m_priest.MaxP[2],
                    m_priest.MaxP[3],
                    m_priest.MaxP[4],
                    m_priest.MaxP[5],
                    m_priest.MaxP[6]
                    );
                rct = new Rectangle(0, m_LineHeight, this.Width, m_LineHeight);
                g.DrawString(s, this.Font, sb, rct, sf);

            }
            finally
            {
                sb.Dispose();
            }

        }
    }
}

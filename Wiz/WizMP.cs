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

        #region Prop
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
            set { m_LineHeight = value; ChkSize(); this.Invalidate(); }
        }
        private int m_CaptionWidth = 20;
        public int CaptionWidth
        {
            get { return m_CaptionWidth; }
            set { m_CaptionWidth = value; ChkSize(); this.Invalidate(); }
        }
        private int m_ValueWidth = 20;
        public int ValueWidth
        {
            get { return m_ValueWidth; }
            set { m_ValueWidth = value; ChkSize(); this.Invalidate(); }
        }
        #endregion


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
                    m_state.CurrentCharChanged += M_state_ChangeCurrentChar;
                    m_state.LoadFileFinished += M_state_FinishedLoadFile;
                    m_state.ValueChanged += M_state_FinishedLoadFile;
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

        // ****************************************************************
        // ****************************************************************
        public WizMP()
        {
            this.ForeColor = Color.White;
            this.BackColor = Color.Black;
        }
        // ****************************************************************

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
        public void ChkSize()
        {
            this.Size = new Size(m_CaptionWidth + m_ValueWidth * 7, m_LineHeight * 2);
            this.MinimumSize = this.Size;
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
                int x = 0;
                int y = 0;
                Rectangle rct = new Rectangle(0, 0, this.Width, this.Height);
                g.FillRectangle(sb, rct);

                if (m_IsDrawFrame == true)
                {
                    pn.Color = Color.DarkGray;
                    g.DrawRectangle(pn, rct);
                    g.DrawLine(pn, 0, m_LineHeight, this.Width, m_LineHeight);
                    g.DrawLine(pn, 0, m_LineHeight*2, this.Width, m_LineHeight*2);

                    x = m_CaptionWidth;
                    g.DrawLine(pn, x, 0, x,this.Height);
                    for (int i=0; i<=7; i++)
                    {
                        g.DrawLine(pn, x, 0, x, this.Height);
                        x += m_ValueWidth;
                    }

                }

                sb.Color = this.ForeColor;
                rct = new Rectangle(0, 0, m_CaptionWidth, m_LineHeight);
                g.DrawString("M", this.Font, sb, rct, sf);
                rct = new Rectangle(0, m_LineHeight, m_CaptionWidth, m_LineHeight);
                g.DrawString("P", this.Font, sb, rct, sf);

                sf.Alignment = StringAlignment.Center;
                x = m_CaptionWidth;
                y = 0;
                for ( int i=0; i<7;i++)
                {
                    rct = new Rectangle(x, y, m_ValueWidth, m_LineHeight);
                    g.DrawString(m_magic.MaxP[i].ToString(), this.Font, sb, rct, sf);
                    rct = new Rectangle(x, y+m_LineHeight, m_ValueWidth, m_LineHeight);
                    g.DrawString(m_priest.MaxP[i].ToString(), this.Font, sb, rct, sf);
                    x += m_ValueWidth;
                }

            }
            finally
            {
                sb.Dispose();
            }

        }
    }
}

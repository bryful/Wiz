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
    public class WizHP : Control
    {
        private int m_hp = 0;
        private int m_hpmax = 0;

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

        // *************************************************************************
        public void GetInfo()
        {
            m_hp =0;
            m_hpmax = 0;

            if(m_state!=null)
            {
                m_hp = m_state.CharHP;
                m_hpmax = m_state.CharHPMax;
            }

            this.Invalidate();

        }
        #endregion

        private bool m_IsDrawFrame = false;
        public bool IsDrawFrame
        {
            get { return m_IsDrawFrame; }
            set { m_IsDrawFrame = value; this.Invalidate(); }
        }

        private int m_CaptionWidth = 100;
        public int CaptionWidth
        {
            get { return m_CaptionWidth; }
            set { m_CaptionWidth = value; SizeChk(); this.Invalidate(); }
        }
        private int m_HPWidth = 100;
        public int HPWidth
        {
            get { return m_HPWidth; }
            set { m_HPWidth = value; SizeChk();  this.Invalidate(); }
        }
        private int m_HPMaxWidth = 100;
        public int HPMaxWidth
        {
            get { return m_HPMaxWidth; }
            set { m_HPMaxWidth = value; SizeChk();  this.Invalidate(); }
        }
        // ***********************************************************************
        public WizHP()
        {
            this.BackColor = Color.Black;
            this.ForeColor = Color.White;

        }
        // ***********************************************************************
        public void SizeChk()
        {
            int w = m_CaptionWidth + m_HPWidth + m_HPMaxWidth;
            int h = this.MinimumSize.Height;
            this.MinimumSize = new Size(w, h);
        }
        // ***********************************************************************
        protected override void OnPaint(PaintEventArgs e)
        {
            //base.OnPaint(e);
            Graphics g = e.Graphics;

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
                    int x = m_CaptionWidth;
                    g.DrawLine(pn, x, 0, x, this.Height);
                    x += m_HPWidth;
                    g.DrawLine(pn, x, 0, x, this.Height);
                    x += m_HPMaxWidth;
                    g.DrawLine(pn, x, 0, x, this.Height);
                }
                sb.Color = this.ForeColor;
                rct = new Rectangle(0, 0, m_CaptionWidth, this.Height);
                g.DrawString("H.P.", this.Font, sb, rct, sf);

                sf.Alignment = StringAlignment.Far;
                rct = new Rectangle(m_CaptionWidth, 0, m_HPWidth, this.Height);
                g.DrawString(m_hp.ToString()+"/", this.Font, sb, rct, sf);

                rct = new Rectangle(m_CaptionWidth+m_HPWidth, 0, m_HPMaxWidth, this.Height);
                g.DrawString(m_hpmax.ToString() , this.Font, sb, rct, sf);

            }
            finally
            {
                sb.Dispose();
            }
        }
    }
}

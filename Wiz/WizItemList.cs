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
    public class WizItemList : Control
    {
        public WizItemList()
        {
            this.ForeColor = Color.White;
            this.BackColor = Color.Black;
        }

        WizItem[] m_items = new WizItem[0];
        private bool m_IsDrawFrame = false;
        public bool IsDrawFrame
        {
            get { return m_IsDrawFrame; }
            set { m_IsDrawFrame = value; this.Invalidate(); }
        }
        private int m_LineHeight = 18;
        public int LineHeight
        {
            get { return m_LineHeight; }
            set { m_LineHeight = value; SizeChk();  this.Invalidate(); }
        }
        // *************************************************************************
        public void SizeChk()
        {
            int h = m_LineHeight * 8;
            int w = this.MinimumSize.Width;
            this.MinimumSize = new Size(w, h);
        }
        // *************************************************************************
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
            if(m_state!=null)
            {
                m_items = m_state.CharItems;
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
                    int y = m_LineHeight;
                    for (int i = 0; i <= 8; i++)
                    {
                        g.DrawLine(pn, 0, y, this.Width, y);
                        y += m_LineHeight;
                    }
                }
                sb.Color = this.ForeColor;
                sf.Alignment = StringAlignment.Near;

                if(m_items.Length>0)
                {
                    for ( int i=0;i<m_items.Length;i++)
                    {
                        rct = new Rectangle(0, m_LineHeight*i, this.Width, m_LineHeight);
                        g.DrawString(m_items[i].CaptionText, this.Font, sb, rct, sf);
                    }
                }
            }
            finally
            {
                sb.Dispose();
            }

        }
    }
}

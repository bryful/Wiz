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
    public class WizCharList : WizBoxControl
    {
 

        private bool m_IsActive = true;
        public bool IsActive
        {
            get { return m_IsActive; }
            set
            {
                m_IsActive = value;
                this.Invalidate();
            }
        }
        private WizNesState m_state = null;
        public WizNesState WizNesState
        {
            get { return m_state; }
            set
            {
                m_state = value;
                if (m_state!=null)
                {
                    m_state.LoadFileFinished += RedrawAction;
                    m_state.CurrentCharChanged += RedrawAction;
                    m_state.ValueChanged += RedrawAction;
                }
                this.Invalidate();
            }
        }
        // ***********************************
        private void RedrawAction(object sender, EventArgs e)
        {
            this.Invalidate();
        }
        // ***********************************
        private int m_LineHeight = 18;
        public int LineHeight
        {
            get { return m_LineHeight; }
            set
            {
                m_LineHeight = value;
                if (m_LineHeight < 12) m_LineHeight = 12;
                int x = this.MinimumSize.Width;
                this.MinimumSize = new Size(x, m_LineHeight * m_LineCount+this.TopMargin+ this.BottomMargin);
                this.Invalidate();
            }
        }
        private int m_LineCount = 20;
        public int LineCount
        {
            get { return m_LineCount; }
        }


    private int m_ListTopMgn = 5;
        public int ListTopMgn
        {
            get { return m_ListTopMgn; }
            set { m_ListTopMgn = value;  if (m_ListTopMgn < 0) m_ListTopMgn = 0; this.Invalidate();}
        }
        private int m_ListBottomMgn = 5;
        public int ListBottomMgn
        {
            get { return m_ListBottomMgn; }
            set { m_ListBottomMgn = value; if (m_ListBottomMgn < 0) m_ListBottomMgn = 0; this.Invalidate(); }
        }
        private int m_ListLeftMgn = 30;
        public int ListLeftMgn
        {
            get { return m_ListLeftMgn; }
            set { m_ListLeftMgn = value; if (m_ListLeftMgn < 0) m_ListLeftMgn = 0; this.Invalidate(); }
        }
        private int m_ListRightMgn = 10;
        public int ListRightMgn
        {
            get { return m_ListRightMgn; }
            set { m_ListRightMgn = value; if (m_ListRightMgn < 0) m_ListRightMgn = 0; this.Invalidate(); }
        }
        // ****************************************************************************
        public WizCharList()
        {
            this.SetStyle(
           ControlStyles.DoubleBuffer |
           ControlStyles.UserPaint |
           ControlStyles.AllPaintingInWmPaint,
           true);
            int x = this.MinimumSize.Width;
            this.MinimumSize = new Size(x, m_LineHeight * m_LineCount + this.TopMargin + this.BottomMargin);
        }
        // ****************************************************************************
        protected override void InitLayout()
        {
            base.InitLayout();
        }
        // ****************************************************************************
        protected override void OnPaint(PaintEventArgs e)
        {
            base.OnPaint(e);
            if (m_state == null) return;
            string[] names = m_state.CharNames;
            if (names.Length <= 0) return;

            SolidBrush sb = new SolidBrush(this.ForeColor);
            StringFormat sf = new StringFormat();
            sf.Alignment = StringAlignment.Near;
            sf.LineAlignment = StringAlignment.Center;
            Graphics g = e.Graphics;

            try
            {
                //テキストの描画範囲
                Rectangle rct = new Rectangle(
                    this.SiseMargin + m_ListLeftMgn,
                    this.TopMargin + m_ListTopMgn,
                    this.ClientSize.Width - (this.SiseMargin*2 + m_ListLeftMgn + m_ListRightMgn),
                    m_LineHeight
                    );
                for (int i = 0; i < names.Length; i++)
                {
                    if (i==m_state.CharCurrent)
                    {
                        Rectangle rr = new Rectangle(rct.Left, rct.Top + 3, rct.Width, rct.Height - 6);
                        sb.Color = Color.Blue;
                        g.FillRectangle(sb, rr);
                        if (m_IsActive == true)
                        {
                            sb.Color = Color.Red;
                            WizU.DrawCursor(g, sb, rct.Left - 25, rct.Top + rct.Height/2);
                        }
                        sb.Color = this.ForeColor;
                    }
                    g.DrawString(names[i], this.Font, sb, rct, sf);


                    rct.Location = new Point(rct.Left, rct.Top + m_LineHeight);
                }
            }
            finally
            {
                sb.Dispose();
            }

        }
        // ****************************************************************************
        protected override void OnMouseDown(MouseEventArgs e)
        {
            base.OnMouseDown(e);
            if (m_IsActive == false) return;
            if (m_state != null)
            {
                int c = (e.Y - (this.TopMargin + m_ListTopMgn)) / m_LineHeight;
                if ((c >= 0) && (c < m_state.CharCount))
                {
                    m_state.CharCurrent = c;
                }
            }

        }
        // ****************************************************************************
        public void CursolDown()
        {
            if (m_IsActive == false) return;
            if ( m_state !=null)
            {
                if ( (m_state.CharCurrent>=0)&&(m_state.CharCurrent< m_state.CharCount-1))
                {
                    m_state.CharCurrent = m_state.CharCurrent + 1;
                }
            }
        }
        // ****************************************************************************
        public void CursolUp()
        {
            if (m_IsActive == false) return;
            if (m_state != null)
            {
                if ((m_state.CharCurrent >= 1) && (m_state.CharCurrent < m_state.CharCount))
                {
                    m_state.CharCurrent = m_state.CharCurrent - 1;
                }
            }
        }

    }
}

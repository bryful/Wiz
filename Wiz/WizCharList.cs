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
    public class WizCharList : WizConrol
    {

        public event EventHandler ChangedSelectedIndex;
        protected virtual void OnChangedSelectedIndex(EventArgs e)
        {
            ChangedSelectedIndex?.Invoke(this, e);
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
                    m_state.FinishedLoadFile += RedrawAction;
                    m_state.ChangeCurrentChar += RedrawAction;
                }
            }
        }
        // ***********************************
        private void RedrawAction(object sender, EventArgs e)
        {
            if (m_state != null)
            {
                m_SelectedIndex = m_state.CurrentChar;
            }
            this.Invalidate();
        }
        // ***********************************

        private int m_TextSideMargin = 20;
        private int m_TextVurtualMargin = 5;
        private int m_LineHeight = 20;
        private int m_LineCount = 20;
        private int m_Width = 150;

        private int m_SelectedIndex = -1;
        // ****************************************************************************
        public WizCharList()
        {
            this.SetStyle(
           ControlStyles.DoubleBuffer |
           ControlStyles.UserPaint |
           ControlStyles.AllPaintingInWmPaint,
           true);
        }
        // ****************************************************************************
        protected override void InitLayout()
        {
            base.InitLayout();
            this.ClientSize = new Size(m_Width, m_LineHeight* m_LineCount);
            this.MaximumSize = this.Size;
            this.MinimumSize = this.Size;
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
                Rectangle rct = new Rectangle(
                    this.SiseMargin + m_TextSideMargin,
                    this.TopMargin + m_TextVurtualMargin,
                    this.ClientSize.Width - (this.SiseMargin + m_TextSideMargin) * 2,
                    m_LineHeight
                    );
                for (int i = 0; i < names.Length; i++)
                {
                    if (i==m_state.CurrentChar)
                    {
                        Rectangle rr = new Rectangle(rct.Left, rct.Top + 6, rct.Width, rct.Height - 12);
                        sb.Color = Color.Blue;
                        g.FillRectangle(sb, rr);
                        sb.Color = this.ForeColor;

                        Point[] ps = new Point[]
                        {
                            new Point(rr.Left-15,rr.Top),
                            new Point(rr.Left-3,rr.Top+4),
                            new Point(rr.Left-15,rr.Top + 8)
                        };
                        g.FillPolygon(sb, ps);
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
            if (m_state != null)
            {
                int c = (e.Y - (this.TopMargin + m_TextVurtualMargin)) / m_LineHeight;
                if ((c >= 0) && (c < m_state.CharCount))
                {
                    m_state.CurrentChar = c;
                }
                this.Focus();
            }

        }
        // ****************************************************************************
        public void CursolDown()
        {
            if ( m_state !=null)
            {
                if ( (m_state.CurrentChar>=0)&&(m_state.CurrentChar< m_state.CharCount-1))
                {
                    m_state.CurrentChar = m_state.CurrentChar + 1;
                    this.Invalidate();
                }
            }
        }
        // ****************************************************************************
        public void CursolUp()
        {
            if (m_state != null)
            {
                if ((m_state.CurrentChar >= 1) && (m_state.CurrentChar < m_state.CharCount))
                {
                    m_state.CurrentChar = m_state.CurrentChar - 1;
                    this.Invalidate();
                }
            }
        }

    }
}

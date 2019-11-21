using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;


namespace WizFCEdit
{
    public class WizComboBox :Control
    {
        private bool m_IsListMode = false;
        public bool IsListMode
        {
            get { return m_IsListMode; }
            set { m_IsListMode = value; }
        }

        private List<string> m_List = new List<string>();
        public string[] List
        {
            get { return m_List.ToArray(); }
            set
            {
                m_List = value.ToList();

                if (m_SelecteIndex>=m_List.Count)
                {
                    m_SelecteIndex = m_List.Count - 1;
                }
                SizeChk();
                this.Invalidate();
            }
        }

        private int m_SelecteIndex = -1;
        public int SelectedIndex
        {
            get { return m_SelecteIndex; }
            set
            {
                if (m_SelecteIndex != value)
                {
                    m_SelecteIndex = value;
                    this.Invalidate();
                }
            }
        }

        private Point m_OffsetPoint = new Point(10, 5);
        public Point OffsetPoint
        {
            get { return m_OffsetPoint; }
            set { m_OffsetPoint = value; this.Invalidate(); }
        }

        private int m_LineHeight = 20;
        public  int LineHeight
        {
            get { return m_LineHeight; }
            set
            {
                if (m_LineHeight!=value)
                {
                    m_LineHeight = value;
                    SizeChk();
                    this.Invalidate();
                }
            }
        }

        private WizBox wb = new WizBox();

        public WizComboBox()
        {
            this.SetStyle(
               ControlStyles.DoubleBuffer |
               ControlStyles.UserPaint |
               ControlStyles.AllPaintingInWmPaint,
               true);
            this.ForeColor = Color.White;
            this.BackColor = Color.Black;

            wb.LeftMargin = 2;
            wb.RightMargin = 2;
            wb.TopMargin = 2;
            wb.BottomMargin = 2;
            wb.LineWidth = 2;
            wb.Corner = 3;
            SizeChk();
        }


        public void Clear()
        {
            m_List.Clear();
            SizeChk();
            m_SelecteIndex = -1;
            this.Invalidate();
        }
        public void Add(string s)
        {
            m_List.Add(s);
            SizeChk();
            this.Invalidate();
        }
        // ************************************************************************
        public void SizeChk()
        {
            int w = this.Width;
            int h = (m_List.Count)*m_LineHeight + m_OffsetPoint.Y * 2;
            this.Size = new Size(w, h);
        }
        // ************************************************************************
        protected override void OnPaint(PaintEventArgs e)
        {
            SolidBrush sb = new SolidBrush(this.BackColor);
            Pen pn = new Pen(this.ForeColor);
            StringFormat sf = new StringFormat();
            sf.Alignment = StringAlignment.Near;
            sf.LineAlignment = StringAlignment.Center;
            Graphics g = e.Graphics;
            try
            {
                wb.Graphics = g;
                wb.Size = this.Size;
                wb.DrawFrame();
                sb.Color = this.ForeColor;
                if (m_List.Count > 0)
                {
                    Rectangle rct = new Rectangle(m_OffsetPoint, new Size(this.Width - m_OffsetPoint.X * 2, m_LineHeight));
                    for (int i=0; i< m_List.Count; i++ )
                    {
                        if(i==m_SelecteIndex)
                        {
                            sb.Color = Color.Blue;
                            Rectangle r2 = new Rectangle(rct.Left, rct.Top + m_LineHeight / 4, rct.Width, m_LineHeight / 2);
                            g.FillRectangle(sb, r2);
                            sb.Color = this.ForeColor;
                        }
                        g.DrawString(m_List[i], this.Font, sb, rct, sf);
                        rct.Location = new Point(rct.Left, rct.Top + m_LineHeight);
                    }
                }

            }
            finally
            {
                sb.Dispose();
            }
        }
        // ************************************************************************
        private void ChkMousePos()
        {
            Point cp = this.PointToClient(Cursor.Position);
            int idx = (cp.Y - m_OffsetPoint.Y) / m_LineHeight;
            if (idx < 0) idx = -1;
            else if (idx >= m_List.Count) idx = -1;
            if (m_SelecteIndex != idx)
            {
                m_SelecteIndex = idx;
                this.Invalidate();
            }
        }
        protected override void OnMouseEnter(EventArgs e)
        {
            base.OnMouseEnter(e);
            ChkMousePos();
        }
        protected override void OnMouseMove(MouseEventArgs e)
        {
            base.OnMouseMove(e);
            ChkMousePos();
        }
        protected override void OnMouseDown(MouseEventArgs e)
        {
            base.OnMouseDown(e);
            if (m_IsListMode == true)
            {
                this.Visible = false;
            }
        }
        protected override void OnMouseUp(MouseEventArgs e)
        {
            base.OnMouseUp(e);
            if( m_IsListMode==true)
            {
                this.Visible = false;
            }
        }
        protected override void OnMouseLeave(EventArgs e)
        {
            base.OnMouseLeave(e);
            int v = -1;
            if(m_SelecteIndex!=v)
            {
                m_SelecteIndex = -1;
                this.Invalidate();
            }

            if (m_IsListMode == true)
            {
                this.Visible = false;
            }
        }

        static public void MeDelete(Control.ControlCollection cons,WizComboBox cmb)
        {
            if (cons.Count <= 0) return;
            cons.Remove(cmb);
            cmb.Dispose();
        }
        protected override void OnKeyDown(KeyEventArgs e)
        {
            if (m_IsListMode == true)
            {
                if (e.KeyCode == Keys.Escape)
                {
                    this.Visible = false;
                }
            }
            base.OnKeyDown(e);
        }
        protected override void OnPreviewKeyDown(PreviewKeyDownEventArgs e)
        {
            if (m_IsListMode == true)
            {
                if (e.KeyCode == Keys.Escape)
                {
                    this.Visible = false;
                }
            }
            base.OnPreviewKeyDown(e);
        }
    }
}

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
    public partial class WizConrol : Control
    {
        private int m_SideMargin = 5;
        public int SiseMargin
        {
            get { return m_SideMargin; }
            set
            {
                m_SideMargin = value;
                this.Invalidate();
            }
        }

        private int m_TopMargin = 5;
        public int TopMargin
        {
            get { return m_TopMargin; }
            set
            {
                int v = value;
                if (v < 0) v = 0;
                if (m_TopMargin != v)
                {
                    m_TopMargin = v;
                    this.Invalidate();
                }
            }
        }
        private int m_BottomMargin = 5;
        public int BottomMargin
        {
            get { return m_BottomMargin; }
            set
            {
                int v = value;
                if (v < 0) v = 0;
                if (m_BottomMargin != v)
                {
                    m_BottomMargin = v;
                    this.Invalidate();
                }
            }
        }
        private int m_Corner = 5;
        public int Corner
        {
            get { return m_Corner; }
            set
            {
                int v = value;
                if (v < 0) v = 0;
                if (m_Corner != v)
                {
                    m_Corner = v;
                    this.Invalidate();
                }
            }
        }
        private int m_LineWidth = 3;
        public int LineWidth
        {
            get { return m_LineWidth; }
            set
            {
                int v = value;
                if (v < 0) v = 0;
                if (m_LineWidth != v)
                {
                    m_LineWidth = v;
                    this.Invalidate();
                }
            }
        }
        // ************************************************************
        public WizConrol()
        {
            InitializeComponent();
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
            //base.OnPaint(e);
            Graphics g = e.Graphics;
            SolidBrush sb = new SolidBrush(this.BackColor);
            Pen p = new Pen(this.ForeColor);
            p.Width = m_LineWidth;
            p.LineJoin = LineJoin.Round;
            try
            {
                //塗りつぶし
                g.FillRectangle(sb, this.Bounds);

                if (m_LineWidth > 0)
                {
                    int w = this.ClientSize.Width;
                    int h = this.ClientSize.Height;
                    Point[] ps = {
                        new Point(m_SideMargin, m_TopMargin+m_Corner),
                        new Point(m_SideMargin+m_Corner, m_TopMargin),
                        new Point(w - m_SideMargin - m_Corner, m_TopMargin),
                        new Point(w - m_SideMargin , m_TopMargin+m_Corner),
                        new Point(w - m_SideMargin , h-m_BottomMargin-m_Corner),
                        new Point(w - m_SideMargin -m_Corner, h-m_BottomMargin),
                        new Point(m_SideMargin + m_Corner, h-m_BottomMargin),
                        new Point(m_SideMargin , h-m_BottomMargin-m_Corner)
                        };
                    g.DrawPolygon(p, ps);
                }
            }
            finally
            {
                sb.Dispose();
                p.Dispose();
            }
        }
        // ************************************************************

    }
}

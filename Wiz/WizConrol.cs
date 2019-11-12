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
        private int m_TopMargin = 5;
        private int m_BottomMargin = 5;

        public WizConrol()
        {
            InitializeComponent();
        }
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
            p.Width = 5;
            p.LineJoin = LineJoin.Round;
            try
            {
                g.FillRectangle(sb, this.Bounds);
                Rectangle rct = new Rectangle(
                   m_SideMargin, m_TopMargin,
                   this.ClientSize.Width - m_SideMargin * 2,
                   this.ClientSize.Height - m_TopMargin  - m_BottomMargin
                   );
                g.DrawRectangle(p, rct);
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

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
    public class WizTextBox :Control
    {
        private bool m_IsDrawFrame = false;
        private string m_NearText = "";
        public string NearText
        {
            get { return m_NearText; }
            set { m_NearText = value; this.Invalidate(); }
        }
        private string m_FarText = "";
        public string FarText
        {
            get { return m_FarText; }
            set { m_FarText = value; this.Invalidate(); }
        }


        public WizTextBox()
        {
            this.BackColor = Color.Black;
            this.ForeColor = Color.White;
            this.Text = "";
        }
        public bool IsDrawFrame
        {
            get { return m_IsDrawFrame; }
            set
            {
                m_IsDrawFrame = value;
                this.Invalidate();
            }
        }
 
        // *********************************************************************
        protected override void OnPaint(PaintEventArgs e)
        {
            base.OnPaint(e);
            SolidBrush sb = new SolidBrush(this.BackColor);
            Pen p = new Pen(Color.DarkGray);
            p.Width = 2;
            StringFormat sf = new StringFormat();
            sf.LineAlignment = StringAlignment.Center;
            Graphics g = e.Graphics;
            try
            {
                Rectangle rct = new Rectangle(0, 0, this.Size.Width, this.Size.Height);
                g.FillRectangle(sb, rct);

                if (m_IsDrawFrame == true)
                {
                    g.DrawRectangle(p, rct);
                }
                sb.Color = this.ForeColor;
                if (m_NearText!="")
                {
                    sf.Alignment = StringAlignment.Near;
                    g.DrawString(m_NearText, this.Font, sb, rct, sf);
                }
                if (m_FarText != "")
                {
                    sf.Alignment = StringAlignment.Far;
                    g.DrawString(m_FarText, this.Font, sb, rct, sf);
                }
            }
            finally
            {
                sb.Dispose();
                p.Dispose();
                sf.Dispose();
            }



        }
    }

}

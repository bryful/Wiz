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
    public class WizScnComb : Control
    {
        private WIZSCN m_scn = WIZSCN.SFC1;

        public WIZSCN WIZSCN
        {
            get { return m_scn; }
            set
            {
                m_scn = value;

                this.Invalidate();
            }
        }

        // ******************************************************************************
        private WizData m_WizData = null;
        public WizData WizData
        {
            get { return m_WizData; }
            set
            {
                m_WizData = value;
                if(m_WizData != null)
                {
                    m_WizData.LoadFileFinished += M_WizData_LoadFileFinished;
                }
            }

        }
        // ******************************************************************************
        private void M_WizData_LoadFileFinished(object sender, EventArgs e)
        {
            if (m_WizData == null) return;
            if ( (m_WizData.SCN==WIZSCN.SFC1)|| (m_WizData.SCN == WIZSCN.SFC2)|| (m_WizData.SCN == WIZSCN.SFC3))
            {
                this.Visible = true;
            }
            else
            {
                this.Visible = false;
            }
        }

        private int XArea1 = 0;
        private int XArea2 = 0;
        // ******************************************************************************
        public WizScnComb()
        {
            this.ForeColor = Color.White;
            this.BackColor = Color.Black;

            this.Font = new Font(this.Font.FontFamily, 8);

            ChkSize();
        }
        // ******************************************************************************
        private void ChkSize()
        {
            XArea1 = this.ClientSize.Width / 3;
            XArea2 = XArea1 * 2;

        }
        // ******************************************************************************
        protected override void OnSizeChanged(EventArgs e)
        {
            base.OnSizeChanged(e);
            ChkSize();
            this.Invalidate();

        }
        // ******************************************************************************
        protected override void OnPaint(PaintEventArgs e)
        {
            //base.OnPaint(e);

            if ( (m_scn==WIZSCN.SFC1)|| (m_scn == WIZSCN.SFC2)|| (m_scn == WIZSCN.SFC3))
            {
                SolidBrush sb = new SolidBrush(this.BackColor);
                Pen pn = new Pen(this.ForeColor);
                StringFormat sf = new StringFormat();
                sf.Alignment = StringAlignment.Center;
                sf.LineAlignment = StringAlignment.Center;
                try
                {
                    Graphics g = e.Graphics;
                    g.FillRectangle(sb, this.ClientRectangle);
                    g.DrawRectangle(pn, new Rectangle(0, 0, this.ClientSize.Width - 1, this.ClientSize.Height - 1));

                    Rectangle rct = new Rectangle(0, 0, XArea1, this.Height);
                    string s = "PG";
                    if (m_scn == WIZSCN.SFC1)
                    {
                        sb.Color = this.ForeColor;
                        g.FillRectangle(sb, rct);
                        sb.Color = this.BackColor;
                        g.DrawString(s, this.Font, sb, rct, sf);
                    }
                    else
                    {
                        sb.Color = this.ForeColor;
                        g.DrawString(s, this.Font, sb, rct, sf);
                    }
                    rct = new Rectangle(XArea1, 0, XArea1, this.Height);
                    s = "LOL";
                    if (m_scn == WIZSCN.SFC2)
                    {
                        sb.Color = this.ForeColor;
                        g.FillRectangle(sb, rct);
                        sb.Color = this.BackColor;
                        g.DrawString(s, this.Font, sb, rct, sf);
                    }
                    else
                    {
                        sb.Color = this.ForeColor;
                        g.DrawString(s, this.Font, sb, rct, sf);
                    }
                    rct = new Rectangle(XArea2, 0, XArea1, this.Height);
                    s = "KOD";
                    if (m_scn == WIZSCN.SFC3)
                    {
                        sb.Color = this.ForeColor;
                        g.FillRectangle(sb, rct);
                        sb.Color = this.BackColor;
                        g.DrawString(s, this.Font, sb, rct, sf);
                    }
                    else
                    {
                        sb.Color = this.ForeColor;
                        g.DrawString(s, this.Font, sb, rct, sf);
                    }




                }
                finally
                {
                    sb.Dispose();
                }

            }
            else
            {

            }

        }
        // ******************************************************************************
        protected override void OnMouseClick(MouseEventArgs e)
        {
            base.OnMouseClick(e);
            
            if (e.X < XArea1)
            {
                m_scn = WIZSCN.SFC1;
            }else if (e.X <XArea2)
            {
                m_scn = WIZSCN.SFC2;
            }
            else
            {
                m_scn = WIZSCN.SFC3;
            }

            if (m_WizData!=null)
            {
                m_WizData.SetSFC_SCN(m_scn);
            }

            this.Invalidate();
        }
    }
}

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
    public class WizCaption : WizConrol
    {
        // **************************************************
        public WizCaption()
        {

        }
        // **************************************************
        protected override void OnPaint(PaintEventArgs e)
        {
            base.OnPaint(e);
            if (this.Text != "")
            {
                Graphics g = e.Graphics;
                SolidBrush sb = new SolidBrush(this.ForeColor);
                StringFormat sf = new StringFormat();
                sf.Alignment = StringAlignment.Center;
                sf.LineAlignment = StringAlignment.Center;
                try
                {
                    Rectangle rct = new Rectangle(
                        this.SiseMargin,
                        this.TopMargin,
                        this.ClientSize.Width - this.SiseMargin * 2,
                        this.ClientSize.Height - this.TopMargin - this.BottomMargin
                        );
                    g.DrawString(this.Text, this.Font, sb, rct, sf);

                }
                finally
                {
                    sb.Dispose();
                    sf.Dispose();
                }
            }

        }
    }
}

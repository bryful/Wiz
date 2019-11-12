using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace WizEdit
{
    public partial class WizMainForm : Form
    {
        public WizMainForm()
        {
            InitializeComponent();
        }
        protected override void InitLayout()
        {
            this.BackColor = Color.Black;
        }
        protected override void OnPaint(PaintEventArgs e)
        {
            base.OnPaint(e);
            Graphics g = e.Graphics;
            SolidBrush sb = new SolidBrush(this.BackColor);
            g.FillRectangle(sb, this.Bounds);
        }
    }
}

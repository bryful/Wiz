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
    public partial class WizForm : Form
    {
        private WizBox wb = new WizBox();
        private WizBox wbCap = new WizBox();
        private string m_Caption = "Wizardry FC State File Editor";
        private WizNesState m_state = null;
        public WizNesState WizNesState
        {
            get { return m_state; }
            set { m_state = value; }
        }
        private WizCharList m_CharList = null;
        public WizCharList WizCharList
        {
            get { return m_CharList; }
            set { m_CharList = value; }
        }
        public WizForm()
        {
            InitializeComponent();
            wb.Rectangle = this.ClientRectangle;
            wb.TopMargin = 50;

            wbCap.Size = new Size(220, 40);
        }
        protected override void InitLayout()
        {
            base.InitLayout();
            this.ForeColor = Color.White;
            this.BackColor = Color.Black;
        }
        // *****************************************************************************
        public void CapSize()
        {
            wb.Rectangle = this.ClientRectangle;
            wbCap.Left = this.ClientSize.Width / 2 - wbCap.Width / 2;
            wbCap.Top = wb.Top + wb.TopMargin - wbCap.Height/2;
            this.Text = this.ClientRectangle.ToString();
        }
        // *****************************************************************************
        protected override void OnPaint(PaintEventArgs e)
        {
            wb.Graphics = e.Graphics;
            wb.Back = this.BackColor;
            wb.Fore = this.ForeColor;
            wb.DrawFrame();

            wbCap.Graphics = e.Graphics;
            wbCap.Back = this.BackColor;
            wbCap.Fore = this.ForeColor;
            wbCap.DrawFrame();

            SolidBrush sb = new SolidBrush(this.ForeColor);
            StringFormat sf = new StringFormat();
            sf.Alignment = StringAlignment.Center;
            sf.LineAlignment = StringAlignment.Center;
            try
            {
                e.Graphics.DrawString(m_Caption,this.Font, sb, wbCap.Rectangle, sf);
            }finally
            {
                sb.Dispose();
                sf.Dispose();
            }
            base.OnPaint(e);


        }
        // *****************************************************************************
        protected override void OnSizeChanged(EventArgs e)
        {
            CapSize();
            base.OnSizeChanged(e);
            this.Invalidate();
        }
    }
}

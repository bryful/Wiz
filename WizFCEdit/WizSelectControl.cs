using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Drawing;
using System.Data;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace WizFCEdit
{
    public partial class WizSelectControl : WizBoxControl
    {
        private bool m_IsDisp = false;
        public bool IsDisp { get { return m_IsDisp; } }

        private ListBox m_ListBox = new ListBox();
        public WizSelectControl()
        {
            InitializeComponent();
            m_ListBox.Name = "m_ListBox";
            m_ListBox.BackColor = Color.Black;
            m_ListBox.ForeColor = Color.White;
            m_ListBox.BorderStyle = BorderStyle.None;

            SetSize();

            this.Controls.Add(m_ListBox);

            m_ListBox.Focus();
            m_ListBox.ScrollAlwaysVisible = true;
            m_ListBox.MouseDoubleClick += M_ListBox_MouseDoubleClick;
        }
        public bool IsShowScrol
        {
            get { return m_ListBox.ScrollAlwaysVisible; }
            set { m_ListBox.ScrollAlwaysVisible = value; }
        }
        public bool ListEnabled
        {
            get { return m_ListBox.Enabled; }
            set { m_ListBox.Enabled = value; }
        }
        private void M_ListBox_MouseDoubleClick(object sender, MouseEventArgs e)
        {
            this.OnMouseDoubleClick(e);
        }

        public void SetSize()
        {
            m_ListBox.Location = new Point(20, 10);
            m_ListBox.Size = new Size(this.Width - 30, this.Height - 20);
        }
        protected override void OnSizeChanged(EventArgs e)
        {
            base.OnSizeChanged(e);
            SetSize();
        }
        public void ClearItem()
        {
            m_ListBox.Items.Clear();
        }
        public void AddItem(string s)
        {
            m_ListBox.Items.Add(s);
        }
        public void SetFont(Font f)
        {
            this.Font = f;
            m_ListBox.Font = this.Font;
        }
        public int SelectedIndex
        {
            get { return m_ListBox.SelectedIndex; }
            set { m_ListBox.SelectedIndex = value; }
        }
        public void SetIsDisp(bool b)
        {
            m_IsDisp = b;
            this.Visible = b;
            if(b==true)m_ListBox.Focus();
        }
        public void SetOwnerSize(Control ctl)
        {
            this.Location = new Point(ctl.Left - 20, ctl.Top - 10);
            this.Size = new Size(ctl.Width + 40, ctl.Height * 3);
        }
    }
}

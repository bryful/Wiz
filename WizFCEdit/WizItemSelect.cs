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


namespace WizFCEdit
{
    public class WizItemSelect : ComboBox
    {
        private bool m_IsListMode = false;
        public bool IsListMode
        {
            get { return m_IsListMode; }
            set { m_IsListMode = value; }
        }
        public int ItemID
        {
            get { return SelectedIndex; }
            set { SelectedIndex = value; }
        }

        public WizItemSelect()
        {
            this.ForeColor = Color.White;
            this.BackColor = Color.Black;
            this.DropDownStyle = ComboBoxStyle.DropDownList;
            this.FlatStyle = FlatStyle.Flat;
        }
        protected override void OnMouseDown(MouseEventArgs e)
        {
            base.OnMouseDown(e);
            if (m_IsListMode == true)
            {
                this.Visible = false;
            }
        }
        protected override void OnSelectedIndexChanged(EventArgs e)
        {
            base.OnSelectedIndexChanged(e);
            if (m_IsListMode == true)
            {
                this.Visible = false;
            }
        }
        protected override void OnMouseUp(MouseEventArgs e)
        {
            base.OnMouseUp(e);
            if (m_IsListMode == true)
            {
                this.Visible = false;
            }
        }
        protected override void OnMouseLeave(EventArgs e)
        {
            base.OnMouseLeave(e);
            this.SelectedIndex = -1;

            if (m_IsListMode == true)
            {
                this.Visible = false;
            }
        }
        protected override void OnMouseClick(MouseEventArgs e)
        {
            base.OnMouseClick(e);
            if (m_IsListMode == true)
            {
                this.Visible = false;
            }
        }
        protected override void OnDropDownClosed(EventArgs e)
        {
            base.OnDropDownClosed(e);
            if (m_IsListMode == true)
            {
                this.Visible = false;
            }
        }
        static public void MeDelete(Control.ControlCollection cons, WizItemSelect cmb)
        {
            if (cons.Count <= 0) return;
            cons.Remove(cmb);
            cmb.Dispose();
        }
    }
}

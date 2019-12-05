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
    public class WizCharName : Control
    {
        private bool m_IsEdit = true;
        public bool IsEdit { set; get; }
        private string m_CharName = "";
        private WizBox wb = new WizBox();

        public WizCharName()
        {
            this.BackColor = Color.Black;
            this.ForeColor = Color.White;
        }
        #region state
        private WizData m_state = null;
        public WizData WizNesState
        {
            get { return m_state; }
            set
            {
                m_state = value;
                if (m_state != null)
                {
                    m_state.CurrentCharChanged += M_state_ChangeCurrentChar;
                    m_state.LoadFileFinished += M_state_ValueChanged;
                    m_state.ValueChanged += M_state_ValueChanged;
                }
                GetInfo();
            }
        }
        private void M_state_ValueChanged(object sender, EventArgs e)
        {
            GetInfo();
        }
        private void M_state_ChangeCurrentChar(object sender, CurrentCharEventArgs e)
        {
            GetInfo();
        }
        #endregion
        // *************************************************************************
        public void GetInfo()
        {
            if(m_state!=null)
            {
                m_CharName = m_state.CharName;
                this.Invalidate();
            }
        }
        // *************************************************************************
        protected override void OnPaint(PaintEventArgs e)
        {
            //base.OnPaint(e);
            SolidBrush sb = new SolidBrush(this.BackColor);
            StringFormat sf = new StringFormat();
            sf.Alignment = StringAlignment.Near;
            sf.LineAlignment = StringAlignment.Center;
            try
            {
                Rectangle rct = new Rectangle();
                Graphics g = e.Graphics;
                g.FillRectangle(sb, this.ClientRectangle);
                rct = new Rectangle(0, 0, this.Width, this.Height);
                sb.Color = this.ForeColor;
                g.DrawString(m_CharName, this.Font, sb, rct, sf);
            }
            finally
            {
                sb.Dispose();
            }
        }
        protected override void OnMouseDown(MouseEventArgs e)
        {
            base.OnMouseDown(e);
            if (m_IsEdit == true) EditShow();
        }
        public void EditShow()
        {
            if (m_state == null) return;
            if (m_IsEdit == false) return;
            WizCharNameEdit dlg = new WizCharNameEdit();
            dlg.SCN = m_state.SCN;
            dlg.CharNameCode = m_state.CharNameCode;
            dlg.Names = m_state.CharNamesWithOutCurrent;
            if (dlg.ShowDialog() == DialogResult.OK)
            {
                m_state.CharNameCode = dlg.CharNameCode;
            }
        }
    }
}

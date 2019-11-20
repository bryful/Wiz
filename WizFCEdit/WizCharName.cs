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
    public class WizCharName : Control
    {
        private string m_CharName = "";
        private byte[] m_CharNameCode = new byte[0];
        private WizBox wb = new WizBox();
        private bool m_IsEditMode = false;
        public bool IsEditMode
        {
            get { return m_IsEditMode; }
            set
            {
                if(value==true)
                {
                    EditModeON();
                }
                else
                {
                    EditModeOFF();
                }
            }
        }
        private Point m_OrgLoc = new Point();
        private Size m_OrgSize = new Size();
        private Size m_OrgMax = new Size();
        private Size m_OrgMin = new Size();

        private Point m_DispOffset = new Point(10, 10);

        private Size m_EditSize = new Size(200, 300);

        public WizCharName()
        {
            this.BackColor = Color.Black;
            this.ForeColor = Color.White;
            this.Size = new Size(200, 20);
            //this.MaximumSize = new Size(0, 20);
            //this.MinimumSize = new Size(0, 20);
        }
        #region state
        private WizFCState m_state = null;
        public WizFCState WizNesState
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
                m_CharNameCode = m_state.CharNameCode;
                this.Invalidate();
            }
        }
        // *************************************************************************
        public void EditModeON()
        {
            if (m_IsEditMode == true) return;
            m_IsEditMode = true;
            m_OrgLoc = this.Location;
            m_OrgSize = this.Size;
            m_OrgMax = this.MaximumSize;
            m_OrgMin = this.MinimumSize;
            this.MaximumSize = m_EditSize;
            this.MinimumSize = m_EditSize;
            this.Size = m_EditSize;
            this.Location = new Point(this.Location.X - m_DispOffset.X, this.Location.Y - m_DispOffset.Y);

            this.BringToFront();
            this.Invalidate();

        }
        public void EditModeOFF()
        {
            if (m_IsEditMode == false) return;
            m_IsEditMode = false;
            this.MaximumSize = m_OrgMax;
            this.MinimumSize = m_OrgMin;
            this.Location = m_OrgLoc;
            this.Size = m_OrgSize;
            this.Invalidate();
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

                if(m_IsEditMode)
                {
                    wb.Graphics = g;
                    wb.Size = this.Size;
                    wb.DrawFrame();
                }
                else
                {
                }
                if(m_IsEditMode)
                {
                    rct = new Rectangle(m_DispOffset.X, m_DispOffset.X, m_OrgSize.Width, m_OrgSize.Height);
                }
                else
                {
                    rct = new Rectangle(0, 0, this.Width, this.Height);

                }
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
            if (m_IsEditMode)
            {
                EditModeOFF();
            }
            else
            {
                EditModeON();
            }
        }
    }
}

using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace WizFCEdit
{
    public class WizCharClass :Control
    {
        public bool IsEditAlg = true;
        public bool IsEditClass = true;
        public bool IsEditRace = true;

        private WIZALG m_Alg = WIZALG.GOOD;
        private WIZCLASS m_Class = WIZCLASS.FIG;
        private WIZRACE m_Race = WIZRACE.HUMAN;

        private int m_AlgWidth = 25;
        public int AlgWidth
        {
            get { return m_AlgWidth; }
            set
            {
                if (m_AlgWidth != value)
                {
                    m_AlgWidth = value;
                    this.Invalidate();
                }
            }
        }
        private int m_ClassWidth = 35;
        public int ClassWidth
        {
            get { return m_ClassWidth; }
            set
            {
                if (m_ClassWidth != value)
                {
                    m_ClassWidth = value;
                    this.Invalidate();
                }
            }
        }
        private int m_RaceWidth = 50;
        public int RaceWidth
        {
            get { return m_RaceWidth; }
            set
            {
                if (m_RaceWidth != value)
                {
                    m_RaceWidth = value;
                    this.Invalidate();
                }
            }
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
                    GetInfo();
                    this.Invalidate();
                }
            }
        }

        private void M_state_ValueChanged(object sender, EventArgs e)
        {
            GetInfo();
            this.Invalidate();
        }
        private void M_state_ChangeCurrentChar(object sender, CurrentCharEventArgs e)
        {
            GetInfo();
            this.Invalidate();
        }
        #endregion

        private void GetInfo()
        {
            if (m_state == null) return;
            m_Alg = m_state.CharAlg;
            m_Class = m_state.CharClass;
            m_Race = m_state.CharRace;
        }
        private void SetInfo()
        {
            if (m_state == null) return;
            if (IsEditAlg) m_state.CharAlg = m_Alg;
            if (IsEditClass) m_state.CharClass = m_Class;
            if (IsEditRace) m_state.CharRace = m_Race;
        }


        // ******************************************************************
        public WizCharClass()
        {
            this.ForeColor = Color.White;
            this.BackColor = Color.Black;
        }
        // ******************************************************************
        protected override void OnPaint(PaintEventArgs e)
        {
            //base.OnPaint(e);
            SolidBrush sb = new SolidBrush(this.BackColor);
            StringFormat sf = new StringFormat();
            sf.Alignment = StringAlignment.Near;
            sf.LineAlignment = StringAlignment.Center;
            Graphics g = e.Graphics;
            try
            {
                g.FillRectangle(sb, this.ClientRectangle);
                sb.Color = this.ForeColor;
                Rectangle rct = new Rectangle(0, 0, m_AlgWidth, this.Height);
                g.DrawString(WizFCState.AlgString(m_Alg)[0]+"-", this.Font,sb, rct, sf);
                rct = new Rectangle(m_AlgWidth,0,m_ClassWidth,this.Height);
                g.DrawString(WizFCState.ClassString(m_Class), this.Font, sb, rct, sf);
                rct = new Rectangle(m_AlgWidth+m_ClassWidth, 0, m_RaceWidth, this.Height);
                g.DrawString(WizFCState.RaceString(m_Race), this.Font, sb, rct, sf);
            }
            finally
            {
                sb.Dispose();
                sf.Dispose();
            }

        }
        // ******************************************************************
        protected override void OnMouseDown(MouseEventArgs e)
        {
            base.OnMouseDown(e);
            int x = e.X;
            if (x < m_AlgWidth)
            {
                if (IsEditAlg)
                {
                    WizComboBox cmb = new WizComboBox();
                    int ox = cmb.OffsetPoint.X;
                    int oy = cmb.OffsetPoint.Y;
                    cmb.Name = "A";
                    cmb.Location = new Point(this.Left - ox, this.Top - oy);
                    cmb.Size = new Size(100, this.Height * 3);
                    for (int i = 0; i < WizFCState.AlgStr.Length; i++)
                    {
                        cmb.Add(WizFCState.AlgString((WIZALG)i));
                    }
                    cmb.SelectedIndex = (int)m_Alg;
                    cmb.IsListMode = true;
                    cmb.VisibleChanged += Cmb_VisibleChanged;
                    this.Parent.Controls.Add(cmb);
                    cmb.BringToFront();
                    cmb.Visible = true;
                }
            }else if(x< (m_AlgWidth+ m_ClassWidth))
            {
                if (IsEditClass)
                {
                    WizComboBox cmb = new WizComboBox();
                    int ox = cmb.OffsetPoint.X;
                    int oy = cmb.OffsetPoint.Y;
                    cmb.Name = "A";
                    cmb.Location = new Point(this.Left - ox + m_AlgWidth, this.Top - oy);
                    cmb.Size = new Size(55, this.Height * 3);
                    for (int i = 0; i < WizFCState.ClassStr.Length; i++)
                    {
                        cmb.Add(WizFCState.ClassString((WIZCLASS)i));
                    }
                    cmb.SelectedIndex = (int)m_Class;
                    cmb.IsListMode = true;
                    cmb.VisibleChanged += Cmb_VisibleChanged2;
                    this.Parent.Controls.Add(cmb);
                    cmb.BringToFront();
                    cmb.Visible = true;
                }
            }else if (x < (m_AlgWidth + m_ClassWidth+m_RaceWidth))
            {
                if (IsEditRace)
                {
                    WizComboBox cmb = new WizComboBox();
                    int ox = cmb.OffsetPoint.X;
                    int oy = cmb.OffsetPoint.Y;
                    cmb.Name = "A";
                    cmb.Location = new Point(this.Left - ox + m_AlgWidth + m_ClassWidth, this.Top - oy);
                    cmb.Size = new Size(70, this.Height * 5);
                    for (int i = 0; i < WizFCState.RaceStr.Length; i++)
                    {
                        cmb.Add(WizFCState.RaceString((WIZRACE)i));
                    }
                    cmb.SelectedIndex = (int)m_Race;
                    cmb.IsListMode = true;
                    cmb.VisibleChanged += Cmb_VisibleChanged3;
                    this.Parent.Controls.Add(cmb);
                    cmb.BringToFront();
                    cmb.Visible = true;
                }
            }

        }

        private void Cmb_VisibleChanged(object sender, EventArgs e)
        {
            WizComboBox w = (WizComboBox)sender;
            if (w.SelectedIndex >= 0) {
                WIZALG r = (WIZALG)w.SelectedIndex;
                if(m_Alg!=r)
                {
                    m_Alg = r;
                    SetInfo();
                    this.Invalidate();
                }
            }
            WizComboBox.MeDelete(this.Parent.Controls, w);
        }
        private void Cmb_VisibleChanged2(object sender, EventArgs e)
        {
            WizComboBox w = (WizComboBox)sender;
            if (w.SelectedIndex >= 0)
            {
                WIZCLASS r = (WIZCLASS)w.SelectedIndex;
                if (m_Class != r)
                {
                    m_Class = r;
                    SetInfo();
                    this.Invalidate();
                }
            }
            WizComboBox.MeDelete(this.Parent.Controls, w);
        }
        private void Cmb_VisibleChanged3(object sender, EventArgs e)
        {
            WizComboBox w = (WizComboBox)sender;
            if (w.SelectedIndex >= 0)
            {
                WIZRACE r = (WIZRACE)w.SelectedIndex;
                if (m_Race != r)
                {
                    m_Race = r;
                    SetInfo();
                    this.Invalidate();
                }
            }
            WizComboBox.MeDelete(this.Parent.Controls, w);
        }
    }
}

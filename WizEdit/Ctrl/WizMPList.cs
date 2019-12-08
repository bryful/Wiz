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
    public class WizMPList : Control
    {
        private bool refFlag = false; 

        public bool IsEdit
        {
            get { return m_mag[0].IsEdit; }
            set
            {
                if (IsEdit == value) return;

                for (int i=0;i<7;i++)
                {
                    m_mag[i].IsEdit = value;
                    m_pri[i].IsEdit = value;
                }
                //m_MP9.Enabled = value;
                //m_MP9.Visible = value;
            }
        }
        /*
        public bool IsEditSpell
        {
            get { return m_Edit.Enabled; }
            set
            {
                m_Edit.Enabled = value;
                m_Edit.Visible = value;
            }
        }
        */
        private MagicPoint m_magic = new MagicPoint();
        private MagicPoint m_priest = new MagicPoint();

        private Label m_lbMag = new Label();
        private Label m_lbPri = new Label();

        private WizMPEdit[] m_mag = new WizMPEdit[7];
        private WizMPEdit[] m_pri = new WizMPEdit[7];


        //WizButton m_Edit = new WizButton();
        //WizButton m_MP9 = new WizButton();

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
                    m_state.LoadFileFinished += M_state_FinishedLoadFile;
                    m_state.ValueChanged += M_state_FinishedLoadFile;
                }
                GetInfo();
            }
        }
        private void M_state_FinishedLoadFile(object sender, EventArgs e)
        {
            GetInfo();
        }

        private void M_state_ChangeCurrentChar(object sender, CurrentCharEventArgs e)
        {
            GetInfo();
        }
        #endregion

        // ****************************************************************
        // ****************************************************************
        public WizMPList()
        {
            this.SetStyle(
         ControlStyles.DoubleBuffer |
         ControlStyles.UserPaint |
         ControlStyles.AllPaintingInWmPaint,
         true);
            this.ForeColor = Color.White;
            this.BackColor = Color.Black;

            int h = 22; 
            m_lbMag.Name = "M";
            m_lbMag.Text = "M";
            m_lbMag.Location = new Point(0, 0);
            m_lbMag.AutoSize = false;
            m_lbMag.Size = new Size(30, 20);
            m_lbPri.Name = "P";
            m_lbPri.Text = "P";
            m_lbPri.Location = new Point(0, h);
            m_lbPri.AutoSize = false;
            m_lbPri.Size = new Size(30, 20);

            int l = 30;
            int w = 22;
            for ( int i=0;i<7;i++)
            {
                m_mag[i] = new WizMPEdit
                {
                    Name = String.Format("Mag{0}", i)
                };
                m_mag[i] = new WizMPEdit
                {
                    Location = new Point(l, 0)
                };
                l += w;
                m_mag[i].Size = new Size(w, 20);
                m_mag[i].Tag = i;
                m_mag[i].ValueChanged += MPValueChanged;

            }
            l = 30;
            for (int i = 0; i < 7; i++)
            {
                m_pri[i] = new WizMPEdit
                {
                    Name = String.Format("Pri{0}", i)
                };
                m_pri[i] = new WizMPEdit
                {
                    Location = new Point(l, h)
                };
                l += w;
                m_pri[i].Size = new Size(w, 20);
                m_pri[i].Tag = i;
                m_pri[i].ValueChanged += MPValueChanged;
            }
            /*
            m_Edit.Name ="Edit";
            m_Edit.Text = ">>Edit Spell";
            m_Edit.Location = new Point(5, 42);
            m_Edit.Size = new Size(70, 20);
            m_Edit.IsDrawWaku = false;
            m_Edit.Click += M_Edit_Click;

            m_MP9.Name = "MPALL9";
            m_MP9.Text = "MPALL9";
            m_MP9.Location = new Point(80, 42);
            m_MP9.Size = new Size(60, 20);
            m_MP9.IsDrawWaku = false;
            m_MP9.Click += M_MP9_Click;
            */

            this.Controls.Add(m_lbMag);
            for (int i = 0; i < 7; i++)
            {
                this.Controls.Add(m_mag[i]);
            }
            this.Controls.Add(m_lbPri);
            for (int i = 0; i < 7; i++)
            {
                this.Controls.Add(m_pri[i]);
            }
            //this.Controls.Add(m_Edit);
            //this.Controls.Add(m_MP9);
        }

        private void M_MP9_Click(object sender, EventArgs e)
        {
            if (m_state != null)
            {
                for (int i = 0; i < 7; i++)
                {
                    m_mag[i].Value = 9;
                    m_pri[i].Value = 9;
                }
                SetInfo();
            }
        }
        private void M_Edit_Click(object sender, EventArgs e)
        {
            if (m_state == null) return;
            WizSpellEditDialogcs dlg = new WizSpellEditDialogcs();
            if(dlg.EditShowDialog(m_state))
            {
                m_state.CharSpell = dlg.Spell;
            }
        }

        private void MPValueChanged(object sender, EventArgs e)
        {
            SetInfo();
        }

        // *************************************************************************
        public void GetInfo()
        {
            if (refFlag == true) return;
            if (m_state != null)
            {
                m_magic = m_state.CharMagic;
                m_priest = m_state.CharPriest;
                DataToCntrol();
                this.Invalidate();
            }

        }
        // *************************************************************************
        public void SetInfo()
        {
            if (refFlag == true) return;
            if (m_state != null)
            {
                for (int i = 0; i < 7; i++)
                {
                    m_magic.NowP[i] = (byte)m_mag[i].Value;
                    m_magic.MaxP[i] = (byte)m_mag[i].Value;
                    m_priest.NowP[i] = (byte)m_pri[i].Value;
                    m_priest.MaxP[i] = (byte)m_pri[i].Value;
                }
                m_state.CharMagic = m_magic;
                m_state.CharPriest = m_priest;
            }

        }
        // *************************************************************************
        private void DataToCntrol()
        {
            refFlag = true;
            for (int i=0; i<7;i++)
            {
                m_mag[i].Value = m_magic.MaxP[i];
                m_pri[i].Value = m_priest.MaxP[i];
            }
            refFlag = false;
        }
        // *************************************************************************
    }
}

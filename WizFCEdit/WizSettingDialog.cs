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
    public partial class WizSettingDialog : Form
    {
        private WizLimit m_Limit = new WizLimit();
        private CheckBox[] m_cb = new CheckBox[(int)WizLimit.P.Count];

        public WIZSCN SCN
        {
            get { return (WIZSCN)(cmbSCN.SelectedIndex + 1); }
            set { cmbSCN.SelectedIndex = (int)value - 1; }
        }

        public WizSettingDialog()
        {
            InitializeComponent();

            #region cb
            m_cb[0] = cb0;
            m_cb[1] = cb1;
            m_cb[2] = cb2;
            m_cb[3] = cb3;
            m_cb[4] = cb4;
            m_cb[5] = cb5;
            m_cb[6] = cb6;
            m_cb[7] = cb7;
            m_cb[8] = cb8;
            m_cb[9] = cb9;
            m_cb[10] = cb10;
            m_cb[11] = cb11;
            m_cb[12] = cb12;
            m_cb[13] = cb13;
            m_cb[14] = cb14;
            m_cb[15] = cb15;
            m_cb[16] = cb16;
            m_cb[17] = cb17;
            m_cb[18] = cb18;
            m_cb[19] = cb19;
            #endregion

            for (int i = 0; i < (int)WizLimit.P.Count; i++)
            {
                m_cb[i].Click += WizSettingDialog_Click;
            }

            cbLevelInit.Click += CbLevelInit_Click;
        }

        private void CbLevelInit_Click(object sender, EventArgs e)
        {
            m_Limit.LevelInit = cbLevelInit.Checked;
        }

        private void WizSettingDialog_Click(object sender, EventArgs e)
        {
            for (int i = 0; i < (int)WizLimit.P.Count; i++)
            {
                m_Limit.Values[i] = m_cb[i].Checked;
            }

        }
        public WizLimit WizLimit
        {
            get
            {
                WizLimit ret = new WizLimit();
                ret.CopyFrom(m_Limit);
                return ret;
            }
            set
            {
                m_Limit.CopyFrom(value);
                for (int i = 0; i < (int)WizLimit.P.Count; i++)
                {
                    m_cb[i].Checked = m_Limit.Values[i];
                    cbLevelInit.Checked = m_Limit.LevelInit; 
                }
            }
        }
    }
}

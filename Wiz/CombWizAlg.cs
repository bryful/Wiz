using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using System.IO;

namespace WizEdit
{
    public class CombWizAlg : ComboBox
    {
        private WIZALG m_Alg = WIZALG.GOOD;
        public CombWizAlg()
        {
            this.DropDownStyle = ComboBoxStyle.DropDownList;
            this.SelectedIndexChanged += CombWizRace_SelectedIndexChanged;
        }

        private void CombWizRace_SelectedIndexChanged(object sender, EventArgs e)
        {
            int s = SelectedIndex;
            if (s < 0) s = 0;
            m_Alg = (WIZALG)s;
        }

        protected override void InitLayout()
        {
            base.InitLayout();
            this.Items.Clear();
            this.Items.AddRange(WizNesState.AlgStr);
            m_Alg = WIZALG.GOOD;
            this.SelectedIndex = 0;
            //this.Enabled = false;
        }
        public WIZALG Alg
        {
            get { return m_Alg; }
            set
            {
                int v = (int)value;
                if (this.Items.Count > 0)
                {
                    if (SelectedIndex != v)
                    {
                        SelectedIndex = v;
                    }
                }
                m_Alg = value;
            }
        }
    }
}

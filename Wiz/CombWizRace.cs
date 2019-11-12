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
    public class CombWizRace : ComboBox
    {
        private WIZRACE m_Race = WIZRACE.HUMAN;
        public CombWizRace()
        {
            this.DropDownStyle = ComboBoxStyle.DropDownList;
            this.SelectedIndexChanged += CombWizRace_SelectedIndexChanged;
        }

        private void CombWizRace_SelectedIndexChanged(object sender, EventArgs e)
        {
            int s = SelectedIndex;
            if (s < 0) s = 0;
            m_Race = (WIZRACE)s;
        }

        protected override void InitLayout()
        {
            base.InitLayout();
            this.Items.Clear();
            this.Items.AddRange(WizNesState.RaceStr);
            m_Race = WIZRACE.HUMAN;
            this.SelectedIndex = 0;
            //this.Enabled = false;
        }
        public WIZRACE Race
        {
            get { return m_Race; }
            set
            {
                if (SelectedIndex != (int)value)
                {
                    SelectedIndex = (int)value;
                    m_Race = value;
                }
            }
        }

    }
}
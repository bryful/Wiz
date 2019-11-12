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
        private RACE m_Race = RACE.HUMAN;
        public CombWizRace()
        {
            this.DropDownStyle = ComboBoxStyle.DropDownList;
            this.SelectedIndexChanged += CombWizRace_SelectedIndexChanged;
        }

        private void CombWizRace_SelectedIndexChanged(object sender, EventArgs e)
        {
            int s = SelectedIndex;
            if (s < 0) s = 0;
            m_Race = (RACE)s;
        }

        protected override void InitLayout()
        {
            base.InitLayout();
            this.Items.Clear();
            this.Items.AddRange(WizNesState.RaceStr);
            m_Race = RACE.HUMAN;
            this.SelectedIndex = 0;
            //this.Enabled = false;
        }
        public RACE Race
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
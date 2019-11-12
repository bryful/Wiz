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
    public class CombWizJob : ComboBox
    {
        private JOB m_Job = JOB.FIG;
        public CombWizJob()
        {
            this.DropDownStyle = ComboBoxStyle.DropDownList;
            this.SelectedIndexChanged += CombWizRace_SelectedIndexChanged;
        }

        private void CombWizRace_SelectedIndexChanged(object sender, EventArgs e)
        {
            int s = SelectedIndex;
            if (s < 0) s = 0;
            m_Job = (JOB)s;
        }

        protected override void InitLayout()
        {
            base.InitLayout();
            this.Items.Clear();
            this.Items.AddRange(WizNesState.JobStr);
            m_Job = JOB.FIG;
            this.SelectedIndex = 0;
            //this.Enabled = false;
        }
        public JOB Job
        {
            get { return m_Job; }
            set
            {
                if (SelectedIndex != (int)value)
                {
                    SelectedIndex = (int)value;
                    m_Job = value;
                }
            }
        }

    }
}
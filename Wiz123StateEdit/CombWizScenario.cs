using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Drawing;
using System.Data;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;


namespace Wiz123StateEdit
{
    public class CombWizScenario : ComboBox
    {
		bool refFlag = false;
       private Snes9xWiz123SFC m_wiz123sfc = null;
        public event EventHandler ScenarioChanged;
        public CombWizScenario()
        {
            DropDownStyle = ComboBoxStyle.DropDownList;
            FormattingEnabled = true;
            Items.Clear();
            Items.AddRange(new object[] {
                "WIZ1_Proving_Grounds_of_the_Mad_Overlord",
                "WIZ2_Legacy_of_Llylgamyn",
                "WIZ3_Knight_of_Diamonds"
                    });
            SelectedIndex = 0;
            MaxDropDownItems = 3;
            BackColor = Color.Black;
            FlatStyle = FlatStyle.Flat;
            this.Font = new Font("ＭＳ ゴシック", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(128)));
            ForeColor = System.Drawing.Color.White;

            SelectedIndexChanged += CombWizScenario_SelectedIndexChanged;
        }
        //------------------------------------------------------------------
        private void CombWizScenario_SelectedIndexChanged(object sender, EventArgs e)
        {
			if (refFlag ==true) return;
            OnScenarioChanged(EventArgs.Empty);
            if (m_wiz123sfc!=null)
            {
                m_wiz123sfc.Scenario = Senario;

            }
        }
        //---------------------------------------
        protected virtual void OnScenarioChanged(EventArgs e)
        {
            if (ScenarioChanged != null)
            {
                ScenarioChanged(this, e);
            }
        }
        public SCENARIO Senario
        {
            get {
                if (Items.Count > 0)
                {
                    return (SCENARIO)SelectedIndex;
                }
                else
                {
                    return SCENARIO.WIZ1_Proving_Grounds_of_the_Mad_Overlord;
                }
            }
            set
            {
                if (Items.Count>0)
                {
					bool bak = refFlag;
					refFlag = true;
					SelectedIndex = (int)value;
					refFlag = false;
				}
			}
        }
        public Snes9xWiz123SFC Wiz123SFC
        {
            get { return m_wiz123sfc; }
            set
            {
                m_wiz123sfc = value;
                if (m_wiz123sfc!=null)
                {
                    Items.Clear();
                    Items.AddRange(new object[] {
                "WIZ1_Proving_Grounds_of_the_Mad_Overlord",
                "WIZ2_Legacy_of_Llylgamyn",
                "WIZ3_Knight_of_Diamonds"
                    });
					bool bak = refFlag;
					refFlag = true;
                    SelectedIndex = 0;
					refFlag = false;

				}
			}
        }


    }
}

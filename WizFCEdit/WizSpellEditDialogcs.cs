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
    public partial class WizSpellEditDialogcs : Form
    {
        public byte[] Spell
        {
            get { return wizSpellList1.Spell; }
            set { wizSpellList1.Spell = value; }
        }
        public WIZ_SCN SCN
        {
            get { return wizSpellList1.SCN; }
            set { wizSpellList1.SCN = value; }
        }

        public WizSpellEditDialogcs()
        {
            InitializeComponent();
            this.StartPosition = FormStartPosition.CenterParent;
        }

        public bool EditShowDialog(WizFCState state)
        {
            bool ret = false;
            if (state == null) return ret;

            this.Spell = state.CharSpell;
            this.SCN = state.SCN;

            return (this.ShowDialog() == DialogResult.OK);


        }

        private void btnForgetAll_Click(object sender, EventArgs e)
        {
            wizSpellList1.ForgetALL();
        }

        private void btnGetAll_Click(object sender, EventArgs e)
        {
            wizSpellList1.GetALL();
        }
    }
}

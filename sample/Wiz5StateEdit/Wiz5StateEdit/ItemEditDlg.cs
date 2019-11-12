using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace Wiz5StateEdit
{
    public partial class ItemEditDlg : Form
    {
        public ItemEditDlg()
        {
            InitializeComponent();
        }

        private void ItemEditDlg_Load(object sender, EventArgs e)
        {

        }
        //--------------------------------------------------------------
        public void SetItems(string[] a,int si=0)
        {
            comboBox1.Items.Clear();
            for (int i = 0; i < a.Length; i++)
            {
                comboBox1.Items.Add(a[i]);
            }
            comboBox1.SelectedIndex = si;
            label1.Text = a[si];

        }
        //--------------------------------------------------------------
        public int SelectedIndex
        {
            get { return comboBox1.SelectedIndex; }
        }
    }
}

using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace Wiz123StateEdit
{
    public partial class Form2 : Form
    {
        private string m_path = "";
        private string cap = "ウィザードリィⅠ・Ⅱ・Ⅲ Snes9x State data Edit";
        public Form2()
        {
            InitializeComponent();
            chrItemList1.Wiz123SFC = snes9xWiz123SFC1;
            chrMPCount1.Wiz123sfc = snes9xWiz123SFC1;
            chrLV.Wiz123sfc = snes9xWiz123SFC1;
            chrChikara.Wiz123sfc = snes9xWiz123SFC1;
            shopList1.Wiz123sfc = snes9xWiz123SFC1;
        }
        private void Form2_DragDrop(object sender, DragEventArgs e)
        {

            string[] fileName = (string[])e.Data.GetData(DataFormats.FileDrop, false);

            LoadSnes9x(fileName[0]);

        }

        private void Form2_DragEnter(object sender, DragEventArgs e)
        {
            if (e.Data.GetDataPresent(DataFormats.FileDrop))
                //ドラッグされたデータ形式を調べ、ファイルのときはコピーとする
                e.Effect = DragDropEffects.Copy;
            else
                //ファイル以外は受け付けない
                e.Effect = DragDropEffects.None;
        }
        private void LoadSnes9x(string p)
        {
            bool b = false;
            //saveToolStripMenuItem.Enabled = b;
            b = snes9xWiz123SFC1.Load(p);
            if (b)
            {
                m_path = p;
                this.Text = p;
            }
            else
            {
                this.Text = cap;
            }
            //saveToolStripMenuItem.Enabled = b;

        }

    }
}

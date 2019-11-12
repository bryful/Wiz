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
    public partial class Form1 : Form
    {
        private string m_path="";
        private string cap = "ウィザードリィⅤ 災禍の中心 Snes9x State data Edit";
        public Form1()
        {
            InitializeComponent();
            this.Text = cap;
        }


        private void Form1_DragDrop(object sender, DragEventArgs e)
        {

            string[] fileName =(string[])e.Data.GetData(DataFormats.FileDrop, false);

            LoadSnes9x(fileName[0]);

        }

        private void Form1_DragEnter(object sender, DragEventArgs e)
        {
            if (e.Data.GetDataPresent(DataFormats.FileDrop))
                //ドラッグされたデータ形式を調べ、ファイルのときはコピーとする
                e.Effect = DragDropEffects.Copy;
            else
                //ファイル以外は受け付けない
                e.Effect = DragDropEffects.None;
        }

        private void openToolStripMenuItem_Click(object sender, EventArgs e)
        {
            OpenFileDialog ofd = new OpenFileDialog();

            ofd.FileName = m_path;
            if (m_path == "")
            {
                ofd.InitialDirectory = System.Environment.GetFolderPath(Environment.SpecialFolder.Personal);
            }
            ofd.Title = "Open SFC Wizardry5 State Data File";
            ofd.RestoreDirectory = true;

            if (ofd.ShowDialog() == DialogResult.OK)
            {
                LoadSnes9x(ofd.FileName);
            }
        }
        private void LoadSnes9x(string p)
        {
            bool b = false;
            saveToolStripMenuItem.Enabled = b;
            b = snes9xWizFive1.Load(p);
            if (b)
            {
                m_path = p;
                this.Text = p;
            }
            else
            {
                this.Text = cap;
            }
            saveToolStripMenuItem.Enabled = b;

        }


        private void saveToolStripMenuItem_Click(object sender, EventArgs e)
        {
            snes9xWizFive1.State.Save();
        }
    }
}

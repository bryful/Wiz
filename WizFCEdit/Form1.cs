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

using BRY;

using Codeplex.Data;
/// <summary>
/// 基本となるアプリのスケルトン
/// </summary>
namespace WizEdit
{
    public partial class Form1 : WizForm
    {
        public string TTitle = "Wizardry (FC) Editor";
 
        //-------------------------------------------------------------
        /// <summary>
        /// コンストラクタ
        /// </summary>
        public Form1()
        {
            InitializeComponent();

            this.KeyPreview = true;
            this.Text = TTitle;
        }



        // ***************************************************************
        private void M_state_FinishedLoadFile(object sender, EventArgs e)
        {
        }
        // ***************************************************************
        private void M_state_ChangeCurrentChar(object sender, CurrentCharEventArgs e)
        {
            //combWizAlg1.Alg =
        }
        // ***************************************************************

        /// <summary>
        /// コントロールの初期化はこっちでやる
        /// </summary>
        protected override void InitLayout()
        {
            base.InitLayout();
        }
        //-------------------------------------------------------------
        /// <summary>
        /// フォーム作成時に呼ばれる
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void Form1_Load(object sender, EventArgs e)
        {
            //設定ファイルの読み込み
            JsonPref pref = new JsonPref();
            if (pref.Load())
            {
                bool ok = false;
                Point p = pref.GetPoint("Point", out ok);
                if (ok) this.Location = p;
                bool[] wl = pref.GetBoolArray("WizLimit",out ok);
                this.LimitValues = wl;
                string s = pref.GetString("PictureFolder", out ok);
                if(ok)
                {
                    if (System.IO.Directory.Exists(s)==true)
                    {
                        wizPictureBox1.PicureFolderPath = s;
                    }
                }

            }
           // this.Text = Path.GetFileNameWithoutExtension(Application.ExecutablePath);
        }
        //-------------------------------------------------------------
        /// <summary>
        /// フォームが閉じられた時
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void Form1_FormClosed(object sender, FormClosedEventArgs e)
        {
            //設定ファイルの保存
            JsonPref pref = new JsonPref();
            pref.SetPoint("Point", this.Location);
            pref.SetBoolArray("WizLimit", this.LimitValues);
            pref.SetString("PictureFolder", wizPictureBox1.PicureFolderPath);
            pref.Save();

        }
        //-------------------------------------------------------------
        /// <summary>
        /// ドラッグ＆ドロップの準備
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void Form1_DragEnter(object sender, DragEventArgs e)
        {
            if (e.Data.GetDataPresent(DataFormats.FileDrop))
            {
                e.Effect = DragDropEffects.All;
            }
            else
            {
                e.Effect = DragDropEffects.None;
            }
        }
        /// <summary>
        /// ドラッグ＆ドロップの本体
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void Form1_DragDrop(object sender, DragEventArgs e)
        {
            string[] files = (string[])e.Data.GetData(DataFormats.FileDrop, false);
            //ここでは単純にファイルをリストアップするだけ
            GetCommand(files);
        }
        //-------------------------------------------------------------
        /// <summary>
        /// ダミー関数
        /// </summary>
        /// <param name="cmd"></param>
        public void GetCommand(string[] cmd)
        {
            if (cmd.Length > 0)
            {
                foreach (string s in cmd)
                {
                    if (LoadFile(s) == true) break;
                }                
            }
        }
        /// <summary>
        /// メニューの終了
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        //-------------------------------------------------------------
        private void quitToolStripMenuItem_Click(object sender, EventArgs e)
        {
            Application.Exit();
        }

        private void aboutToolStripMenuItem_Click(object sender, EventArgs e)
        {
            AppInfoDialog.ShowAppInfoDialog();
        }

        /// <summary>
        /// Stateファイルを読み込む
        /// </summary>
        /// <param name="p"></param>
        /// <returns></returns>
        public bool LoadFile(string p)
        {
            return wizNesState1.LoadFile(p);
        }
        public void OpenSelectDialog()
        {
        }
 
        private void wizNameBox1_Click(object sender, EventArgs e)
        {
            OpenSelectDialog();
        }

        private void btnSetting_Click(object sender, EventArgs e)
        {
            this.ShowSettings();
        }

        private void btnUp_Click(object sender, EventArgs e)
        {
            CharCurrentDataUp();
        }

        private void btnDown_Click(object sender, EventArgs e)
        {
            CharCurrentDataDown();
        }

        private void openToolStripMenuItem_Click(object sender, EventArgs e)
        {
            if(WizFCState!=null)
            {
                if (WizFCState.LoadFile()==true)
                {
                    this.Text = WizFCState.DataPath;
                }
            }
        }

        private void saveToolStripMenuItem_Click(object sender, EventArgs e)
        {
            if (WizFCState != null)
            {
                if (WizFCState.FileMode==FILEMODE.ROM)
                {
                    if(File.Exists(WizFCState.DataPath)==true)
                    {
                        MessageBox.Show("ROMモードの時は上書き禁止です。必ず別名保存してくださいC");
                        return;
                    }
                }

                if (WizFCState.Save())
                {
                    this.Text = WizFCState.DataPath;
                }
            }
        }

        private void saveAsToolStripMenuItem_Click(object sender, EventArgs e)
        {
            if (WizFCState != null)
            {
                if (WizFCState.SaveAs())
                {
                    this.Text = WizFCState.DataPath;
                }
            }
        }

        private void settingsToolStripMenuItem_Click(object sender, EventArgs e)
        {
            this.ShowSettings();
        }

        private void reloadToolStripMenuItem_Click(object sender, EventArgs e)
        {
            if (WizFCState != null)
            {
                if(WizFCState.DataPath!="")
                {
                    WizFCState.Reload();
                }
            }
        }

        private void pctureFolderToolStripMenuItem_Click(object sender, EventArgs e)
        {
            string p = wizPictureBox1.PicureFolderPath;

            FolderBrowserDialog fbd = new FolderBrowserDialog();

            fbd.Description = "キャラクタアイコンのあるフォルダを指定してください。";
            if (p != "")
            {
                fbd.SelectedPath = p;
            }

            //ダイアログを表示する
            if (fbd.ShowDialog(this) == DialogResult.OK)
            {
                wizPictureBox1.PicureFolderPath = fbd.SelectedPath;
            }
        }
    }
}

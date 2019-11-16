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
 
        //-------------------------------------------------------------
        /// <summary>
        /// コンストラクタ
        /// </summary>
        public Form1()
        {
            InitializeComponent();




            this.KeyPreview = true;
            /*
            wizSelectControl1.SetIsDisp(false);
            wizSelectControl1.MouseDoubleClick += WizSelectControl1_MouseDoubleClick;
            wizSelectControl1.SetFont(wizCharList1.Font);
            */
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
                Size sz = pref.GetSize("Size", out bool ok);
                if (ok) this.Size = sz;
                Point p = pref.GetPoint("Point", out ok);
                if (ok) this.Location = p;
            }
            this.Text = Path.GetFileNameWithoutExtension(Application.ExecutablePath);
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
            pref.SetSize("Size", this.Size);
            pref.SetPoint("Point", this.Location);

            pref.SetIntArray("IntArray", new int[] { 8, 9, 7 });
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
        private void WizSelectControl1_MouseDoubleClick(object sender, MouseEventArgs e)
        {
            HideSelectControl();
        }
        public void OpenSelectDialog()
        {
            /*
            //wizSelectControl1.SetOwnerSize(wizNameBox1);
            wizSelectControl1.ClearItem();
            wizSelectControl1.AddItem("Good");
            wizSelectControl1.AddItem("Neutral");
            wizSelectControl1.AddItem("Evil");
            wizSelectControl1.SelectedIndex = 1;
            ShowSelectControl();
            */
        }
        public void ShowSelectControl()
        {
            /*
            if (wizSelectControl1.IsDisp == false)
            {
                wizSelectControl1.SetIsDisp(true);
                wizCharList1.IsActive = false;
            }
            */

        }
        public void HideSelectControl()
        {
            /*
            if (wizSelectControl1.IsDisp == true)
            {
                wizSelectControl1.SetIsDisp(false);
                wizCharList1.IsActive = true;
            }
            */
        }

        private void wizNameBox1_Click(object sender, EventArgs e)
        {
            OpenSelectDialog();
        }
       
       
    }
}

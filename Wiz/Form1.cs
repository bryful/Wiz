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
    public partial class Form1 : Form
    {
        private WizNesState m_state = new WizNesState();
        //-------------------------------------------------------------
        /// <summary>
        /// コンストラクタ
        /// </summary>
        public Form1()
        {
            InitializeComponent();
        }
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
                Size sz = pref.GetSize("Size", out ok);
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
            bool ret = false;
            ret = m_state.LoadFile(p);
            if (ret == true) DispNames();
            return ret;
        }
        public void DispNames()
        {
            listBox1.Items.Clear();
            if (m_state.SCN == WIZ_SCN.NO) return;
            listBox1.SuspendLayout();
            for ( int i=0; i<m_state. CharCount;i++)
            {
                listBox1.Items.Add(m_state.GetName(i));
            }
            listBox1.ResumeLayout();
        }
        public void DispCharData(int idx)
        {
            listBox2.Items.Clear();
            if ((idx < 0) || (idx >= 20)) return;
            byte[] data = m_state.GetCharData(idx);
            int sz = m_state.CharSize;
            if (sz <= 0) return;
            listBox2.SuspendLayout();
            for ( int i=0; i<sz; i++)
            {
                string ss = m_state.CodeToString(data[i]);
                string s = String.Format("{0:X4} {1:X2} {2}", i, data[i], ss);
                listBox2.Items.Add(s);
            }
            combWizRace1.Race = m_state.GetRace(idx);
            combWizJob1.Job = m_state.GetJob(idx);
            combWizAlg1.Alg = m_state.GetAlg(idx);
            listBox2.ResumeLayout();
        }

        private void listBox1_SelectedIndexChanged(object sender, EventArgs e)
        {
            DispCharData(listBox1.SelectedIndex);

        }
    }
}

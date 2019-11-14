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
namespace WIzSaveChk
{
    public partial class Form1 : Form
    {
        private byte[] m_save = new byte[0];
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
                    if (LoadFile(s)==true)
                    {
                        DispSave();
                        break;
                    }
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
        public bool LoadFile(string p)
        {
            bool ret = false;
            if (File.Exists(p) == false) return ret;
            FileStream fs = new FileStream(p, FileMode.Open, FileAccess.Read);
            try
            {
                int fsize = (int)fs.Length;
                m_save = new byte[fsize];
                int sz = fs.Read(m_save, 0, fsize);
                ret = (sz == fsize);
            }
            finally
            {
                fs.Close();
            }
            if (ret == false)
            {
                m_save = new byte[0];
            }
            return ret;
        }
        public void DispSave()
        {
            listBox1.Items.Clear();
            if (m_save.Length <= 0x80) return;
            for ( int i=0;i<0x80;i++)
            {
                string s = String.Format("{0:X4} - {1:X2}", i, m_save[i]);
                listBox1.Items.Add(s);
            }
            AddShort();

        }
        public void AddByte()
        {
            edAddByte.Text = "";
            if (m_save.Length <= 0x80) return;

            int v =0;
            for ( int i=0; i<0x7E;i++)
            {
                v = v ^ (int)m_save[i];
            }
            string s = String.Format("{0:X6}", v);
            edAddByte.Text = s;

        }
        public void AddShort()
        {
            edAddByte.Text = "";
            if (m_save.Length <= 0x80) return;

            int v = 0xFFFF;
            for (int i = 0; i < 0x3F; i++)
            {
                v  = v * ( (int)m_save[i*2] + (int)m_save[i * 2+1] * 0x100);
                v = v & 0xFFFF;
            }
            string s = String.Format("{0:X6}", v);
            edAddByte.Text = s;
        }
    }
}


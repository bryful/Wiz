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
namespace WizChecksum
{
    public partial class Form1 : Form
    {
        private byte[] m_buf = new byte[0];
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
                    if(LoadSav(s)==true)
                    {
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
        private void button1_Click(object sender, EventArgs e)
        {

            JsonPref j = new JsonPref();

            int[] aaa = new int[] { 78, 9, 12 };
            double[] bbb = new double[] { 0.7, 0.01, 0.12 };
            string[] ccc = new string[] { "eee", "sfskjbF", "13" };
            j.SetIntArray("aa", aaa);
            j.SetDoubleArray("bb", bbb);
            j.SetStringArray("cc", ccc);

            MessageBox.Show(j.ToJson());

        }
        public bool LoadSav(string p)
        {
            bool ret = false;
            FileStream fs = new FileStream(p, FileMode.Open, FileAccess.Read);

            try
            {
                m_buf = new byte[fs.Length];
                int sz = fs.Read(m_buf, 0, m_buf.Length);
                ret = (sz == m_buf.Length);
                if (ret == false)
                {
                    m_buf = new byte[0];
                }
                else
                {
                    DispSav();
                }
            }
            catch
            {
                m_buf = new byte[0];
            }
            finally
            {
                fs.Close();

            }

            return ret;
        }
        public void DispSav()

        {
            listBox1.Items.Clear();
            if (m_buf.Length < 0x100) return;

            for (int i=0; i<0x100;i++)
            {
                string s = String.Format("0x{0:X2}: {1:X2}", i, m_buf[i]);
                listBox1.Items.Add(s);
            }


        }

        private void button1_Click_1(object sender, EventArgs e)
        {
            byte[] a = new byte[0x100];

            for ( int i=0;i<0x80;i++)
            {
                a[i] = m_buf[i];
            }


            ushort v =  CRC16.Calc(a, 0x7e, 0xFFFF);
            a[0x80 - 2] = (byte)((v & 0xFF00) >> 8);
            a[0x80 - 1] = (byte)((v & 0xFF));

            for (int i = 0; i < 0x80; i++)
            {
                byte jj = (byte)(a[i] ^ 0xFF);
                jj = (byte)(((jj & 0xF) << 4) | ((jj & 0xF0) >> 4));
                a[0x100 - i - 1] = jj;
            }
            listBox1.Items.Clear();

            for (int i = 0; i < 0x100; i++)
            {
                string s = String.Format("0x{0:X2}: {1:X2} {2:X2} {3}", i, m_buf[i],a[i], (m_buf[i]== a[i]));
                listBox1.Items.Add(s);
            }


        }

        private void button2_Click(object sender, EventArgs e)
        {
            int v = 0;
            for (int i = 0; i < 0x8; i++)
            {
                v = (v +(m_buf[i]^0xFF))&0xFF;
            }
            v = (v^0xFF);
            textBox1.Text = String.Format("{0:X2}", v);
        }
    }
}

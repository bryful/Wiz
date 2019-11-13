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

            //m_state.FinishedLoadFile += M_state_FinishedLoadFile;
            //m_state.ChangeCurrentChar += M_state_ChangeCurrentChar;
        }


        // ***************************************************************
        private void M_state_FinishedLoadFile(object sender, EventArgs e)
        {
            this.SuspendLayout();
            listBox2.Items.Clear();
            this.ResumeLayout();
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
        // ************************************************************************
        /*
        protected override void OnPaint(PaintEventArgs e)
        {
            base.OnPaint(e);
            SolidBrush sb = new SolidBrush(Color.Black);
            Pen p = new Pen(Color.White);
            try
            {
                Graphics g = e.Graphics;

                g.FillRectangle(sb, this.Bounds);
                int mgn = 5;
                Rectangle rct = new Rectangle(
                    mgn, mgn,
                    this.ClientSize.Width - mgn * 2,
                    this.ClientSize.Width - mgn * 2
                    );
                g.DrawRectangle(p, rct);

            }
            finally
            {
                sb.Dispose();
                p.Dispose();
            }
        }
        */
        /// <summary>
        /// Stateファイルを読み込む
        /// </summary>
        /// <param name="p"></param>
        /// <returns></returns>
        public bool LoadFile(string p)
        {
            return m_state.LoadFile(p);
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
            //combWizRace1.Race = m_state.RaceFromIndex(idx);
            //combWizJob1.Job = m_state.ClassFromIndex(idx);
            //combWizAlg1.Alg = m_state.AlgFromIndex(idx);
            listBox2.ResumeLayout();
        }
        /*
        protected override void OnPreviewKeyDown(PreviewKeyDownEventArgs e)
        {
            if (m_state != null)
            {
                if (this.Focused == true)
                {
                    if (e.KeyCode == Keys.Up) { wizCharList1.CursolUp(); }
                    else if (e.KeyCode == Keys.Down) { wizCharList1.CursolDown(); }
                }
            }
            base.OnPreviewKeyDown(e);
        }
        */
        protected override void OnKeyDown(KeyEventArgs e)
        {
            if (m_state != null)
            {
                this.Text = e.KeyCode.ToString();
                if (e.KeyCode == Keys.Up) { wizCharList1.CursolUp(); }
                else if (e.KeyCode == Keys.Down) { wizCharList1.CursolDown(); }
            }
            base.OnKeyDown(e);
        }
    }
}

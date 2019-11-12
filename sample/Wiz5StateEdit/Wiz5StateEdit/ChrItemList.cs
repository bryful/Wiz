using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Drawing;
using System.Data;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace Wiz5StateEdit
{
    public class ChrItemList :Control
    {
        /// <summary>
        /// データ
        /// </summary>
        private Snes9xWizFive m_wizFive = null;
        //アイテム状態
        private const int m_adr1 = 0x1043;
        //アイテム種類
        private const int m_adr2 = 0x104B;
        private const int m_adr3 = 0x1053;

        private ListBox listBox1 = new ListBox();
        private Button btnUp = new Button();
        private Button btnDown = new Button();

        private Button btnNOR = new Button();

        private int m_targetChr = -1;
        private int m_itemCount = 0;

        private string[] m_itemName = new string[]
            {
            "00ガラクタ",
            "01たいまつ",
            "02ランプ",
            "03ゴムのアヒル",
            "04たんとう",
            "05つえ",
            "06ショートソード",
            "07ロングソード",
            "08メイス",
            "09ハンドアックス",
            "0Aながやり",
            "0Bウォーハンマー",
            "0Cホーリーバッシャー",
            "0Dせんしのゆみ",
            "0Eとうぞくのゆみ",
            "0Fローブ",
            "10かわよろい",
            "11くさりかたびら",
            "12あしがるのよろい",
            "13プレートメイル",
            "14まるたて",
            "15ヒーターシールド",
            "16かわのかぶと",
            "17かわのこて",
            "18ローバズソード",
            "19ナイトソード",
            "1Aブラックブレード",
            "1Bかたな",
            "1Cバトルアックス",
            "1Dモーニングスター",
            "1Eやめるフレイル",
            "1Fハルバード",
            "20クロスボウ",
            "21かたいかわよろい",
            "22ひかるくさりかたびら",
            "23もののふのよろい",
            "24ナイトプレート",
            "25はくぎんのよろい",
            "26かたいまるたて",
            "27ナイトシールド",
            "28もんしょうのたて",
            "29しんちゅうのかぶと",
            "2Aてつのたて",
            "2Bヴァンプレイス",
            "2Cマスターソード",
            "2Dロビンソード",
            "2Eファイアーソード",
            "2Fたつじんのかたな",
            "30ソウルスティーラー",
            "31シルバーアックス",
            "32デスアックス",
            "33せいなるフレイル",
            "34ファウストハルバード",
            "35シルバーハンマー",
            "36まほうつかいのゆみ",
            "37ヘビィクロスボウ",
            "38ごうかなかわよろい",
            "39ぎんのくさりかたびら",
            "3Aたつじんのよろい",
            "3Bマスタープレート",
            "3Cスカーレットローブ",
            "3Dエメラルドローブ",
            "3Eタワーシールド",
            "3Fはがねのかぶと",
            "40ほのおのとんがりぼうし",
            "41ぎんのこて",
            "42ナイトヴァンプレイス",
            "43カシナートのけん",
            "44まもりのよろい",
            "45まふうじのたて",
            "46ほうせきのアーメット",
            "47まほうのずきん",
            "48ミルダールのこて",
            "49やぎざのマント",
            "4Aもりのせいのゆみ",
            "4Bむらまさ",
            "4Cオーディンソード",
            "4Dこんじきのよろい",
            "4Eまほうつかいのゆびわ",
            "4Fどくろのゆびわ",
            "50ぜんかいのゆびわ",
            "51ひすいのゆびわ",
            "52こどくのゆびわ",
            "53きせきのアンク",
            "54ちからのアンク",
            "55いのちのアンク",
            "56ちえのアンク",
            "57いのりのアンク",
            "58わかさのアンク",
            "59しょうかんのつえ",
            "5Aしにがみのつえ",
            "5Bねむりのまきもの",
            "5Cいしのまきもの",
            "5Dほのおのまきもの",
            "5Eしょうかんのまきもの",
            "5Fきずぐすり",
            "60ほれぐすり",
            "61どくけし",
            "62きつけぐすり",
            "63げきやく",
            "64とっこうやく",
            "65ダイヤのキング",
            "66ハートのクイーン",
            "67スペードのジャック",
            "68クラブのエース",
            "69ましらのワンド",
            "6Aいなづまのつえ",
            "6Bからくりヒバリ",
            "6Cみずのつえ",
            "6Dほのおのつえ",
            "6Eくうきのつえ",
            "6Fたいちのつえ",
            "70せいすい",
            "71きんのメダリオン",
            "72こおりのかぎ",
            "73はんけん",
            "74チケット",
            "75がいこつのかぎ",
            "76かいちゅうどけい",
            "77バッテリー",
            "78せきかしたあくま",
            "79きんのかぎ",
            "7Aあおいろうそく",
            "7Bほうせきのしゃく",
            "7Cじょれいのひやく",
            "7Dかなのこ",
            "7Eラムしゅ",
            "7Fぎんのかぎ",
            "80トークンのはいったふくろ",
            "81しんちゅうのかぎ",
            "82リルガミンのほうじゅ",
            "83アブリエルのハート",
            "84せいなるタリスマン",
            "85にじのまよけ",
            "86きりのまよけ",
            "87ほのおのまよけ"
            };
        //--------------------------------------------
        public ChrItemList()
        {
            this.SuspendLayout();

            this.BackColor = System.Drawing.Color.Black;
            this.ForeColor = System.Drawing.Color.White;
            this.MinimumSize = new System.Drawing.Size(195, 50);
            this.MaximumSize = new System.Drawing.Size(4000, 4000);
            this.Size = new System.Drawing.Size(195, 175);
            this.Name = "ChrItemList";


            this.btnUp.FlatStyle = FlatStyle.Flat;
            this.btnUp.ForeColor = Color.White;
            this.btnUp.Location = new Point(0, 0);
            this.btnUp.Margin = new Padding(0);
            this.btnUp.Name = "btnUp";
            this.btnUp.Size = new Size(40, 24);
            this.btnUp.TabIndex = 0;
            this.btnUp.Text = "Up";
            this.btnUp.UseVisualStyleBackColor = true;
            //this.btnUp.Enabled = false;

            this.btnDown.FlatStyle = FlatStyle.Flat;
            this.btnDown.ForeColor = Color.White;
            this.btnDown.Location = new Point(45, 0);
            this.btnDown.Margin = new Padding(0);
            this.btnDown.Name = "btnDown";
            this.btnDown.Size = new Size(40, 24);
            this.btnDown.TabIndex = 1;
            this.btnDown.Text = "Dwn";
            this.btnDown.UseVisualStyleBackColor = true;
            //this.btnDown.Enabled = false;

            this.btnNOR.FlatStyle = FlatStyle.Flat;
            this.btnNOR.ForeColor = Color.White;
            this.btnNOR.Location = new Point(140, 0);
            this.btnNOR.Margin = new Padding(0);
            this.btnNOR.Name = "btnNOR";
            this.btnNOR.Size = new Size(55, 24);
            this.btnNOR.TabIndex = 2;
            this.btnNOR.Text = "正常化";
            this.btnNOR.UseVisualStyleBackColor = true;
            this.btnNOR.Anchor = (AnchorStyles)(AnchorStyles.Right);


            this.listBox1.Font = new Font("ＭＳ ゴシック", 10F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(128)));
            this.listBox1.BackColor = System.Drawing.Color.Black;
            this.listBox1.ForeColor = Color.White;
            this.listBox1.FormattingEnabled = true;
            this.listBox1.ItemHeight = 19;
            this.listBox1.Location = new System.Drawing.Point(0, 25);
            this.listBox1.Name = "listBox1";
            this.listBox1.Size = new System.Drawing.Size(195, 150);
            this.listBox1.TabIndex = 5;
            this.listBox1.Anchor = ((AnchorStyles)((((AnchorStyles.Top | AnchorStyles.Bottom) | AnchorStyles.Left) | AnchorStyles.Right)));

            this.Controls.Add(this.btnUp);
            this.Controls.Add(this.btnDown);
            this.Controls.Add(this.btnNOR);
            this.Controls.Add(this.listBox1);

            this.ResumeLayout(false);


            btnUp.Click += BtnUp_Click;
            btnDown.Click += BtnDown_Click;
            btnNOR.Click += BtnNOR_Click;

            this.listBox1.DoubleClick += ListBox1_DoubleClick;
        }

        //-------------------------------------------------------------
        private void ListBox1_DoubleClick(object sender, EventArgs e)
        {
            if ((Control.ModifierKeys & Keys.Shift) == Keys.Shift)
            {
                if (m_targetChr < 0) return;
                int si = listBox1.SelectedIndex;
                if (si < 0) return;
                int adr1 = m_adr1 + 0x80 * m_targetChr + si;
                int adr2 = m_adr2 + 0x80 * m_targetChr + si;

                int v = (int)m_wizFive.State.GetByte(adr2);


                using (ItemEditDlg dlg = new ItemEditDlg())
                {

                    dlg.SetItems(m_itemName, v);
                    if (dlg.ShowDialog() == DialogResult.OK)
                    {
                        m_wizFive.State.SetByte(adr1, 0);
                        m_wizFive.State.SetByte(adr2, (byte)dlg.SelectedIndex);
                        GetValue();
                        listBox1.SelectedIndex = si;

                    }
                }
            }
        }

        //-------------------------------------------------------------
        private void BtnNOR_Click(object sender, EventArgs e)
        {
            ToNor();
        }

        //-------------------------------------------------------------
        private void BtnDown_Click(object sender, EventArgs e)
        {
            ItemDown();
        }

        //-------------------------------------------------------------
        private void BtnUp_Click(object sender, EventArgs e)
        {
            ItemUp();
        }

        //-------------------------------------------------------------
        public void SwapItem(int idx0, int idx1)
        {
            if (m_targetChr < 0) return;
            if (idx0 == idx1) return;
            if ((idx0 < 0) || (idx0 >= m_itemCount) || (idx1 < 0) || (idx1 >= m_itemCount)) return;
            byte ii0 = m_wizFive.State.GetByte(m_adr1 + 0x80 * m_targetChr + idx0);
            byte ic0 = m_wizFive.State.GetByte(m_adr2 + 0x80 * m_targetChr + idx0);
            byte ii1 = m_wizFive.State.GetByte(m_adr1 + 0x80 * m_targetChr + idx1);
            byte ic1 = m_wizFive.State.GetByte(m_adr2 + 0x80 * m_targetChr + idx1);

            m_wizFive.State.SetByte(m_adr1 + 0x80 * m_targetChr + idx0, ii1);
            m_wizFive.State.SetByte(m_adr2 + 0x80 * m_targetChr + idx0, ic1);
            m_wizFive.State.SetByte(m_adr1 + 0x80 * m_targetChr + idx1, ii0);
            m_wizFive.State.SetByte(m_adr2 + 0x80 * m_targetChr + idx1, ic0);

        }
        //-------------------------------------------------------------
        public void ItemUp()
        {
            int si = listBox1.SelectedIndex;
            if (si > 0)
            {
                SwapItem(si, si - 1);
                GetValue();
                listBox1.SelectedIndex = si - 1;
            }

        }
        //-------------------------------------------------------------
        public void ItemDown()
        {
            int si = listBox1.SelectedIndex;
            if ( (si >= 0)&&(si <m_itemCount-1))
            {
                SwapItem(si, si + 1);
                GetValue();
                listBox1.SelectedIndex = si + 1;
            }

        }
        //-------------------------------------------------------------
        public void ToNor()
        {

            if (m_targetChr < 0) return;
            int si = listBox1.SelectedIndex;
            if (si < 0) return;
            int adr = m_adr1 + 0x80 * m_targetChr + si;
            byte b = m_wizFive.State.GetByte(adr);
            if (b != 0)
            {
                b = 0;
            }
            else
            {
                b = 0x80;
            }
            m_wizFive.State.SetByte(adr, b);
            GetValue();
            listBox1.SelectedIndex = si;

        }
        //-------------------------------------------------------------
        public void GetValue()
        {
            this.SuspendLayout();
            listBox1.Items.Clear();
            m_targetChr = -1;
            m_itemCount = 0;
            if (m_wizFive != null)
            {
                int idx = m_wizFive.SelectedIndex;
                m_targetChr = idx;
                if ((idx >= 0)&&(m_wizFive.CharEnabled(idx) == true))
                {
                    //アイテムの個数
                    int ic = (int)m_wizFive.State.GetByte(m_adr3 + 0x80 * idx);
                    m_itemCount = ic;
                    if (ic>0)
                    {
                        if (ic > 8) ic = 8;

                        for ( int i=0; i<ic; i++)
                        {
                            int v1 = (int)m_wizFive.State.GetByte(m_adr1 + 0x80 * idx + i);
                            int v2 = (int)m_wizFive.State.GetByte(m_adr2 + 0x80 * idx + i);
                            if ((v2 < 0)|| (v2 > 0x87)) v2 = 0;

                            bool shiki = ((v1 & 0x20) == 0x20);
                            bool noroi = ((v1 & 0x40) == 0x40);
                            bool soubi = ((v1 & 0x80) == 0x80);

                            string s = "";
                            if (soubi)
                            {
                                s += "＊";
                            }
                            else if (noroi)
                            {
                                s += "呪";
                            }
                            else
                            {
                                s += "  ";
                            }
                            if (shiki) s += " 未識別:";
                            s += m_itemName[v2];
                            listBox1.Items.Add(s);
                        }

                    }
                }
            }
            this.ResumeLayout(false);
        }
        //-------------------------------------------------------------
        public Snes9xWizFive WizFive
        {
            get { return m_wizFive; }
            set
            {
                m_wizFive = value;
                if (m_wizFive != null)
                {
                    m_wizFive.SelectedIndexChanged += M_wiz5_SelectedIndexChanged;
                    m_wizFive.LoadFileEvent += M_wizFive_LoadFileEvent;
                }
            }
        }
        //-------------------------------------------------------------
        private void M_wizFive_LoadFileEvent(object sender, EventArgs e)
        {
            GetValue();
        }

        //-------------------------------------------------------------
        private void M_wiz5_SelectedIndexChanged(object sender, EventArgs e)
        {
            GetValue();
        }

    }
}

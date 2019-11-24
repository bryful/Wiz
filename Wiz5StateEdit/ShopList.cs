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
    public class ShopList : ListBox
    {
        private Snes9xWizFive m_wizFive = null;
        private int m_Adr = 0x1A00;
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
        //-------------------------------------------------------------
        public ShopList()
        {
            this.DoubleClick += ShopList_DoubleClick;
        }

        //-------------------------------------------------------------
        private void ShopList_DoubleClick(object sender, EventArgs e)
        {
            if ((Control.ModifierKeys & Keys.Shift) == Keys.Shift)
                ValueUp();
        }

        //-------------------------------------------------------------
        public void GetValue()
        {
            if (m_wizFive == null) return;

            this.SuspendLayout();
            this.Items.Clear();

            for(int i=0; i<0x88;i++)
            {
                byte v = m_wizFive.State.GetByte(m_Adr + i);
                string s = "";
                s = string.Format("{0:X2}: {1}", v, m_itemName[i]);
                this.Items.Add(s);
             }
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
        private void ValueUp()
        {
            if (m_wizFive == null) return;
            int si = this.SelectedIndex;
            if (si < 0) return;

            byte v = m_wizFive.State.GetByte(m_Adr + si);
            if (v == 0) v = 1;
            else if (v < 0xFF) v = 0xFF;
            else v = 0;

            m_wizFive.State.SetByte(m_Adr + si, v);

            this.Items[si] = string.Format("{0:X2}: {1}", v, m_itemName[si]);

        }


    }
}

﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace WizFCEdit
{
    public class WizItem
    {
        private WIZSCN m_scn = WIZSCN.NO; 
        public WIZSCN SCN
        {
            get { return m_scn; }
            set { m_scn = value; }
        }
        private byte m_ID = 0;
        public byte ID
        {
            get { return m_ID; }
            set { m_ID = value; }
        }
        private byte m_Status = 0;
        public byte Status
        {
            get { return m_Status; }
            set { m_Status = value; }
        }
        public bool Indeterminate
        {
            get { return ((m_Status & 0x20) == 0x20); }
            set
            {
                if (value == true)
                {
                    m_Status = (byte)(m_Status | 0x20);
                }
                else
                {
                    m_Status = (byte)(m_Status & 0xDF);
                }
            }
        }
        public bool Curse
        {
            get { return ((m_Status & 0x40)  == 0x40); }
            set
            {
                if (value == true)
                {
                    m_Status = (byte)(m_Status | 0x40);
                }
                else
                {
                    m_Status = (byte)(m_Status & 0xBF);
                }
            }
        }
        public bool Equipment
        {
            get { return ((m_Status & 0x80 ) == 0x80); }
            set
            {
                if (value == true)
                {
                    m_Status = (byte)(m_Status | 0x80);
                }
                else
                {
                    m_Status = (byte)(m_Status & 0x7F);
                }
            }
        }
        public WizItem(WIZSCN scn = WIZSCN.S1)
        {
            m_scn = scn;
        }
        public string ItemName
        {
            get
            {
                switch (m_scn)
                {
                    case WIZSCN.S1:
                        return m_WizFCItemNames1[m_ID];
                    case WIZSCN.S2:
                        return m_WizFCItemNames2[m_ID];
                    case WIZSCN.S3:
                        return m_WizFCItemNames3[m_ID];
                    default:
                        return "";
                }

            }
        }
        public string CaptionText
        {
            get
            {
                string s = "";
                if(Indeterminate == true)
                {
                    s = ItemName.Substring(0, 3);
                    s += "未識別";
                }
                else
                {
                    s = ItemName;
                }
                return s;
            }
        }
        public string [] ItemNames
        {
            get
            {
                switch (m_scn)
                {
                    case WIZSCN.S1:
                        return m_WizFCItemNames1;
                    case WIZSCN.S2:
                        return m_WizFCItemNames2;
                    case WIZSCN.S3:
                        return m_WizFCItemNames3;
                    default:
                        return new string[0];
                }

            }
        }
        public int ItemCount
        {
            get
            {
                switch (m_scn)
                {
                    case WIZSCN.S1:
                        return m_WizFCItemNames1.Length;
                    case WIZSCN.S2:
                        return m_WizFCItemNames2.Length;
                    case WIZSCN.S3:
                        return m_WizFCItemNames3.Length;
                    default:
                        return 0;
                }

            }
        }
        #region Wiz ItemName
        private string[] m_WizFCItemNames1 = new string[]{
			/*00*/ "00:壊れたアイテム",
			/*01*/ "01:剣",
			/*02*/ "02:短剣",
			/*03*/ "03:メイス",
			/*04*/ "04:フレイル",
			/*05*/ "05:杖",
			/*06*/ "06:短刀",
			/*07*/ "07:小型の盾",
			/*08*/ "08:盾",
			/*09*/ "09:ローブ",
			/*0A*/ "0A:革の鎧",
			/*0B*/ "0B:鎖帷子",
			/*0C*/ "0C:胸当て",
			/*0D*/ "0D:鎧",
			/*0E*/ "0E:兜",
			/*0F*/ "0F:治療",
			/*10*/ "10:毒消し",
			/*11*/ "11:切り裂きの剣",
			/*12*/ "12:良い短剣",
			/*13*/ "13:粉砕のメイス",
			/*14*/ "14:鉄の杖",
			/*15*/ "15:眠り",
			/*16*/ "16:硬い革鎧",
			/*17*/ "17:光る鎖帷子",
			/*18*/ "18:丈夫の鎧",
			/*19*/ "19:鉄の盾",
			/*1A*/ "1A:胴鎧",
			/*1B*/ "1B:苦痛",
			/*1C*/ "1C:炎",
			/*1D*/ "1D:鈍らな剣",
			/*1E*/ "1E:幻滅の短剣",
			/*1F*/ "1F:災いのメイス",
			/*20*/ "20:硬い杖",
			/*21*/ "21:ドラゴンスレイヤー",
			/*22*/ "22:忍耐の兜",
			/*23*/ "23:腐った革鎧",
			/*24*/ "24:錆びた鎖帷子",
			/*25*/ "25:罅割れた胸当て",
			/*26*/ "26:歪んだ盾",
			/*27*/ "27:宝石の指輪",
			/*28*/ "28:苦しみ",
			/*29*/ "29:隠れ身",
			/*2A*/ "2A:真二つの剣",
			/*2B*/ "2B:最強の短剣",
			/*2C*/ "2C:力のメイス",
			/*2D*/ "2D:明かり",
			/*2E*/ "2E:暗闇",
			/*2F*/ "2F:銅の篭手",
			/*30*/ "30:豪華な革鎧",
			/*31*/ "31:エルフの鎖帷子",
			/*32*/ "32:極上の鎧",
			/*33*/ "33:支えの盾",
			/*34*/ "34:悪の兜",
			/*35*/ "35:回復",
			/*36*/ "36:守りの指輪",
			/*37*/ "37:ワースレイヤー",
			/*38*/ "38:メイジマッシャー",
			/*39*/ "39:ヘビのメイス",
			/*3A*/ "3A:沈黙の杖",
			/*3B*/ "3B:カシナートの剣",
			/*3C*/ "3C:戒めの指輪",
			/*3D*/ "3D:炎の杖",
			/*3E*/ "3E:悪の鎖帷子",
			/*3F*/ "3F:中立の鎧",
			/*40*/ "40:悪の盾",
			/*41*/ "41:窒息の指輪",
			/*42*/ "42:転移の兜",
			/*43*/ "43:一撃",
			/*44*/ "44:破滅の短剣",
			/*45*/ "45:切り裂きの短刀",
			/*46*/ "46:病めるメイス",
			/*47*/ "47:捻れた杖",
			/*48*/ "48:早業の短刀",
			/*49*/ "49:呪われたローブ",
			/*4A*/ "4A:破滅の革鎧",
			/*4B*/ "4B:呪いの鎖帷子",
			/*4C*/ "4C:悪魔の胸当て",
			/*4D*/ "4D:虚ろの盾",
			/*4E*/ "4E:古びた兜",
			/*4F*/ "4F:希望の胸当て",
			/*50*/ "50:銀の篭手",
			/*51*/ "51:悪のサーベル",
			/*52*/ "52:ソウルスレイヤー",
			/*53*/ "53:盗賊の短刀",
			/*54*/ "54:英雄の鎧",
			/*55*/ "55:聖なる鎧",
			/*56*/ "56:村正",
			/*57*/ "57:手裏剣",
			/*58*/ "58:氷の鎖帷子",
			/*59*/ "59:悪の鎧",
			/*5A*/ "5A:守りの盾",
			/*5B*/ "5B:回復の指輪",
			/*5C*/ "5C:破邪の指輪",
			/*5D*/ "5D:死の指輪",
			/*5E*/ "5E:ワードナの魔除け",
			/*5F*/ "5F:クマの置物",
			/*60*/ "60:カエルの置物",
			/*61*/ "61:青銅の鍵",
			/*62*/ "62:銀の鍵",
			/*63*/ "63:金の鍵",
			/*64*/ "64:ブルーリボン",
        };
        private string[] m_WizFCItemNames2 = new string[]{
			/*00*/ "00:壊れたアイテム",
			/*01*/ "01:イアリシンの宝珠",
			/*02*/ "02:中立の水晶",
			/*03*/ "03:悪の水晶",
			/*04*/ "04:善の水晶",
			/*05*/ "05:ビン詰めの船",
			/*06*/ "06:大地の杖",
			/*07*/ "07:空気の魔除け",
			/*08*/ "08:聖水",
			/*09*/ "09:炎の杖",
			/*0A*/ "0A:金のメダリオン",
			/*0B*/ "0B:ミューズフェスの宝珠",
			/*0C*/ "0C:チョウのナイフ",
			/*0D*/ "0D:短剣",
			/*0E*/ "0E:段平",
			/*0F*/ "0F:メイス",
			/*10*/ "10:杖",
			/*11*/ "11:オノ",
			/*12*/ "12:戦オノ",
			/*13*/ "13:短刀",
			/*14*/ "14:フレイル",
			/*15*/ "15:盾",
			/*16*/ "16:鉄の盾",
			/*17*/ "17:魔法使いのローブ",
			/*18*/ "18:革の鎧",
			/*19*/ "19:鎖帷子",
			/*1A*/ "1A:胸当て",
			/*1B*/ "1B:鎧",
			/*1C*/ "1C:兜",
			/*1D*/ "1D:傷薬",
			/*1E*/ "1E:毒消し",
			/*1F*/ "1F:短剣 ＋１",
			/*20*/ "20:段平 ＋１",
			/*21*/ "21:メイス ＋１",
			/*22*/ "22:戦オノ ＋１",
			/*23*/ "23:ヌンチャク",
			/*24*/ "24:短刀 ＋１",
			/*25*/ "25:眠りの巻物",
			/*26*/ "26:革の鎧 ＋１",
			/*27*/ "27:鎖帷子 ＋１",
			/*28*/ "28:胸当て ＋１",
			/*29*/ "29:鎧 ＋１",
			/*2A*/ "2A:鉄の盾 ＋１",
			/*2B*/ "2B:鉄の兜",
			/*2C*/ "2C:鉄の篭手",
			/*2D*/ "2D:苦痛の巻物",
			/*2E*/ "2E:炎の薬",
			/*2F*/ "2F:短剣 －１",
			/*30*/ "30:段平 －１",
			/*31*/ "31:メイス －１",
			/*32*/ "32:短刀 －１",
			/*33*/ "33:戦オノ －１",
			/*34*/ "34:マルゴーのフレイル",
			/*35*/ "35:宝石の袋",
			/*36*/ "36:魔法使いの杖",
			/*37*/ "37:炎の段平",
			/*38*/ "38:盾 －１",
			/*39*/ "39:革の鎧 －１",
			/*3A*/ "3A:鎖帷子 －１",
			/*3B*/ "3B:胸当て －１",
			/*3C*/ "3C:鎧 －１",
			/*3D*/ "3D:兜 －１",
			/*3E*/ "3E:隠れ身の薬",
			/*3F*/ "3F:金の指輪",
			/*40*/ "40:サラマンダーの指輪",
			/*41*/ "41:ヘビの牙",
			/*42*/ "42:短剣 ＋２",
			/*43*/ "43:段平 ＋２",
			/*44*/ "44:戦オノ ＋２",
			/*45*/ "45:象牙の短刀（Ｇ）",
			/*46*/ "46:黒檀の短刀（Ｅ）",
			/*47*/ "47:琥珀の短刀（Ｎ）",
			/*48*/ "48:メイス ＋２",
			/*49*/ "49:ミスリルの篭手",
			/*4A*/ "4A:麻痺の魔除け",
			/*4B*/ "4B:革の鎧 ＋２",
			/*4C*/ "4C:鉄の盾 ＋２",
			/*4D*/ "4D:身躱しのローブ",
			/*4E*/ "4E:鎖帷子 ＋２",
			/*4F*/ "4F:胸当て ＋２",
			/*50*/ "50:鎧 ＋２",
			/*51*/ "51:鋼の兜",
			/*52*/ "52:ワーガンローブ",
			/*53*/ "53:巨人の棍棒",
			/*54*/ "54:カシナートの剣",
			/*55*/ "55:羊飼いの杖",
			/*56*/ "56:邪悪のオノ",
			/*57*/ "57:死の杖",
			/*58*/ "58:魔除けの宝石",
			/*59*/ "59:エメラルドの袋",
			/*5A*/ "5A:ガーネットの袋",
			/*5B*/ "5B:青真珠",
			/*5C*/ "5C:ルビーのスリッパ",
			/*5D*/ "5D:ネクロマンサーの杖",
			/*5E*/ "5E:命の書",
			/*5F*/ "5F:死の書",
			/*60*/ "60:ドラゴンの牙",
			/*61*/ "61:トロールの指輪",
			/*62*/ "62:ウサギの足",
			/*63*/ "63:盗賊のピック",
			/*64*/ "64:悪魔の書",
			/*65*/ "65:チョウのナイフ",
			/*66*/ "66:金のティアラ",
			/*67*/ "67:カマキリの篭手",
			/*68*/ "68:村正",
			/*69*/ "69:手裏剣",
			/*6A*/ "6A:聖なる鎧",
			/*6B*/ "6B:赤い靴",
			/*6C*/ "6C:金の斧",
			/*6D*/ "6D:黄色い耳栓",
			/*6E*/ "6E:琥珀の杖",
    };
        private string[] m_WizFCItemNames3 = new string[]{
			/*00*/ "00:ガラクタ",
			/*01*/ "01:剣",
			/*02*/ "02:短剣",
			/*03*/ "03:メイス",
			/*04*/ "04:フレイル",
			/*05*/ "05:杖",
			/*06*/ "06:短刀",
			/*07*/ "07:バックラー",
			/*08*/ "08:盾",
			/*09*/ "09:ローブ",
			/*0A*/ "0A:革鎧",
			/*0B*/ "0B:鎖帷子",
			/*0C*/ "0C:胸当て",
			/*0D*/ "0D:鎧",
			/*0E*/ "0E:兜",
			/*0F*/ "0F:傷薬",
			/*10*/ "10:毒消し",
			/*11*/ "11:切り裂きの剣",
			/*12*/ "12:鋭い短剣",
			/*13*/ "13:粉砕のメイス",
			/*14*/ "14:鉄の杖",
			/*15*/ "15:眠りの",
			/*16*/ "16:硬い革鎧",
			/*17*/ "17:光る鎖帷子",
			/*18*/ "18:丈夫の鎧",
			/*19*/ "19:鉄の盾",
			/*1A*/ "1A:胴鎧",
			/*1B*/ "1B:痛みの",
			/*1C*/ "1C:炎の",
			/*1D*/ "1D:諸刃の剣",
			/*1E*/ "1E:幻滅の短剣",
			/*1F*/ "1F:災いのメイス",
			/*20*/ "20:硬い杖",
			/*21*/ "21:ドラゴンスレイヤー",
			/*22*/ "22:忍耐の兜",
			/*23*/ "23:腐った革鎧",
			/*24*/ "24:錆びた鎖帷子",
			/*25*/ "25:歴戦の胸当て",
			/*26*/ "26:歪んだ盾",
			/*27*/ "27:宝石の指輪",
			/*28*/ "28:苦しみの",
			/*29*/ "29:煙玉",
			/*2A*/ "2A:真二つの剣",
			/*2B*/ "2B:最強の短剣",
			/*2C*/ "2C:力のメイス",
			/*2D*/ "2D:導きの",
			/*2E*/ "2E:目眩ましの",
			/*2F*/ "2F:銅の篭手",
			/*30*/ "30:豪華な革鎧",
			/*31*/ "31:エルフの鎖帷子",
			/*32*/ "32:極上の鎧",
			/*33*/ "33:支えの盾",
			/*34*/ "34:悪の兜",
			/*35*/ "35:特効薬",
			/*36*/ "36:守りの指輪",
			/*37*/ "37:ワースレイヤー",
			/*38*/ "38:メイジマッシャー",
			/*39*/ "39:蛇のメイス",
			/*3A*/ "3A:沈黙の杖",
			/*3B*/ "3B:カシナートの剣",
			/*3C*/ "3C:戒めの指輪",
			/*3D*/ "3D:炎の杖",
			/*3E*/ "3E:悪の鎖帷子",
			/*3F*/ "3F:中立の鎧",
			/*40*/ "40:悪の盾",
			/*41*/ "41:窒息の指輪",
			/*42*/ "42:転移の兜",
			/*43*/ "43:一撃の",
			/*44*/ "44:破滅の短剣",
			/*45*/ "45:切り裂きの短刀",
			/*46*/ "46:病めるメイス",
			/*47*/ "47:捻れた杖",
			/*48*/ "48:早業の短刀",
			/*49*/ "49:呪われたローブ",
			/*4A*/ "4A:破滅の革鎧",
			/*4B*/ "4B:呪いの鎖帷子",
			/*4C*/ "4C:悪魔の胸当て",
			/*4D*/ "4D:虚ろの盾",
			/*4E*/ "4E:古びた兜",
			/*4F*/ "4F:希望の胸当て",
			/*50*/ "50:銀の篭手",
			/*51*/ "51:悪のサーベル",
			/*52*/ "52:ソウルスレイヤー",
			/*53*/ "53:盗賊の短刀",
			/*54*/ "54:英雄の鎧",
			/*55*/ "55:聖なる鎧",
			/*56*/ "56:村正",
			/*57*/ "57:手裏剣",
			/*58*/ "58:氷の鎖帷子",
			/*59*/ "59:悪の鎧",
			/*5A*/ "5A:守りの盾",
			/*5B*/ "5B:回復の指輪",
			/*5C*/ "5C:破邪の指輪",
			/*5D*/ "5D:死の指輪",
			/*5E*/ "5E:復活の杖",
			/*5F*/ "5F:古の御守り",
			/*60*/ "60:身躱しのローブ",
			/*61*/ "61:手袋",
			/*62*/ "62:魔封じのネックレス",
			/*63*/ "63:光の杖",
			/*64*/ "64:エクスカリバー",
			/*65*/ "65:閃きの剣",
			/*66*/ "66:プリーストパンチャー",
			/*67*/ "67:僧侶のメイス",
			/*68*/ "68:閃きの短剣",
			/*69*/ "69:炎の指輪",
			/*6A*/ "6A:呪われた鎧",
			/*6B*/ "6B:ミスリルの鎧",
			/*6C*/ "6C:癒しの杖",
			/*6D*/ "6D:命の指輪",
			/*6E*/ "6E:変化の指輪",
			/*6F*/ "6F:不思議な石",
			/*70*/ "70:希望の石",
			/*71*/ "71:神秘的な石",
			/*72*/ "72:偉大なる魔法の杖",
			/*73*/ "73:力のコイン",
			/*74*/ "74:若返りの石",
			/*75*/ "75:心の石",
			/*76*/ "76:信心の石",
			/*77*/ "77:ブラーニィの石",
			/*78*/ "78:熟練の魔除け",
			/*79*/ "79:熟練の魔除け",
			/*7A*/ "7A:偉大なる魔法の杖",
			/*7B*/ "7B:力のコイン",
			/*7C*/ "7C:ニルダの杖",
			/*7D*/ "7D:ハースニール",
			/*7E*/ "7E:伝説の兜",
			/*7F*/ "7F:伝説の盾",
			/*80*/ "80:伝説の篭手",
			/*81*/ "81:伝説の鎧",
			/*82*/ "82:錆びた鍵",
			/*83*/ "83:血塗れのバッジ",
			/*84*/ "84:奇妙な紋章",
			/*85*/ "85:黒檀の鍵",
			/*86*/ "86:修道院の鍵",
			/*87*/ "87:ミスリルの鍵",
			/*88*/ "88:マスターキー",
			/*89*/ "89:悪魔の石",
			};

        public string[] WizFCItemNames1
        {
            get { return m_WizFCItemNames1; }
        }
        public string[] WizFCItemNames2
        {
            get { return m_WizFCItemNames2; }
        }
        public string[] WizFCItemNames3
        {
            get { return m_WizFCItemNames2; }
        }
        #endregion
    }
}

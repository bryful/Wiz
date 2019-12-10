using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Drawing;
using System.Data;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using System.Drawing.Drawing2D;
using System.IO;
using System.IO.Compression;

namespace WizEdit
{
    public class CurrentCharEventArgs : EventArgs
    {
        public int CurrentChar;
    }
    public class WizData :Component
    {
        private string m_DataPath = "";
        public string DataPath
        {
            get { return m_DataPath; }
        }

 
        #region Event
        //CurrentCharが変更された時
        public delegate void CurrentCharChangeHandler(object sender, CurrentCharEventArgs e);
        public event CurrentCharChangeHandler CurrentCharChanged;
        protected virtual void OnCurrentCharChanged(CurrentCharEventArgs e)
        {
            CurrentCharChanged?.Invoke(this, e);
        }
        //ファイルがロードされた時
        public event EventHandler LoadFileFinished;
        protected virtual void OnLoadFileFinished(EventArgs e)
        {
            LoadFileFinished?.Invoke(this, e);
        }

        public event EventHandler ValueChanged;
        protected virtual void OnValueChanged(EventArgs e)
        {
            ValueChanged?.Invoke(this, e);
        }
        #endregion

        #region prop
        /// <summary>
        /// 読み込んだステートファイルそのもの
        /// </summary>
        private byte[] m_Data = new byte[0];
        private int m_OffsetAdr = -1;
        private int m_OffsetAdr2 = -1;
        private int m_OffsetAdr3 = -1;
        /// <summary>
        /// SRAM領域のアドレス
        /// </summary>
        public int OffsetAdr { get { return m_OffsetAdr; } }
        public int OffsetAdr2 { get { return m_OffsetAdr2; } }
        public int OffsetAdr3 { get { return m_OffsetAdr3; } }


        private WIZSCN m_scn = WIZSCN.NO;
        /// <summary>
        /// 読み込んだステートファイルのシナリオ
        /// </summary>
        public WIZSCN SCN { get { return m_scn; } }

        public void SetSFC_SCN(WIZSCN scn)
        {
            if (m_scn == scn) return;
            if ( (m_scn==WIZSCN.SFC1)|| (m_scn == WIZSCN.SFC2)||(m_scn == WIZSCN.SFC3))
            {
                if ((scn == WIZSCN.SFC1) || (scn == WIZSCN.SFC2) || (scn == WIZSCN.SFC3))
                {
                    m_scn = scn;
                    m_res_scn = scn;
                    OnLoadFileFinished(new EventArgs());
                }

            }
        }


        private WIZFILE m_WizFile = WIZFILE.STATE;
        public WIZFILE FileMode
        {
            get { return m_WizFile; }
        }

        public int  CharCount
        {
            get
            {
                if (m_WizFile == WIZFILE.ROM)
                {
                    return 6;
                }
                else
                {
                    return 20;
                }
            }
        }

        private int m_CharCurrent = -1;
        public int CharCurrent
        {
            get { return m_CharCurrent; }
            set
            {
                if ((value >= 0) && (value < CharCount))
                {
                    m_CharCurrent = value;
                }
                else
                {
                    m_CharCurrent = -1;
                }
                //イベント発生
                CurrentCharEventArgs e = new CurrentCharEventArgs
                {
                    CurrentChar = m_CharCurrent
                };
                OnCurrentCharChanged(e);
            }
        }
        public void CharCurrentUp()
        {
            if (m_CharCurrent>0)
            {
                CharCurrent = m_CharCurrent - 1;
            }
        }
        public void CharCurrentDown()
        {
            if ((m_CharCurrent < CharCount -1))
            {
                CharCurrent = m_CharCurrent + 1;
            }
        }

        #endregion


        static public string[] Titles()
        {
            string[] ret = new string[10];
            for ( int i=1;i<11;i++)
            {
                ret[i - 1] = ScenarioTitleStr((WIZSCN)i, WIZFILE.SAVE);
            }
            return ret;
        }
        static public string ScenarioTitleStr(WIZSCN scn, WIZFILE wf = WIZFILE.NONE)
        {
            string ret = "";
            switch (scn)
            {
                case WIZSCN.FC1: ret = "Wiz1(PG) FC "; break;
                case WIZSCN.FC2: ret = "Wiz2(LOL) FC"; break;
                case WIZSCN.FC3: ret = "Wiz3(KOD) FC"; break;
                case WIZSCN.SFC1: ret = "Wiz1(PG) SFC "; break;
                case WIZSCN.SFC2: ret = "Wiz2(LOL) SFC "; break;
                case WIZSCN.SFC3: ret = "Wiz3(KOD) SFC "; break;
                case WIZSCN.SFC5: ret = "Wiz5(HOM) SFC "; break;
                case WIZSCN.GBC1: ret = "Wiz1(PG) GBC "; break;
                case WIZSCN.GBC2: ret = "Wiz2(LOL) GBC"; break;
                case WIZSCN.GBC3: ret = "Wiz3(KOD) GBC"; break;
                default:
                    ret = "";
                    break;
            }
            switch (wf)
            {
                case WIZFILE.ROM:
                    ret += " ROM";
                    break;
                case WIZFILE.STATE:
                    ret += " State";
                    break;
                case WIZFILE.SAVE:
                    ret += " Save";
                    break;
            }
            return ret;
        }

        public string ScenarioTitle
        {
            get
            {
                return ScenarioTitleStr(m_scn, m_WizFile);
            }
        }

        #region Const Text
        static public readonly string[] RaceStr = new string[]
        {
            "HUMAN",
            "ELF",
            "DWARF",
            "GNOME",
            "HOBIT"
        };
        static public string RaceString(WIZRACE r)
        {
            int v = (int)r;
            if (v < 0) v = 0;
            else if (v >= RaceStr.Length) v = 0;
            return RaceStr[v];
        }
        static public readonly string[] ClassStr = new string[]
        {
            "FIG",
            "MAG",
            "PRI",
            "THI",
            "BIS",
            "SAM",
            "LOR",
            "NIN"
        };
        static public string ClassString(WIZCLASS r)
        {
            int v = (int)r;
            if (v < 0) v = 0;
            else if (v >= ClassStr.Length) v = 0;
            return ClassStr[v];
        }
        static public readonly string[] AlgStr = new string[]
       {
            "Good",
            "Neutral",
            "Evil"
       };
        static public string AlgString(WIZALG r)
        {
            int v = (int)r;
            if (v < 0) v = 0;
            else if (v >= AlgStr.Length) v = 0;
            return AlgStr[v];
        }
        static public readonly string[] StatusStr = new string[]
       {
           // 0:OK, 1:ASLEEP, 2:AFRAID, 3:PARALY, 4:STONED, 5:DEAD, 6:ASHED, 7:LOST
            "OK",
            "ASLEEP",
            "AFRAID",
            "PARALY",
            "STONED",
            "DEAD",
            "ASHED",
            "LOST",
            ""
       };
        static public readonly string[] StatusStrJ = new string[]
       {
            "OK",
            "ねむっている",
            "おそれている",
            "まひしている",
            "いしになった",
            "しんでいる",
            "はいになった",
            "うしなわれた"
       };
        static public string StatusStringJ(WIZSTATUS r)
        {
            int v = (int)r;
            if (v < 0) v = 0;
            else if (v >= StatusStrJ.Length) v = 0;
            return StatusStrJ[v];
        }
        #endregion


        #region FC1 SPELL TABLE
        private readonly int[][] Wiz1FCSpellTo = new int[7][]
       {
            new int[]{0x0001,0x0002,0x0004,0x0008,0x0101,0x0102,0x0201,0x0202},
            new int[]{0x0301,0x0302,0x0304,0x0401,0x0402,0x0404,0x0501,0x0502},
            new int[]{0x0504,0x0508,0x0601,0x0602,0x0604,0x0701,0x0702,0x0704},
            new int[]{0x0708,0x0710,0x0801,0x0802,0x0804,0x0808,0x0901,0x0902},
            new int[]{0x0904,0x0908,0x0A01,0x0A02,0x0A04,0x0A08,0x0B01,0x0B02},
            new int[]{0x0B04,0x0B08,0x0B10,0x0B20,0x0C01,0x0C02,0x0C04,0x0C08},
            new int[]{0x0D01, 0x0D02}
       };
        private readonly int[][] Wiz1FCSpellFrom = new int[14][]
    {
            new int[]{0x0001,0x0002,0x0004,0x0008},
            new int[]{0x0010,0x0020},
            new int[]{0x0040,0x0080},
            new int[]{0x0101,0x0102,0x0104},
            new int[]{0x0108,0x0110,0x0120},
            new int[]{0x0140,0x0180,0x0201,0x0202},
            new int[]{0x0204,0x0208,0x0210},

            new int[]{0x0220,0x0240,0x0280,0x0301,0x0302},
            new int[]{0x0304,0x0308,0x0310,0x0320},
            new int[]{0x0340,0x0380,0x0401,0x0402},
            new int[]{0x0404,0x0408,0x0410,0x0420},
            new int[]{0x0440,0x0480,0x0501,0x0502,0x0504,0x0508},
            new int[]{0x0510,0x0520,0x0540,0x0580},
            new int[]{0x0601, 0x0602}
    };
        #endregion

        // ***********************************************************************
        /// <summary>
        /// コンストラクタ
        /// </summary>
        public WizData()
        {
            if (ResLoad() == true)
            {

            }
        }
        // ************************************************************************
        /// <summary>
        /// キャラクターの先頭アドレス
        /// </summary>
        
        // ************************************************************************
        public int CharSize
        {
            get
            {

                switch (m_scn)
                {
                    case WIZSCN.FC1:
                        if (m_WizFile == WIZFILE.ROM)
                        {
                            return 0x080;
                        }
                        else
                        {
                            return 0x0100;
                        }
                    case WIZSCN.FC2:
                    case WIZSCN.FC3:
                        return 0x0060;
                    case WIZSCN.SFC1:
                    case WIZSCN.SFC2:
                    case WIZSCN.SFC3:
                    case WIZSCN.GBC1:
                    case WIZSCN.GBC2:
                    case WIZSCN.GBC3:
                        return 0x006E;

                    case WIZSCN.SFC5:
                        return 0x0080;

                    default:
                        return 0;
                }
            }
        }
        // ************************************************************************
        public int CharAdr(int index)
        {
            if(m_scn==WIZSCN.SFC2)
            {
                return m_OffsetAdr2 + CharSize * index;
            }else if (m_scn == WIZSCN.SFC3)
            {
                return m_OffsetAdr3 + CharSize * index;
            }
            else
            {
                return m_OffsetAdr + CharSize * index;
            }
        }
        // ************************************************************************
        public byte[] CharNameCodeFromIndex(int index)
        {
            byte[] ret = new byte[0];
            int idx = CharAdr(index);
            if (idx < 0) return ret;

            int cnt = m_Data[idx + 1];

            if (cnt == 0)
            {
                switch (m_scn)
                {
                    case WIZSCN.FC1:
                        ret = WizString.Wiz1FCNoneName;
                        break;
                    case WIZSCN.FC2:
                    case WIZSCN.FC3:
                        ret = WizString.Wiz2FCNoneName;
                        break;
                    case WIZSCN.SFC1:
                    case WIZSCN.SFC2:
                    case WIZSCN.SFC3:
                    case WIZSCN.SFC5:
                        ret = WizString.WizSFCNoneName;
                        break;
                    case WIZSCN.GBC1:
                    case WIZSCN.GBC2:
                    case WIZSCN.GBC3:
                        ret = WizString.WizGBCNoneName;
                        break;
                }
            }
            else
            {
                ret = GetCode(idx + 2, cnt);
            }
            return ret;

        }
        // ************************************************************************
        public void SetCharNameCodeFromIndex(int index, byte[] nm)
        {
            int idx = CharAdr(index);
            if (idx < 0) return;
            if (m_Data[idx] == 0) return;

            if (nm.Length <= 0) return;
 
            m_Data[idx + 1] = (byte)nm.Length;

            byte[] a = new byte[8];
            for (int i=0;i<8;i++)
            {
                switch (m_scn)
                {
                    case WIZSCN.FC1:
                        a[i] = 0x24;
                        break;
                    case WIZSCN.FC2:
                    case WIZSCN.FC3:
                        a[i] = 0x20;
                        break;
                    case WIZSCN.SFC1:
                    case WIZSCN.SFC2:
                    case WIZSCN.SFC3:
                    case WIZSCN.SFC5:
                        a[i] = 0x20;
                        break;
                    case WIZSCN.GBC1:
                    case WIZSCN.GBC2:
                    case WIZSCN.GBC3:
                        a[i] = 0x00;
                        break;
                }
            }
            for ( int i=0;i< nm.Length;i++)
            {
                a[i] = nm[i];
            }
            SetCode(idx + 2, a);
            OnValueChanged(new EventArgs());

        }
        // ************************************************************************
        public byte[] CharNameCode
        {
            get { return CharNameCodeFromIndex(m_CharCurrent); }
            set { SetCharNameCodeFromIndex(m_CharCurrent, value); }
        }
        // ************************************************************************
        public string CharNameFromIndex(int index)
        {
            int idx = CharAdr(index);
            if (idx < 0) return "";
            if (m_Data[idx] == 0) return WizString.NoneName;
            int cnt = m_Data[idx + 1];
            if (cnt <= 0) cnt = 8;
            byte[] nm = GetCode(idx+2, cnt);
            return WizString.CodeToString(m_scn, nm);

        }
        // ************************************************************************
        public string [] CharNamesWithOutCurrent
        {
            get
            {
                string[] ret = new string[CharCount-1];
                for ( int i=0; i< CharCount - 1;i++)
                {
                    if (i != m_CharCurrent)
                    {
                        ret[i] = CharNameFromIndex(i);
                    }
                }
                return ret;
            }
        }
        // ************************************************************************
        public string[] CharNames
        {
            get
            {
                string[] ret = new string[CharCount];
                for (int i = 0; i < CharCount; i++)
                {
                    ret[i] = CharNameFromIndex(i);
                }
                return ret;
            }
        }
        // ************************************************************************
        public bool CanSetCharName(string s)
        {
            bool ret = false;
            string[] ns = CharNamesWithOutCurrent;
            int idx = -1;

            for (int i=0; i<CharCount;i++)
            {
                if(s == ns[i])
                {
                    idx = i;
                    break;
                }
            }
            ret = (idx < 0);
            return ret;
        }
        // ************************************************************************
        public string CharName
        {
            get { return CharNameFromIndex(m_CharCurrent); }
        }
        // ************************************************************************
        public WIZRACE CharRaceFromIndex(int idx)
        {
            WIZRACE ret = WIZRACE.HUMAN;
            if ((idx<0)||(idx>=CharCount))
            {
                return ret;
            }
            int adr = CharAdr(idx);
            switch (m_scn)
            {
                case WIZSCN.FC1:
                    adr += 0x0A;
                    ret = (WIZRACE)(m_Data[adr] & 0x07);
                    break;
                case WIZSCN.FC2:
                case WIZSCN.FC3:
                case WIZSCN.GBC1:
                case WIZSCN.GBC2:
                case WIZSCN.GBC3:
                case WIZSCN.SFC1:
                case WIZSCN.SFC2:
                case WIZSCN.SFC3:
                case WIZSCN.SFC5:
                    adr += 0x0A;
                    ret = (WIZRACE)(m_Data[adr] >> 5 & 0x07);
                    break;
                default:
                    return ret;
            }

            return ret;
        }
        // ************************************************************************
        public  void SetCharRaceFromIndex(int idx, WIZRACE r)
        {
            /*
            //種族                  //76543210 5-7bit
	        Wiz2Human	=	$00;    //00000000 人間
	        Wiz2Elf		=	$20;    //00100000 エルフ
	        Wiz2Dwarf	=	$40;	//01000000 ドワーフ
	        Wiz2Gnome	=	$60;	//01100000 ノーム
	        Wiz2Hobit	=	$80;	//10000000 ホビット
             */
            if ((idx < 0) || (idx >= CharCount))
            {
                return;
            }
            int adr = CharAdr(idx);
            if (m_Data[adr] == 0) return;
            if (CharRaceFromIndex(idx) == r) return;
            switch (m_scn)
            {
                case WIZSCN.FC1:
                    adr += 0x0A;
                    m_Data[adr] = (byte)((byte)r & 0x07);
                    OnValueChanged(new EventArgs());
                    break;
                case WIZSCN.FC2:
                case WIZSCN.FC3:
                case WIZSCN.GBC1:
                case WIZSCN.GBC2:
                case WIZSCN.GBC3:
                case WIZSCN.SFC1:
                case WIZSCN.SFC2:
                case WIZSCN.SFC3:
                case WIZSCN.SFC5:
                    adr += 0x0A;
                    byte v = m_Data[adr];
                    v = (byte)((v & 0x1F) + (((byte)r & 0x07) << 5));
                    m_Data[adr] = v;
                    OnValueChanged(new EventArgs());
                    break;
            }
        }
        // ************************************************************************
        public WIZRACE CharRace
        {
            get { return CharRaceFromIndex(m_CharCurrent);}
            set { SetCharRaceFromIndex(m_CharCurrent, value); }
        }
        // ************************************************************************
        public string CharRaceStr
        {
            get
            {
                WIZRACE idx = CharRaceFromIndex(m_CharCurrent);
                if ((idx >= WIZRACE.HUMAN) && (idx <= WIZRACE.HOBIT))
                {
                    return RaceStr[(int)idx];
                }
                else
                {
                    return "???";  
                }
            }
        }

        // ************************************************************************
        public WIZCLASS CharClassFromIndex(int idx)
        {
            WIZCLASS ret = WIZCLASS.FIG;
            if ((idx < 0) || (idx >= CharCount))
            {
                return ret;
            }
            int adr = CharAdr(idx);
            switch (m_scn)
            {
                case WIZSCN.FC1:
                    adr += 0x0B;
                    ret = (WIZCLASS)(m_Data[adr] & 0x07);
                    break;
                case WIZSCN.FC2:
                case WIZSCN.FC3:
                case WIZSCN.GBC1:
                case WIZSCN.GBC2:
                case WIZSCN.GBC3:
                case WIZSCN.SFC1:
                case WIZSCN.SFC2:
                case WIZSCN.SFC3:
                case WIZSCN.SFC5:
                    adr += 0x0A;
                    ret = (WIZCLASS)(m_Data[adr] >> 2 & 0x07);
                    break;
            }

            return ret;
        }
        // ************************************************************************
        public void SetCharClassFromIndex(int idx, WIZCLASS cl)
        {
            /*
             *
            職業                    //76543210 2-4bit
	        Wiz2Fighter	= $00;	    //00000000せんし
	        Wiz2Mage		= $04;	//00000100まほうつかい
	        Wiz2Priest	= $08;	    //00001000そうりょ
	        Wiz2Thief		= $0C;	//00001100シーフ
	        Wiz2Bishop	= $10;	    //00010000ビショップ
	        Wiz2Sumrai	= $14;	    //00010100サムライ
	        Wiz2Lord		= $18;	//00011000ロード
	        Wiz2Ninja		= $1C;	//00011100ニンジャ

             */
            if ((idx < 0) || (idx >= CharCount))
            {
                return;
            }
            int adr = CharAdr(idx);
            if (m_Data[adr] == 0) return;
            if (CharClassFromIndex(idx) == cl) return;

            switch (m_scn)
            {
                case WIZSCN.FC1:
                    adr += 0x0B;
                    m_Data[adr] = (byte)((byte)cl & 0x07);
                    OnValueChanged(new EventArgs());
                    break;
                case WIZSCN.FC2:
                case WIZSCN.FC3:
                case WIZSCN.GBC1:
                case WIZSCN.GBC2:
                case WIZSCN.GBC3:
                case WIZSCN.SFC1:
                case WIZSCN.SFC2:
                case WIZSCN.SFC3:
                case WIZSCN.SFC5:
                    adr += 0x0A;
                    byte v = m_Data[adr];
                    v = (byte)((v & 0xE3) | (((byte)cl & 0x07) << 2));
                    m_Data[adr] = v;
                    OnValueChanged(new EventArgs());
                    break;
            }
        }
        // ************************************************************************
        public WIZCLASS CharClass
        {
            get { return CharClassFromIndex(m_CharCurrent); }
            set { SetCharClassFromIndex(m_CharCurrent, value); }
        }
        public string CharClassStr
        {
            get
            {
                WIZCLASS idx = CharClassFromIndex(m_CharCurrent);
                if((idx>=WIZCLASS.FIG)&&(idx<=WIZCLASS.NIN))
                {
                    return ClassStr[(int)idx];
                }
                else
                {
                    return "???";
                }
            }
        }
        // ************************************************************************
        public WIZALG CharAlgFromIndex(int idx)
        {
            WIZALG ret = WIZALG.GOOD;
            if ((idx < 0) || (idx >= CharCount))
            {
                return ret;
            }
            int adr = CharAdr(idx);
            switch (m_scn)
            {
                case WIZSCN.FC1:
                    adr += 0x0C;
                    ret = (WIZALG)(m_Data[adr] & 0x03);
                    break;
                case WIZSCN.FC2:
                case WIZSCN.FC3:
                case WIZSCN.GBC1:
                case WIZSCN.GBC2:
                case WIZSCN.GBC3:
                case WIZSCN.SFC1:
                case WIZSCN.SFC2:
                case WIZSCN.SFC3:
                case WIZSCN.SFC5:
                    adr += 0x0A;
                    ret = (WIZALG)(m_Data[adr] & 0x03);
                    break;
                default:
                    return ret;
            }

            return ret;
        }
        // ************************************************************************
        public void SetCharAlgFromIndex(int idx, WIZALG alg)
        {
            /*
             * 
             * Const

           //属性                    //76543210 0-1Bit
	        Wiz2Good		=00;    //00000000 Ｇ
	        Wiz2Neutral	=01;		//00000001 Ｎ
	        Wiz2Evil		=02;	//00000010 Ｅ
	        Wiz2Etc			=03;	//00000011 ？ (？はどの属性とも組めるが、全ての装備が呪われるし、転職ができない。魔物？)
    */
            if ((idx < 0) || (idx >= CharCount))
            {
                return;
            }
            int adr = CharAdr(idx);
            if (m_Data[adr] == 0) return;
            if (CharAlgFromIndex(idx) == alg) return;
            switch (m_scn)
            {
                case WIZSCN.FC1:
                    adr += 0x0C;
                    m_Data[adr] = (byte)((byte)alg & 0x03);
                    OnValueChanged(new EventArgs());
                    break;
                case WIZSCN.FC2:
                case WIZSCN.FC3:
                case WIZSCN.GBC1:
                case WIZSCN.GBC2:
                case WIZSCN.GBC3:
                case WIZSCN.SFC1:
                case WIZSCN.SFC2:
                case WIZSCN.SFC3:
                case WIZSCN.SFC5:
                    //adr += 0x0A;
                    byte v = m_Data[adr + 0x0A];
                    v = (byte)((v & 0xFC) | (byte)alg);
                    m_Data[adr + 0x0A] = v;
                    OnValueChanged(new EventArgs());
                    break;
            }
        }
        // ************************************************************************
        public WIZALG CharAlg
        {
            get { return CharAlgFromIndex(m_CharCurrent); }
            set { SetCharAlgFromIndex(m_CharCurrent, value); }
        }
        // ************************************************************************
        public string CharAlgStr
        {
            get
            {
                WIZALG idx = CharAlgFromIndex(m_CharCurrent);
                if ((idx >= WIZALG.GOOD) && (idx <= WIZALG.EVIL))
                {
                    return AlgStr[(int)idx];
                }else
                {
                    return "???";
                }
            }
        }
        // ************************************************************************
        public ushort CharLevelFromIndex(int idx)
        {
            ushort ret = 1;
            if ((idx < 0) || (idx >= CharCount))
            {
                return ret;
            }
            int adr = CharAdr(idx);
            switch (m_scn)
            {
                case WIZSCN.FC1:
                    adr += 0x23;
                    ret = (ushort)((ushort)m_Data[adr] * 0x100 + (ushort)m_Data[adr + 1]);
                    break;
                case WIZSCN.FC2:
                case WIZSCN.FC3:
                    adr += 0x21;
                    ret = (ushort)((ushort)m_Data[adr] * 0x100 + (ushort)m_Data[adr + 1]);
                    break;
                case WIZSCN.GBC1:
                case WIZSCN.GBC2:
                case WIZSCN.GBC3:
                case WIZSCN.SFC1:
                case WIZSCN.SFC2:
                case WIZSCN.SFC3:
                case WIZSCN.SFC5:
                    adr += 0x21;
                    ret = (ushort)((ushort)m_Data[adr]  + (ushort)m_Data[adr + 1] * 0x100);
                    break;
                default:
                    return ret;
            }

            return ret;
        }
        // ************************************************************************
        public void SetCharLevelFromIndex(int idx,ushort v)
        {
            if ((idx < 0) || (idx >= CharCount))
            {
                return;
            }
            int adr = CharAdr(idx);
            if (m_Data[adr] == 0) return;
            if (v <= 0) v = 1;

            if (CharLevelFromIndex(idx) == v) return;
            switch (m_scn)
            {
                case WIZSCN.FC1:
                    adr += 0x23;
                    m_Data[adr] = (byte)((v >> 8) & 0xFF);
                    m_Data[adr+1] = (byte)(v & 0xFF);
                    OnValueChanged(new EventArgs());

                    break;
                case WIZSCN.FC2:
                case WIZSCN.FC3:
                    adr += 0x21;
                    m_Data[adr] = (byte)((v >> 8) & 0xFF);
                    m_Data[adr + 1] = (byte)(v & 0xFF);
                    OnValueChanged(new EventArgs());
                    break;
                case WIZSCN.GBC1:
                case WIZSCN.GBC2:
                case WIZSCN.GBC3:
                case WIZSCN.SFC1:
                case WIZSCN.SFC2:
                case WIZSCN.SFC3:
                case WIZSCN.SFC5:
                    adr += 0x21;
                    m_Data[adr] = (byte)((v >> 0) & 0xFF);
                    m_Data[adr + 1] = (byte)((v >> 8) & 0xFF);
                    OnValueChanged(new EventArgs());
                    break;
            }
        }
        // ************************************************************************
        public ushort CharLevel
        {
            get { return CharLevelFromIndex(m_CharCurrent); }
            set { SetCharLevelFromIndex(m_CharCurrent, value); }
        }
        // ************************************************************************
        public long CharGoldFromIndex(int idx)
        {
            long ret = 0;
            if ((idx < 0) || (idx >= CharCount))
            {
                return ret;
            }
            int adr = CharAdr(idx);
            switch (m_scn)
            {
                case WIZSCN.FC1:
                    adr += 0x13;
                    ret = WizU.WizHexToLong(GetCode(adr, 6));
                    break;
                case WIZSCN.FC2:
                case WIZSCN.FC3:
                case WIZSCN.GBC1:
                case WIZSCN.GBC2:
                case WIZSCN.GBC3:
                case WIZSCN.SFC1:
                case WIZSCN.SFC2:
                case WIZSCN.SFC3:
                case WIZSCN.SFC5:
                    adr += 0x11;
                    ret = WizU.WizHexToLong(GetCode(adr, 6));
                    break;
                default:
                    return ret;
            }

            return ret;
        }
        // ************************************************************************
        public void  SetCharGoldFromIndex(int idx,long v)
        {
            if ((idx < 0) || (idx >= CharCount))
            {
                return;
            }
            if (v < 0) v = 0;
            else if (v > 0xFFFFFFFFFFFF) v = 0xFFFFFFFFFFFF;

            int adr = CharAdr(idx);
            if (m_Data[adr] == 0) return;


            if (CharGoldFromIndex(idx) == v) return;


            byte[] va = WizU.LongToWizHex(v);
            switch (m_scn)
            {
                case WIZSCN.FC1:
                    adr += 0x13;
                    SetCode(adr, va);
                    OnValueChanged(new EventArgs());
                    break;
                case WIZSCN.FC2:
                case WIZSCN.FC3:
                case WIZSCN.GBC1:
                case WIZSCN.GBC2:
                case WIZSCN.GBC3:
                case WIZSCN.SFC1:
                case WIZSCN.SFC2:
                case WIZSCN.SFC3:
                case WIZSCN.SFC5:
                    adr += 0x11;
                    SetCode(adr, va);
                    OnValueChanged(new EventArgs());
                    break;
            }
        }
        // ************************************************************************
        public long CharGold
        {
            get { return CharGoldFromIndex(m_CharCurrent); }
            set { SetCharGoldFromIndex(m_CharCurrent, value); }
        }
        // ************************************************************************
        public long CharExpFromIndex(int idx)
        {
            long ret = 1;
            if ((idx < 0) || (idx >= CharCount))
            {
                return ret;
            }
            int adr = CharAdr(idx);
            switch (m_scn)
            {
                case WIZSCN.FC1:
                    adr += 0x19;
                    ret = WizU.WizHexToLong(GetCode(adr, 6));
                    break;
                case WIZSCN.FC2:
                case WIZSCN.FC3:
                case WIZSCN.GBC1:
                case WIZSCN.GBC2:
                case WIZSCN.GBC3:
                case WIZSCN.SFC1:
                case WIZSCN.SFC2:
                case WIZSCN.SFC3:
                case WIZSCN.SFC5:
                    adr += 0x17;
                    ret = WizU.WizHexToLong(GetCode(adr, 6));
                    break;
                default:
                    return ret;
            }

            return ret;
        }
        // ************************************************************************
        public void SetCharExpFromIndex(int idx,long v)
        {
            if ((idx < 0) || (idx >= CharCount))
            {
                return;
            }
            int adr = CharAdr(idx);
            if (m_Data[adr] == 0) return;
            if (CharExpFromIndex(idx) == v) return;
            byte[] va = WizU.LongToWizHex(v);

            switch (m_scn)
            {
                case WIZSCN.FC1:
                    adr += 0x19;
                    SetCode(adr, va);
                    OnValueChanged(new EventArgs());
                    break;
                case WIZSCN.FC2:
                case WIZSCN.FC3:
                case WIZSCN.GBC1:
                case WIZSCN.GBC2:
                case WIZSCN.GBC3:
                case WIZSCN.SFC1:
                case WIZSCN.SFC2:
                case WIZSCN.SFC3:
                case WIZSCN.SFC5:
                    adr += 0x17;
                    SetCode(adr, va);
                    OnValueChanged(new EventArgs());
                    break;
            }

            return;
        }
        // ************************************************************************
        public long CharExp
        {
            get { return CharExpFromIndex(m_CharCurrent); }
            set { SetCharExpFromIndex(m_CharCurrent, value); }
        }
        // ************************************************************************
        public sbyte CharAgeFromIndex(int idx)
        {
            sbyte ret = 0;
            if ((idx < 0) || (idx >= CharCount))
            {
                return ret;
            }
            int adr = CharAdr(idx);
            switch (m_scn)
            {
                case WIZSCN.FC1:
                    adr += 0x26;
                    ret = (sbyte)m_Data[adr];
                    break;
                case WIZSCN.FC2:
                case WIZSCN.FC3:
                case WIZSCN.GBC1:
                case WIZSCN.GBC2:
                case WIZSCN.GBC3:
                case WIZSCN.SFC1:
                case WIZSCN.SFC2:
                case WIZSCN.SFC3:
                case WIZSCN.SFC5:
                    adr += 0x24;
                    ret = (sbyte)m_Data[adr];
                    break;
                default:
                    return ret;
            }

            return ret;
        }
        public void SetCharAgeFromIndex(int idx, sbyte v)
        {
            if ((idx < 0) || (idx >= CharCount))
            {
                return;
            }
            if (v < -128) v = -128;
            else if (v > 127) v = 127;
            sbyte v2 = (sbyte)v;

            int adr = CharAdr(idx);
            if (m_Data[adr] == 0) return;

            if (CharAgeFromIndex(idx) == v2) return;


            switch (m_scn)
            {
                case WIZSCN.FC1:
                    adr += 0x26;
                    m_Data[adr] = (byte)v2;
                    OnValueChanged(new EventArgs());
                    break;
                case WIZSCN.FC2:
                case WIZSCN.FC3:
                case WIZSCN.GBC1:
                case WIZSCN.GBC2:
                case WIZSCN.GBC3:
                case WIZSCN.SFC1:
                case WIZSCN.SFC2:
                case WIZSCN.SFC3:
                case WIZSCN.SFC5:
                    adr += 0x24;
                    m_Data[adr] = (byte)v2;
                    OnValueChanged(new EventArgs());
                    break;
            }
        }
        // ************************************************************************
        public sbyte CharAge
        {
            get { return CharAgeFromIndex(m_CharCurrent); }
            set { SetCharAgeFromIndex(m_CharCurrent, value); }
        }
        // ************************************************************************
        public byte CharWeekFromIndex(int idx)
        {
            byte ret = 1;
            if ((idx < 0) || (idx >= CharCount))
            {
                return ret;
            }
            int adr = CharAdr(idx);
            switch (m_scn)
            {
                case WIZSCN.FC1:
                    adr += 0x27;
                    ret = (byte)m_Data[adr];
                    break;
                case WIZSCN.FC2:
                case WIZSCN.FC3:
                case WIZSCN.GBC1:
                case WIZSCN.GBC2:
                case WIZSCN.GBC3:
                case WIZSCN.SFC1:
                case WIZSCN.SFC2:
                case WIZSCN.SFC3:
                case WIZSCN.SFC5:
                    adr += 0x25;
                    ret = (byte)m_Data[adr];
                    break;
                default:
                    return ret;
            }

            return ret;
        }
        public void SetCharWeekFromIndex(int idx,byte v)
        {
            if ((idx < 0) || (idx >= CharCount))
            {
                return;
            }

            int adr = CharAdr(idx);
            if (m_Data[adr] == 0) return;

            if (CharWeekFromIndex(idx) == v) return;

            switch (m_scn)
            {
                case WIZSCN.FC1:
                    adr += 0x27;
                    m_Data[adr] = (byte)v;
                    OnValueChanged(new EventArgs());
                    break;
                case WIZSCN.FC2:
                case WIZSCN.FC3:
                case WIZSCN.GBC1:
                case WIZSCN.GBC2:
                case WIZSCN.GBC3:
                case WIZSCN.SFC1:
                case WIZSCN.SFC2:
                case WIZSCN.SFC3:
                case WIZSCN.SFC5:
                    adr += 0x25;
                    m_Data[adr] = (byte)v;
                    OnValueChanged(new EventArgs());
                    break;
            }
        }
        // ************************************************************************
        public byte CharWeek
        {
            get { return CharWeekFromIndex(m_CharCurrent); }
            set { SetCharWeekFromIndex(m_CharCurrent, value); }
        }
        // ************************************************************************
        public sbyte CharACFromIndex(int idx)
        {
            sbyte ret = 0;
            if ((idx < 0) || (idx >= CharCount))
            {
                return ret;
            }
            int adr = CharAdr(idx);
            switch (m_scn)
            {
                case WIZSCN.FC1:
                    adr += 0x28;
                    ret = (sbyte)m_Data[adr];
                    break;
                case WIZSCN.FC2:
                case WIZSCN.FC3:
                case WIZSCN.SFC1:
                case WIZSCN.SFC2:
                case WIZSCN.SFC3:
                case WIZSCN.SFC5:
                    adr += 0x26;
                    ret = (sbyte)m_Data[adr];
                    break;
                case WIZSCN.GBC1:
                case WIZSCN.GBC2:
                case WIZSCN.GBC3:
                    adr += 0x5C;
                    ret = (sbyte)m_Data[adr];
                    break;
                default:
                    return ret;
            }

            return ret;
        }
        public void SetCharACFromIndex(int idx, sbyte v)
        {
            if ((idx < 0) || (idx >= CharCount))
            {
                return;
            }
            if (v < -128) v = -128;
            else if (v > 127) v = 127;
            sbyte v2 = (sbyte)v;

            int adr = CharAdr(idx);
            if (m_Data[adr] == 0) return;

            if (CharACFromIndex(idx) == v2) return;

            switch (m_scn)
            {
                case WIZSCN.FC1:
                    adr += 0x28;
                    m_Data[adr] = (byte)v2;
                    OnValueChanged(new EventArgs());
                    break;
                case WIZSCN.FC2:
                case WIZSCN.FC3:
                case WIZSCN.SFC1:
                case WIZSCN.SFC2:
                case WIZSCN.SFC3:
                case WIZSCN.SFC5:
                    adr += 0x26;
                    m_Data[adr] = (byte)v2;
                    OnValueChanged(new EventArgs());
                    break;
                case WIZSCN.GBC1:
                case WIZSCN.GBC2:
                case WIZSCN.GBC3:
                    adr += 0x5C;
                    m_Data[adr] = (byte)v2;
                    OnValueChanged(new EventArgs());
                    break;
            }
        }
        // ************************************************************************
        public sbyte CharAC
        {
            get { return CharACFromIndex(m_CharCurrent); }
            set { SetCharACFromIndex(m_CharCurrent, value); }
        }
        // ************************************************************************
        public byte CharStrengthFromIndex(int idx)
        {
            byte ret = 0;
            if ((idx < 0) || (idx >= CharCount))
            {
                return ret;
            }
            int adr = CharAdr(idx);
            switch (m_scn)
            {
                case WIZSCN.FC1:
                    adr += 0x0D;
                    ret = (byte)m_Data[adr];
                    break;
                case WIZSCN.FC2:
                case WIZSCN.FC3:
                case WIZSCN.SFC1:
                case WIZSCN.SFC2:
                case WIZSCN.SFC3:
                case WIZSCN.SFC5:
                case WIZSCN.GBC1:
                case WIZSCN.GBC2:
                case WIZSCN.GBC3:
                    adr += 0x0B;
                    ret = (byte)m_Data[adr];
                    break;
                default:
                    return ret;
            }
            return ret;
        }
        // ************************************************************************
        public void SetCharStrengthFromIndex(int idx,byte v)
        {
            if ((idx < 0) || (idx >= CharCount))
            {
                return;
            }
            int adr = CharAdr(idx);
            if (m_Data[adr] == 0) return;

            if (CharStrengthFromIndex(idx) == v) return;
            switch (m_scn)
            {
                case WIZSCN.FC1:
                    adr += 0x0D;
                    m_Data[adr] = (byte)v;
                    OnValueChanged(new EventArgs());
                    break;
                case WIZSCN.FC2:
                case WIZSCN.FC3:
                case WIZSCN.SFC1:
                case WIZSCN.SFC2:
                case WIZSCN.SFC3:
                case WIZSCN.SFC5:
                case WIZSCN.GBC1:
                case WIZSCN.GBC2:
                case WIZSCN.GBC3:
                    adr += 0x0B;
                    m_Data[adr] = (byte)v;
                    OnValueChanged(new EventArgs());
                    break;
            }
        }
        // ************************************************************************
        public byte CharStrength
        {
            get { return CharStrengthFromIndex(m_CharCurrent); }
            set { SetCharStrengthFromIndex(m_CharCurrent, value); }
        }
        // ************************************************************************
        public byte CharIQFromIndex(int idx)
        {
            byte ret = 0;
            if ((idx < 0) || (idx >= CharCount))
            {
                return ret;
            }
            int adr = CharAdr(idx);
            switch (m_scn)
            {
                case WIZSCN.FC1:
                    adr += 0x0E;
                    ret = (byte)m_Data[adr];
                    break;
                case WIZSCN.FC2:
                case WIZSCN.FC3:
                case WIZSCN.SFC1:
                case WIZSCN.SFC2:
                case WIZSCN.SFC3:
                case WIZSCN.SFC5:
                case WIZSCN.GBC1:
                case WIZSCN.GBC2:
                case WIZSCN.GBC3:
                    adr += 0x0C;
                    ret = (byte)m_Data[adr];
                    break;
                default:
                    return ret;
            }
            return ret;
        }
        // ************************************************************************
        public void SetCharIQFromIndex(int idx, byte v)
        {
            if ((idx < 0) || (idx >= CharCount))
            {
                return;
            }
            if (v < 0) v = 0;
            else if (v > 0xFF) v = 0xFF;

            int adr = CharAdr(idx);
            if (m_Data[adr] == 0) return;
            if (CharIQFromIndex(idx) == v) return;

            switch (m_scn)
            {
                case WIZSCN.FC1:
                    adr += 0x0E;
                    m_Data[adr] = (byte)v;
                    OnValueChanged(new EventArgs());
                    break;
                case WIZSCN.FC2:
                case WIZSCN.FC3:
                case WIZSCN.SFC1:
                case WIZSCN.SFC2:
                case WIZSCN.SFC3:
                case WIZSCN.SFC5:
                case WIZSCN.GBC1:
                case WIZSCN.GBC2:
                case WIZSCN.GBC3:
                    adr += 0x0C;
                    m_Data[adr] = (byte)v;
                    OnValueChanged(new EventArgs());
                    break;
            }
        }
        // ************************************************************************
        public byte CharIQ
        {
            get { return CharIQFromIndex(m_CharCurrent); }
            set { SetCharIQFromIndex(m_CharCurrent, value); }
        }
        // ************************************************************************
        public byte CharPietyFromIndex(int idx)
        {
            byte ret = 0;
            if ((idx < 0) || (idx >= CharCount))
            {
                return ret;
            }
            int adr = CharAdr(idx);
            switch (m_scn)
            {
                case WIZSCN.FC1:
                    adr += 0x0F;
                    ret = (byte)m_Data[adr];
                    break;
                case WIZSCN.FC2:
                case WIZSCN.FC3:
                case WIZSCN.SFC1:
                case WIZSCN.SFC2:
                case WIZSCN.SFC3:
                case WIZSCN.SFC5:
                case WIZSCN.GBC1:
                case WIZSCN.GBC2:
                case WIZSCN.GBC3:
                    adr += 0x0D;
                    ret = (byte)m_Data[adr];
                    break;
                default:
                    return ret;
            }
            return ret;
        }
        // ************************************************************************
        public void SetCharPietyFromIndex(int idx, byte v)
        {
            if ((idx < 0) || (idx >= CharCount))
            {
                return;
            }
            if (v < 0) v = 0;
            else if (v > 0xFF) v = 0xFF;

            int adr = CharAdr(idx);
            if (m_Data[adr] == 0) return;
            if (CharPietyFromIndex(idx) == v) return;

            switch (m_scn)
            {
                case WIZSCN.FC1:
                    adr += 0x0F;
                    m_Data[adr] = (byte)v;
                    OnValueChanged(new EventArgs());
                    break;
                case WIZSCN.FC2:
                case WIZSCN.FC3:
                case WIZSCN.SFC1:
                case WIZSCN.SFC2:
                case WIZSCN.SFC3:
                case WIZSCN.SFC5:
                case WIZSCN.GBC1:
                case WIZSCN.GBC2:
                case WIZSCN.GBC3:
                    adr += 0x0D;
                    m_Data[adr] = (byte)v;
                    OnValueChanged(new EventArgs());
                    break;
            }
        }
        // ************************************************************************
        public byte CharPiety
        {
            get { return CharPietyFromIndex(m_CharCurrent); }
            set { SetCharPietyFromIndex(m_CharCurrent, value); }
        }
        // ************************************************************************
        public byte CharVitarityFromIndex(int idx)
        {
            byte ret = 0;
            if ((idx < 0) || (idx >= CharCount))
            {
                return ret;
            }
            int adr = CharAdr(idx);
            switch (m_scn)
            {
                case WIZSCN.FC1:
                    adr += 0x10;
                    ret = (byte)m_Data[adr];
                    break;
                case WIZSCN.FC2:
                case WIZSCN.FC3:
                case WIZSCN.SFC1:
                case WIZSCN.SFC2:
                case WIZSCN.SFC3:
                case WIZSCN.SFC5:
                case WIZSCN.GBC1:
                case WIZSCN.GBC2:
                case WIZSCN.GBC3:
                    adr += 0x0E;
                    ret = (byte)m_Data[adr];
                    break;
                default:
                    return ret;
            }
            return ret;
        }
        // ************************************************************************
        public void SetCharVitarityFromIndex(int idx, byte v)
        {
            if ((idx < 0) || (idx >= CharCount))
            {
                return;
            }
            if (v < 0) v = 0;
            else if (v > 0xFF) v = 0xFF;

            int adr = CharAdr(idx);
            if (m_Data[adr] == 0) return;

            if (CharVitarityFromIndex(idx) == v) return;
            switch (m_scn)
            {
                case WIZSCN.FC1:
                    adr += 0x10;
                    m_Data[adr] = (byte)v;
                    OnValueChanged(new EventArgs());
                    break;
                case WIZSCN.FC2:
                case WIZSCN.FC3:
                case WIZSCN.SFC1:
                case WIZSCN.SFC2:
                case WIZSCN.SFC3:
                case WIZSCN.SFC5:
                case WIZSCN.GBC1:
                case WIZSCN.GBC2:
                case WIZSCN.GBC3:
                    adr += 0x0E;
                    m_Data[adr] = (byte)v;
                    OnValueChanged(new EventArgs());
                    break;
            }
        }
        // ************************************************************************
        public byte CharVitarity
        {
            get { return CharVitarityFromIndex(m_CharCurrent); }
            set { SetCharVitarityFromIndex(m_CharCurrent, value); }
        }
        // ************************************************************************
        public byte CharAgilityFromIndex(int idx)
        {
            byte ret = 0;
            if ((idx < 0) || (idx >= CharCount))
            {
                return ret;
            }
            int adr = CharAdr(idx);
            switch (m_scn)
            {
                case WIZSCN.FC1:
                    adr += 0x11;
                    ret = (byte)m_Data[adr];
                    break;
                case WIZSCN.FC2:
                case WIZSCN.FC3:
                case WIZSCN.SFC1:
                case WIZSCN.SFC2:
                case WIZSCN.SFC3:
                case WIZSCN.SFC5:
                case WIZSCN.GBC1:
                case WIZSCN.GBC2:
                case WIZSCN.GBC3:
                    adr += 0x0F;
                    ret = (byte)m_Data[adr];
                    break;
                default:
                    return ret;
            }
            return ret;
        }
        // ************************************************************************
        public void SetCharAgilityFromIndex(int idx, byte v)
        {
            if ((idx < 0) || (idx >= CharCount))
            {
                return;
            }
            if (v < 0) v = 0;
            else if (v > 0xFF) v = 0xFF;

            int adr = CharAdr(idx);
            if (m_Data[adr] == 0) return;

            if (CharAgilityFromIndex(idx) == v) return;

            switch (m_scn)
            {
                case WIZSCN.FC1:
                    adr += 0x11;
                    m_Data[adr] = (byte)v;
                    OnValueChanged(new EventArgs());
                    break;
                case WIZSCN.FC2:
                case WIZSCN.FC3:
                case WIZSCN.SFC1:
                case WIZSCN.SFC2:
                case WIZSCN.SFC3:
                case WIZSCN.SFC5:
                case WIZSCN.GBC1:
                case WIZSCN.GBC2:
                case WIZSCN.GBC3:
                    adr += 0x0F;
                    m_Data[adr] = (byte)v;
                    OnValueChanged(new EventArgs());
                    break;
            }
        }
        // ************************************************************************
        public byte CharAgility
        {
            get { return CharAgilityFromIndex(m_CharCurrent); }
            set { SetCharAgilityFromIndex(m_CharCurrent, value); }
        }
        // ************************************************************************
        public byte CharLuckFromIndex(int idx)
        {
            byte ret = 0;
            if ((idx < 0) || (idx >= CharCount))
            {
                return ret;
            }
            int adr = CharAdr(idx);
            switch (m_scn)
            {
                case WIZSCN.FC1:
                    adr += 0x12;
                    ret = (byte)m_Data[adr];
                    break;
                case WIZSCN.FC2:
                case WIZSCN.FC3:
                case WIZSCN.SFC1:
                case WIZSCN.SFC2:
                case WIZSCN.SFC3:
                case WIZSCN.SFC5:
                case WIZSCN.GBC1:
                case WIZSCN.GBC2:
                case WIZSCN.GBC3:
                    adr += 0x10;
                    ret = (byte)m_Data[adr];
                    break;
                default:
                    return ret;
            }
            return ret;
        }
        // ************************************************************************
        public void SetCharLuckFromIndex(int idx, byte v)
        {
            if ((idx < 0) || (idx >= CharCount))
            {
                return;
            }
            if (v < 0) v = 0;
            else if (v > 0xFF) v = 0xFF;

            int adr = CharAdr(idx);
            if (m_Data[adr] == 0) return;

            if (CharLuckFromIndex(idx) == v) return;

            switch (m_scn)
            {
                case WIZSCN.FC1:
                    adr += 0x12;
                    m_Data[adr] = (byte)v;
                    OnValueChanged(new EventArgs());
                    break;
                case WIZSCN.FC2:
                case WIZSCN.FC3:
                case WIZSCN.SFC1:
                case WIZSCN.SFC2:
                case WIZSCN.SFC3:
                case WIZSCN.SFC5:
                case WIZSCN.GBC1:
                case WIZSCN.GBC2:
                case WIZSCN.GBC3:
                    adr += 0x10;
                    m_Data[adr] = (byte)v;
                    OnValueChanged(new EventArgs());
                    break;
            }
        }
        // ************************************************************************
        public byte CharLuck
        {
            get { return CharLuckFromIndex(m_CharCurrent); }
            set { SetCharLuckFromIndex(m_CharCurrent, value); }
        }
        
        // ************************************************************************
        public ushort CharHPFromIndex(int idx)
        {
            ushort ret = 0;

            if ((idx < 0) || (idx >= CharCount))
            {
                return ret;
            }
            int adr = CharAdr(idx);
            switch (m_scn)
            {
                case WIZSCN.FC1:
                    adr += 0x1F;
                    ret = (ushort)((ushort)m_Data[adr] * 0x100 + (ushort)m_Data[adr+1] );
                    break;
                case WIZSCN.FC2:
                case WIZSCN.FC3:
                    adr += 0x1D;
                    ret = (ushort)((ushort)m_Data[adr] + (ushort)m_Data[adr + 1] * 0x100);
                    break;
                case WIZSCN.SFC1:
                case WIZSCN.SFC2:
                case WIZSCN.SFC3:
                case WIZSCN.SFC5:
                case WIZSCN.GBC1:
                case WIZSCN.GBC2:
                case WIZSCN.GBC3:
                    adr += 0x1D;
                    ret = (ushort)((ushort)m_Data[adr] + (ushort)m_Data[adr + 1] * 0x100 );
                    break;
                default:
                    return ret;
            }

            return ret;
        }
        // ************************************************************************
        public void SetCharHPFromIndex(int idx,ushort v)
        {
            if ((idx < 0) || (idx >= CharCount))
            {
                return;
            }
            int adr = CharAdr(idx);
            if (v < 0) v = 0;
            else if (v > 0xFFFF) v = 0xFFFF;

            if (m_Data[adr] == 0) return;

            if (CharHPFromIndex(idx) == v) return;

            switch (m_scn)
            {
                case WIZSCN.FC1:
                    adr += 0x1F;
                    m_Data[adr] = (byte)((v >> 8) & 0xFF);
                    m_Data[adr+1] = (byte)(v  & 0xFF);
                    OnValueChanged(new EventArgs());
                    break;
                case WIZSCN.FC2:
                case WIZSCN.FC3:
                    adr += 0x1D;
                    m_Data[adr] = (byte)((v >> 0) & 0xFF);
                    m_Data[adr + 1] = (byte)((v >> 8) & 0xFF);
                    OnValueChanged(new EventArgs());
                    break;
                case WIZSCN.SFC1:
                case WIZSCN.SFC2:
                case WIZSCN.SFC3:
                case WIZSCN.SFC5:
                case WIZSCN.GBC1:
                case WIZSCN.GBC2:
                case WIZSCN.GBC3:
                    adr += 0x1D;
                    m_Data[adr] = (byte)((v >> 0) & 0xFF);
                    m_Data[adr + 1] = (byte)((v>>8) & 0xFF);
                    OnValueChanged(new EventArgs());
                    break;
            }
        }
        // ************************************************************************
        public ushort CharHP
        {
            get { return CharHPFromIndex(m_CharCurrent); }
            set { SetCharHPFromIndex(m_CharCurrent, value); }
        }
        // ************************************************************************
        public ushort CharHPMaxFromIndex(int idx)
        {
            ushort ret = 0;

            if ((idx < 0) || (idx >= CharCount))
            {
                return ret;
            }
            int adr = CharAdr(idx);

            switch (m_scn)
            {
                case WIZSCN.FC1:
                    adr += 0x21;
                    ret = (ushort)((ushort)m_Data[adr] * 0x100 + (ushort)m_Data[adr + 1]);
                    break;
                case WIZSCN.FC2:
                case WIZSCN.FC3:
                    adr += 0x1F;
                    ret = (ushort)((ushort)m_Data[adr] + (ushort)m_Data[adr + 1] * 0x100);
                    break;
                case WIZSCN.SFC1:
                case WIZSCN.SFC2:
                case WIZSCN.SFC3:
                case WIZSCN.SFC5:
                case WIZSCN.GBC1:
                case WIZSCN.GBC2:
                case WIZSCN.GBC3:
                    adr += 0x1F;
                    ret = (ushort)((ushort)m_Data[adr]  + (ushort)m_Data[adr + 1] * 0x100);
                    break;
                default:
                    return ret;
            }

            return ret;
        }
        // ************************************************************************
        public void SetCharHPMaxFromIndex(int idx, ushort v)
        {
            if ((idx < 0) || (idx >= CharCount))
            {
                return;
            }
            int adr = CharAdr(idx);
            if (v < 0) v = 0;
            else if (v > 0xFFFF) v = 0xFFFF;
            if (m_Data[adr] == 0) return;
            if (CharHPMaxFromIndex(idx) == v) return;

            switch (m_scn)
            {
                case WIZSCN.FC1:
                    adr += 0x21;
                    m_Data[adr] = (byte)((v >> 8) & 0xFF);
                    m_Data[adr + 1] = (byte)(v & 0xFF);
                    OnValueChanged(new EventArgs());
                    break;
                case WIZSCN.FC2:
                case WIZSCN.FC3:
                    adr += 0x1F;
                    m_Data[adr] = (byte)((v >> 0) & 0xFF);
                    m_Data[adr + 1] = (byte)((v >> 8) & 0xFF);
                    OnValueChanged(new EventArgs());
                    break;
                case WIZSCN.SFC1:
                case WIZSCN.SFC2:
                case WIZSCN.SFC3:
                case WIZSCN.SFC5:
                case WIZSCN.GBC1:
                case WIZSCN.GBC2:
                case WIZSCN.GBC3:
                    adr += 0x1F;
                    m_Data[adr] = (byte)((v >> 0) & 0xFF);
                    m_Data[adr + 1] = (byte)((v >>8) & 0xFF);
                    OnValueChanged(new EventArgs());
                    break;
            }
        }
        // ************************************************************************
        public ushort CharHPMax
        {
            get { return CharHPMaxFromIndex(m_CharCurrent); }
            set { SetCharHPMaxFromIndex(m_CharCurrent, value); }
        }
        // ************************************************************************
        public WIZSTATUS CharStatusFromIndex(int idx)
        {
            WIZSTATUS ret = WIZSTATUS.OK;

            if ((idx < 0) || (idx >= CharCount))
            {
                return ret;
            }
            int adr = CharAdr(idx);
            int v = 0;
            switch (m_scn)
            {
                case WIZSCN.FC1:
                    adr += 0x25;
                    v = (int)(m_Data[adr] & 0x7);
                    break;
                case WIZSCN.FC2:
                case WIZSCN.FC3:
                case WIZSCN.SFC1:
                case WIZSCN.SFC2:
                case WIZSCN.SFC3:
                case WIZSCN.SFC5:
                case WIZSCN.GBC1:
                case WIZSCN.GBC2:
                case WIZSCN.GBC3:
                    adr += 0x23;
                    v = (int)(m_Data[adr] & 0x7);
                    break;
                default:
                    return ret;
            }
            ret = (WIZSTATUS)v;

            return ret;
        }
        // ************************************************************************
        public void SetCharStatusFromIndex(int idx, WIZSTATUS v)
        {
            if ((idx < 0) || (idx >= CharCount))
            {
                return;
            }
            int adr = CharAdr(idx);
            if (m_Data[adr] == 0) return;
            if (CharStatusFromIndex(idx) == v) return;
            byte v2 = (byte)((byte)v & 0x0F);
            switch (m_scn)
            {
                case WIZSCN.FC1:
                    adr += 0x25;
                    m_Data[adr] = v2;
                    OnValueChanged(new EventArgs());
                    break;
                case WIZSCN.FC2:
                case WIZSCN.FC3:
                case WIZSCN.SFC1:
                case WIZSCN.SFC2:
                case WIZSCN.SFC3:
                case WIZSCN.SFC5:
                case WIZSCN.GBC1:
                case WIZSCN.GBC2:
                case WIZSCN.GBC3:
                    adr += 0x23;
                    m_Data[adr] = v2;
                    OnValueChanged(new EventArgs());
                    break;
            }
        }
        // ************************************************************************
        public WIZSTATUS CharStatus
        {
            get { return CharStatusFromIndex(m_CharCurrent); }
            set { SetCharStatusFromIndex(m_CharCurrent, value); }
        }
        // ************************************************************************
        public string CharStatusStr
        {
            get
            {
                WIZSTATUS s = CharStatusFromIndex(m_CharCurrent);
                return StatusStrJ[ (int)s];
            }
        }
        // ************************************************************************
        public byte[] CharDataFromIndex(int idx)
        {
            int sz = CharSize;
            byte[] ret = new byte[sz];
            if (sz <= 0) return ret;
            if ((idx < 0) || (idx >= CharCount)) return ret;

            return GetCode(CharAdr(idx), sz);

        }
        // ************************************************************************
        public void SetCharDataFromIndex(int idx,byte[] a)
        {
            if ((idx < 0) || (idx >= CharCount)) return;
            if(a.Length != CharSize)
            {
                return;
            }
            SetCode(idx, a);

        }
 
        // ************************************************************************
        public MagicPoint CharMagicFromIndex(int idx)
        {
            MagicPoint ret = new MagicPoint();

            if ((idx < 0) || (idx >= CharCount))
            {
                return ret;
            }
            int adr = CharAdr(idx);
            switch (m_scn)
            {
                case WIZSCN.FC1:
                    ret.NowP = GetCode(adr + 0x29, 7);
                    ret.MaxP = GetCode(adr + 0x37, 7);
                    ret.Learning = GetCode(adr + 0x45, 7);
                    break;
                case WIZSCN.FC2:
                case WIZSCN.FC3:
                case WIZSCN.SFC1:
                case WIZSCN.SFC2:
                case WIZSCN.SFC3:
                case WIZSCN.SFC5:
                    byte [] a = GetCode(adr + 0x27, 7);
                    for ( int i=0; i<7; i++)
                    {
                        ret.NowP[i] = (byte)((a[i] >> 4) & 0xF);
                        ret.MaxP[i] = (byte)(a[i] & 0xF);
                    }
                    ret.Learning = GetCode(adr + 0x35, 7);
                    break;
                case WIZSCN.GBC1:
                case WIZSCN.GBC2:
                case WIZSCN.GBC3:
                    byte[] a2 = GetCode(adr + 0x26, 7);
                    for (int i = 0; i < 7; i++)
                    {
                        ret.NowP[i] = (byte)((a2[i] >> 4) & 0xF);
                        ret.MaxP[i] = (byte)(a2[i] & 0xF);
                    }
                    ret.Learning = GetCode(adr + 0x34, 7);
                    break;
                default:
                    return ret;
            }
            return ret;

        }
        // ************************************************************************
        public void SetCharMagicFromIndex(int idx, MagicPoint mp)
        {
            if ((idx < 0) || (idx >= CharCount))
            {
                return;
            }
            int adr = CharAdr(idx);
            if (m_Data[adr] == 0) return;

            switch (m_scn)
            {
                case WIZSCN.FC1:
                    SetCode(adr + 0x29, mp.NowP);
                    SetCode(adr + 0x37, mp.MaxP);
                    break;
                case WIZSCN.FC2:
                case WIZSCN.FC3:
                case WIZSCN.SFC1:
                case WIZSCN.SFC2:
                case WIZSCN.SFC3:
                case WIZSCN.SFC5:
                    byte[] aa = new byte[7];
                    for (int i = 0; i < 7; i++)
                    {
                        aa[i] = (byte)((byte)((byte)(mp.NowP[i]) & 0x0F) << 4 | (byte)((byte)(mp.MaxP[i]) & 0x0F));
                    }
                    SetCode(adr + 0x27, aa);
                    break;
                case WIZSCN.GBC1:
                case WIZSCN.GBC2:
                case WIZSCN.GBC3:
                    byte[] aa2 = new byte[7];
                    for (int i = 0; i < 7; i++)
                    {
                        aa2[i] = (byte)((byte)((byte)(mp.NowP[i]) & 0x0F) << 4 | (byte)((byte)(mp.MaxP[i]) & 0x0F));
                    }
                    SetCode(adr + 0x26, aa2);
                    break;
            }

        }        
        // ************************************************************************
        public MagicPoint CharMagic
        {
            get { return CharMagicFromIndex(m_CharCurrent); }
            set { SetCharMagicFromIndex(m_CharCurrent, value); }
        }
        // ************************************************************************
        public MagicPoint CharPriestFromIndex(int idx)
        {
            MagicPoint ret = new MagicPoint();

            if ((idx < 0) || (idx >= CharCount))
            {
                return ret;
            }
            int adr = CharAdr(idx);
            switch (m_scn)
            {
                case WIZSCN.FC1:
                    ret.NowP = GetCode(adr + 0x30, 7);
                    ret.MaxP = GetCode(adr + 0x3E, 7);
                    ret.Learning = GetCode(adr + 0x45, 7);
                    break;
                case WIZSCN.FC2:
                case WIZSCN.FC3:
                case WIZSCN.SFC1:
                case WIZSCN.SFC2:
                case WIZSCN.SFC3:
                case WIZSCN.SFC5:
                    byte[] a = GetCode(adr + 0x2E, 7);
                    for (int i = 0; i < 7; i++)
                    {
                        ret.NowP[i] = (byte)((a[i] >> 4) & 0xF);
                        ret.MaxP[i] = (byte)(a[i] & 0xF);
                    }
                    ret.Learning = GetCode(adr + 0x3C, 7);
                    break;
                case WIZSCN.GBC1:
                case WIZSCN.GBC2:
                case WIZSCN.GBC3:
                    byte[] a2 = GetCode(adr + 0x2D, 7);
                    for (int i = 0; i < 7; i++)
                    {
                        ret.NowP[i] = (byte)((a2[i] >> 4) & 0xF);
                        ret.MaxP[i] = (byte)(a2[i] & 0xF);
                    }
                    ret.Learning = GetCode(adr + 0x3B, 7);
                    break;
                default:
                    return ret;
            }
            return ret;

        }
        // ************************************************************************
        public void SetCharPriestFromIndex(int idx, MagicPoint mp)
        {
            if ((idx < 0) || (idx >= CharCount))
            {
                return;
            }
            int adr = CharAdr(idx);
            if (m_Data[adr] == 0) return;

            switch (m_scn)
            {
                case WIZSCN.FC1:
                    SetCode(adr + 0x30, mp.NowP);
                    SetCode(adr + 0x3E, mp.MaxP);
                    break;
                case WIZSCN.FC2:
                case WIZSCN.FC3:
                case WIZSCN.SFC1:
                case WIZSCN.SFC2:
                case WIZSCN.SFC3:
                case WIZSCN.SFC5:
                    byte[] aa = new byte[7];
                    for (int i = 0; i < 7; i++)
                    {
                        aa[i] = (byte)((byte)((byte)(mp.NowP[i]) & 0x0F) << 4 | (byte)((byte)(mp.MaxP[i]) & 0x0F));
                    }
                    SetCode(adr + 0x2E, aa);
                    break;
                case WIZSCN.GBC1:
                case WIZSCN.GBC2:
                case WIZSCN.GBC3:
                    byte[] aa2 = new byte[7];
                    for (int i = 0; i < 7; i++)
                    {
                        aa2[i] = (byte)((byte)((byte)(mp.NowP[i]) & 0x0F) << 4 | (byte)((byte)(mp.MaxP[i]) & 0x0F));
                    }
                    SetCode(adr + 0x2D, aa2);
                    break;
            }

        }
        // ************************************************************************
        public MagicPoint CharPriest
        {
            get { return CharPriestFromIndex(m_CharCurrent); }
            set { SetCharPriestFromIndex(m_CharCurrent, value); }
        }
        // ************************************************************************
        public WizItem CharItemFromIndex(int c_idx,int i_idx)
        {
            WizItem ret = new WizItem(m_scn);
            if ((c_idx < 0) || (c_idx >= CharCount))
            {
                return ret;
            }
            if ((i_idx < 0) || (i_idx >= 8))
            {
                return ret;
            }
            int adr = CharAdr(c_idx);
            int cnt = 0;
            switch (m_scn)
            {
                case WIZSCN.FC1:
                    cnt = m_Data[adr + 0x5C];
                    if (i_idx < cnt)
                    {
                        ret.ID = m_Data[adr + 0x54 + i_idx];
                        ret.Status = m_Data[adr + 0x4C + i_idx];
                    }
                    break;
                case WIZSCN.FC2:
                case WIZSCN.FC3:
                case WIZSCN.SFC1:
                case WIZSCN.SFC2:
                case WIZSCN.SFC3:
                case WIZSCN.SFC5:
                    cnt = m_Data[adr + 0x53];
                    if (i_idx < cnt)
                    {
                        ret.ID = m_Data[adr + 0x4B + i_idx];
                        ret.Status = m_Data[adr + 0x43 + i_idx];
                    }
                    break;
                case WIZSCN.GBC1:
                case WIZSCN.GBC2:
                case WIZSCN.GBC3:
                    cnt = m_Data[adr + 0x52];
                    if (i_idx < cnt)
                    {
                        ret.ID = m_Data[adr + 0x4A + i_idx];
                        ret.Status = m_Data[adr + 0x42 + i_idx];
                    }
                    break;
                default:
                    return ret;
            }
            return ret;

        }
        // ************************************************************************
        public void  SetCharItemFromIndex(int c_idx, int i_idx,WizItem wi)
        {
            if ((c_idx < 0) || (c_idx >= CharCount))
            {
                return;
            }
            if ((i_idx < 0) || (i_idx >= 8))
            {
                return;
            }
            int adr = CharAdr(c_idx);
            if (m_Data[adr] == 0) return;
            int cnt = 0;
            bool upd = false;
            int ad = 0;
            switch (m_scn)
            {
                case WIZSCN.FC1:
                    cnt = m_Data[adr + 0x5C];
                    if (i_idx < cnt)
                    {
                        ad = adr + 0x54 + i_idx;
                        if (m_Data[ad] != wi.ID)
                        {
                            m_Data[ad] = wi.ID;
                            upd = true;
                        }
                        ad = adr + 0x4C + i_idx;
                        if (m_Data[ad] != wi.Status)
                        {
                            m_Data[ad] = wi.Status;
                            upd = true;
                        }
                    }
                    break;
                case WIZSCN.FC2:
                case WIZSCN.FC3:
                case WIZSCN.SFC1:
                case WIZSCN.SFC2:
                case WIZSCN.SFC3:
                case WIZSCN.SFC5:
                    cnt = m_Data[adr + 0x53];
                    if (i_idx < cnt)
                    {
                        ad = adr + 0x4B + i_idx;
                        if (m_Data[ad] != wi.ID)
                        {
                            m_Data[ad] = wi.ID;
                            upd = true;
                        }
                        ad = adr + 0x43 + i_idx;
                        if (m_Data[ad] != wi.Status)
                        {
                            m_Data[ad] = wi.Status;
                            upd = true;
                        }
                    }
                    break;
                case WIZSCN.GBC1:
                case WIZSCN.GBC2:
                case WIZSCN.GBC3:
                    cnt = m_Data[adr + 0x52];
                    if (i_idx < cnt)
                    {
                        ad = adr + 0x4A + i_idx;
                        if (m_Data[ad] != wi.ID)
                        {
                            m_Data[ad] = wi.ID;
                            upd = true;
                        }
                        ad = adr + 0x42 + i_idx;
                        if (m_Data[ad] != wi.Status)
                        {
                            m_Data[ad] = wi.Status;
                            upd = true;
                        }
                    }
                    break;
            }
            if (upd==true)
            {
                OnValueChanged(new EventArgs());
            }

        }
        // ************************************************************************
        public byte [] CharSpellFromIndex(int idx)
        {
            byte[] ret = new byte[0];
            if ((idx < 0) || (idx >= CharCount))
            {
                return ret;
            }
            int adr = CharAdr(idx);
            switch (m_scn)
            {
                case WIZSCN.FC1:
                    adr += 0x45;
                    ret = new byte[14];
                    for (int i = 0; i < 14; i++) ret[i] = 0;

                    byte[] a = GetCode(adr, 7);
                    for (int i = 0; i < 7; i++) 
                    {
                        int cnt = Wiz1FCSpellTo[i].Length;
                        byte v = a[i];
                        for ( int j=0; j<cnt;j++)
                        {
                            if ((v & 0x01)==1)
                            {
                                int bit = Wiz1FCSpellTo[i][j] & 0xFF;
                                int ti = (Wiz1FCSpellTo[i][j] >> 8) & 0xFF;
                                ret[ti] = (byte)(ret[ti] | bit);

                            }
                            v = (byte)(v >> 1);
                        }
                    }

                    break;
                case WIZSCN.FC2:
                case WIZSCN.FC3:
                case WIZSCN.SFC1:
                case WIZSCN.SFC2:
                case WIZSCN.SFC3:
                case WIZSCN.SFC5:
                    adr += 0x35;
                    ret = GetCode(adr, 14);
                    break;
                case WIZSCN.GBC1:
                case WIZSCN.GBC2:
                case WIZSCN.GBC3:
                    adr += 0x34;
                    ret = GetCode(adr, 14);
                    break;
                default:
                    return ret;
            }
            return ret;
        }
        // ************************************************************************
        public void SetCharSpellFromIndex(int idx, byte[] a)
        {
            if ((idx < 0) || (idx >= CharCount))
            {
                return;
            }
            int adr = CharAdr(idx);
            if (m_Data[adr] == 0) return;
            switch (m_scn)
            {
                case WIZSCN.FC1:
                    adr += 0x45;
                    if (a.Length == 14)
                    {
                        byte[] b = new byte[7];
                        for (int i = 0; i < 7; i++) b[i] = 0;

                        for (int i = 0; i < 14; i++)
                        {
                            int bb = a[i];
                            int cnt = Wiz1FCSpellFrom[i].Length;
                            for (int j = 0; j < cnt; j++)
                            {
                                if ((bb & 0x01) == 1)
                                {
                                    int bit = Wiz1FCSpellFrom[i][j] & 0xFF;
                                    int ix = (Wiz1FCSpellFrom[i][j]>>8) & 0xFF;
                                    b[ix] = (byte)(b[ix] | bit);
                                }
                                bb = (byte)(bb >> 1);
                            }
                        }


                        SetCode(adr, b);
                    }
                    break;
                case WIZSCN.FC2:
                case WIZSCN.FC3:
                case WIZSCN.SFC1:
                case WIZSCN.SFC2:
                case WIZSCN.SFC3:
                case WIZSCN.SFC5:
                    adr += 0x35;
                    if (a.Length == 14)
                    {
                        SetCode(adr, a);
                    }
                    break;
                case WIZSCN.GBC1:
                case WIZSCN.GBC2:
                case WIZSCN.GBC3:
                    adr += 0x34;
                    if (a.Length == 14)
                    {
                        SetCode(adr, a);
                    }
                    break;
            }
        }
        // ************************************************************************
        public byte[] CharSpell
        {
            get { return CharSpellFromIndex(m_CharCurrent); }
            set { SetCharSpellFromIndex(m_CharCurrent, value); }
        }
        // ************************************************************************
        public WizItem [] CharItemsFromIndex(int idx)
        {
            WizItem[] ret = new WizItem[0];
            if ((idx < 0) || (idx >= CharCount))
            {
                return ret;
            }
            int adr = CharAdr(idx);
            int cnt = 0;
            switch (m_scn)
            {
                case WIZSCN.FC1:
                    cnt = m_Data[adr + 0x5C];
                    if (cnt>0)
                    {
                        ret = new WizItem[cnt];
                        for (int i = 0; i < cnt; i++)
                        {
                            ret[i] = new WizItem(m_scn)
                            {
                                ID = m_Data[adr + 0x54 + i],
                                Status = m_Data[adr + 0x4C + i]
                            };
                        }
                    }

                    break;
                case WIZSCN.FC2:
                case WIZSCN.FC3:
                case WIZSCN.SFC1:
                case WIZSCN.SFC2:
                case WIZSCN.SFC3:
                case WIZSCN.SFC5:
                    cnt = m_Data[adr + 0x53];
                    if (cnt > 0)
                    {
                        ret = new WizItem[cnt];
                        for (int i = 0; i < cnt; i++)
                        {
                            ret[i] = new WizItem(m_scn)
                            {
                                ID = m_Data[adr + 0x4B + i],
                                Status = m_Data[adr + 0x43 + i]
                            };
                        }
                    }

                    break;
                case WIZSCN.GBC1:
                case WIZSCN.GBC2:
                case WIZSCN.GBC3:
                    cnt = m_Data[adr + 0x52];
                    if (cnt > 0)
                    {
                        ret = new WizItem[cnt];
                        for (int i = 0; i < cnt; i++)
                        {
                            ret[i] = new WizItem(m_scn)
                            {
                                ID = m_Data[adr + 0x4A + i],
                                Status = m_Data[adr + 0x42 + i]
                            };
                        }
                    }

                    break;
                default:
                    return ret;
            }
            return ret;

        }
        // ************************************************************************
        public WizItem[] CharItems
        {
            get { return CharItemsFromIndex(m_CharCurrent); }
        }
        // ************************************************************************
        // ************************************************************************
        public int CharRipFromIndex(int idx)
        {
            int ret = 0;

            if ((idx < 0) || (idx >= CharCount))
            {
                return ret;
            }
            if ((m_scn == WIZSCN.FC1) || (m_scn == WIZSCN.FC1) || (m_scn == WIZSCN.FC2))
            {
                return ret;
            }
            int adr = CharAdr(idx);
            switch (m_scn)
            {
                case WIZSCN.SFC1:
                case WIZSCN.SFC2:
                case WIZSCN.SFC3:
                    ret = m_Data[adr + 0x60] + (m_Data[adr + 0x61] << 8);
                    break;
                case WIZSCN.SFC5:
                    ret = m_Data[adr + 0x69] + (m_Data[adr + 0x6A] << 8);
                    break;
                case WIZSCN.GBC1:
                case WIZSCN.GBC2:
                case WIZSCN.GBC3:
                    ret = m_Data[adr + 0x6B];
                    break;
                default:
                    return ret;
            }
            return ret;
        }
        // ************************************************************************
        public void SetCharRipFromIndex(int idx, int v)
        {
            if ((idx < 0) || (idx >= CharCount))
            {
                return;
            }

            if ((m_scn==WIZSCN.FC1)|| (m_scn == WIZSCN.FC1)|| (m_scn == WIZSCN.FC2))
            {
                return;
            }
            int adr = CharAdr(idx);
            if (m_Data[adr] == 0) return;

            if (v < 0) v = 0;
            int bak = CharRipFromIndex(idx);

            switch (m_scn)
            {
                case WIZSCN.SFC1:
                case WIZSCN.SFC2:
                case WIZSCN.SFC3:
                    if (v > 0xFFFF ) v = 0xFFFF;
                    if (v!=bak)
                    {
                        m_Data[adr + 0x60] = (byte)(v & 0xFF);
                        m_Data[adr + 0x61] = (byte)((v>>8) & 0xFF);
                        OnValueChanged(new EventArgs());
                    }
                    break;
                case WIZSCN.SFC5:
                    if (v > 0xFFFF) v = 0xFFFF;
                    if (v != bak)
                    {
                        m_Data[adr + 0x69] = (byte)(v & 0xFF);
                        m_Data[adr + 0x6A] = (byte)((v >> 8) & 0xFF);
                        OnValueChanged(new EventArgs());
                    }
                    break;
                case WIZSCN.GBC1:
                case WIZSCN.GBC2:
                case WIZSCN.GBC3:
                    if (v > 0xFF) v = 0xFF;
                    if (v != bak)
                    {
                        m_Data[adr + 0x6B] = (byte)v;
                        OnValueChanged(new EventArgs());
                    }
                    break;
            }
        }
        // ************************************************************************
        public int CharRip
        {
            get { return CharRipFromIndex(m_CharCurrent); }
            set { SetCharRipFromIndex(m_CharCurrent,value); }
        }
        // ************************************************************************
        public long CharMarkFromIndex(int idx)
        {
            long ret = 0;
            if ((idx < 0) || (idx >= CharCount))
            {
                return ret;
            }
            if ((m_scn == WIZSCN.FC1) || (m_scn == WIZSCN.FC1) || (m_scn == WIZSCN.FC2))
            {
                return ret;
            }
            int adr = CharAdr(idx);
            switch (m_scn)
            {
                case WIZSCN.SFC1:
                case WIZSCN.SFC2:
                case WIZSCN.SFC3:
                    ret = WizU.WizHexToLong(GetCode(adr + 0x62, 6));
                    break;
                case WIZSCN.SFC5:
                    ret = WizU.WizHexToLong(GetCode(adr + 0x63, 6));
                    break;
                case WIZSCN.GBC1:
                case WIZSCN.GBC2:
                case WIZSCN.GBC3:
                    ret = WizU.WizHexToLong(GetCode(adr + 0x65, 6));
                    break;
                default:
                    return ret;
            }

            return ret;
        }
        // ************************************************************************
        public void SetCharMarkFromIndex(int idx, long v)
        {
            if ((idx < 0) || (idx >= CharCount))
            {
                return;
            }
            if ((m_scn == WIZSCN.FC1) || (m_scn == WIZSCN.FC1) || (m_scn == WIZSCN.FC2))
            {
                return;
            }
            if (v < 0) v = 0;
            else if (v > 999999999999) v = 999999999999;

            int adr = CharAdr(idx);
            if (m_Data[adr] == 0) return;


            if (CharMarkFromIndex(idx) == v) return;


            byte[] va = WizU.LongToWizHex(v);
            switch (m_scn)
            {
                case WIZSCN.SFC1:
                case WIZSCN.SFC2:
                case WIZSCN.SFC3:
                    SetCode(adr + 0x62, va);
                    OnValueChanged(new EventArgs());
                    break;
                case WIZSCN.SFC5:
                    SetCode(adr + 0x63, va);
                    OnValueChanged(new EventArgs());
                    break;

                case WIZSCN.GBC1:
                case WIZSCN.GBC2:
                case WIZSCN.GBC3:
                    SetCode(adr + 0x65, va);
                    OnValueChanged(new EventArgs());
                    break;
            }
        }
        // ************************************************************************
        public long CharMark
        {
            get { return CharMarkFromIndex(m_CharCurrent); }
            set { SetCharMarkFromIndex(m_CharCurrent, value); }
        }
        // ************************************************************************
        public string CodeToString(byte v)
        {
            return WizString.CodeToString(m_scn, v);
        }
        // ************************************************************************
        /// <summary>
        /// byte列を検索
        /// </summary>
        /// <param name="s">検索するバイト配列</param>
        /// <param name="index">検索スタートインデックス</param>
        /// <returns>インデックス。見つからなかったら-1</returns>
        public int FindCode(byte[] s, int index = 0)
        {
            int ret = -1;
            int bs = m_Data.Length;
            int ss = s.Length;
            if (bs <= 0) return ret;
            if (ss <= 0) return ret;
            if (index >= bs) return ret;
            int bs2 = bs - ss;
            if (bs2 < 0) return ret;
            for (int i = index; i < bs2; i++)
            {
                if (m_Data[i] == s[0])
                {
                    bool flg = true;
                    for (int j = 0; j < ss; j++)
                    {
                        if (m_Data[i + j] != s[j])
                        {
                            flg = false;
                            break;
                        }
                    }
                    if (flg == true)
                    {
                        ret = i;
                        break;
                    }
                }
            }
            return ret;
        }
        // ************************************************************************
        /// <summary>
        /// 文字列の検索　アスキー文字　Wiz文字ではない
        /// </summary>
        /// <param name="s">検索スタートインデックス<文字列/param>
        /// <param name="index"></param>
        /// <returns>インデックス。見つからなかったら-1</returns>
        public int FindString(string s,int index = 0)
        {
            int ret = -1;
            if (s == "") return ret;
            byte[] ss = new byte[s.Length];
            for ( int i=0; i<s.Length; i++)
            {
                ss[i] = (byte)s[i];
            }
            ret = FindCode(ss, index);
            return ret;
        }
        // ************************************************************************
        /// <summary>
        /// バイト配列を抜き出す
        /// </summary>
        /// <param name="index">インデクス</param>
        /// <param name="len">配列の長さ</param>
        /// <returns>バイト配列</returns>
        public byte[] GetCode(int index, int len)
        {
            if (len < 0) len = 0;
            byte[] ret = new byte[len];
            if ((len <= 0)||(index <0)||(index>= m_Data.Length))
            {
                return ret;
            }
            for ( int i=0; i<len;i++)
            {
                ret[i] = m_Data[index + i];
            }
            return ret;
        }
        public void SetCode(int index, byte [] a)
        {
            int len = a.Length;
            if (len <= 0) return;
            if ((len > 0) && (index >= 0) && (index < m_Data.Length))
            {
                for (int i = 0; i < len; i++)
                {
                    m_Data[index + i] = a[i];
                }
            }

        }
        private bool CompareCode(byte[] a, byte[] b)
        {
            bool ret = false;
            if (a.Length == b.Length)
            {
                ret = true;
                for (int i = 0; i < a.Length; i++)
                {
                    if (a[i] != b[i])
                    {
                        ret = false;
                        break;
                    }
                }
            }
            return ret;
        }

      
        // ************************************************************************
        /// <summary>
        /// 読み込み
        /// SCNナンバーも設定される
        /// </summary>
        /// <param name="p">stateファイルのパス</param>
        /// <returns>正常に読み込んだか</returns>
        public bool LoadFile(string p)
        {
            bool ret = false;
            m_DataPath = "";
            if (File.Exists(p) == false) return ret;

            WizIO wio = new WizIO();

            if ( wio.LoadFile(p)==true)
            {
                m_Data = wio.Data;
                m_scn = wio.SCN;
                m_WizFile = wio.WizFile;
                m_OffsetAdr = wio.OffserAdr;
                m_OffsetAdr2 = wio.OffserAdr2;
                m_OffsetAdr3 = wio.OffserAdr3;
                m_DataPath = p;
                ret = true;
                OnLoadFileFinished(EventArgs.Empty);
            }


            return ret;
        }
     
        /// <summary>
        /// 
        /// </summary>
        /// <param name="p"></param>
        /// <returns></returns>
        public bool SaveFile(string p)
        {
            bool ret = false;
            if (m_Data.Length <= 0) return ret;


            if(m_WizFile==WIZFILE.ROM)
            {
                if(m_DataPath == p)
                {
                    MessageBox.Show("ROMモードの時は上書き禁止です。必ず別名保存してくださいA");
                    return ret;
                }
                else
                if (File.Exists(p) == true)
                {
                    MessageBox.Show("ROMモードの時は上書き禁止です。必ず別名保存してくださいB");
                    return ret;
                }
            }



            if(m_WizFile==WIZFILE.SAVE)
            {
                switch (m_scn)
                {
                    case WIZSCN.FC1:
                        ChecksumWiz1FC();
                        break;
                    case WIZSCN.FC2:
                    case WIZSCN.FC3:
                    case WIZSCN.SFC5:
                    case WIZSCN.GBC1:
                    case WIZSCN.GBC2:
                    case WIZSCN.GBC3:
                        ChecksumWiz();
                        break;
                    case WIZSCN.SFC1:
                    case WIZSCN.SFC2:
                    case WIZSCN.SFC3:
                        ChecksumWiz123SFC();
                        break;
                }
            }


            FileStream fs = new FileStream(p, System.IO.FileMode.Create, FileAccess.Write);
            try
            {
                fs.Write(m_Data, 0, m_Data.Length);
                ret = true;
            }
            catch
            {
                ret = false;
            }
            finally
            {
                fs.Close();
            }
            if(ret == true)
            {
                m_DataPath = p;
            }

            return ret;
        }
        // ************************************************************************
        public bool Save()
        {
            if(m_DataPath!="")
            {
                return SaveFile(m_DataPath);
            }
            else
            {
                return SaveAs();
            }
        }
        // ************************************************************************
        public bool SaveAs()
        {
            bool ret = false;
            SaveFileDialog dlg = new SaveFileDialog();
            dlg.Filter =
            dlg.Filter = "すべてのファイル(*.*)|*.*";
            dlg.Title = "保存先のファイルを選択してください";
            dlg.RestoreDirectory = true;
            if (m_DataPath!="")
            {
                dlg.FileName = Path.GetFileName(m_DataPath);
                dlg.InitialDirectory = Path.GetDirectoryName(m_DataPath);
            }

            //ダイアログを表示する
            if (dlg.ShowDialog() == DialogResult.OK)
            {
                if(m_WizFile==WIZFILE.ROM)
                {
                    if (dlg.FileName == m_DataPath)
                    {
                        MessageBox.Show("ROMモードの時は上書き禁止です。必ず別名保存してください");
                        return ret;
                    }
                }
                ret = SaveFile(dlg.FileName);
            }
            return ret;
        }
        public bool LoadFile()
        {
            bool ret = false;
            OpenFileDialog dlg = new OpenFileDialog();
            if (m_DataPath != "")
            {
                dlg.FileName = Path.GetFileName(m_DataPath);
                dlg.InitialDirectory = Path.GetDirectoryName(m_DataPath);
            }
            else
            {
                dlg.FileName = "";

            }
            dlg.Filter = "すべてのファイル(*.*)|*.*";
            dlg.Title = "保存先のファイルを選択してください";
            dlg.RestoreDirectory = true;
            //ダイアログを表示する
            if (dlg.ShowDialog() == DialogResult.OK)
            {
                ret = LoadFile(dlg.FileName);
            }
            return ret;
        }
        public void Reload()
        {
            if(m_DataPath!="")
            {
                LoadFile(m_DataPath);
            }
        }
        public bool IsReload
        {
            get { return (m_DataPath != ""); }
        }
        // ************************************************************************
        private WIZSCN m_res_scn = WIZSCN.FC1;
        public WIZSCN RES_SCN
        {
            get { return m_res_scn; }
            set
            {
                if (m_res_scn != value)
                {
                    m_res_scn = value;
                    ResLoad();
                }
            }
        }
        // ************************************************************************
        /// <summary>
        /// リソースにあるsテートデータの読み出し
        /// </summary>
        /// <returns></returns>
        public bool ResLoad()
        {
            bool ret = false;
            m_DataPath = "";
            //if (File.Exists( m_DataPath) == true) return ret;
            byte[] bs = null;
            WIZSCN bak = WIZSCN.NO;
            switch(m_res_scn)
            {
                case WIZSCN.FC1:
                    bs= Properties.Resources.Wizardry1FC;
                    break;
                case WIZSCN.FC2:
                    bs = Properties.Resources.Wizardry2FC;
                    break;
                case WIZSCN.FC3:
                    bs = Properties.Resources.Wizardry3FC;
                    break;
                case WIZSCN.SFC1:
                case WIZSCN.SFC2:
                case WIZSCN.SFC3:
                    bak = m_res_scn;
                    bs = Properties.Resources.Wizardry123SFC;
                    break;
                case WIZSCN.SFC5:
                    bs = Properties.Resources.Wizardry5SFC;
                    break;
                case WIZSCN.GBC1:
                    bs = Properties.Resources.Wizardry1GBC;
                    break;
                case WIZSCN.GBC2:
                    bs = Properties.Resources.Wizardry2GBC;
                    break;
                case WIZSCN.GBC3:
                    bs = Properties.Resources.Wizardry3GBC;
                    break;
                default:
                    return ret;
            }
            WizIO wio = new WizIO();

            if (wio.LoadData(bs) == true)
            {
                m_Data = wio.Data;
                m_scn = wio.SCN;
                m_res_scn = wio.SCN;
                if (m_res_scn == WIZSCN.SFC1)
                {
                    m_scn = bak;
                    m_res_scn = bak;
                }
                m_WizFile = wio.WizFile;
                m_OffsetAdr = wio.OffserAdr;
                m_OffsetAdr2 = wio.OffserAdr2;
                m_OffsetAdr3 = wio.OffserAdr3;
                OnLoadFileFinished(EventArgs.Empty);
                ret = true;
            }
            return ret;
        }
        // ************************************************************************
        /// <summary>
        /// カレンとシナリオのアイテム名配列
        /// </summary>
        public string [] ItemList
        {
            get
            {
                WizItem wi = new WizItem(m_scn);
                return wi.ItemNames;
            }
        }

        #region ソート関係
        // ************************************************************************
        /// <summary>
        /// キャラクタの場所入れ替え
        /// </summary>
        /// <param name="idx0"></param>
        /// <param name="idx1"></param>
        public void SwapChar(int idx0,int idx1)
        {
            if ((idx0 < 0) || (idx0 >= CharCount)) return;
            if ((idx1 < 0) || (idx1 >= CharCount)) return;
            if (idx0 == idx1) return;

            int sz = CharSize;
            int adr0 = CharAdr(idx0);
            int adr1 = CharAdr(idx1);

            byte[] tmp0 = GetCode(adr0, sz);
            byte[] tmp1 = GetCode(adr1, sz);

            SetCode(adr0, tmp1);
            SetCode(adr1, tmp0);
        }
        // ************************************************************************
        /// <summary>
        /// キャラのソート
        /// </summary>
        public void CurrentDataUp()
        {
            if ((m_CharCurrent <= 0)||(m_CharCurrent >= CharCount)) return;
            SwapChar(m_CharCurrent - 1, m_CharCurrent);
            m_CharCurrent--;
            OnValueChanged(new EventArgs());
        }
        // ************************************************************************
        /// <summary>
        /// キャラのソート
        /// </summary>
        public void CurrentDataDown()
        {
            if ((m_CharCurrent < 0) || (m_CharCurrent >= CharCount-1)) return;
            SwapChar(m_CharCurrent, m_CharCurrent+1);
            m_CharCurrent++;
            OnValueChanged(new EventArgs());
        }
        #endregion
        // ************************************************************************
        private byte[] ChecksumSub(int adr, int sz)
        {
            byte[] ret = new byte[0];

            if (m_Data[adr] == 0) return ret;
            ushort crc = CRC16.Calc(m_Data, adr, sz, 0xFFFF);
            if (crc != 0)
            {
                crc = CRC16.Calc(m_Data, adr, sz - 2, 0xFFFF);
                byte v0 = (byte)((crc >> 8) & 0xFF);
                byte v1 = (byte)(crc & 0xFF);
                m_Data[adr + sz - 2] = v0;
                m_Data[adr + sz - 1] = v1;
                ret = new byte[2];
                ret[0] = v0;
                ret[1] = v1;
            }
            return ret;
        }
        // ************************************************************************
        private void ChecksumWiz()
        {
            if ((m_scn == WIZSCN.FC1) || (m_scn == WIZSCN.SFC1) || (m_scn == WIZSCN.SFC2) || (m_scn == WIZSCN.SFC3)) return;
            int chrSz = CharSize;
            for ( int i=0;i<CharCount;i++)
            {
                int adr = CharAdr(i);
                ChecksumSub(adr, chrSz);
            }
            byte [] bb = GetCode(m_OffsetAdr, chrSz* CharCount);
            SetCode(m_OffsetAdr2, bb);
        }      
        // ************************************************************************
        private void ChecksumWiz123SFC()
        {
            if((m_scn==WIZSCN.SFC1)|| (m_scn == WIZSCN.SFC2)|| (m_scn == WIZSCN.SFC3)){
                int chrSz = CharSize;
                for (int i = 0; i < CharCount; i++)
                {
                    int adr = m_OffsetAdr + chrSz * i;
                    if (m_Data[adr] != 0) ChecksumSub(adr, chrSz);

                    adr = m_OffsetAdr2 + chrSz * i;
                    if (m_Data[adr] != 0) ChecksumSub(adr, chrSz);

                    adr = m_OffsetAdr3 + chrSz * i;
                    if (m_Data[adr] != 0) ChecksumSub(adr, chrSz);

                }
            }
        }
        // ************************************************************************
        private void ChecksumWiz1FC()
        {
            if (m_scn != WIZSCN.FC1) return;
            int chrSz = 0x80;
            for (int i = 0; i < CharCount; i++)
            {
                int adr = CharAdr(i);
                byte[] a = GetCode(adr, chrSz);

                for(int k=0;k<14; k++)
                {
                    int v = 8;
                    for (int j = 0; j < 8; j++)
                    {
                        v = v + a[8 * k + j];
                    }
                    if ((v >> 8) != 0)
                    {
                        v = (v & 0xFF) + 1;
                    }
                    a[0x70 + k] = (byte)v;
                }
                ushort crc = CRC16.Calc(a, 0,chrSz-2, 0xFFFF);
                a[chrSz - 2] =  (byte)((crc >> 8) & 0xFF);
                a[chrSz - 1] =  (byte)(crc & 0xFF);

                SetCode(adr, a);

                byte[] b = new byte[chrSz];
                for ( int j=0; j< chrSz; j++)
                {
                    byte v = (byte)(a[j] ^ 0xFF);
                    v = (byte)(((v & 0xF) << 4) | ((v & 0xF0) >> 4));
                    b[chrSz - j - 1] = v;
                }
                SetCode(adr + chrSz, b);


            }
        }
        // ************************************************************************
        private void ChecksumROM()
        {
            for (int i = 0; i < CharCount; i++)
            {
                int adr = CharAdr(i);
                int sz = CharSize;
                ushort crc = CRC16.Calc(m_Data, adr, sz - 2, 0xFFFF);
                m_Data[adr + sz - 2] = (byte)((crc & 0xFF00) >> 8);
                m_Data[adr + sz - 1] = (byte)(crc & 0xFF);
            }
        }
        // ****************************************************************      
        public void Init_MP()
        {
            byte[] mp = WizSpellList.SpellBaseCount(m_scn);
            int adr = CharAdr(m_CharCurrent);
            switch (m_scn)
            {
                case WIZSCN.FC1:
                    SetCode(adr + 0x29, mp);
                    SetCode(adr + 0x37, mp);
                    break;
                case WIZSCN.FC2:
                case WIZSCN.FC3:
                case WIZSCN.SFC1:
                case WIZSCN.SFC2:
                case WIZSCN.SFC3:
                case WIZSCN.SFC5:
                    for (int i = 0; i < 14; i++) { mp[i] = (byte)(mp[i] << 8 | mp[i]); }
                    SetCode(adr + 0x27, mp);
                    break;
                case WIZSCN.GBC1:
                case WIZSCN.GBC2:
                case WIZSCN.GBC3:
                    for (int i = 0; i < 14; i++) { mp[i] = (byte)(mp[i] << 8 | mp[i]); }
                    SetCode(adr + 0x26, mp);
                    break;
            }
            OnValueChanged(new EventArgs());
        }
        // ****************************************************************      
        public void ALL9_MP()
        {
            byte[] mp = new byte[14];
            for (int i = 0; i < 14; i++) { mp[i] = 0x9; }
            int adr = CharAdr(m_CharCurrent);
            switch (m_scn)
            {
                case WIZSCN.FC1:
                    SetCode(adr + 0x29, mp);
                    SetCode(adr + 0x37, mp);
                    break;
                case WIZSCN.FC2:
                case WIZSCN.FC3:
                case WIZSCN.SFC1:
                case WIZSCN.SFC2:
                case WIZSCN.SFC3:
                case WIZSCN.SFC5:
                    for (int i = 0; i < 14; i++) { mp[i] = 0x99; }
                    SetCode(adr + 0x27, mp);
                    break;
                case WIZSCN.GBC1:
                case WIZSCN.GBC2:
                case WIZSCN.GBC3:
                    for (int i = 0; i < 14; i++) { mp[i] = 0x99; }
                    SetCode(adr + 0x26, mp);
                    break;
            }
            OnValueChanged(new EventArgs());

        }
        // ****************************************************************      
        public void ALL0_MP()
        {
            byte[] mp = new byte[14];
            for (int i = 0; i < 14; i++) { mp[i] = 0x00; }
            int adr = CharAdr(m_CharCurrent);
            switch (m_scn)
            {
                case WIZSCN.FC1:
                    SetCode(adr + 0x29, mp);
                    SetCode(adr + 0x37, mp);
                    break;
                case WIZSCN.FC2:
                case WIZSCN.FC3:
                case WIZSCN.SFC1:
                case WIZSCN.SFC2:
                case WIZSCN.SFC3:
                case WIZSCN.SFC5:
                    SetCode(adr + 0x27, mp);
                    break;
                case WIZSCN.GBC1:
                case WIZSCN.GBC2:
                case WIZSCN.GBC3:
                    SetCode(adr + 0x26, mp);
                    break;
            }
            OnValueChanged(new EventArgs());

        }
    }
}

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

namespace WizFCEdit
{
    #region Const
    public enum WIZSCN
    {
        NO = 0,
        S1 = 1,
        S2,
        S3
    }

    public enum FILEMODE
    {
        STATE =0,
        SAVE
    }


    public enum WIZRACE
    {
        HUMAN=0,
        ELF,
        DWARF,
        GNOME,
        HOBIT
    }
    public enum WIZCLASS
    {
        // 0:FIG, 1:MAG, 2:PRI, 3:THI, 4:BIS, 5:SAM, 6:LOR, 7:NIN
        FIG=0,
        MAG,
        PRI,
        THI,
        BIS,
        SAM,
        LOR,
        NIN
    }
    public enum WIZALG
    {
        // 0:善, 1:中立, 2:悪
        GOOD =0,
        NEUT,
        EVIL
    }

    public enum WIZSTATUS
    {
        // 0:OK, 1:ASLEEP, 2:AFRAID, 3:PARALY, 4:STONED, 5:DEAD, 6:ASHED, 7:LOST
        OK=0,
        ASLEEP,
        AFRAID,
        PARALY,
        STONED,
        DEAD,
        ASHED,
        LOST
    }


    #endregion


    public class MagicPoint
    {
        public byte[] NowP = new byte[7];
        public byte[] MaxP = new byte[7];
        public byte[] Learning = new byte[7];
        public MagicPoint()
        {
            Clear();
        }
        public void Clear()
        {
            for (int i = 0; i < 7; i++)
            {
                NowP[i] = 0;
                MaxP[i] = 0;
                Learning[i] = 0;

            }
        }
    }
   
    public class CurrentCharEventArgs : EventArgs
    {
        public int CurrentChar;
    }
    public class WizFCState :Component
    {
        private string m_statePath = "";
        public string StatePath
        {
            get { return m_statePath; }
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
        private byte[] m_buf = new byte[0];
        private int m_sramAdr = -1;
        /// <summary>
        /// SRAM領域のアドレス
        /// </summary>
        public int SramAdr { get { return m_sramAdr; } }
        /// <summary>
        /// SRAMのサイズ
        /// </summary>
        public int SRAM_SIZE { get { return 0x1FFF; } }

        private WIZSCN m_scn = WIZSCN.NO;
        /// <summary>
        /// 読み込んだステートファイルのシナリオ
        /// </summary>
        public WIZSCN SCN { get { return m_scn; } }

        private FILEMODE m_FileMode = FILEMODE.STATE;
        public FILEMODE FileMOde
        {
            get { return m_FileMode; }
        }

        private readonly int m_CharCount = 20;
        public int  CharCount { get { return m_CharCount; } }

        private int m_CharCurrent = -1;
        public int CharCurrent
        {
            get { return m_CharCurrent; }
            set
            {
                if ((value >= 0) && (value < m_CharCount))
                {
                    m_CharCurrent = value;
                }
                else
                {
                    m_CharCurrent = -1;
                }
                //イベント発生
                CurrentCharEventArgs e = new CurrentCharEventArgs();
                e.CurrentChar = m_CharCurrent;
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
            if ((m_CharCurrent < m_CharCount -1))
            {
                CharCurrent = m_CharCurrent + 1;
            }
        }

        #endregion

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

        // ***********************************************************************
        /// <summary>
        /// コンストラクタ
        /// </summary>
        public WizFCState()
        {
            if (ResLoad()==true)
            {

            }
        }
        /// <summary>
        /// キャラクターの先頭アドレス
        /// </summary>
        // ************************************************************************
        public int CharStartAdr
        {
            get
            {
                if (m_FileMode == FILEMODE.STATE)
                {
                    switch (m_scn)
                    {
                        case WIZSCN.S1:
                            return 0x0009;
                        case WIZSCN.S2:
                            return 0x0409;
                        case WIZSCN.S3:
                            return 0x0409;
                        default:
                            return 0;
                    }
                }
                else
                {
                    switch (m_scn)
                    {
                        case WIZSCN.S1:
                            return 0x0000;
                        case WIZSCN.S2:
                            return 0x0400;
                        case WIZSCN.S3:
                            return 0x0400;
                        default:
                            return 0;

                    }
                }
            }
        }
        // ************************************************************************
        public int CharSize
        {
            get
            {

                switch (m_scn)
                {
                    case WIZSCN.S1:
                        return 0x0100;
                    case WIZSCN.S2:
                        return 0x0060;
                    case WIZSCN.S3:
                        return 0x0060;
                    default:
                        return 0;
                }
            }
        }
        // ************************************************************************
        public int CharAdr(int index)
        {
            return SramAdr + CharStartAdr + CharSize * index;
        }
        // ************************************************************************
        public byte[] CharNameCodeFromIndex(int index)
        {
            byte[] ret = new byte[0];
            int idx = CharAdr(index);
            if (idx < 0) return ret;

            if (m_buf[idx + 1] == 0)
            {
                if (m_scn == WIZSCN.S1)
                {
                    return WizFCString.Wiz1NoneName;
                }
                else
                {
                    return WizFCString.Wiz2NoneName;
                }
            }
            int cnt = m_buf[idx + 1];
            if (cnt <= 0) return ret;
            ret = GetCode(idx + 2, cnt);
            return ret;

        }
        // ************************************************************************
        public void SetCharNameCodeFromIndex(int index, byte[] nm)
        {
            int idx = CharAdr(index);
            if (idx < 0) return;
            if (m_buf[idx] == 0) return;

            if (nm.Length <= 0) return;
 
            m_buf[idx + 1] = (byte)nm.Length;

            byte[] a = new byte[8];
            for (int i=0;i<8;i++)
            {
                if(m_scn==WIZSCN.S1)
                {
                    a[i] = 0x24;
                }
                else
                {
                    a[i] = 0x20;
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
            if (m_buf[idx] == 0) return WizFCString.NoneName;
            int cnt = m_buf[idx + 1];
            if (cnt <= 0) cnt = 8;
            byte[] nm = GetCode(idx+2, cnt);
            return WizFCString.CodeToString(m_scn, nm);

        }
        // ************************************************************************
        public string [] CharNamesWithOutCurrent
        {
            get
            {
                string[] ret = new string[m_CharCount-1];
                for ( int i=0; i<m_CharCount-1;i++)
                {
                    if (i != m_CharCurrent)
                    {
                        ret[i] = CharNameFromIndex(i);
                    }
                }
                return ret;
            }
        }
        public string[] CharNames
        {
            get
            {
                string[] ret = new string[m_CharCount];
                for (int i = 0; i < m_CharCount; i++)
                {
                    ret[i] = CharNameFromIndex(i);
                }
                return ret;
            }
        }

        public bool CanSetCharName(string s)
        {
            bool ret = false;
            string[] ns = CharNamesWithOutCurrent;
            int idx = -1;

            for (int i=0; i<m_CharCount;i++)
            {
                if(s == ns[i])
                {
                    idx = i;
                    break;
                }
            }
            ret = (idx >= 0);
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
            if ((idx<0)||(idx>=m_CharCount))
            {
                return ret;
            }
            int adr = CharAdr(idx);
            switch (m_scn)
            {
                case WIZSCN.S1:
                    adr += 0x0A;
                    ret = (WIZRACE)(m_buf[adr] & 0x07);
                    break;
                case WIZSCN.S2:
                case WIZSCN.S3:
                    adr += 0x0A;
                    ret = (WIZRACE)(m_buf[adr] >> 5 & 0x07);
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
            if ((idx < 0) || (idx >= m_CharCount))
            {
                return;
            }
            int adr = CharAdr(idx);
            if (m_buf[adr] == 0) return;
            if (CharRaceFromIndex(idx) == r) return;
            switch (m_scn)
            {
                case WIZSCN.S1:
                    adr += 0x0A;
                    m_buf[adr] = (byte)((byte)r & 0x07);
                    OnValueChanged(new EventArgs());
                    break;
                case WIZSCN.S2:
                case WIZSCN.S3:
                    adr += 0x0A;
                    m_buf[adr] = (byte)(((byte)r & 0x07) << 5);
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
            if ((idx < 0) || (idx >= m_CharCount))
            {
                return ret;
            }
            int adr = CharAdr(idx);
            switch (m_scn)
            {
                case WIZSCN.S1:
                    adr += 0x0B;
                    ret = (WIZCLASS)(m_buf[adr] & 0x07);
                    break;
                case WIZSCN.S2:
                case WIZSCN.S3:
                    adr += 0x0A;
                    ret = (WIZCLASS)(m_buf[adr] >> 2 & 0x07);
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
            if ((idx < 0) || (idx >= m_CharCount))
            {
                return;
            }
            int adr = CharAdr(idx);
            if (m_buf[adr] == 0) return;
            if (CharClassFromIndex(idx) == cl) return;

            switch (m_scn)
            {
                case WIZSCN.S1:
                    adr += 0x0B;
                    m_buf[adr] = (byte)((byte)cl & 0x07);
                    OnValueChanged(new EventArgs());
                    break;
                case WIZSCN.S2:
                case WIZSCN.S3:
                    adr += 0x0A;
                    byte v = m_buf[adr];
                    v = (byte)((v & 0xE3) | (((byte)cl & 0x07) << 2));
                    m_buf[adr] = v;
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
            if ((idx < 0) || (idx >= m_CharCount))
            {
                return ret;
            }
            int adr = CharAdr(idx);
            switch (m_scn)
            {
                case WIZSCN.S1:
                    adr += 0x0C;
                    ret = (WIZALG)(m_buf[adr] & 0x03);
                    break;
                case WIZSCN.S2:
                case WIZSCN.S3:
                    adr += 0x0A;
                    ret = (WIZALG)(m_buf[adr] & 0x03);
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
            if ((idx < 0) || (idx >= m_CharCount))
            {
                return;
            }
            int adr = CharAdr(idx);
            if (m_buf[adr] == 0) return;
            if (CharAlgFromIndex(idx) == alg) return;
            switch (m_scn)
            {
                case WIZSCN.S1:
                    adr += 0x0C;
                    m_buf[adr] = (byte)((byte)alg & 0x03);
                    OnValueChanged(new EventArgs());
                    break;
                case WIZSCN.S2:
                case WIZSCN.S3:
                    //adr += 0x0A;
                    byte v = m_buf[adr + 0x0A];
                    v = (byte)((v & 0xFC) | (byte)alg);
                    m_buf[adr + 0x0A] = v;
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
            if ((idx < 0) || (idx >= m_CharCount))
            {
                return ret;
            }
            int adr = CharAdr(idx);
            switch (m_scn)
            {
                case WIZSCN.S1:
                    adr += 0x23;
                    ret = (ushort)((ushort)m_buf[adr] * 0x100 + (ushort)m_buf[adr + 1]);
                    break;
                case WIZSCN.S2:
                case WIZSCN.S3:
                    adr += 0x21;
                    ret = (ushort)((ushort)m_buf[adr] * 0x100 + (ushort)m_buf[adr + 1]);
                    break;
                default:
                    return ret;
            }

            return ret;
        }
        // ************************************************************************
        public void SetCharLevelFromIndex(int idx,ushort v)
        {
            if ((idx < 0) || (idx >= m_CharCount))
            {
                return;
            }
            int adr = CharAdr(idx);
            if (m_buf[adr] == 0) return;
            if (v <= 0) v = 1;

            if (CharLevelFromIndex(idx) == v) return;
            switch (m_scn)
            {
                case WIZSCN.S1:
                    adr += 0x23;
                    m_buf[adr] = (byte)((v >> 8) & 0xFF);
                    m_buf[adr+1] = (byte)(v & 0xFF);
                    OnValueChanged(new EventArgs());

                    break;
                case WIZSCN.S2:
                case WIZSCN.S3:
                    adr += 0x21;
                    m_buf[adr] = (byte)((v >> 8) & 0xFF);
                    m_buf[adr + 1] = (byte)(v & 0xFF);
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
            if ((idx < 0) || (idx >= m_CharCount))
            {
                return ret;
            }
            int adr = CharAdr(idx);
            switch (m_scn)
            {
                case WIZSCN.S1:
                    adr += 0x13;
                    ret = WizU.WizHexToLong(GetCode(adr, 6));
                    break;
                case WIZSCN.S2:
                case WIZSCN.S3:
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
            if ((idx < 0) || (idx >= m_CharCount))
            {
                return;
            }
            if (v < 0) v = 0;
            else if (v > 0xFFFFFFFFFFFF) v = 0xFFFFFFFFFFFF;

            int adr = CharAdr(idx);
            if (m_buf[adr] == 0) return;


            if (CharGoldFromIndex(idx) == v) return;


            byte[] va = WizU.LongToWizHex(v);
            switch (m_scn)
            {
                case WIZSCN.S1:
                    adr += 0x13;
                    SetCode(adr, va);
                    OnValueChanged(new EventArgs());
                    break;
                case WIZSCN.S2:
                case WIZSCN.S3:
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
            if ((idx < 0) || (idx >= m_CharCount))
            {
                return ret;
            }
            int adr = CharAdr(idx);
            switch (m_scn)
            {
                case WIZSCN.S1:
                    adr += 0x19;
                    ret = WizU.WizHexToLong(GetCode(adr, 6));
                    break;
                case WIZSCN.S2:
                case WIZSCN.S3:
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
            if ((idx < 0) || (idx >= m_CharCount))
            {
                return;
            }
            int adr = CharAdr(idx);
            if (m_buf[adr] == 0) return;
            if (CharExpFromIndex(idx) == v) return;
            byte[] va = WizU.LongToWizHex(v);

            switch (m_scn)
            {
                case WIZSCN.S1:
                    adr += 0x19;
                    SetCode(adr, va);
                    OnValueChanged(new EventArgs());
                    break;
                case WIZSCN.S2:
                case WIZSCN.S3:
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
            if ((idx < 0) || (idx >= m_CharCount))
            {
                return ret;
            }
            int adr = CharAdr(idx);
            switch (m_scn)
            {
                case WIZSCN.S1:
                    adr += 0x26;
                    ret = (sbyte)m_buf[adr];
                    break;
                case WIZSCN.S2:
                case WIZSCN.S3:
                    adr += 0x24;
                    ret = (sbyte)m_buf[adr];
                    break;
                default:
                    return ret;
            }

            return ret;
        }
        public void SetCharAgeFromIndex(int idx, sbyte v)
        {
            if ((idx < 0) || (idx >= m_CharCount))
            {
                return;
            }
            if (v < -128) v = -128;
            else if (v > 127) v = 127;
            sbyte v2 = (sbyte)v;

            int adr = CharAdr(idx);
            if (m_buf[adr] == 0) return;

            if (CharAgeFromIndex(idx) == v2) return;


            switch (m_scn)
            {
                case WIZSCN.S1:
                    adr += 0x26;
                    m_buf[adr] = (byte)v2;
                    OnValueChanged(new EventArgs());
                    break;
                case WIZSCN.S2:
                case WIZSCN.S3:
                    adr += 0x24;
                    m_buf[adr] = (byte)v2;
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
            if ((idx < 0) || (idx >= m_CharCount))
            {
                return ret;
            }
            int adr = CharAdr(idx);
            switch (m_scn)
            {
                case WIZSCN.S1:
                    adr += 0x27;
                    ret = (byte)m_buf[adr];
                    break;
                case WIZSCN.S2:
                case WIZSCN.S3:
                    adr += 0x25;
                    ret = (byte)m_buf[adr];
                    break;
                default:
                    return ret;
            }

            return ret;
        }
        public void SetCharWeekFromIndex(int idx,byte v)
        {
            if ((idx < 0) || (idx >= m_CharCount))
            {
                return;
            }

            int adr = CharAdr(idx);
            if (m_buf[adr] == 0) return;

            if (CharWeekFromIndex(idx) == v) return;

            switch (m_scn)
            {
                case WIZSCN.S1:
                    adr += 0x27;
                    m_buf[adr] = (byte)v;
                    OnValueChanged(new EventArgs());
                    break;
                case WIZSCN.S2:
                case WIZSCN.S3:
                    adr += 0x25;
                    m_buf[adr] = (byte)v;
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
            if ((idx < 0) || (idx >= m_CharCount))
            {
                return ret;
            }
            int adr = CharAdr(idx);
            switch (m_scn)
            {
                case WIZSCN.S1:
                    adr += 0x28;
                    ret = (sbyte)m_buf[adr];
                    break;
                case WIZSCN.S2:
                case WIZSCN.S3:
                    adr += 0x26;
                    ret = (sbyte)m_buf[adr];
                    break;
                default:
                    return ret;
            }

            return ret;
        }
        public void SetCharACFromIndex(int idx, sbyte v)
        {
            if ((idx < 0) || (idx >= m_CharCount))
            {
                return;
            }
            if (v < -128) v = -128;
            else if (v > 127) v = 127;
            sbyte v2 = (sbyte)v;

            int adr = CharAdr(idx);
            if (m_buf[adr] == 0) return;

            if (CharACFromIndex(idx) == v2) return;

            switch (m_scn)
            {
                case WIZSCN.S1:
                    adr += 0x28;
                    m_buf[adr] = (byte)v2;
                    OnValueChanged(new EventArgs());
                    break;
                case WIZSCN.S2:
                case WIZSCN.S3:
                    adr += 0x26;
                    m_buf[adr] = (byte)v2;
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
            if ((idx < 0) || (idx >= m_CharCount))
            {
                return ret;
            }
            int adr = CharAdr(idx);
            switch (m_scn)
            {
                case WIZSCN.S1:
                    adr += 0x0D;
                    ret = (byte)m_buf[adr];
                    break;
                case WIZSCN.S2:
                case WIZSCN.S3:
                    adr += 0x0B;
                    ret = (byte)m_buf[adr];
                    break;
                default:
                    return ret;
            }
            return ret;
        }
        // ************************************************************************
        public void SetCharStrengthFromIndex(int idx,byte v)
        {
            if ((idx < 0) || (idx >= m_CharCount))
            {
                return;
            }
            int adr = CharAdr(idx);
            if (m_buf[adr] == 0) return;

            if (CharStrengthFromIndex(idx) == v) return;
            switch (m_scn)
            {
                case WIZSCN.S1:
                    adr += 0x0D;
                    m_buf[adr] = (byte)v;
                    OnValueChanged(new EventArgs());
                    break;
                case WIZSCN.S2:
                case WIZSCN.S3:
                    adr += 0x0B;
                    m_buf[adr] = (byte)v;
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
            if ((idx < 0) || (idx >= m_CharCount))
            {
                return ret;
            }
            int adr = CharAdr(idx);
            switch (m_scn)
            {
                case WIZSCN.S1:
                    adr += 0x0E;
                    ret = (byte)m_buf[adr];
                    break;
                case WIZSCN.S2:
                case WIZSCN.S3:
                    adr += 0x0C;
                    ret = (byte)m_buf[adr];
                    break;
                default:
                    return ret;
            }
            return ret;
        }
        // ************************************************************************
        public void SetCharIQFromIndex(int idx, byte v)
        {
            if ((idx < 0) || (idx >= m_CharCount))
            {
                return;
            }
            if (v < 0) v = 0;
            else if (v > 0xFF) v = 0xFF;

            int adr = CharAdr(idx);
            if (m_buf[adr] == 0) return;
            if (CharIQFromIndex(idx) == v) return;

            switch (m_scn)
            {
                case WIZSCN.S1:
                    adr += 0x0E;
                    m_buf[adr] = (byte)v;
                    OnValueChanged(new EventArgs());
                    break;
                case WIZSCN.S2:
                case WIZSCN.S3:
                    adr += 0x0C;
                    m_buf[adr] = (byte)v;
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
            if ((idx < 0) || (idx >= m_CharCount))
            {
                return ret;
            }
            int adr = CharAdr(idx);
            switch (m_scn)
            {
                case WIZSCN.S1:
                    adr += 0x0F;
                    ret = (byte)m_buf[adr];
                    break;
                case WIZSCN.S2:
                case WIZSCN.S3:
                    adr += 0x0D;
                    ret = (byte)m_buf[adr];
                    break;
                default:
                    return ret;
            }
            return ret;
        }
        // ************************************************************************
        public void SetCharPietyFromIndex(int idx, byte v)
        {
            if ((idx < 0) || (idx >= m_CharCount))
            {
                return;
            }
            if (v < 0) v = 0;
            else if (v > 0xFF) v = 0xFF;

            int adr = CharAdr(idx);
            if (m_buf[adr] == 0) return;
            if (CharPietyFromIndex(idx) == v) return;

            switch (m_scn)
            {
                case WIZSCN.S1:
                    adr += 0x0F;
                    m_buf[adr] = (byte)v;
                    OnValueChanged(new EventArgs());
                    break;
                case WIZSCN.S2:
                case WIZSCN.S3:
                    adr += 0x0D;
                    m_buf[adr] = (byte)v;
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
            if ((idx < 0) || (idx >= m_CharCount))
            {
                return ret;
            }
            int adr = CharAdr(idx);
            switch (m_scn)
            {
                case WIZSCN.S1:
                    adr += 0x10;
                    ret = (byte)m_buf[adr];
                    break;
                case WIZSCN.S2:
                case WIZSCN.S3:
                    adr += 0x0E;
                    ret = (byte)m_buf[adr];
                    break;
                default:
                    return ret;
            }
            return ret;
        }
        // ************************************************************************
        public void SetCharVitarityFromIndex(int idx, byte v)
        {
            if ((idx < 0) || (idx >= m_CharCount))
            {
                return;
            }
            if (v < 0) v = 0;
            else if (v > 0xFF) v = 0xFF;

            int adr = CharAdr(idx);
            if (m_buf[adr] == 0) return;

            if (CharVitarityFromIndex(idx) == v) return;
            switch (m_scn)
            {
                case WIZSCN.S1:
                    adr += 0x10;
                    m_buf[adr] = (byte)v;
                    OnValueChanged(new EventArgs());
                    break;
                case WIZSCN.S2:
                case WIZSCN.S3:
                    adr += 0x0E;
                    m_buf[adr] = (byte)v;
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
            if ((idx < 0) || (idx >= m_CharCount))
            {
                return ret;
            }
            int adr = CharAdr(idx);
            switch (m_scn)
            {
                case WIZSCN.S1:
                    adr += 0x11;
                    ret = (byte)m_buf[adr];
                    break;
                case WIZSCN.S2:
                case WIZSCN.S3:
                    adr += 0x0F;
                    ret = (byte)m_buf[adr];
                    break;
                default:
                    return ret;
            }
            return ret;
        }
        // ************************************************************************
        public void SetCharAgilityFromIndex(int idx, byte v)
        {
            if ((idx < 0) || (idx >= m_CharCount))
            {
                return;
            }
            if (v < 0) v = 0;
            else if (v > 0xFF) v = 0xFF;

            int adr = CharAdr(idx);
            if (m_buf[adr] == 0) return;

            if (CharAgilityFromIndex(idx) == v) return;

            switch (m_scn)
            {
                case WIZSCN.S1:
                    adr += 0x11;
                    m_buf[adr] = (byte)v;
                    OnValueChanged(new EventArgs());
                    break;
                case WIZSCN.S2:
                case WIZSCN.S3:
                    adr += 0x0F;
                    m_buf[adr] = (byte)v;
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
            if ((idx < 0) || (idx >= m_CharCount))
            {
                return ret;
            }
            int adr = CharAdr(idx);
            switch (m_scn)
            {
                case WIZSCN.S1:
                    adr += 0x12;
                    ret = (byte)m_buf[adr];
                    break;
                case WIZSCN.S2:
                case WIZSCN.S3:
                    adr += 0x10;
                    ret = (byte)m_buf[adr];
                    break;
                default:
                    return ret;
            }
            return ret;
        }
        // ************************************************************************
        public void SetCharLuckFromIndex(int idx, byte v)
        {
            if ((idx < 0) || (idx >= m_CharCount))
            {
                return;
            }
            if (v < 0) v = 0;
            else if (v > 0xFF) v = 0xFF;

            int adr = CharAdr(idx);
            if (m_buf[adr] == 0) return;

            if (CharLuckFromIndex(idx) == v) return;

            switch (m_scn)
            {
                case WIZSCN.S1:
                    adr += 0x12;
                    m_buf[adr] = (byte)v;
                    OnValueChanged(new EventArgs());
                    break;
                case WIZSCN.S2:
                case WIZSCN.S3:
                    adr += 0x10;
                    m_buf[adr] = (byte)v;
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

            if ((idx < 0) || (idx >= m_CharCount))
            {
                return ret;
            }
            int adr = CharAdr(idx);
            switch (m_scn)
            {
                case WIZSCN.S1:
                    adr += 0x1F;
                    ret = (ushort)((ushort)m_buf[adr] * 0x100 + (ushort)m_buf[adr+1] );
                    break;
                case WIZSCN.S2:
                case WIZSCN.S3:
                    adr += 0x1D;
                    ret = (ushort)((ushort)m_buf[adr] + (ushort)m_buf[adr + 1] * 0x100);
                    break;
                default:
                    return ret;
            }

            return ret;
        }
        // ************************************************************************
        public void SetCharHPFromIndex(int idx,ushort v)
        {
            if ((idx < 0) || (idx >= m_CharCount))
            {
                return;
            }
            int adr = CharAdr(idx);
            if (v < 0) v = 0;
            else if (v > 0xFFFF) v = 0xFFFF;

            if (m_buf[adr] == 0) return;

            if (CharHPFromIndex(idx) == v) return;

            switch (m_scn)
            {
                case WIZSCN.S1:
                    adr += 0x1F;
                    m_buf[adr] = (byte)((v >> 8) & 0xFF);
                    m_buf[adr+1] = (byte)(v  & 0xFF);
                    OnValueChanged(new EventArgs());
                    break;
                case WIZSCN.S2:
                case WIZSCN.S3:
                    adr += 0x1D;
                    m_buf[adr] = (byte)((v >> 0) & 0xFF);
                    m_buf[adr + 1] = (byte)((v>>8) & 0xFF);
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

            if ((idx < 0) || (idx >= m_CharCount))
            {
                return ret;
            }
            int adr = CharAdr(idx);

            switch (m_scn)
            {
                case WIZSCN.S1:
                    adr += 0x21;
                    ret = (ushort)((ushort)m_buf[adr] * 0x100 + (ushort)m_buf[adr + 1]);
                    break;
                case WIZSCN.S2:
                case WIZSCN.S3:
                    adr += 0x1F;
                    ret = (ushort)((ushort)m_buf[adr] + (ushort)m_buf[adr + 1] * 0x100);
                    break;
                default:
                    return ret;
            }

            return ret;
        }
        // ************************************************************************
        public void SetCharHPMaxFromIndex(int idx, ushort v)
        {
            if ((idx < 0) || (idx >= m_CharCount))
            {
                return;
            }
            int adr = CharAdr(idx);
            if (v < 0) v = 0;
            else if (v > 0xFFFF) v = 0xFFFF;
            if (m_buf[adr] == 0) return;
            if (CharHPMaxFromIndex(idx) == v) return;

            switch (m_scn)
            {
                case WIZSCN.S1:
                    adr += 0x21;
                    m_buf[adr] = (byte)((v >> 8) & 0xFF);
                    m_buf[adr + 1] = (byte)(v & 0xFF);
                    OnValueChanged(new EventArgs());
                    break;
                case WIZSCN.S2:
                case WIZSCN.S3:
                    adr += 0x1F;
                    m_buf[adr] = (byte)((v >> 0) & 0xFF);
                    m_buf[adr + 1] = (byte)((v >>8) & 0xFF);
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

            if ((idx < 0) || (idx >= m_CharCount))
            {
                return ret;
            }
            int adr = CharAdr(idx);
            int v = 0;
            switch (m_scn)
            {
                case WIZSCN.S1:
                    adr += 0x25;
                    v = (int)(m_buf[adr] & 0x7);
                    break;
                case WIZSCN.S2:
                case WIZSCN.S3:
                    adr += 0x23;
                    v = (int)(m_buf[adr] & 0x7);
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
            if ((idx < 0) || (idx >= m_CharCount))
            {
                return;
            }
            int adr = CharAdr(idx);
            if (m_buf[adr] == 0) return;
            if (CharStatusFromIndex(idx) == v) return;
            byte v2 = (byte)((byte)v & 0x0F);
            switch (m_scn)
            {
                case WIZSCN.S1:
                    adr += 0x25;
                    m_buf[adr] = v2;
                    OnValueChanged(new EventArgs());
                    break;
                case WIZSCN.S2:
                case WIZSCN.S3:
                    adr += 0x23;
                    m_buf[adr] = v2;
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
            if ((idx < 0) || (idx >= m_CharCount)) return ret;

            return GetCode(CharAdr(idx), sz);

        }
        // ************************************************************************
        public void SetCharDataFromIndex(int idx,byte[] a)
        {
            if ((idx < 0) || (idx >= m_CharCount)) return;
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

            if ((idx < 0) || (idx >= m_CharCount))
            {
                return ret;
            }
            int adr = CharAdr(idx);
            switch (m_scn)
            {
                case WIZSCN.S1:
                    ret.NowP = GetCode(adr + 0x29, 7);
                    ret.MaxP = GetCode(adr + 0x37, 7);
                    ret.Learning = GetCode(adr + 0x45, 7);
                    break;
                case WIZSCN.S2:
                case WIZSCN.S3:
                    byte [] a = GetCode(adr + 0x27, 7);
                    for ( int i=0; i<7; i++)
                    {
                        ret.NowP[i] = (byte)((a[i] >> 4) & 0xF);
                        ret.MaxP[i] = (byte)(a[i] & 0xF);
                    }
                    ret.Learning = GetCode(adr + 0x35, 7);
                    break;
                default:
                    return ret;
            }
            return ret;

        }
        // ************************************************************************
        public void SetCharMagicFromIndex(int idx, MagicPoint mp)
        {
            if ((idx < 0) || (idx >= m_CharCount))
            {
                return;
            }
            int adr = CharAdr(idx);
            if (m_buf[adr] == 0) return;

            switch (m_scn)
            {
                case WIZSCN.S1:
                    SetCode(adr + 0x29, mp.NowP);
                    SetCode(adr + 0x37, mp.MaxP);
                    break;
                case WIZSCN.S2:
                case WIZSCN.S3:
                    byte[] aa = new byte[7];
                    for (int i = 0; i < 7; i++)
                    {
                        aa[i] = (byte)((byte)((byte)(mp.NowP[i]) & 0x0F) << 4 | (byte)((byte)(mp.MaxP[i]) & 0x0F));
                    }
                    SetCode(adr + 0x27, aa);
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

            if ((idx < 0) || (idx >= m_CharCount))
            {
                return ret;
            }
            int adr = CharAdr(idx);
            switch (m_scn)
            {
                case WIZSCN.S1:
                    ret.NowP = GetCode(adr + 0x30, 7);
                    ret.MaxP = GetCode(adr + 0x3E, 7);
                    ret.Learning = GetCode(adr + 0x45, 7);
                    break;
                case WIZSCN.S2:
                case WIZSCN.S3:
                    byte[] a = GetCode(adr + 0x2E, 7);
                    for (int i = 0; i < 7; i++)
                    {
                        ret.NowP[i] = (byte)((a[i] >> 4) & 0xF);
                        ret.MaxP[i] = (byte)(a[i] & 0xF);
                    }
                    ret.Learning = GetCode(adr + 0x3C, 7);
                    break;
                default:
                    return ret;
            }
            return ret;

        }
        // ************************************************************************
        public void SetCharPriestFromIndex(int idx, MagicPoint mp)
        {
            if ((idx < 0) || (idx >= m_CharCount))
            {
                return;
            }
            int adr = CharAdr(idx);
            if (m_buf[adr] == 0) return;

            switch (m_scn)
            {
                case WIZSCN.S1:
                    SetCode(adr + 0x30, mp.NowP);
                    SetCode(adr + 0x3E, mp.MaxP);
                    break;
                case WIZSCN.S2:
                case WIZSCN.S3:
                    byte[] aa = new byte[7];
                    for (int i = 0; i < 7; i++)
                    {
                        aa[i] = (byte)((byte)((byte)(mp.NowP[i]) & 0x0F) << 4 | (byte)((byte)(mp.MaxP[i]) & 0x0F));
                    }
                    SetCode(adr + 0x2E, aa);
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
            if ((c_idx < 0) || (c_idx >= m_CharCount))
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
                case WIZSCN.S1:
                    cnt = m_buf[adr + 0x5C];
                    if (i_idx < cnt)
                    {
                        ret.ID = m_buf[adr + 0x54 + i_idx];
                        ret.Status = m_buf[adr + 0x4C + i_idx];
                    }
                    break;
                case WIZSCN.S2:
                case WIZSCN.S3:
                    cnt = m_buf[adr + 0x53];
                    if (i_idx < cnt)
                    {
                        ret.ID = m_buf[adr + 0x4B + i_idx];
                        ret.Status = m_buf[adr + 0x43 + i_idx];
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
            if ((c_idx < 0) || (c_idx >= m_CharCount))
            {
                return;
            }
            if ((i_idx < 0) || (i_idx >= 8))
            {
                return;
            }
            int adr = CharAdr(c_idx);
            if (m_buf[adr] == 0) return;
            int cnt = 0;
            bool upd = false;
            int ad = 0;
            switch (m_scn)
            {
                case WIZSCN.S1:
                    cnt = m_buf[adr + 0x5C];
                    if (i_idx < cnt)
                    {
                        ad = adr + 0x54 + i_idx;
                        if (m_buf[ad] != wi.ID)
                        {
                            m_buf[ad] = wi.ID;
                            upd = true;
                        }
                        ad = adr + 0x4C + i_idx;
                        if (m_buf[ad] != wi.Status)
                        {
                            m_buf[ad] = wi.Status;
                            upd = true;
                        }
                    }
                    break;
                case WIZSCN.S2:
                case WIZSCN.S3:
                    cnt = m_buf[adr + 0x53];
                    if (i_idx < cnt)
                    {
                        ad = adr + 0x4B + i_idx;
                        if (m_buf[ad] != wi.ID)
                        {
                            m_buf[ad] = wi.ID;
                            upd = true;
                        }
                        ad = adr + 0x43 + i_idx;
                        if (m_buf[ad] != wi.Status)
                        {
                            m_buf[ad] = wi.Status;
                            upd = true;
                        }
                    }
                    break;
            }
            if(upd==true)
            {
                OnValueChanged(new EventArgs());
            }

        }
        // ************************************************************************
        public byte [] CharSpellFromIndex(int idx)
        {
            byte[] ret = new byte[0];
            if ((idx < 0) || (idx >= m_CharCount))
            {
                return ret;
            }
            int adr = CharAdr(idx);
            switch (m_scn)
            {
                case WIZSCN.S1:
                    adr += 0x45;
                    ret = GetCode(adr, 7);
                    break;
                case WIZSCN.S2:
                case WIZSCN.S3:
                    //Wiz2MSkill = $35;
                    //Wiz2PSkill = $3C;
                    adr += 0x35;
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
            if ((idx < 0) || (idx >= m_CharCount))
            {
                return;
            }
            int adr = CharAdr(idx);
            if (m_buf[adr] == 0) return;
            switch (m_scn)
            {
                case WIZSCN.S1:
                    adr += 0x45;
                    if (a.Length == 7)
                    {
                        SetCode(adr, a);
                    }
                    break;
                case WIZSCN.S2:
                case WIZSCN.S3:
                    //Wiz2MSkill = $35;
                    //Wiz2PSkill = $3C;
                    adr += 0x35;
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
            if ((idx < 0) || (idx >= m_CharCount))
            {
                return ret;
            }
            int adr = CharAdr(idx);
            int cnt = 0;
            switch (m_scn)
            {
                case WIZSCN.S1:
                    cnt = m_buf[adr + 0x5C];
                    if (cnt>0)
                    {
                        ret = new WizItem[cnt];
                        for (int i = 0; i < cnt; i++)
                        {
                            ret[i] = new WizItem(m_scn)
                            {
                                ID = m_buf[adr + 0x54 + i],
                                Status = m_buf[adr + 0x4C + i]
                            };
                        }
                    }

                    break;
                case WIZSCN.S2:
                case WIZSCN.S3:
                    cnt = m_buf[adr + 0x53];
                    if (cnt > 0)
                    {
                        ret = new WizItem[cnt];
                        for (int i = 0; i < cnt; i++)
                        {
                            ret[i] = new WizItem(m_scn)
                            {
                                ID = m_buf[adr + 0x4B + i],
                                Status = m_buf[adr + 0x43 + i]
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
        public string CodeToString(byte v)
        {
            return WizFCString.CodeToString(m_scn, v);
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
            int bs = m_buf.Length;
            int ss = s.Length;
            if (bs <= 0) return ret;
            if (ss <= 0) return ret;
            if (index >= bs) return ret;
            int bs2 = bs - ss;
            if (bs2 < 0) return ret;
            for (int i = index; i < bs2; i++)
            {
                if (m_buf[i] == s[0])
                {
                    bool flg = true;
                    for (int j = 0; j < ss; j++)
                    {
                        if (m_buf[i + j] != s[j])
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
            if ((len <= 0)||(index <0)||(index>= m_buf.Length))
            {
                return ret;
            }
            for ( int i=0; i<len;i++)
            {
                ret[i] = m_buf[index + i];
            }
            return ret;
        }
        public void SetCode(int index, byte [] a)
        {
            int len = a.Length;
            if (len <= 0) return;
            if ((len > 0) && (index >= 0) && (index < m_buf.Length))
            {
                for (int i = 0; i < len; i++)
                {
                    m_buf[index + i] = a[i];
                }
            }

        }
        // ************************************************************************
        /// <summary>
        /// 読み込んだデータがStateファイルでWiz Nesか確認
        /// </summary>
        /// <returns>正常ならtrue。scnにシナリオナンバーを設定</returns>
        private bool ChkState()
        {
            bool ret = false;
            m_scn = WIZSCN.NO;
            m_sramAdr = -1;
            m_CharCurrent = -1;

            //サイズチェック
            if (m_buf.Length < 14872) return ret;

            int idx = FindString("SNSS", 0);
            if (idx != 0) return ret;
            idx = FindString("BASR", idx);
            if (idx != 8) return ret;

            int sramIdx = FindString("SRAM");
            if (sramIdx < 0) return ret;
            m_sramAdr = sramIdx + 4;



            if (FindString("Wizardry-Proving Grounds",idx)>0)
            {
                m_scn = WIZSCN.S1;
            }else if (FindString("Wizardry-Legacy of Llylgamyn", idx) > 0)
            {
                m_scn = WIZSCN.S2;
            }
            else if (FindString("GAME STUDIO Inc.", idx) > 0)
            {
                m_scn = WIZSCN.S3;
            }
            ret = (m_scn != WIZSCN.NO);

            if(ret==true)
            {
                CharCurrent = 0;
                m_FileMode = FILEMODE.STATE;
            }
            else
            {
                m_buf = new byte[0];
            }

            return ret;
        }
        private bool ChkSave()
        {
            bool ret = false;
            m_scn = WIZSCN.NO;
            m_sramAdr = 0;
            m_CharCurrent = 0;

            //サイズチェック
            if (m_buf.Length < 8192) return ret;


            int idx = -1;
            idx = FindString("YAJIMAK.CROSS", 0x1FE0);
            if(idx>0x1FE0)
            {
                m_scn = WIZSCN.S1;
                m_FileMode = FILEMODE.SAVE;
                ret = true;
            }
            else
            {
                idx = -1;
                idx = FindString("By Kei Cross08-10-88", 0x1F70);
                if (idx > 0x1F70)
                {
                    m_scn = WIZSCN.S2;
                    m_FileMode = FILEMODE.SAVE;
                    ret = true;
                }
                else
                {
                    idx = -1;
                    idx = FindString("Kei Cross06/10/89", 0x1F70);
                    if (idx > 0x1F70)
                    {
                        m_scn = WIZSCN.S3;
                        m_FileMode = FILEMODE.SAVE;
                        ret = true;
                    }
                    else
                    {
                        idx = -1;
                    }
                }

            }
            if(ret==false)
            {
                m_buf = new byte[0];
            }
            else
            {
                CharCurrent = 0;
                m_sramAdr = 0;
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
            m_statePath = "";
            if (File.Exists(p) == false) return ret;
            FileStream fs = new FileStream(p, FileMode.Open, FileAccess.Read);
            try
            {
                int fsize = (int)fs.Length;
                m_buf = new byte[fsize];
                int sz = fs.Read(m_buf, 0, fsize);
                if (sz == fsize)
                {
                    ret = ChkState();
                    if(ret==false)
                    {
                        ret = ChkSave();
                    }
                }
            }
            finally
            {
                fs.Close();
            }
            if (ret == false)
            {
                m_buf = new byte[0];
            }
            else
            {
                m_statePath = p;
                OnLoadFileFinished(EventArgs.Empty);
            }
            //イベント
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
            if (m_buf.Length <= 0) return ret;


            if(m_FileMode==FILEMODE.SAVE)
            {
                if(m_scn == WIZSCN.S1)
                {
                    ChecksumWiz1();
                }
                else
                {
                    return false;
                }
            }


            FileStream fs = new FileStream(p,FileMode.Create,FileAccess.Write);
            try
            {
                fs.Write(m_buf, 0, m_buf.Length);
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
                m_statePath = p;
            }

            return ret;
        }
        // ************************************************************************
        public bool Save()
        {
            if(m_statePath!="")
            {
                return SaveFile(m_statePath);
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
            dlg.Filter =
                 "Johnファイル(*.jn*)|*.jn*;" +
                 "|NNNesterJファイル(*.ss*)|*.ss*;" +
                 "|Savファイル(*.ss*)|*.Sav;" +
                 "|すべてのファイル(*.*)|*.*";
            dlg.Title = "保存先のファイルを選択してください";
            dlg.RestoreDirectory = true;
            if (m_statePath!="")
            {
                dlg.FileName = Path.GetFileName(m_statePath);
                dlg.InitialDirectory = Path.GetDirectoryName(m_statePath);
            }

            //ダイアログを表示する
            if (dlg.ShowDialog() == DialogResult.OK)
            {
                ret = SaveFile(dlg.FileName);
            }
            return ret;
        }
        public bool LoadFile()
        {
            bool ret = false;
            OpenFileDialog dlg = new OpenFileDialog();
            if (m_statePath != "")
            {
                dlg.FileName = Path.GetFileName(m_statePath);
                dlg.InitialDirectory = Path.GetDirectoryName(m_statePath);
            }
            else
            {
                dlg.FileName = "";

            }
            dlg.Filter =
       "Johnファイル(*.jn*)|*.jn*;" +
       "|NNNesterJファイル(*.ss*)|*.ss*;" +
       "|Savファイル(*.ss*)|*.Sav;" +
       "|すべてのファイル(*.*)|*.*";
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
            if(m_statePath!="")
            {
                LoadFile(m_statePath);
            }
        }
        public bool IsReload
        {
            get { return (m_statePath != ""); }
        }
        // ************************************************************************
        private WIZSCN m_res_scn = WIZSCN.S1;
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
        /// <summary>
        /// リソースにあるsテートデータの読み出し
        /// </summary>
        /// <returns></returns>
        public bool ResLoad()
        {
            bool ret = false;
            if (File.Exists( m_statePath) == true) return ret;
            byte[] bs = null;
            switch(m_res_scn)
            {
                case WIZSCN.S1:
                    bs= Properties.Resources.Wizardry1;
                    break;
                case WIZSCN.S2:
                    bs = Properties.Resources.Wizardry2;
                    break;
                case WIZSCN.S3:
                    bs = Properties.Resources.Wizardry3;
                    break;
                default:
                    return ret;
            }
            int ln = bs.Length;
            if (ln>0)
            {
                m_buf = new byte[ln];
                for (int i = 0; i < ln; i++) m_buf[i] = bs[i];
                ret = ChkState();
                if(ret==false)
                {
                    ret = ChkSave();

                }
                if (ret == false)
                {
                    m_buf = new byte[0];
                }
                else
                {
                    m_statePath = "";
                    OnLoadFileFinished(new EventArgs());
                }
            }
            return ret;
        }
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
        /// <summary>
        /// キャラクタの場所入れ替え
        /// </summary>
        /// <param name="idx0"></param>
        /// <param name="idx1"></param>
        public void SwapChar(int idx0,int idx1)
        {
            if ((idx0 < 0) || (idx0 >= m_CharCount)) return;
            if ((idx1 < 0) || (idx1 >= m_CharCount)) return;
            if (idx0 == idx1) return;

            int sz = CharSize;
            int adr0 = CharAdr(idx0);
            int adr1 = CharAdr(idx1);

            byte[] tmp0 = GetCode(adr0, sz);
            byte[] tmp1 = GetCode(adr1, sz);

            SetCode(adr0, tmp1);
            SetCode(adr1, tmp0);
        }
        /// <summary>
        /// キャラのソート
        /// </summary>
        public void CurrentDataUp()
        {
            if ((m_CharCurrent <= 0)||(m_CharCurrent >= m_CharCount)) return;
            SwapChar(m_CharCurrent - 1, m_CharCurrent);
            m_CharCurrent--;
            OnValueChanged(new EventArgs());
        }
        /// <summary>
        /// キャラのソート
        /// </summary>
        public void CurrentDataDown()
        {
            if ((m_CharCurrent < 0) || (m_CharCurrent >= m_CharCount-1)) return;
            SwapChar(m_CharCurrent, m_CharCurrent+1);
            m_CharCurrent++;
            OnValueChanged(new EventArgs());
        }
        #endregion
        // ************************************************************************
        private void Checksum()
        {
            int adrCS = 0;
            switch (m_scn)
            {
                case WIZSCN.S1:
                    adrCS =  0x080;
                    break;
                case WIZSCN.S2:
                    adrCS = 0x0060;
                    break;
                case WIZSCN.S3:
                    adrCS = 0x0060;
                    break;
                default:
                    return;
            }

            for ( int i=0;i<m_CharCount;i++)
            {
                int adr = CharAdr(i);
                byte[] a = GetCode(adr, adrCS);
                ushort crc = CRC16.Calc(a, (ushort)a.Length, 0xFFFF);
                if(crc!=0)
                {
                    crc = CRC16.Calc(a, (ushort)(a.Length - 2), 0xFFFF);
                    m_buf[adr + adrCS] = (byte)((crc >> 8) & 0xFF);
                    m_buf[adr + adrCS+1] = (byte)(crc & 0xFF);
                }
            }
        }
        private void ChecksumWiz1()
        {
            int chrSz = 0x80;
            for (int i = 0; i < m_CharCount; i++)
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
    }
}

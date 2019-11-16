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

namespace WizEdit
{
    #region Const
    public enum WIZ_SCN
    {
        NO = 0,
        S1 = 1,
        S2,
        S3
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
    public class WizNesState :Component
    {
        public const int BounusCount = 6;
 
        #region Event
        //CurrentCharが変更された時
        public delegate void ChangeCurrentCharHandler(object sender, CurrentCharEventArgs e);
        public event ChangeCurrentCharHandler ChangeCurrentChar;
        protected virtual void OnChangeCurrentChar(CurrentCharEventArgs e)
        {
            ChangeCurrentChar?.Invoke(this, e);
        }
        //ファイルがロードされた時
        public event EventHandler FinishedLoadFile;
        protected virtual void OnFinishedLoadFile(EventArgs e)
        {
            FinishedLoadFile?.Invoke(this, e);
        }
        #endregion

        #region prop
        /// <summary>
        /// 読み込んだステートファイルそのもの
        /// </summary>
        private byte[] m_stateBuf = new byte[0];
        private int m_sramIndex = -1;
        /// <summary>
        /// SRAM領域のアドレス
        /// </summary>
        public int SramAdr { get { return m_sramIndex; } }
        /// <summary>
        /// SRAMのサイズ
        /// </summary>
        public int SRAM_SIZE { get { return 0x1FFF; } }

        private WIZ_SCN m_scn = WIZ_SCN.NO;
        /// <summary>
        /// 読み込んだステートファイルのシナリオ
        /// </summary>
        public WIZ_SCN SCN { get { return m_scn; } }

        public int CharNameLength {get{ return 8; } }
        public int  CharCountMax { get { return 20; } }
        private int m_CharCount = 0;
        /// <summary>
        /// 訓練所に登録されているキャラクタ数
        /// </summary>
        public int CharCount { get { return m_CharCount; } }

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
                OnChangeCurrentChar(e);
            }
        }
        public void CharCurrentUp()
        {
            if ((m_CharCurrent>0)&&(m_CharCount>0))
            {
                CharCurrent = m_CharCurrent - 1;
            }
        }
        public void CharCurrentDown()
        {
            if ((m_CharCurrent < m_CharCount -1) && (m_CharCount > 0))
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
        static public readonly string[] AlgStr = new string[]
       {
            "Good",
            "Neutral",
            "Evil"
       };
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
        #endregion
        // ***********************************************************************
        /// <summary>
        /// コンストラクタ
        /// </summary>
        public WizNesState()
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
                switch (m_scn)
                {
                    case WIZ_SCN.S1:
                        return 0x0009;
                    case WIZ_SCN.S2:
                        return 0x0409;
                    case WIZ_SCN.S3:
                        return 0x0409;
                    default:
                        return 0;
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
                    case WIZ_SCN.S1:
                        return 0x0100;
                    case WIZ_SCN.S2:
                        return 0x0060;
                    case WIZ_SCN.S3:
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
        public string CharNameFromIndex(int index)
        {
            int idx = CharAdr(index);
            if (idx <= 0) return "";
            idx += 2;
            byte[] nm = GetCode(idx, CharNameLength);
            return WizNesString.CodeToString(m_scn, nm);

        }
        // ************************************************************************
        public string [] CharNames
        {
            get
            {
                string[] ret = new string[m_CharCount];
                if (m_CharCount>0)
                {
                    for ( int i=0; i<m_CharCount;i++)
                    {
                        ret[i] = CharNameFromIndex(i);
                    }
                }
                return ret;
            }
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
                case WIZ_SCN.S1:
                    adr += 0x0A;
                    ret = (WIZRACE)(m_stateBuf[adr] & 0x07);
                    break;
                case WIZ_SCN.S2:
                case WIZ_SCN.S3:
                    adr += 0x0A;
                    ret = (WIZRACE)(m_stateBuf[adr] >> 5 & 0x07);
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
            switch (m_scn)
            {
                case WIZ_SCN.S1:
                    adr += 0x0A;
                    m_stateBuf[adr] = (byte)((byte)r & 0x07);
                    break;
                case WIZ_SCN.S2:
                case WIZ_SCN.S3:
                    adr += 0x0A;
                    byte v = m_stateBuf[adr];
                    byte v2 = (byte)(((byte)r & 0x07) << 5);
                    v = (byte)((v & 0x1F) | v2);
                    m_stateBuf[adr] = v;
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
                case WIZ_SCN.S1:
                    adr += 0x0B;
                    ret = (WIZCLASS)(m_stateBuf[adr] & 0x07);
                    break;
                case WIZ_SCN.S2:
                case WIZ_SCN.S3:
                    adr += 0x0A;
                    ret = (WIZCLASS)(m_stateBuf[adr] >> 2 & 0x07);
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
            switch (m_scn)
            {
                case WIZ_SCN.S1:
                    adr += 0x0B;
                    m_stateBuf[adr] = (byte)((byte)cl & 0x07);
                    break;
                case WIZ_SCN.S2:
                case WIZ_SCN.S3:
                    adr += 0x0A;
                    byte v = m_stateBuf[adr];
                    byte v2 = (byte)(((byte)cl & 0x07) << 2); // 
                    v = (byte)((v & 0xE3) | v2);
                    m_stateBuf[adr] = v;
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
                case WIZ_SCN.S1:
                    adr += 0x0C;
                    ret = (WIZALG)(m_stateBuf[adr] & 0x03);
                    break;
                case WIZ_SCN.S2:
                case WIZ_SCN.S3:
                    adr += 0x0A;
                    ret = (WIZALG)(m_stateBuf[adr] & 0x03);
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
            switch (m_scn)
            {
                case WIZ_SCN.S1:
                    adr += 0x0C;
                    m_stateBuf[adr] = (byte)((byte)alg & 0x03);
                    break;
                case WIZ_SCN.S2:
                case WIZ_SCN.S3:
                    //adr += 0x0A;
                    byte v = m_stateBuf[adr + 0x0A];
                    v = (byte)((v & 0xFC) | (byte)alg);
                    m_stateBuf[adr + 0x0A] = v;
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
        public int CharLevelFromIndex(int idx)
        {
            int ret = 1;
            if ((idx < 0) || (idx >= m_CharCount))
            {
                return ret;
            }
            int adr = CharAdr(idx);
            switch (m_scn)
            {
                case WIZ_SCN.S1:
                    adr += 0x23;
                    ret = ((int)m_stateBuf[adr] * 0x100 + (int)m_stateBuf[adr + 1]);
                    break;
                case WIZ_SCN.S2:
                case WIZ_SCN.S3:
                    adr += 0x21;
                    ret = ((int)m_stateBuf[adr] * 0x100 + (int)m_stateBuf[adr + 1]);
                    break;
                default:
                    return ret;
            }

            return ret;
        }
        // ************************************************************************
        public int CharLevel
        {
            get { return CharLevelFromIndex(m_CharCurrent); }
        }
        // ************************************************************************
        public long CharGoldFromIndex(int idx)
        {
            long ret = 1;
            if ((idx < 0) || (idx >= m_CharCount))
            {
                return ret;
            }
            int adr = CharAdr(idx);
            switch (m_scn)
            {
                case WIZ_SCN.S1:
                    adr += 0x13;
                    ret = WizU.WizHexToLong(GetCode(adr, 6));
                    break;
                case WIZ_SCN.S2:
                case WIZ_SCN.S3:
                    adr += 0x11;
                    ret = WizU.WizHexToLong(GetCode(adr, 6));
                    break;
                default:
                    return ret;
            }

            return ret;
        }
        // ************************************************************************
        public long CharGold
        {
            get { return CharGoldFromIndex(m_CharCurrent); }
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
                case WIZ_SCN.S1:
                    adr += 0x19;
                    ret = WizU.WizHexToLong(GetCode(adr, 6));
                    break;
                case WIZ_SCN.S2:
                case WIZ_SCN.S3:
                    adr += 0x17;
                    ret = WizU.WizHexToLong(GetCode(adr, 6));
                    break;
                default:
                    return ret;
            }

            return ret;
        }
        // ************************************************************************
        public long CharExp
        {
            get { return CharExpFromIndex(m_CharCurrent); }
        }
        // ************************************************************************
        public int CharAgeFromIndex(int idx)
        {
            int ret = 1;
            if ((idx < 0) || (idx >= m_CharCount))
            {
                return ret;
            }
            int adr = CharAdr(idx);
            switch (m_scn)
            {
                case WIZ_SCN.S1:
                    adr += 0x26;
                    ret = (int)m_stateBuf[adr];
                    break;
                case WIZ_SCN.S2:
                case WIZ_SCN.S3:
                    adr += 0x24;
                    ret = (int)m_stateBuf[adr];
                    break;
                default:
                    return ret;
            }

            return ret;
        }
        // ************************************************************************
        public long CharAge
        {
            get { return CharAgeFromIndex(m_CharCurrent); }
        }
        // ************************************************************************
        public int CharWeekFromIndex(int idx)
        {
            int ret = 1;
            if ((idx < 0) || (idx >= m_CharCount))
            {
                return ret;
            }
            int adr = CharAdr(idx);
            switch (m_scn)
            {
                case WIZ_SCN.S1:
                    adr += 0x27;
                    ret = (int)m_stateBuf[adr];
                    break;
                case WIZ_SCN.S2:
                case WIZ_SCN.S3:
                    adr += 0x25;
                    ret = (int)m_stateBuf[adr];
                    break;
                default:
                    return ret;
            }

            return ret;
        }
        // ************************************************************************
        public long CharWeek
        {
            get { return CharWeekFromIndex(m_CharCurrent); }
        }
        // ************************************************************************
        public int CharACFromIndex(int idx)
        {
            int ret = 1;
            if ((idx < 0) || (idx >= m_CharCount))
            {
                return ret;
            }
            int adr = CharAdr(idx);
            switch (m_scn)
            {
                case WIZ_SCN.S1:
                    adr += 0x28;
                    ret = (int)m_stateBuf[adr];
                    break;
                case WIZ_SCN.S2:
                case WIZ_SCN.S3:
                    adr += 0x26;
                    ret = (int)m_stateBuf[adr];
                    break;
                default:
                    return ret;
            }

            return ret;
        }
        // ************************************************************************
        public long CharAC
        {
            get { return CharACFromIndex(m_CharCurrent); }
        }       // 
        // ************************************************************************
        public byte[] CharBounusFromIndex(int idx)
        {
            byte[] ret = new byte[BounusCount];

            if ((idx < 0) || (idx >= m_CharCount))
            {
                for (int i =0; i < BounusCount; i++) ret[i] = 0;
                return ret;
            }
            int adr = CharAdr(idx);
            switch (m_scn)
            {
                case WIZ_SCN.S1:
                    adr += 0x0D;
                    ret = GetCode(adr, BounusCount);
                    break;
                case WIZ_SCN.S2:
                case WIZ_SCN.S3:
                    adr += 0x0B;
                    ret = GetCode(adr, BounusCount);
                    break;
                default:
                    return ret;
            }

            return ret;
        }
        // ************************************************************************
        public byte[] CharBounus
        {
            get { return CharBounusFromIndex(m_CharCurrent); }
        }
        // ************************************************************************
        public int CharHPFromIndex(int idx)
        {
            int ret = 0;

            if ((idx < 0) || (idx >= m_CharCount))
            {
                return ret;
            }
            int adr = CharAdr(idx);
            switch (m_scn)
            {
                case WIZ_SCN.S1:
                    adr += 0x1F;
                    ret = m_stateBuf[adr]* 0x100 + m_stateBuf[adr+1];
                    break;
                case WIZ_SCN.S2:
                case WIZ_SCN.S3:
                    adr += 0x1D;
                    ret = m_stateBuf[adr] * 0x100 + m_stateBuf[adr + 1];
                    break;
                default:
                    return ret;
            }

            return ret;
        }
        // ************************************************************************
        public int CharHP
        {
            get { return CharHPFromIndex(m_CharCurrent); }
        }
        // ************************************************************************
        public int CharHPMaxFromIndex(int idx)
        {
            int ret = 0;

            if ((idx < 0) || (idx >= m_CharCount))
            {
                return ret;
            }
            int adr = CharAdr(idx);
            switch (m_scn)
            {
                case WIZ_SCN.S1:
                    adr += 0x21;
                    ret = m_stateBuf[adr] * 0x100 + m_stateBuf[adr + 1];
                    break;
                case WIZ_SCN.S2:
                case WIZ_SCN.S3:
                    adr += 0x1F;
                    ret = m_stateBuf[adr] * 0x100 + m_stateBuf[adr + 1];
                    break;
                default:
                    return ret;
            }

            return ret;
        }
        // ************************************************************************
        public int CharHPMax
        {
            get { return CharHPMaxFromIndex(m_CharCurrent); }
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
                case WIZ_SCN.S1:
                    adr += 0x25;
                    v = (int)(m_stateBuf[adr] & 0x7);
                    break;
                case WIZ_SCN.S2:
                case WIZ_SCN.S3:
                    adr += 0x23;
                    v = (int)(m_stateBuf[adr] & 0x7);
                    break;
                default:
                    return ret;
            }
            ret = (WIZSTATUS)v;

            return ret;
        }
        // ************************************************************************
        public WIZSTATUS CharStatus
        {
            get { return CharStatusFromIndex(m_CharCurrent); }
        }
        public string CharStatusStr
        {
            get
            {
                WIZSTATUS s = CharStatusFromIndex(m_CharCurrent);
                return StatusStr[ (int)s];
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
        public byte[] CharData
        {
            get { return CharDataFromIndex(m_CharCurrent); }
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
                case WIZ_SCN.S1:
                    ret.NowP = GetCode(adr + 0x29, 7);
                    ret.MaxP = GetCode(adr + 0x37, 7);
                    ret.Learning = GetCode(adr + 0x45, 7);
                    break;
                case WIZ_SCN.S2:
                case WIZ_SCN.S3:
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
        public MagicPoint CharMagic
        {
            get { return CharMagicFromIndex(m_CharCurrent); }
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
                case WIZ_SCN.S1:
                    ret.NowP = GetCode(adr + 0x30, 7);
                    ret.MaxP = GetCode(adr + 0x3E, 7);
                    ret.Learning = GetCode(adr + 0x45, 7);
                    break;
                case WIZ_SCN.S2:
                case WIZ_SCN.S3:
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
        public MagicPoint CharPriest
        {
            get { return CharPriestFromIndex(m_CharCurrent); }
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
                case WIZ_SCN.S1:
                    cnt = m_stateBuf[adr + 0x5C];
                    if (cnt>0)
                    {
                        ret = new WizItem[cnt];
                        for (int i = 0; i < cnt; i++)
                        {
                            ret[i] = new WizItem(m_scn);
                            ret[i].ID = m_stateBuf[adr + 0x54 + i];
                            ret[i].Status = m_stateBuf[adr + 0x4C + i];
                        }
                    }

                    break;
                case WIZ_SCN.S2:
                case WIZ_SCN.S3:
                    cnt = m_stateBuf[adr + 0x53];
                    if (cnt > 0)
                    {
                        ret = new WizItem[cnt];
                        for (int i = 0; i < cnt; i++)
                        {
                            ret[i] = new WizItem(m_scn);
                            ret[i].ID = m_stateBuf[adr + 0x4B + i];
                            ret[i].Status = m_stateBuf[adr + 0x43 + i];
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
        public int GetCharCount()
        {
            int ret = 0;
            for ( int i=0; i< CharCountMax;i++)
            {
                if (m_stateBuf[CharAdr(i)]==0)
                {
                    break;
                }
                ret++;
            }
            return ret;
        }
        // ************************************************************************
        public string CodeToString(byte v)
        {
            return WizNesString.CodeToString(m_scn, v);
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
            int bs = m_stateBuf.Length;
            int ss = s.Length;
            if (bs <= 0) return ret;
            if (ss <= 0) return ret;
            if (index >= bs) return ret;
            int bs2 = bs - ss;
            if (bs2 < 0) return ret;
            for (int i = index; i < bs2; i++)
            {
                if (m_stateBuf[i] == s[0])
                {
                    bool flg = true;
                    for (int j = 0; j < ss; j++)
                    {
                        if (m_stateBuf[i + j] != s[j])
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
        }// ************************************************************************
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
            if ((len <= 0)||(index <0)||(index>= m_stateBuf.Length))
            {
                return ret;
            }
            for ( int i=0; i<len;i++)
            {
                ret[i] = m_stateBuf[index + i];
            }
            return ret;
        }
        // ************************************************************************
        /// <summary>
        /// SRAM領域をすべて獲得
        /// </summary>
        /// <returns></returns>
        public byte[] GetSRAM()
        {
            if (m_sramIndex < 0) return new byte[0];
            byte[] ret = GetCode(m_sramIndex,SRAM_SIZE);
            return ret;
        }
        // ************************************************************************
        /// <summary>
        /// 読み込んだデータがStateファイルでWiz Nesか確認
        /// </summary>
        /// <returns>正常ならtrue。scnにシナリオナンバーを設定</returns>
        private bool ChkState()
        {
            bool ret = false;
            m_scn = WIZ_SCN.NO;
            m_sramIndex = -1;
            m_CharCount = 0;
            m_CharCurrent = -1;

            //サイズチェック
            if (m_stateBuf.Length < 14872) return ret;

            int idx = FindString("SNSS", 0);
            if (idx != 0) return ret;
            idx = FindString("BASR", idx);
            if (idx != 8) return ret;

            int sramIdx = FindString("SRAM");
            if (sramIdx < 0) return ret;
            m_sramIndex = sramIdx + 4;



            if (FindString("Wizardry-Proving Grounds",idx)>0)
            {
                m_scn = WIZ_SCN.S1;
            }else if (FindString("Wizardry-Legacy of Llylgamyn", idx) > 0)
            {
                m_scn = WIZ_SCN.S2;
            }
            else if (FindString("GAME STUDIO Inc.", idx) > 0)
            {
                m_scn = WIZ_SCN.S3;
            }
            ret = (m_scn != WIZ_SCN.NO);

            if(ret==true)
            {
                m_CharCount = GetCharCount();
                if(m_CharCount>0)
                {
                    CharCurrent = 0;
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
            if (File.Exists(p) == false) return ret;
            FileStream fs = new FileStream(p, FileMode.Open, FileAccess.Read);
            try
            {
                int fsize = (int)fs.Length;
                m_stateBuf = new byte[fsize];
                int sz = fs.Read(m_stateBuf, 0, fsize);
                if (sz == fsize)
                {
                    ret = ChkState();
                }
            }
            finally
            {
                fs.Close();
            }
            if (ret == false)
            {
                m_stateBuf = new byte[0];
            }
            //イベント
            OnFinishedLoadFile(EventArgs.Empty);

            return ret;
        }
    // ************************************************************************
    public bool ResLoad()
        {
            bool ret = false;
            byte[] bs = Properties.Resources.wiz1;
            int ln = bs.Length;
            if (ln>0)
            {
                m_stateBuf = new byte[ln];
                for (int i = 0; i < ln; i++) m_stateBuf[i] = bs[i];
                ret = ChkState();
                if (ret == false)
                {
                    m_stateBuf = new byte[0];
                }
            }
            return ret;
        }
    }
}

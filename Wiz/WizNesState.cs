using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

using System.IO;

namespace WizEdit
{
    public enum WIZ_SCN
    {
        NO = 0,
        S1 = 1,
        S2,
        S3
    }
    public enum RACE
    {
        HUMAN=0,
        ELF,
        DWARF,
        GNOME,
        HOBIT
    }
    public enum JOB
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
    public enum ALG
    {
        // 0:善, 1:中立, 2:悪
        GOOD =0,
        NEUT,
        EVEL
    }


    public class WizNesState
    {
        #region prop
        private byte[] m_stateBuf = new byte[0];
        private int m_sramIndex = -1;
        public int SramIndex { get { return m_sramIndex; } }
        public int SRAM_SIZE { get { return 0x1FFF; } }

        private WIZ_SCN m_scn = WIZ_SCN.NO;
        public WIZ_SCN SCN { get { return m_scn; } }

        public int CharNameLength {get{ return 8; } }
        public int  CharCountMax { get { return 20; } }
        private int m_CharCount = 0;
        public int CharCount { get { return m_CharCount; } }

        private int m_CharTarget = -1;
        public int CharTarget
        {
            get { return m_CharTarget; }
            set
            {
                if (m_CharCount <= 0) return;
                if ( m_CharTarget != value)
                {
                    m_CharTarget = value;
                }
            }
        }

        static public readonly string[] RaceStr = new string[]
        {
            "HUMAN",
            "ELF",
            "DWARF",
            "GNOME",
            "HOBIT"
        };
        static public readonly string[] JobStr = new string[]
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
            "Evel"
       };
        #endregion
        /// <summary>
        /// 
        /// </summary>
        public WizNesState()
        {
        }
        /// <summary>
        /// キャラクターの先頭アドレス
        /// </summary>
        // ************************************************************************
        public int CharStartIndex
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
        public int CharIndex(int index)
        {
            return SramIndex + CharStartIndex + CharSize * index;
        }
        // ************************************************************************
        public string GetName(int index)
        {
            int idx = CharIndex(index);
            if (idx <= 0) return "";
            idx += 2;
            byte[] nm = GetCode(idx, CharNameLength);
            return WizNesString.CodeToString(m_scn, nm);

        }
        // ************************************************************************
        public RACE GetRace(int idx)
        {
            RACE ret = RACE.HUMAN;

            int adr = CharIndex(idx);
            switch (m_scn)
            {
                case WIZ_SCN.S1:
                    adr += 0x0A;
                    ret = (RACE)(m_stateBuf[adr] & 0x07);
                    break;
                case WIZ_SCN.S2:
                case WIZ_SCN.S3:
                    adr += 0x0A;
                    ret = (RACE)(m_stateBuf[adr] >> 5 & 0x07);
                    break;
                default:
                    return ret;
            }

            return ret;
        }
        // ************************************************************************
        public JOB GetJob(int idx)
        {
            JOB ret = JOB.FIG;

            int adr = CharIndex(idx);
            switch (m_scn)
            {
                case WIZ_SCN.S1:
                    adr += 0x0B;
                    ret = (JOB)(m_stateBuf[adr] & 0x07);
                    break;
                case WIZ_SCN.S2:
                case WIZ_SCN.S3:
                    adr += 0x0A;
                    ret = (JOB)(m_stateBuf[adr] >> 2 & 0x07);
                    break;
                default:
                    return ret;
            }

            return ret;
        }
        // ************************************************************************
        public ALG GetAlg(int idx)
        {
            ALG ret = ALG.GOOD;

            int adr = CharIndex(idx);
            switch (m_scn)
            {
                case WIZ_SCN.S1:
                    adr += 0x0C;
                    ret = (ALG)(m_stateBuf[adr] & 0x03);
                    break;
                case WIZ_SCN.S2:
                case WIZ_SCN.S3:
                    adr += 0x0A;
                    ret = (ALG)(m_stateBuf[adr] & 0x03);
                    break;
                default:
                    return ret;
            }

            return ret;
        }        
        // ************************************************************************
        public byte[] GetCharData(int idx)
        {
            int sz = CharSize;
            byte[] ret = new byte[sz];
            if (sz <= 0) return ret;

            return GetCode(CharIndex(idx), sz);

        }
        // ************************************************************************
        public int GetCharCount()
        {
            int ret = 0;
            for ( int i=0; i< CharCountMax;i++)
            {
                if (m_stateBuf[CharIndex(i)]==0)
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
            m_CharTarget = -1;

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
                    m_CharTarget = 0;
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

            return ret;
        }
    }
}

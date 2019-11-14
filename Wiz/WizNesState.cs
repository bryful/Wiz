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

    #endregion


    public class CurrentCharEventArgs : EventArgs
    {
        public int CurrentChar;
    }
    public class WizNesState :Component
    {
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

        private int m_CurrentChar = -1;
        public int CurrentChar
        {
            get { return m_CurrentChar; }
            set
            {
                if ((value >= 0) && (value < m_CharCount))
                {
                    m_CurrentChar = value;
                }
                else
                {
                    m_CurrentChar = -1;
                }
                //イベント発生
                CurrentCharEventArgs e = new CurrentCharEventArgs();
                e.CurrentChar = m_CurrentChar;
                OnChangeCurrentChar(e);
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
            "Evil"
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
            get { return CharNameFromIndex(m_CurrentChar); }
        }
        // ************************************************************************
        public WIZRACE RaceFromIndex(int idx)
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
        public WIZRACE Race
        {
            get { return RaceFromIndex(m_CurrentChar);}
        }

        // ************************************************************************
        public WIZCLASS ClassFromIndex(int idx)
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
        public WIZCLASS CLASS
        {
            get { return ClassFromIndex(m_CurrentChar); }
        }
        // ************************************************************************
        public WIZALG AlgFromIndex(int idx)
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
        public WIZALG Alg
        {
            get { return AlgFromIndex(m_CurrentChar); }
        }
        // ************************************************************************
        public byte[] GetCharData(int idx)
        {
            int sz = CharSize;
            byte[] ret = new byte[sz];
            if (sz <= 0) return ret;

            return GetCode(CharAdr(idx), sz);

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
            m_CurrentChar = -1;

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
                    CurrentChar = 0;
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

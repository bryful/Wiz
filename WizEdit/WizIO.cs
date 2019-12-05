using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

using System.IO;
using System.IO.Compression;

namespace WizEdit
{
    public class WizIO
    {
        private string m_FilePath = "";
        public string FilePath { get { return m_FilePath; } }

        private WIZFILE m_WizFile = WIZFILE.SAVE;
        public WIZFILE WizFile { get { return m_WizFile; } }

        private WIZSCN m_scn = WIZSCN.NO;
        public WIZSCN SCN { get { return m_scn; } }

        private int m_OffserAdr = 0;
        public int OffserAdr { get { return m_OffserAdr; } }
        private int m_OffserAdr2 = 0;
        public int OffserAdr2 { get { return m_OffserAdr2; } }
        private int m_OffserAdr3 = 0;
        public int OffserAdr3 { get { return m_OffserAdr3; } }

        private byte[] m_Data = new byte[0];
        public byte[] Data
        {
            get { return m_Data; }
        }
        // *******************************************************************************************
        public WizIO()
        {

        }
        // *******************************************************************************************
        public void InitData(int sz = 1024)
        {
            Array.Resize(ref m_Data, sz);
            for (int i = 0; i < m_Data.Length; i++)
            {
                m_Data[i] = 0;
            }
        }
        // *******************************************************************************************
        /// <summary>
        /// バイナリ―ファイルを読み込む gz対応
        /// </summary>
        /// <param name="p"></param>
        /// <returns></returns>
        /// 
        public bool LoadFile(string p)
        {
            bool ret = false;

            if (File.Exists(p) == false) return ret;

            if (IsGZipFile(p) == true)
            {
                ret = LoadGZFile(p);
            }
            else
            {
                ret = LoadRawFile(p);
            }
            if (ret)
            {
                if (ChkData() == true)
                {
                    m_FilePath = p;
                }
                else
                {
                    ret = false;
                }
            }
            return ret;
        }
        // *******************************************************************************************
        public bool LoadData(byte [] ba)
        {
            bool ret = false;
            m_Data = ba;

            if(m_Data.Length>0)
            {
                ret = ChkData();
            }
            return ret;
        }
        // *******************************************************************************************
        private bool IsGZipFile(string p)
        {
            bool ret = false;
            using (FileStream fs = new FileStream(p, FileMode.Open))
            {
                if (fs.Length >= 2)
                {
                    int v0 = fs.ReadByte();
                    int v1 = fs.ReadByte();
                    //1F 8B
                    ret = ((v0 == 0x1F) && (v1 == 0x8B));
                }
            }
            return ret;

        }
        // *******************************************************************************************
        private bool LoadRawFile(string p)
        {
            bool ret = false;
            using (FileStream fs = new FileStream(p, FileMode.Open))
            {
                int sz1 = (int)fs.Length;
                InitData(sz1);
                int sz2 =  fs.Read(m_Data, 0, sz1);

                ret = (sz1 == sz2);
            }
            return ret;
        }
        // *******************************************************************************************
        private bool LoadGZFile(string p)
        {
            bool ret = false;

            using (FileStream inStream = new FileStream(p, FileMode.Open, FileAccess.Read))
            {
                using (GZipStream gzStream = new GZipStream(inStream, CompressionMode.Decompress))
                {
                    // 解凍、取り込み
                    byte[] buffer = new byte[1024];
                    int num;
                    // 出力先のストリーム
                    using (MemoryStream outStream = new MemoryStream())
                    {

                        while ((num = gzStream.Read(buffer, 0, buffer.Length)) > 0)
                        {
                            outStream.Write(buffer, 0, num);
                        }
                        InitData((int)outStream.Length);
                        outStream.Position = 0;
                        outStream.Read(m_Data, 0, (int)outStream.Length);
                        ret = true;
                    }
                }
            }
            return ret;
        }
        // *******************************************************************************************
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
        public int FindString(string s, int index = 0)
        {
            int ret = -1;
            if (s == "") return ret;
            byte[] ss = new byte[s.Length];
            for (int i = 0; i < s.Length; i++)
            {
                ss[i] = (byte)s[i];
            }
            ret = FindCode(ss, index);
            return ret;
        }
        // *******************************************************************************************
        private bool ChkData()
        {
            bool ret = false;
            m_OffserAdr = 0;
            m_OffserAdr2 = 0;
            m_OffserAdr3 = 0;
            m_WizFile = WIZFILE.SAVE;
            m_scn = WIZSCN.NO;

            //ファイルの先頭で判別できるものを最初に
            // FC ROM
            if ((m_Data.Length >= 0x40010) && (m_Data[0] == 0x4E) && (m_Data[1] == 0x45) && (m_Data[2] == 0x43)) //NES
            {
                //文字列を探す
                int idx = FindString("WIZARDRY(KOD)", 0);
                if (idx > 0)
                {
                    m_WizFile = WIZFILE.ROM;
                    m_scn = WIZSCN.FC3;
                    m_OffserAdr = 0x97A6;
                }
                else
                {
                    idx = FindString("WIZARDRY(LOL)", 0);
                    if (idx > 0)
                    {
                        m_WizFile = WIZFILE.ROM;
                        m_scn = WIZSCN.FC2;
                        m_OffserAdr = 0x97C8;
                    }
                    else
                    {
                        idx = FindString("WIZARDRY(PG)", 0);
                        if (idx > 0)
                        {
                            m_WizFile = WIZFILE.ROM;
                            m_scn = WIZSCN.FC1;
                            m_OffserAdr = 0x17310;
                        }
                    }
                }
            }
            // SFC STATE
            else if ((m_Data[0] == 0x23) && (m_Data[1] == 0x21) && (m_Data[2] == 0x73) && (m_Data[3] == 0x39) && (m_Data[3] == 0x78)) //#!s9x
            {
                //00 01 02 03 04 05 06 07 08 09 10
                //52 41 4D 3A 31 33 31 30 37 32 3A
                //R  A  M  :  1  3  1  0  7  2  :
                byte[] ramHeader = new byte[] { 0x52, 0x41, 0x4D, 0x3A, 0x31, 0x33, 0x31, 0x30, 0x37, 0x32, 0x3A };
                int idx = FindCode(ramHeader, 0);
                if (idx < 0) return ret;
                int adr  = idx + ramHeader.Length;
                //sfc wiz123 state
                idx = FindString("1999 / 02 / 19 Gung Ho!Presents", 0); //sfc wiz123
                if (idx > 0)
                {
                    int sc = 0;
                    sc = m_Data[adr + 0x295]; //キャラデータの位置
                    if (sc == 0) sc = m_Data[adr + 0x295 + 0x6E];
                    switch (sc)
                    {
                        case 1:
                            m_scn = WIZSCN.SFC1;
                            break;
                        case 3:
                            m_scn = WIZSCN.SFC2;
                            break;
                        case 2:
                            m_scn = WIZSCN.SFC3;
                            break;
                        default:
                            return ret;
                    }
                    m_OffserAdr = adr +  0x295;
                    m_OffserAdr2 = adr + 0x127F;
                    m_WizFile = WIZFILE.STATE;
                }
                //sfc wiz5 state
                else if (idx < 0)
                {
                    idx = FindString("04 / 22 / 92 Kei Cross Presents", 0); // sfc wiz5
                    if (idx >= 0)
                    {
                        m_WizFile = WIZFILE.STATE;
                        m_scn = WIZSCN.SFC5;
                        m_OffserAdr = adr + 0x100;
                    }
                }
            }
            // FC nnnester State 53 4E 53 53 SNSS
            else if ((m_Data[0] == 0x53) && (m_Data[1] == 0x4E) && (m_Data[2] == 0x53) && (m_Data[3] == 0x53))
            {
                int idx = FindString("SRAM", 0);
                if (idx < 0) return ret;
                if (FindString("Wizardry-Proving Grounds", 0) > 0)
                {
                    m_scn = WIZSCN.FC1;
                    m_WizFile = WIZFILE.STATE;
                    m_OffserAdr = idx + 4 + 0x0009;
                }
                else if (FindString("Wizardry-Legacy of Llylgamyn", 0) > 0)
                {
                    m_scn = WIZSCN.FC2;
                    m_WizFile = WIZFILE.STATE;
                    m_OffserAdr = idx + 4 + 0x0409;
                }
                else if (FindString("GAME STUDIO Inc.", 0) > 0)
                {
                    m_scn = WIZSCN.FC3;
                    m_WizFile = WIZFILE.STATE;
                    m_OffserAdr = idx + 4 + 0x0409;
                }

            }
            // John gbc 47 62 53 73 GbSs
            else if ((m_Data[0] == 0x47) && (m_Data[1] == 0x62) && (m_Data[2] == 0x53) && (m_Data[3] == 0x73))
            {
                int idx = m_Data[0x0D02B];
                if (idx <= 0) idx = m_Data[0x0D02C + 0x6B];
                if (idx <= 0) idx = m_Data[0x0D02C + 0x6B *2];
                switch (idx)
                {
                    case 1:
                        m_scn = WIZSCN.GBC1;
                        m_WizFile = WIZFILE.STATE;
                        m_OffserAdr = 0x0D02B;
                        break;
                    case 3:
                        m_scn = WIZSCN.GBC2;
                        m_WizFile = WIZFILE.STATE;
                        m_OffserAdr = 0x0D02B;
                        break;
                    case 2:
                        m_scn = WIZSCN.GBC3;
                        m_WizFile = WIZFILE.STATE;
                        m_OffserAdr = 0x0D02B;
                        break;

                }

            }
            // Wiz123 sfc rom 容量から識別
            else if (m_Data.Length >= 0x400000)
            {
                int idx = FindString("WIZARDRY 1 2 3", 0);
                if (idx >= 0)
                {
                    m_scn = WIZSCN.SFC1;
                    m_WizFile = WIZFILE.ROM;
                    m_OffserAdr = 0x28436;
                    m_OffserAdr2 = 0x286CB;
                    m_OffserAdr3 = 0x28960;

                }

            }
            // GBC rom か Wiz5 rom
            else if (m_Data.Length >= 0x100000)
            {
                if (FindString("WIZARDRY1", 0) >= 0)
                {
                    m_scn = WIZSCN.GBC1;
                    m_WizFile = WIZFILE.ROM;
                    m_OffserAdr = 0x14001;
                }
                else if (FindString("WIZARDRY2", 0) >= 0)
                {
                    m_scn = WIZSCN.GBC2;
                    m_WizFile = WIZFILE.ROM;
                    m_OffserAdr = 0x14001;
                }
                else if (FindString("WIZARDRY3", 0) >= 0)
                {
                    m_scn = WIZSCN.GBC2;
                    m_WizFile = WIZFILE.ROM;
                    m_OffserAdr = 0x14001;
                }
                else if (FindString("WIZARDRY V", 0) >= 0)
                {
                    m_scn = WIZSCN.SFC5;
                    m_WizFile = WIZFILE.ROM;
                    m_OffserAdr = 0x3D47;
                }
            }
            // GBC sv or SFC Wiz123 sav
            else if (m_Data.Length >= 0x8000)
            {
                //gbc sav
                //47 75 6E 67 48 6F 21 21 21 
                //G  u  n  g  H  o  !  !  !
                if ((m_Data[0] == 0x47) && (m_Data[1] == 0x75) && (m_Data[2] == 0x6E) && (m_Data[3] == 0x67) && (m_Data[4] == 0x48) && (m_Data[5] == 0x6F))
                {
                    int sc = m_Data[0x2B];
                    if (sc == 0) sc = m_Data[0x99];
                    switch (sc)
                    {
                        case 1:
                            m_scn = WIZSCN.GBC1;
                            m_WizFile = WIZFILE.SAVE;
                            m_OffserAdr  = 0x002B;
                            m_OffserAdr2 = 0x2012;
                            break;
                        case 3:
                            m_scn = WIZSCN.GBC2;
                            m_WizFile = WIZFILE.SAVE;
                            m_OffserAdr = 0x002B;
                            m_OffserAdr2 = 0x2012;
                            break;
                        case 2:
                            m_scn = WIZSCN.GBC3;
                            m_WizFile = WIZFILE.SAVE;
                            m_OffserAdr = 0x002B;
                            m_OffserAdr2 = 0x2012;
                            break;
                    }
                }
                //wiz123 sav
                // 1999/02/19 Gung Ho! Presents
                // 20 31 39 39 39 2F 30 32 2F 31 39 20 47 75 6E 67 20 48 6F 21 20 50 72 65 73 65 6E 74 73
                else if ((m_Data[0] == 0x20) && (m_Data[1] == 0x31) && (m_Data[2] == 0x39) && (m_Data[3] == 0x39)
                    && (m_Data[0x0C] == 0x47) && (m_Data[0x0D] == 0x75) && (m_Data[0x0E] == 0x6E) && (m_Data[0x0F] == 0x67) && (m_Data[0x10] == 0x20) && (m_Data[0x11] == 0x48))
                {
                    m_scn = WIZSCN.SFC1;
                    m_WizFile = WIZFILE.SAVE;
                    m_OffserAdr = 0x0814;
                    m_OffserAdr2 = 0x1414;
                    m_OffserAdr3 = 0x2014;
                }
            }
            // fc 1iz 123 or wiz5 sav
            else if (m_Data.Length >= 0x2000)
            {
                if (FindString("H.YAJIMAK.CROSS", 0) >= 0)
                {
                    m_WizFile = WIZFILE.SAVE;
                    m_scn = WIZSCN.FC1;
                    m_OffserAdr = 0x0000;
                }
                else if (FindString("By Kei Cross08-10-88", 0) >= 0)
                {
                    m_WizFile = WIZFILE.SAVE;
                    m_scn = WIZSCN.FC2;
                    m_OffserAdr = 0x0400;
                    m_OffserAdr2 = 0x1800;
                }
                else if (FindString("Kei Cross06/10/89", 0) >= 0)
                {
                    m_WizFile = WIZFILE.SAVE;
                    m_scn = WIZSCN.FC3;
                    m_OffserAdr = 0x0400;
                    m_OffserAdr2 = 0x1800;
                }
                else if (FindString("04/22/92 Kei Cross Presents", 0) >= 0)
                {
                    m_WizFile = WIZFILE.SAVE;
                    m_scn = WIZSCN.SFC5;
                    m_OffserAdr = 0x0000;
                    m_OffserAdr = 0x0A00;

                }
            }
            ret = (m_scn != WIZSCN.NO);
            return ret;
        }
        // *******************************************************************************************
    }
}

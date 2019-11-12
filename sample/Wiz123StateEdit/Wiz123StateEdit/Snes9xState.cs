using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

using System.IO;
using System.IO.Compression;

namespace Wiz123StateEdit
{
    public class Snes9xState 
    {
        private byte[] m_Data = new byte[1024];
        private string m_FilePath;
        private int m_RAMAdr;
        private bool m_IsSnes9xState;
        //------------------------------------------------
        public Snes9xState()
        {
           

            Init();
        }
        //
        //------------------------------------------------
        public void InitData(int sz = 1024)
        {
            Array.Resize(ref m_Data, sz);
            for (int i = 0; i < m_Data.Length; i++)
            {
                m_Data[i] = 0;
            }
        }
        //------------------------------------------------
        public void Init()
        {
            for (int i=0; i< m_Data.Length; i++)
            {
                m_Data[i] = 0;
            }
            m_FilePath = "";
            m_RAMAdr = -1;
            m_IsSnes9xState = false;
        }
        //------------------------------------------------
        /// <summary>
        /// ファイルがgzipか確認
        /// </summary>
        /// <param name="p"></param>
        /// <returns></returns>
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
        //------------------------------------------------
        private bool ChkSnes9xState()
        {
            bool ret = false;

            if (m_Data.Length> 1048576)
            {
                //00 01 02 03 04 05
                //23 21 73 39 78 73 6E 70 3A 30 30 30 38   
                // #  !  s  9  x  s  n  p  :  0  0  0  8

                ret = ((m_Data[0] == 0x23) && (m_Data[1] == 0x21) && (m_Data[2] == 0x73) && (m_Data[3] == 0x39) && (m_Data[4] == 0x78));
            }
            return ret;
        }
        //------------------------------------------------
        private int FindRAM()
        {
            int ret = -1;

            byte[] ram = new byte[11] { 0x52, 0x41, 0x4D, 0x3A, 0x31, 0x33, 0x31, 0x30, 0x37, 0x32, 0x3A };
            if (m_Data.Length > 1048576)
            {
                //00 01 02 03 04 05 06 07 08 09 10
                //52 41 4D 3A 31 33 31 30 37 32 3A
                //R  A  M  :  1  3  1  0  7  2  :
                int sz = m_Data.Length - 11;
                for (int i = 0; i < sz; i++)
                {
                    bool b = true;
                    for (int j=0; j<11;j++)
                    {
                        if (m_Data[i+j] == ram[j])
                        {

                        }
                        else
                        {
                            b = false;
                            break;
                        }
                    }
                    if (b == true)
                    {
                        ret = i + 11;
                        break;
                    }

                }
            }
            m_RAMAdr = ret;
            return ret;
        }
        //------------------------------------------------
        private bool LoadRawFile(string p)
        {
            bool ret = false;
            using (FileStream fs = new FileStream(p, FileMode.Open))
            {
                InitData((int)fs.Length);
                fs.Read(m_Data, 0, m_Data.Length);
                ret = ChkSnes9xState();
            }
            return ret;
        }
        //------------------------------------------------
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
                        ret = ChkSnes9xState();
                    }
                }
            }
            return ret;
        }
        //------------------------------------------------
        public bool Load(string p)
        {
            bool ret = false;

            Init();

            if (System.IO.File.Exists(p) == false) return ret;
            if (IsGZipFile(p))
            {
                ret = LoadGZFile(p);
            }
            else
            {
                ret = LoadRawFile(p);
            }
            if (ret == true)
            {
                m_FilePath = p;
                m_RAMAdr = FindRAM();
                m_IsSnes9xState = (m_RAMAdr >= 0);
            }

            return ret;
        }
        //------------------------------------------------
        public bool Save(string p)
        {
            bool ret = false;

            if (File.Exists(p) == true)
            {
                string p2 = Path.ChangeExtension(p, ".bak");
                if (File.Exists(p2)==true)
                {
                    File.Delete(p2);
                }
                File.Move(p, p2);
            }
            using (FileStream fs = new System.IO.FileStream(p, System.IO.FileMode.Create, System.IO.FileAccess.Write))
            {
                fs.Write(m_Data, 0, m_Data.Length);
                ret = true;
            }

            return ret;
        }
        //------------------------------------------------
        public bool Save()
        {
            return Save(m_FilePath);
        }
        //------------------------------------------------
        public string FilePath
        {
            get { return m_FilePath; }
        }
        //------------------------------------------------
        public string HeaderS
        {
            get
            {
                return m_Data[0].ToString("X2") + "," + m_Data[1].ToString("X2") + "," + m_Data[2].ToString("X2") + "," + m_Data[3].ToString("X2");
            }
        }
        //------------------------------------------------
        public bool IsSnes9xState
        {
            get { return m_IsSnes9xState; }
        }
        //------------------------------------------------
        public byte this[int idx]
        {
            get
            {
                return GetByte(idx);
            }
            set
            {
                SetByte(idx, value);
            }
        }
        //------------------------------------------------
        public byte GetByte(int idx)
        {
            if ((idx >= 0) && (idx < 0x2000) && (m_RAMAdr >= 0))
            {
                return m_Data[idx + m_RAMAdr];
            }
            else
            {
                return 0;
            }
        }
        //------------------------------------------------
        public void SetByte(int idx,byte value)
        {
            if ((idx >= 0) && (idx < 0x2000) && (m_RAMAdr >= 0))
            {
                m_Data[idx + m_RAMAdr] = value;
            }
        }
        //------------------------------------------------
        public byte [] GetByteArray(int idx, int sz)
        {
            byte[] ret = new byte[0];
            if (sz <= 0) return ret;
            Array.Resize(ref ret, sz);

            for (int i=0; i<sz;i++)
            {
                ret[i] = m_Data[m_RAMAdr + idx + i];
            }
            return ret;

        }
        //------------------------------------------------
        public void SetByteArray(int idx, byte[] ba)
        {
            int l = ba.Length;
            if (l <= 0) return;

            for (int i=0; i<l;i++)
            {
                int v = idx + i;
                if ((v >= 0) && (v < 0x20000)) {
                    m_Data[m_RAMAdr + v] = ba[i];
                }
            }
        }
        //------------------------------------------------
        public void Clear()
        {
            Array.Resize(ref m_Data, 10);
            Init();

        }
    }
}

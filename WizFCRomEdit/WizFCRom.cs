using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using System.IO;

namespace WizFCRomEdit
{
    public enum WIZSSN
    {
        None =0,
        S1 = 1,
        S2,
        S3
    }


    public class WizFCRom :Component
    {
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
        private string m_Path = "";
        public string Path
        {
            get { return m_Path; }
            set
            {
                if (m_Path !=value)
                {
                    LoadFile(value);
                }
            }
        }
        private byte[] m_Buf = new byte[0];
        private WIZSSN m_WizScn = WIZSSN.S1;
        private int m_SelectCharIndex = 0;
        public int SelectCharIndex
        {
            get { return m_SelectCharIndex; }
            set
            {
                if (m_SelectCharIndex != value)
                {
                    m_SelectCharIndex = value;
                    OnValueChanged(new EventArgs());
                }
            }
        }

        private const int Wiz1Start = 0x17310;
        private const int Wiz2Start = 0x97C8;
        private const int Wiz3Start = 0x97A6;
        private const int RomCharCount = 6;

        // ****************************************************
        public WizFCRom()
        {

        }
        // ****************************************************
        private int StartAdr
        {
            get
            {
                switch (m_WizScn)
                {
                    case WIZSSN.S1:
                        return Wiz1Start;
                    case WIZSSN.S2:
                        return Wiz2Start;
                    case WIZSSN.S3:
                        return Wiz2Start;
                    default:
                        return -1;
                }
            }
        }
        // ****************************************************
        private int CharSize
        {
            get
            {
                switch (m_WizScn)
                {
                    case WIZSSN.S1:
                        return 0x80;
                    case WIZSSN.S2:
                        return 0x60;
                    case WIZSSN.S3:
                        return 0x60;
                    default:
                        return 0;
                }
            }
        }
        // ****************************************************
        private int CharAdrFromIndex(int idx)
        {
            if (idx < 0) return -1;
            return StartAdr + idx * CharSize;
        }
        // ****************************************************
        private int CharAdr
        {
            get { return CharAdrFromIndex(m_SelectCharIndex); }
        }
        // ****************************************************
        public string CharNameFromIndex(int idx)
        {
            string ret = "";
            if ((m_Buf.Length <= 0)||(m_SelectCharIndex<0)) return ret;


        }
        // ****************************************************
        private byte [] GetCode(int adr,int sz)
        {
            if ((adr<0)||(adr>= m_Buf.Length)) return new byte[0];
            if (sz <= 0) return new byte [0];
            if (sz >= m_Buf.Length) return new byte[0];


            byte[] ret = new byte[sz];

            for ( int i=0; i<sz; i++)
            {
                ret[i] = m_Buf[adr + i];
            }
            return ret;
        }
        // ****************************************************
        private void SetCode(int adr, byte []a)
        {
            if ((adr < 0) || (adr >= m_Buf.Length)) return;
            if (a.Length <= 0) return;
            for (int i = 0; i < a.Length; i++)
            {
                m_Buf[adr + i] = a[i];
            }
        }
        // ****************************************************
        private bool CompareCode(byte [] a,byte [] b)
        {
            bool ret = false;
            if (a.Length == b.Length)
            {
                ret = true;
                for ( int i=0; i< a.Length; i++)
                {
                    if(a[i]!=b[i])
                    {
                        ret = false;
                        break;
                    }
                }
            }
            return ret;
        }
        // ****************************************************
        private bool ChkRom()
        {
            bool ret = false;
            m_WizScn = WIZSSN.None;
            if (m_Buf.Length <= 100) return ret;
            bool isrom = ((m_Buf[0] == 'N') && (m_Buf[1] == 'E') && (m_Buf[0] == 'S'));
            if (isrom == false) return ret;


            byte[] ary1 = GetCode(Wiz1Start, 6);
            byte[] wiz1 = new byte[] { 0x01, 0x04, 0x7B, 0x9B, 0x79, 0x01 };
            if(CompareCode(ary1,wiz1)==true)
            {
                m_WizScn = WIZSSN.S1;
            }else
            {
                byte[] ary2 = GetCode(Wiz2Start, 6);
                byte[] wiz2 = new byte[] { 0x03, 0x04, 0x9E, 0xFD, 0x9C, 0x31 };
                if (CompareCode(ary2, wiz2) == true)
                {
                    m_WizScn = WIZSSN.S2;

                }
                else
                {
                    byte[] ary3 = GetCode(Wiz3Start, 6);
                    byte[] wiz3 = new byte[] { 0x02, 0x04, 0x9E, 0xFD, 0x9C, 0x31 };
                    if (CompareCode(ary3, wiz3) == true)
                    {
                        m_WizScn = WIZSSN.S3;

                    }
                }
            }
            ret = (m_WizScn != WIZSSN.None);


            return ret;
        }
        // ****************************************************
        public bool LoadFile(string p)
        {
            bool ret = false;
            m_Path = "";
            if (File.Exists(p) == false) return ret;
            FileStream fs = new FileStream(p, FileMode.Open, FileAccess.Read);
            try
            {
                int fsize = (int)fs.Length;
                m_Buf = new byte[fsize];
                int sz = fs.Read(m_Buf, 0, fsize);
                if (sz == fsize)
                {
                    ret = ChkRom();
                }
            }
            finally
            {
                fs.Close();
            }
            if (ret == false)
            {
                m_Buf = new byte[0];
                m_SelectCharIndex = -1;
            }
            else
            {
                m_Path = p;
                m_SelectCharIndex = 0;
                OnLoadFileFinished(new EventArgs());
            }
            //イベント
            return ret;
        }
        // ****************************************************
    }
}

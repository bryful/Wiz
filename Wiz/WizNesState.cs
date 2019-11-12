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
    public class WizNesState
    {
        
        private byte[] m_stateBuf = new byte[0];
        private WIZ_SCN m_scn = WIZ_SCN.NO;
        /// <summary>
        /// 
        /// </summary>
        public WizNesState()
        {
        }
        // ************************************************************************
        private int FindCode(byte[] s, int index = 0)
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
                if (m_stateBuf[i] == s[i])
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
        private int FindString(string s,int index = 0)
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
        private bool ChkState()
        {
            bool ret = false;
            m_scn = WIZ_SCN.NO
            //サイズチェック
            if (m_stateBuf.Length < 14872) return ret;

            int idx = FindString("SNSS", 0);
            if (idx != 0) return ret;
            idx = FindString("BASR", idx);
            if (idx != 0) return ret;

            if (FindString("Wizardry-Proving Grounds",0)>0)
            {
                m_scn = WIZ_SCN.S1;
            }else if (FindString("Wizardry-Legacy of Llylgamyn", 0) > 0)
            {
                m_scn = WIZ_SCN.S2;
            }
            else if (FindString("GAME STUDIO Inc.", 0) > 0)
            {
                m_scn = WIZ_SCN.S3;
            }

            return (m_scn != WIZ_SCN.NO);
        }
        // ************************************************************************
        /// <summary>
        /// 読み込み
        /// </summary>
        /// <param name="p">stateファイルのパス</param>
        /// <returns></returns>
        public bool load(string p)
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
                    ret = true;
                }
            }
            finally
            {
                fs.Close();
            }
            return ret;
        }
    }
}

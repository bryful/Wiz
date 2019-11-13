using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace WizEdit
{
    public class WizParams
    {
        private byte[] m_data = null;
        private int m_Adr = 0;
        public WizParams(byte[] d, int adr)
        {
            m_data = d;
            m_Adr = adr;
        }
        public int StrengthAdr
        {
            get { return m_Adr; }
            set { m_Adr = value; }
        }
        public byte[] Data
        {
            get { return m_data; }
            set { m_data = value; }
        }

        public byte Strength
        {
            get { return m_data[m_Adr]; }
            set { m_data[m_Adr] = value; }
        }
        public byte IQ
        {
            get { return m_data[m_Adr + 1]; }
            set { m_data[m_Adr + 1] = value; }
        }
        public byte Piety
        {
            get { return m_data[m_Adr + 2]; }
            set { m_data[m_Adr + 2] = value; }
        }
        public byte Vitarity
        {
            get { return m_data[m_Adr + 3]; }
            set { m_data[m_Adr + 3] = value; }
        }
        public byte Agility
        {
            get { return m_data[m_Adr + 4]; }
            set { m_data[m_Adr + 4] = value; }
        }
        public byte Luck
        {
            get { return m_data[m_Adr + 5]; }
            set { m_data[m_Adr + 5] = value; }
        }
    }
}

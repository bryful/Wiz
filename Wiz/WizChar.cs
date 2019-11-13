using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace WizEdit
{



 /*
    public class Wiz16Str
    {
        private int ToTrue(byte v)
        {
            int p0 = v & 0xF;
            if (p0 > 0x09) p0 = 0x09;
            int p1 = (v >> 4) & 0xF;
            if (p1 > 0x09) p1 = 0x09;
            return p1 * 10 + p0;
        }
        private byte FromTrue(int v)
        {
            byte p0 = (byte)(v % 10);
            byte p1 = (byte)((v / 10) % 10);

            return (byte)(((p1 << 4) | p0)&0xFF);
        }
        private byte[] m_Data = new byte[6];
        public Wiz16Str()
        {
            Clear();
        }
        public void Clear()
        {
            for (int i = 0; i < 6; i++) m_Data[i] = 0;
        }
        public byte[] Data
        {
            get
            {
                byte [] ret = new byte[6];
                for (int i = 0; i < 6; i++) ret[i] = m_Data[i];
                return ret;
            }
            set
            {
                Clear();
                int len = value.Length;
                if (len > 6) len = 6;
                for (int i = 0; i < len; i++) m_Data[i] = value[i];
            }
        }
        public int Value
        {
            get
            {
                return ToTrue(m_Data[0])* 100000
                    + ToTrue(m_Data[1]) * 10000
                    + ToTrue(m_Data[2]) * 1000
                    + ToTrue(m_Data[3]) * 100
                    + ToTrue(m_Data[4]) * 10
                    + ToTrue(m_Data[5]);
            }
            set
            {
                int v = value;
                if (v < 0) v = 0;
                m_Data[0] = FromTrue(value & 0xFF);
                m_Data[1] = FromTrue((value >> 08) & 0xFF);
                m_Data[2] = FromTrue((value >> 16) & 0xFF);
                m_Data[3] = FromTrue((value >> 24) & 0xFF);
                m_Data[4] = FromTrue((value >> 32) & 0xFF);
                m_Data[5] = FromTrue((value >> 40) & 0xFF);
            }
        }
    }
    */
    /*
    public class WizChar
    {
        public string Name = "";
        public WIZRACE Race = WIZRACE.HUMAN;
        public WIZALG Alg = WIZALG.GOOD;
        public WIZCLASS Class = WIZCLASS.FIG;
        public WizParams Params = new WizParams();
        public Wiz16Str Gold = new Wiz16Str(); //6byte
        public Wiz16Str Exp = new Wiz16Str(); //6byte
        public int HP = 0;
        public int HPMax = 0; //2byte
        public int Level = 0;
        public byte Status = 0;
        public byte Age = 0;
        public byte AC = 0;
        public WizSpell Magic = new WizSpell();
        public WizSpell Prist = new WizSpell();
        public byte Poison = 0;

    }
    */
}

using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace WizEdit
{
    public partial class GBCChecksum : Form
    {
        int sz = 0x006E;
        int adr = 0x2B;
        byte[] m_Data = new byte[0];
        public GBCChecksum()
        {
            InitializeComponent();
            m_Data = Properties.Resources.Wizardry1GBC;
            for ( int i=0; i<0xC00;i++)
            {
                listBox1.Items.Add(String.Format("0x{0:X4} - 0x{1:X4}\r\n",i, m_Data[i]));
            }
        }

        private void GBCChecksum_Load(object sender, EventArgs e)
        {
        }

        private void button1_Click(object sender, EventArgs e)
        {
         
        }
        public ushort CrcBB(byte[] ptr, int start, int len, ushort crc)
        {
            ushort CRC16POLY = 0xa001;
            int i, j;
            crc = (ushort)(~crc);
            for (i = 0; i < len; i++)
            {
                crc ^= ptr[i + start];
                for (j = 0; j < 8; j++)
                {
                    if ((crc & 1) == 1)
                    {
                        crc = (ushort)((crc >> 1) ^ CRC16POLY);
                    }
                    else
                    {
                        crc >>= 1;
                    }
                }
            }
            return (ushort)(~crc);
        }
        private void button3_Click(object sender, EventArgs e)
        {
            int a = adr + sz;

            //ushort v = CRC16.CalcIBM(m_Data, a, sz-2, 0xFFFF);
            //ushort v = CRC16.Fletcher16(m_Data, a, sz - 2);
           
            int v = 0;
            for ( int i=0; i<sz-2;i++)
            {
                v = v ^ m_Data[i + adr];
            }

            textBox1.Text += String.Format("0x{0:X4}\r\n", v);
        }

        private void button4_Click(object sender, EventArgs e)
        {
            long v = 0;
            int sz2 = (sz - 2) / 2;
            for (int i=0; i<sz2;i++)
            {
                v = (v + (m_Data[i*2 + adr] <<8) | m_Data[i * 2 +1 + adr]) &0xFFFF;
            }
            textBox1.Text += String.Format("0x{0:X4}\r\n", v);
        }
    }
}

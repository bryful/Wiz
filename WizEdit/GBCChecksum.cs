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
            for ( int i=0; i<0x6E;i++)
            {
                listBox1.Items.Add(String.Format("0x{0:X4}\r\n", m_Data[i+adr]));
            }
        }

        private void GBCChecksum_Load(object sender, EventArgs e)
        {
        }

        private void button1_Click(object sender, EventArgs e)
        {
 

            textBox1.Text += "start\r\n";
            textBox1.Update();
            int a = adr;
            ushort vv = (ushort)((ushort)(m_Data[a + sz - 2] << 8) | (ushort)m_Data[a + sz - 1]);
            for (int i = 0xFFFF; i >= 0; i--)
            {
                ushort v = CRC16.crc_ibm(m_Data, (ushort)a, (ushort)(sz - 2), (ushort)i);
                if (vv==v)
                {
                    textBox1.Text += String.Format("0x{0:X4}\r\n", i);
                    textBox1.Update();
                }
            }
            textBox1.Text += "fin\r\n";
        }

        private void button3_Click(object sender, EventArgs e)
        {
            int a = adr + sz;
            //ushort v = CRC16.Calc(m_Data, (ushort)a, (ushort)(sz - 2), 0x3691);
            ushort v = CRC16.crc_ibm(m_Data, (ushort)a, (ushort)(sz - 2), 0xFFFF);

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

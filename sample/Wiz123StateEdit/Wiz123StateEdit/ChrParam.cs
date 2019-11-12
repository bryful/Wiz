using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Drawing;
using System.Data;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;


namespace Wiz123StateEdit
{
    public class ChrParam : Control
    {
        private Label label1 = new Label();
        private NumericUpDown numericUpDown1 = new NumericUpDown();
        private Snes9xWiz123SFC m_wiz123sfc = null;

        private long m_Adr = 0;
        private long m_AdrSize = 1;
        private MODE m_mode;

		bool refFlag = false;
        public enum MODE
        {
            CHIKARA = 0,
            CHIE,
            SINKOSIN,
            SEIMEI,
            SUBAYASA,
            UN,
            GOLD,
            EP,
            LV,
            NENEI,
            AC,
            MARKS,
            RIP

        }
        string[] caps = new string[]
        {
            "ちから",
            "知恵",
            "信仰心",
            "生命力",
            "素早さ",
            "運の良さ",
            "Gold",
            "E.P.",
            "レベル",
            "年齢",
            "A.C.",
            "Marks",
            "Rip"
        };
        long[] adrs = new long[]
        {
            0x02A0,
            0x02A1,
            0x02A2,
            0x02A3,
            0x02A4,
            0x02A5,
            0x02A6, //Gold
            0x02AC, //EP
            0x02B6, //Lv
            0x02B9, //Age
            0x02BB, //AC
            0x02F7, //Marks
            0x02F5, //Rip

        };
        long[] adrsL = new long[]
        {
            1,
            1,
            1,
            1,
            1,
            1,
            6, //Gold
            6, //EP
            2, //Lv
            1, //Age
            1, //AC
            6, //Marks
            1, //Rip
        };
        long[] PMax = new long[]
        {
            0x7F,
            0x7F,
            0x7F,
            0x7F,
            0x7F,
            0x7F,
            999999999999, //Gold
            999999999999, //EP
            0xFFFF, //Lv
            0x7F, //Age
            0x7F, //AC
            0x099999999999, //Marks
            0x7F, //Rip
        };
        //-----------------------------------------------
        public ChrParam()
        {
            this.SuspendLayout();

            this.Font = new Font("ＭＳ ゴシック", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(128)));

            this.label1.BackColor = System.Drawing.Color.Black;
            this.label1.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.label1.Font = this.Font;
            this.label1.ForeColor = System.Drawing.Color.White;
            this.label1.Location = new System.Drawing.Point(0, 0);
            this.label1.Margin = new System.Windows.Forms.Padding(0);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(80, 24);
            this.label1.TabIndex = 0;
            this.label1.Text = "label1";
            this.label1.TextAlign = ContentAlignment.MiddleLeft;

            this.numericUpDown1.AutoSize = false;
            this.numericUpDown1.BackColor = System.Drawing.Color.Black;
            this.numericUpDown1.BorderStyle = System.Windows.Forms.BorderStyle.None;
            this.numericUpDown1.Font = this.Font;
            this.numericUpDown1.ForeColor = System.Drawing.Color.White;
            this.numericUpDown1.Location = new System.Drawing.Point(80, 2);
            this.numericUpDown1.Margin = new System.Windows.Forms.Padding(0);
            this.numericUpDown1.Name = "numericUpDown1";
            this.numericUpDown1.Size = new System.Drawing.Size(110, 22);
            this.numericUpDown1.TabIndex = 1;
            this.numericUpDown1.TextAlign = HorizontalAlignment.Right;
            this.numericUpDown1.Enabled = false;


            this.MaximumSize = new System.Drawing.Size(800, 24);
            this.MinimumSize = new System.Drawing.Size(70, 24);
            this.Name = "ChrParam";
            this.Size = new System.Drawing.Size(190, 24);

            this.Controls.Add(this.numericUpDown1);
            this.Controls.Add(this.label1);

            this.ResumeLayout(false);


            SetMode(MODE.CHIKARA);

            this.Resize += ChrParam_Resize;
            numericUpDown1.ValueChanged += NumericUpDown1_ValueChanged;

        }

        //---------------------------------------------------------
        private void NumericUpDown1_ValueChanged(object sender, EventArgs e)
        {
			if (refFlag == true) return;
            SetValue();
        }

        //---------------------------------------------------------
        private void ChrParam_Resize(object sender, EventArgs e)
        {
            ResizeChk();
        }

        //---------------------------------------------------------
        public int CaptionWidth
        {
            get { return label1.Width; }
            set
            {
                int v = value;
                int w = this.Width - v; //numの横幅
                int wMin = 40;
                if (w < wMin)
                {
                    v = this.Width - wMin;
                    w = wMin;
                }
                this.SuspendLayout();
                label1.Width = v;
                numericUpDown1.Left = v;
                numericUpDown1.Width = w;
                this.ResumeLayout(false);
            }
        }
        //-----------------------------------------------
        public void ResizeChk()
        {
            numericUpDown1.Width = this.Width - label1.Width;

        }
        //---------------------------------------------------------
        public void SetMode(MODE m)
        {
            m_mode = m;
            label1.Text = caps[(int)m];
            m_Adr = adrs[(int)m];
            m_AdrSize = adrsL[(int)m];
            numericUpDown1.Maximum = PMax[(int)m];

            switch (m)
            {
                case MODE.AC:
                    numericUpDown1.Maximum = 127;
                    numericUpDown1.Minimum = -127;
                    break;
            }

        }
        //-----------------------------------------------
        //---------------------------------------------------------
        public MODE Mode
        {
            get { return m_mode; }
            set { SetMode(value); }
        }
        public bool TextLeft
        {
            get
            {
                return (label1.TextAlign == ContentAlignment.MiddleLeft);
            }
            set
            {
                if (value == true)
                {
                    label1.TextAlign = ContentAlignment.MiddleLeft;
                }
                else
                {
                    label1.TextAlign = ContentAlignment.MiddleRight;
                }
            }
        }
        //-------------------------------------------------------------
        public Snes9xWiz123SFC Wiz123sfc
        {
            get { return m_wiz123sfc; }
            set
            {
                m_wiz123sfc = value;
                if (m_wiz123sfc != null)
                {
                    m_wiz123sfc.SelectedIndexChanged += M_wiz123sfc_SelectedIndexChanged;
                    m_wiz123sfc.LoadFileEvent += M_wiz123sfc_LoadFileEvent;
                }
            }
        }
        //-------------------------------------------------------------
        private void M_wiz123sfc_LoadFileEvent(object sender, EventArgs e)
        {
            GetValue();
        }

        //-------------------------------------------------------------
        private void M_wiz123sfc_SelectedIndexChanged(object sender, EventArgs e)
        {
            GetValue();
        }
        //-------------------------------------------------------------
        private long WizHex(byte b)
        {
            long ret = 0;
            ret += (b & 0xF);
            ret += (b >> 4 & 0xF) * 10;
            return ret;
        }
        //-------------------------------------------------------------
        private long WizHexA(byte[] ba)
        {
            long ret = 0;
            long v = 1;
            for (int i = ba.Length - 1; i >= 0; i--)
            {
                ret += WizHex(ba[i]) * v;
                v *= 100;
            }
            return ret;
        }
        //-------------------------------------------------------------
        private byte ToWizHex(long v)
        {
            byte ret = 0;
            //v = v % 100;

            ret += (byte)(v % 10);
            ret += (byte)(((v/10) % 10) << 4);

            return ret;
        }
        //-------------------------------------------------------------
        private byte [] ToWizHexA(long v)
        {
            byte[] ret = new byte[6];

            long vv = v;
            for (int i=05; i>=0;i--)
            {
                ret[i] = ToWizHex(vv % 100);
                vv /= 100;
            }
            return ret;
        }
        //-------------------------------------------------------------
        public int ChkTarget()
        {
            int idx = -1;
            if (m_wiz123sfc != null)
            {
                idx = m_wiz123sfc.SelectedIndex;
                if (idx >= 0)
                {
                    if (m_wiz123sfc.CharEnabled(idx) == false)
                    {
                        idx = -1;
                    }
                }

            }

            if (idx < 0)
            {
                numericUpDown1.Enabled = false;

				bool bak = refFlag;
				refFlag = true;
                numericUpDown1.Value = 0;
				refFlag = false;
			}
			else
            {
                numericUpDown1.Enabled = true;
            }
            return idx;

        }
        //-------------------------------------------------------------
        public void GetValue()
        {
            int idx = ChkTarget();
            if (idx < 0) return;
            int ad = (int)(m_Adr + Wiz.CHR_OFFSET * idx);
            byte[] vs = m_wiz123sfc.State.GetByteArray(ad, (int)m_AdrSize);

			bool bak = refFlag;
			refFlag = true;
			switch (m_mode)
            {
                case MODE.CHIKARA:
                case MODE.CHIE:
                case MODE.SINKOSIN:
                case MODE.SEIMEI:
                case MODE.SUBAYASA:
                case MODE.UN:
                case MODE.NENEI:
                case MODE.RIP:
                    if (vs.Length >= 1)
                    {
                        numericUpDown1.Value = (long)vs[0];
                    }
                    break;
                case MODE.GOLD:
                case MODE.EP:
                    if (vs.Length >= 6)
                    {
                        numericUpDown1.Value = WizHexA(vs);
                    }
                    break;
                case MODE.MARKS:
                    if (vs.Length >= 6)
                    {
                        long v = (long)vs[5];
                        v += (long)vs[4] << 8;
                        v += (long)vs[3] << 16;
                        v += (long)vs[2] << 24;
                        v += (long)vs[1] << 32;
                        v += (long)vs[0] << 40;
                        numericUpDown1.Value = v;
                    }
                    break;
                case MODE.AC:
                    if (vs.Length >= 1)
                    {
                        sbyte vv = (sbyte)vs[0];
                        numericUpDown1.Value = vv;
                    }
                    break;
                case MODE.LV:
                    if (vs.Length >= 2)
                    {
                        numericUpDown1.Value = (int)vs[0] + (int)vs[1] * 256;
                    }
                    break;
            }
			refFlag = bak;
        }
        //-------------------------------------------------------------
        public void SetValue()
        {
            int idx = ChkTarget();
            if (idx < 0) return;
            int ad = (int)(m_Adr + Wiz.CHR_OFFSET * idx);
            //byte[] vs = m_wizFive.State.GetByteArray(ad, (int)m_AdrSize);

            switch (m_mode)
            {
                case MODE.CHIKARA:
                case MODE.CHIE:
                case MODE.SINKOSIN:
                case MODE.SEIMEI:
                case MODE.SUBAYASA:
                case MODE.UN:
                case MODE.NENEI:
                case MODE.RIP:
                    byte v = (byte)numericUpDown1.Value;
                    m_wiz123sfc.State.SetByte(ad,  v);
                    break;
                case MODE.GOLD:
                case MODE.EP:
                    byte[] a = ToWizHexA((long)numericUpDown1.Value);
                    m_wiz123sfc.State.SetByteArray(ad, a);
                    break;
                case MODE.MARKS:
                    byte[] c = new byte[6];
                    long vv = (long)numericUpDown1.Value;
                    c[5] = (byte)(vv & 0xff);
                    c[4] = (byte)((vv >> 8) & 0xff);
                    c[3] = (byte)((vv >>16) & 0xff);
                    c[2] = (byte)((vv >>24) & 0xff);
                    c[1] = (byte)((vv >> 32) & 0xff);
                    c[0] = (byte)((vv >> 40) & 0xff);
                    m_wiz123sfc.State.SetByteArray(ad, c);
                    break;
                case MODE.AC:
                    sbyte b = (sbyte)numericUpDown1.Value;
                    m_wiz123sfc.State.SetByte(ad, (byte)b);

                    break;
                case MODE.LV:
                    int v3 = (int)numericUpDown1.Value;
                    byte[] ba = new byte[2];
                    ba[0] = (byte)(v3 & 0xFF);
                    ba[1] = (byte)((v3>>8) & 0xFF);
                    m_wiz123sfc.State.SetByteArray(ad, ba);

                    break;
            }


        }
    }
}

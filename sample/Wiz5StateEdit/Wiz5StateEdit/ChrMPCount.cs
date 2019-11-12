using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Drawing;
using System.Data;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace Wiz5StateEdit
{
    public class ChrMPCount :Control
    {
        private Label lbM1;
        private Label lbM2;
        private Label lbP1;
        private Label lbP2;
        private Button btnMAll;
        private Button btnPAll;

        private Wiz5StateEdit.Snes9xWizFive m_wizFive = null;
        const int m_adr1 = 0x1027; //MC
        const int m_adr2 = 0x102E; //PC

        const int m_adr3 = 0x1035; //MC
        const int m_adr4 = 0x103C; //PC

        public ChrMPCount()
        {
            this.SuspendLayout();

            lbM1 = new Label();
            lbP1 = new Label();
            lbM2 = new Label();
            lbP2 = new Label();
            btnMAll = new Button();
            btnPAll = new Button();

            this.Font = new System.Drawing.Font("ＭＳ ゴシック", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(128)));

            this.MinimumSize = new Size(170, 80);
            this.MaximumSize = new Size(170, 80);
            this.Size = new Size(170, 80);
            this.Name = "ChrMPCount";
            this.BackColor = System.Drawing.Color.Black;

            lbM1.Font = this.Font;
            lbM1.ForeColor = System.Drawing.Color.White;
            lbM1.Location = new System.Drawing.Point(0, 0);
            lbM1.Name = "lbM1";
            lbM1.Size = new System.Drawing.Size(130, 18);
            lbM1.TabIndex = 0;
            lbM1.Text = "M 0/0/0/0/0/0/0";

            lbM2.Font = this.Font;
            lbM2.ForeColor = System.Drawing.Color.White;
            lbM2.Location = new System.Drawing.Point(0, 18);
            lbM2.Name = "lbM2";
            lbM2.Size = new System.Drawing.Size(130, 18);
            lbM2.TabIndex = 1;
            lbM2.Text = "  0/0/0/0/0/0/0";


            lbP1.Font = this.Font;
            lbP1.ForeColor = System.Drawing.Color.White;
            lbP1.Location = new System.Drawing.Point(0, 40);
            lbP1.Name = "lbP1";
            lbP1.Size = new System.Drawing.Size(130, 18);
            lbP1.TabIndex = 2;
            lbP1.Text = "P 0/0/0/0/0/0/0";

            lbP2.Font = this.Font;
            lbP2.ForeColor = System.Drawing.Color.White;
            lbP2.Location = new System.Drawing.Point(0, 58);
            lbP2.Name = "lbP2";
            lbP2.Size = new System.Drawing.Size(130, 18);
            lbP2.TabIndex = 3;
            lbP2.Text = "  0/0/0/0/0/0/0";

            this.btnMAll.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.btnMAll.Font = new System.Drawing.Font("MS UI Gothic", 8.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(128)));
            this.btnMAll.ForeColor = System.Drawing.Color.White;
            this.btnMAll.Location = new System.Drawing.Point(136, 0);
            this.btnMAll.Margin = new System.Windows.Forms.Padding(0);
            this.btnMAll.Name = "btnMAll";
            this.btnMAll.Size = new System.Drawing.Size(30, 20);
            this.btnMAll.TabIndex = 4;
            this.btnMAll.Text = "ALL";
            this.btnMAll.UseVisualStyleBackColor = true;



            this.btnPAll.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.btnPAll.Font = new System.Drawing.Font("MS UI Gothic", 8.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(128)));
            this.btnPAll.ForeColor = System.Drawing.Color.White;
            this.btnPAll.Location = new System.Drawing.Point(136, 40);
            this.btnPAll.Margin = new System.Windows.Forms.Padding(0);
            this.btnPAll.Name = "btnPAll";
            this.btnPAll.Size = new System.Drawing.Size(30, 20);
            this.btnPAll.TabIndex = 5;
            this.btnPAll.Text = "ALL";
            this.btnPAll.UseVisualStyleBackColor = true;

            this.Controls.Add(lbM1);
            this.Controls.Add(lbM2);
            this.Controls.Add(lbP1);
            this.Controls.Add(lbP2);
            this.Controls.Add(btnMAll);
            this.Controls.Add(btnPAll);

            this.ResumeLayout(false);

            btnMAll.Click += BtnMAll_Click;
            btnPAll.Click += BtnPAll_Click;
        }

        //-------------------------------------------------------------
        private void BtnPAll_Click(object sender, EventArgs e)
        {
            SetValueP();
            //throw new NotImplementedException();
        }

        //-------------------------------------------------------------
        private void BtnMAll_Click(object sender, EventArgs e)
        {
            SetValueM();
            //throw new NotImplementedException();
        }

        //-------------------------------------------------------------
        private byte BLow(byte b)
        {
            return (byte)(b & 0xF);
        }
        //-------------------------------------------------------------
        private byte BHi(byte b)
        {
            return (byte)((b>>4) & 0xF);
        }
        public void GetValue()
        {
            
            if (m_wizFive == null) return;
            int idx = m_wizFive.SelectedIndex;
            if (idx < 0) idx = 0;
            byte[] v1 = m_wizFive.State.GetByteArray(m_adr1 + 0x80 * idx, 7);
            byte[] v2 = m_wizFive.State.GetByteArray(m_adr2 + 0x80 * idx, 7);

            //MP
            lbM1.Text = String.Format("M {0:X}/{1:X}/{2:X}/{3:X}/{4:X}/{5:X}/{6:X}",
                BHi(v1[0]), BHi(v1[1]), BHi(v1[2]), BHi(v1[3]), BHi(v1[4]), BHi(v1[5]), BHi(v1[6]));
            lbM2.Text = String.Format("  {0:X}/{1:X}/{2:X}/{3:X}/{4:X}/{5:X}/{6:X}",
                v1[0] & 0xF, v1[1] & 0xF, v1[2] & 0xF, v1[3] & 0xF, v1[4] & 0xF, v1[5] & 0xF, v1[6] & 0xF);
            //PP
            lbP1.Text = String.Format("P {0:X}/{1:X}/{2:X}/{3:X}/{4:X}/{5:X}/{6:X}",
                BHi(v2[0]), BHi(v2[1]), BHi(v2[2]), BHi(v2[3]), BHi(v2[4]), BHi(v2[5]), BHi(v2[6]));
            lbP2.Text = String.Format("  {0:X}/{1:X}/{2:X}/{3:X}/{4:X}/{5:X}/{6:X}",
                v2[0] & 0xF, v2[1] & 0xF, v2[2] & 0xF, v2[3] & 0xF, v2[4] & 0xF, v2[5] & 0xF, v2[6] & 0xF);


        }
        //-------------------------------------------------------------
        public void SetValueM()
        {
            if (m_wizFive == null) return;
            int idx = m_wizFive.SelectedIndex;
            if (idx < 0) return;

            byte b = m_wizFive.State.GetByte(6 + m_adr3 + 0x80 * idx);

            byte c = 0;
            byte f = 0;
            if (b == 0)
            {
                c = 0x99;
                f = 0xFF;
            }


            for (int i = 0; i < 7; i++) {
                m_wizFive.State.SetByte(i + m_adr1 + 0x80 * idx, c);
                m_wizFive.State.SetByte(i + m_adr3 + 0x80 * idx, f);
            }

            GetValue();
        }
        //-------------------------------------------------------------
        public void SetValueP()
        {
            if (m_wizFive == null) return;
            int idx = m_wizFive.SelectedIndex;
            if (idx < 0) return;

            byte b = m_wizFive.State.GetByte(6 + m_adr4 + 0x80 * idx);

            byte c = 0;
            byte f = 0;
            if (b == 0)
            {
                c = 0x99;
                f = 0xFF;
            }


            for (int i = 0; i < 7; i++)
            {
                m_wizFive.State.SetByte(i + m_adr2 + 0x80 * idx, c);
                m_wizFive.State.SetByte(i + m_adr4 + 0x80 * idx, f);
            }

            GetValue();
        }
        //-------------------------------------------------------------
        public Snes9xWizFive WizFive
        {
            get { return m_wizFive; }
            set
            {
                m_wizFive = value;
                if (m_wizFive != null)
                {
                    m_wizFive.SelectedIndexChanged += M_wiz5_SelectedIndexChanged;
                    m_wizFive.LoadFileEvent += M_wiz5_LoadFileEvent;
                }
            }
        }
        //-------------------------------------------------------------
        private void M_wiz5_LoadFileEvent(object sender, EventArgs e)
        {
            GetValue();
        }

        //-------------------------------------------------------------
        private void M_wiz5_SelectedIndexChanged(object sender, EventArgs e)
        {
            GetValue();
            //throw new NotImplementedException();
        }

    }
}

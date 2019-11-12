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

    public class ChrHP : Control
    {
        private Snes9xWizFive m_wizFive = null;
        const int m_adrN0 = 0x101D; //now
        const int m_adrN1 = 0x101E; //now
        const int m_adrM0 = 0x101F; //now
        const int m_adrM1 = 0x1020; //now

        private Label label1 = new Label();
        private Label label2 = new Label();
        private NumericUpDown numHP = new NumericUpDown();
        private NumericUpDown numMax = new NumericUpDown();

		bool refFlag = false;

        public ChrHP()
        {
            this.Font = new Font("ＭＳ ゴシック", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(128)));
            this.Size = new Size(180, 50);
            this.MinimumSize = new Size(100, 50);
            this.MaximumSize = new Size(900, 50);

            this.label1.Location = new System.Drawing.Point(0, 0);
            this.label1.Margin = new System.Windows.Forms.Padding(0);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(40, 23);
            this.label1.TabIndex = 0;
            this.label1.Text = "H.P.";
            this.label1.TextAlign = System.Drawing.ContentAlignment.MiddleRight;

            this.label2.Location = new System.Drawing.Point(0, 27);
            this.label2.Margin = new System.Windows.Forms.Padding(0);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(40, 22);
            this.label2.TabIndex = 1;
            this.label2.Text = "Max";
            this.label2.TextAlign = System.Drawing.ContentAlignment.MiddleRight;

            this.numHP.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Left)
             | System.Windows.Forms.AnchorStyles.Right)));
            this.numHP.BackColor = System.Drawing.Color.Black;
            this.numHP.Font = new System.Drawing.Font("ＭＳ ゴシック", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(128)));
            this.numHP.ForeColor = System.Drawing.Color.White;
            this.numHP.Location = new System.Drawing.Point(40, 0);
            this.numHP.Margin = new System.Windows.Forms.Padding(0);
            this.numHP.Maximum = new decimal(new int[] {
            -727379969,
            232,
            0,
            0});
            this.numHP.Name = "numHP";
            this.numHP.Size = new System.Drawing.Size(140, 23);
            this.numHP.TabIndex = 2;
            this.numHP.TextAlign = System.Windows.Forms.HorizontalAlignment.Right;
            this.numHP.Enabled = false;

            this.numMax.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Left)
 | System.Windows.Forms.AnchorStyles.Right)));
            this.numMax.BackColor = System.Drawing.Color.Black;
            this.numMax.Font = new System.Drawing.Font("ＭＳ ゴシック", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(128)));
            this.numMax.ForeColor = System.Drawing.Color.White;
            this.numMax.Location = new System.Drawing.Point(40, 27);
            this.numMax.Margin = new System.Windows.Forms.Padding(0);
            this.numMax.Maximum = new decimal(new int[] {
            -727379969,
            232,
            0,
            0});
            this.numMax.Name = "numMax";
            this.numMax.Size = new System.Drawing.Size(140, 23);
            this.numMax.TabIndex = 3;
            this.numMax.TextAlign = System.Windows.Forms.HorizontalAlignment.Right;
            this.numMax.Enabled = false;


            this.BackColor = System.Drawing.Color.Black;
            this.Controls.Add(this.label1);
            this.Controls.Add(this.label2);
            this.Controls.Add(this.numHP);
            this.Controls.Add(this.numMax);
            this.Font = new System.Drawing.Font("ＭＳ ゴシック", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(128)));
            this.ForeColor = System.Drawing.Color.White;
            this.Name = "ChrHP";

            this.ResumeLayout(false);

            numHP.ValueChanged += NumHP_ValueChanged;
            numMax.ValueChanged += NumMax_ValueChanged;
        }

        //-------------------------------------------------------------
        private void NumMax_ValueChanged(object sender, EventArgs e)
        {
			if (refFlag == true) return;
            int idx = ChkTarget();
            if (idx < 0) return;
            int v = (int)numMax.Value;
            if (v < 0) v = 0;
            if (v < numHP.Value)
            {
                v = (int)numHP.Value;
				refFlag = true;
                numMax.Value = v;
				refFlag = false;
			}
			byte v0 = (byte)(v & 0xFF);
            byte v1 = (byte)((v >> 8) & 0xFF);
            m_wizFive.State.SetByte(m_adrM0 + 0x80 * idx, v0);
            m_wizFive.State.SetByte(m_adrM1 + 0x80 * idx, v1);
        }

        //-------------------------------------------------------------
        private void NumHP_ValueChanged(object sender, EventArgs e)
        {
			if (refFlag == true) return;
			int idx = ChkTarget();
            if (idx < 0) return;
            int v = (int)numHP.Value;
            if (v < 0) v = 0;
            if (v > numMax.Value)
            {
                v =  (int)numMax.Value;
				refFlag = true;
				numHP.Value = v;
				refFlag = false;
			}
			byte v0 = (byte)(v & 0xFF);
            byte v1 = (byte)((v>>8) & 0xFF);
            m_wizFive.State.SetByte(m_adrN0 + 0x80 * idx, v0);
            m_wizFive.State.SetByte(m_adrN1 + 0x80 * idx, v1);

        }

        //-------------------------------------------------------------
        public int ChkTarget()
        {
            int idx = -1;
            if (m_wizFive != null)
            {
                idx = m_wizFive.SelectedIndex;
                if (idx >= 0)
                {
                    if (m_wizFive.CharEnabled(idx) == false)
                    {
                        idx = -1;
                    }
                }

            }

            if (idx < 0)
            {
				bool bak = refFlag;
				refFlag = true;
                numHP.Value = 0;
                numMax.Value = 0;
				refFlag = false;
				numHP.Enabled = false;
                numMax.Enabled = false;
            }
            else
            {
                numHP.Enabled = true;
                numMax.Enabled = true;
            }
            return idx;

        }
        //-------------------------------------------------------------
        public void GetValue()
        {
            int idx = ChkTarget();
            if (idx < 0) return;
			bool bak = refFlag;
			refFlag = true;
            int v0 = (int)m_wizFive.State.GetByte(m_adrN0 + 0x80 * idx);
            int v1 = (int)m_wizFive.State.GetByte(m_adrN1 + 0x80 * idx);

            numHP.Value = v0 + v1 * 256;

            v0 = (int)m_wizFive.State.GetByte(m_adrM0 + 0x80 * idx);
            v1 = (int)m_wizFive.State.GetByte(m_adrM1 + 0x80 * idx);

            numMax.Value = v0 + v1 * 256;

			refFlag = false;
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
                    m_wizFive.SelectedIndexChanged += M_wizFive_SelectedIndexChanged;
                    m_wizFive.LoadFileEvent += M_wizFive_LoadFileEvent;
                }
            }
        }

        //-------------------------------------------------------------
        private void M_wizFive_LoadFileEvent(object sender, EventArgs e)
        {
            GetValue();
        }

        //-------------------------------------------------------------
        private void M_wizFive_SelectedIndexChanged(object sender, EventArgs e)
        {
            GetValue();
        }

    }

}

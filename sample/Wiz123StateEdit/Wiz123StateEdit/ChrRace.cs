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
    public class ChrRace :Control
    {
        private Snes9xWiz123SFC m_wiz123SFC = null;
        const int m_adr = Wiz.CHR_RACE;

        private ComboBox cmbHum;
        private ComboBox cmbFig;
        private ComboBox cmbGod;
		bool refFlag = false;
        public ChrRace()
        {
            this.Font = new Font("ＭＳ ゴシック", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(128)));
            this.MaximumSize = new Size(220, 24);
            this.MinimumSize = new Size(220, 24);
            this.Size = new Size(220, 24);
            this.BackColor = System.Drawing.Color.Black;

            this.SuspendLayout();
            cmbGod = new ComboBox();
            cmbFig = new ComboBox();
            cmbHum = new ComboBox();

            cmbGod.BackColor = System.Drawing.Color.Black;
            cmbGod.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
            cmbGod.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            cmbGod.Font = this.Font;
            cmbGod.ForeColor = System.Drawing.Color.White;
            cmbGod.FormattingEnabled = true;
            cmbGod.Items.AddRange(new object[] {
            "G",
            "N",
            "E"});
            cmbGod.Location = new System.Drawing.Point(0, 0);
            cmbGod.Margin = new System.Windows.Forms.Padding(0);
            cmbGod.Name = "cmbGod";
            cmbGod.Size = new System.Drawing.Size(40, 24);
            cmbGod.TabIndex = 0;

            this.cmbFig.BackColor = System.Drawing.Color.Black;
            this.cmbFig.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
            this.cmbFig.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.cmbFig.Font = this.Font;
            this.cmbFig.ForeColor = System.Drawing.Color.White;
            this.cmbFig.FormattingEnabled = true;
            this.cmbFig.Items.AddRange(new object[] {
            "Fighter",
            "Mage",
            "Priest",
            "Thief",
            "Bishop",
            "Samurai",
            "Lord",
            "Ninja"});
            this.cmbFig.Location = new System.Drawing.Point(40, 0);
            this.cmbFig.Margin = new System.Windows.Forms.Padding(0);
            this.cmbFig.Name = "cmbFig";
            this.cmbFig.Size = new System.Drawing.Size(90, 24);
            this.cmbFig.TabIndex = 1;

            this.cmbHum.BackColor = System.Drawing.Color.Black;
            this.cmbHum.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
            this.cmbHum.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.cmbHum.Font = this.Font;
            this.cmbHum.ForeColor = System.Drawing.Color.White;
            this.cmbHum.FormattingEnabled = true;
            this.cmbHum.Items.AddRange(new object[] {
            "Human",
            "Elf",
            "Dwarf ",
            "Gnome",
            "Hobit"});
            this.cmbHum.Location = new System.Drawing.Point(130, 0);
            this.cmbHum.Margin = new System.Windows.Forms.Padding(0);
            this.cmbHum.Name = "cmbHum";
            this.cmbHum.Size = new System.Drawing.Size(90, 24);
            this.cmbHum.TabIndex = 2;


            this.Controls.Add(cmbGod);
            this.Controls.Add(cmbFig);
            this.Controls.Add(cmbHum);


            this.Enabled = false;
            this.ResumeLayout(false);

            cmbGod.SelectedIndexChanged += CmbGod_SelectedIndexChanged;
            cmbFig.SelectedIndexChanged += CmbGod_SelectedIndexChanged;
            cmbHum.SelectedIndexChanged += CmbGod_SelectedIndexChanged;
        }

        //-------------------------------------------------------------
        private void CmbGod_SelectedIndexChanged(object sender, EventArgs e)
        {
			if (refFlag == true) return; 

            SetValue();
        }

        //-------------------------------------------------------------
        public int ChkTarget()
        {
            int idx = -1;
            if (m_wiz123SFC != null)
            {
                idx = m_wiz123SFC.SelectedIndex;
                if (idx >= 0)
                {
                    if (m_wiz123SFC.CharEnabled(idx) == false)
                    {
                        idx = -1;
                    }
                }

            }

            if (idx < 0)
            {
				bool bak = refFlag;
				refFlag = true;
                cmbGod.SelectedIndex = -1;
                cmbFig.SelectedIndex = -1;
                cmbHum.SelectedIndex = -1;
                this.Enabled = false;
				refFlag = false;
			}
			else
            {
                this.Enabled = true;
            }
            return idx;

        }     
        //-------------------------------------------------------------
        public void GetValue()
        {
            int idx = ChkTarget();
            if (idx<0) return;
            int v = (int)m_wiz123SFC.State.GetByte(m_adr + Wiz.CHR_OFFSET * idx);

			bool bak = refFlag;
			refFlag = true;
			//性格
			int v1 = v & 0x03;
            cmbGod.SelectedIndex = v1;
            int v2 = (v >> 2) & 0x07;
            cmbFig.SelectedIndex = v2;
            int v3 = (v >> 5) & 0x07;
            cmbHum.SelectedIndex = v3;
			refFlag = bak;

        }
        //-------------------------------------------------------------
        public void SetValue()
        {
            int idx = ChkTarget();
            if (idx < 0) return;

            int v1 = cmbGod.SelectedIndex;
            if (v1 < 0) v1 = 0;
            int v2 = cmbFig.SelectedIndex;
            if (v2 < 0) v2 = 0;
            int v3 = cmbHum.SelectedIndex;
            if (v3 < 0) v3 = 0;

            byte v = (byte)(v1 | (v2 << 2) | (v3 << 5));

            m_wiz123SFC.State.SetByte(m_adr + Wiz.CHR_OFFSET * idx, v);
        }
        //-------------------------------------------------------------
        public Snes9xWiz123SFC Wiz123SFC
        {
            get { return m_wiz123SFC; }
            set
            {
                m_wiz123SFC = value;
                if (m_wiz123SFC != null)
                {
                    m_wiz123SFC.SelectedIndexChanged += M_wiz123SFC_SelectedIndexChanged;
                    m_wiz123SFC.LoadFileEvent += M_wiz123SFC_LoadFileEvent;
                }
            }
        }

        //-------------------------------------------------------------
        private void M_wiz123SFC_LoadFileEvent(object sender, EventArgs e)
        {
            GetValue();
        }

        //-------------------------------------------------------------
        private void M_wiz123SFC_SelectedIndexChanged(object sender, EventArgs e)
        {
            GetValue();
            //throw new NotImplementedException();
        }
    }
}

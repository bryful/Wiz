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
    public class ChrStatus : Control
    {
        private Label caption;
        private ComboBox cmb;
        private Snes9xWizFive m_wizFive = null;
        const int m_adr = 0x1023;

		bool refFlag = false;
        public ChrStatus()
        {
            this.SuspendLayout();
            this.Font = new System.Drawing.Font("ＭＳ ゴシック", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(128)));
            this.MinimumSize = new Size(110, 24);
            this.MaximumSize = new Size(110, 24);
            this.Size = new Size(110, 24);
            this.Name = "ChrMPCount";
            this.BackColor = System.Drawing.Color.Black;


            caption = new Label();
            this.caption.Font =this.Font;
            this.caption.ForeColor = System.Drawing.Color.White;
            this.caption.Location = new System.Drawing.Point(0, 0);
            this.caption.Margin = new System.Windows.Forms.Padding(0);
            this.caption.Name = "caption";
            this.caption.Size = new System.Drawing.Size(40, 24);
            this.caption.TabIndex = 0;
            this.caption.Text = "状態";
            this.caption.TextAlign = System.Drawing.ContentAlignment.MiddleRight;

            cmb = new ComboBox();
            this.cmb.BackColor = System.Drawing.Color.Black;
            this.cmb.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
            this.cmb.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.cmb.Font = this.Font;
            this.cmb.ForeColor = System.Drawing.Color.White;
            this.cmb.FormattingEnabled = true;
            this.cmb.Items.AddRange(new object[] {
            "OK",
            "恐怖",
            "睡眠",
            "麻痺",
            "石化",
            "死亡",
            "灰",
            "ロスト"});
            this.cmb.Location = new System.Drawing.Point(40, 0);
            this.cmb.Name = "cmb";
            this.cmb.Size = new System.Drawing.Size(70, 24);
            this.cmb.TabIndex = 1;

            this.Controls.Add(caption);
            this.Controls.Add(cmb);

            this.cmb.Enabled = false;

            this.ResumeLayout(false);


            cmb.SelectedIndexChanged += Cmb_SelectedIndexChanged;


        }

        //-------------------------------------------------------------
        private void Cmb_SelectedIndexChanged(object sender, EventArgs e)
        {
			if (refFlag == true) return;
            SetValue();
            //throw new NotImplementedException();
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

            if (idx<0)
            {
				bool bak = refFlag;
				refFlag = true;
                cmb.SelectedIndex = -1;
				refFlag = false;
				cmb.Enabled = false;
            }
            else
            {
                cmb.Enabled = true;
            }
            return idx;

        }
        public void GetValue()
        {
            int idx = ChkTarget();

            if (idx <0) return;

            int v1 = (int)m_wizFive.State.GetByte(m_adr + 0x80 * idx);
            if (v1 < 0) v1 = 0;
            if (v1 >= cmb.Items.Count) v1 = cmb.Items.Count - 1;
			bool bak = refFlag;
			refFlag = true;
			cmb.SelectedIndex = v1;
			refFlag = false;

		}
		//-------------------------------------------------------------
		public void SetValue()
        {
            if (m_wizFive == null) return;
            int idx = m_wizFive.SelectedIndex;
            if (idx < 0) idx = 0;

            int v = cmb.SelectedIndex;
            if (v < 0) v = 0;

            m_wizFive.State.SetByte(m_adr + 0x80 * idx, (byte)v);

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
            //throw new NotImplementedException();
        }

    }
}

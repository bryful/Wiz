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
    public class ChrItemList :Control
    {
        /// <summary>
        /// データ
        /// </summary>
        private Snes9xWiz123SFC m_wiz123SFC = null;
        //アイテム状態
        private const int m_adrIS = Wiz.CHR_ITEMSAT;
        //アイテム種類
        private const int m_adrItm = Wiz.CHR_ITEM;
        private const int m_adrICNT = Wiz.CHR_ITEMCNT;

        private ListBox listBox1 = new ListBox();
        private Button btnUp = new Button();
        private Button btnDown = new Button();

        private Button btnNOR = new Button();

        private int m_targetChr = -1;
        private int m_itemCount = 0;


        //--------------------------------------------
        public ChrItemList()
        {
            this.SuspendLayout();

            this.BackColor = System.Drawing.Color.Black;
            this.ForeColor = System.Drawing.Color.White;
            this.MinimumSize = new System.Drawing.Size(195, 50);
            this.MaximumSize = new System.Drawing.Size(4000, 4000);
            this.Size = new System.Drawing.Size(195, 175);
            this.Name = "ChrItemList";


            this.btnUp.FlatStyle = FlatStyle.Flat;
            this.btnUp.ForeColor = Color.White;
            this.btnUp.Location = new Point(0, 0);
            this.btnUp.Margin = new Padding(0);
            this.btnUp.Name = "btnUp";
            this.btnUp.Size = new Size(40, 24);
            this.btnUp.TabIndex = 0;
            this.btnUp.Text = "Up";
            this.btnUp.UseVisualStyleBackColor = true;
            //this.btnUp.Enabled = false;

            this.btnDown.FlatStyle = FlatStyle.Flat;
            this.btnDown.ForeColor = Color.White;
            this.btnDown.Location = new Point(45, 0);
            this.btnDown.Margin = new Padding(0);
            this.btnDown.Name = "btnDown";
            this.btnDown.Size = new Size(40, 24);
            this.btnDown.TabIndex = 1;
            this.btnDown.Text = "Dwn";
            this.btnDown.UseVisualStyleBackColor = true;
            //this.btnDown.Enabled = false;

            this.btnNOR.FlatStyle = FlatStyle.Flat;
            this.btnNOR.ForeColor = Color.White;
            this.btnNOR.Location = new Point(140, 0);
            this.btnNOR.Margin = new Padding(0);
            this.btnNOR.Name = "btnNOR";
            this.btnNOR.Size = new Size(55, 24);
            this.btnNOR.TabIndex = 2;
            this.btnNOR.Text = "正常化";
            this.btnNOR.UseVisualStyleBackColor = true;
            this.btnNOR.Anchor = (AnchorStyles)(AnchorStyles.Right|AnchorStyles.Top);


            this.listBox1.Font = new Font("ＭＳ ゴシック", 10F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(128)));
            this.listBox1.BackColor = System.Drawing.Color.Black;
            this.listBox1.ForeColor = Color.White;
            this.listBox1.FormattingEnabled = true;
            this.listBox1.ItemHeight = 19;
            this.listBox1.Location = new System.Drawing.Point(0, 25);
            this.listBox1.Name = "listBox1";
            this.listBox1.Size = new System.Drawing.Size(195, 150);
            this.listBox1.TabIndex = 5;
            this.listBox1.Anchor = ((AnchorStyles)((((AnchorStyles.Top | AnchorStyles.Bottom) | AnchorStyles.Left) | AnchorStyles.Right)));

            this.Controls.Add(this.btnUp);
            this.Controls.Add(this.btnDown);
            this.Controls.Add(this.btnNOR);
            this.Controls.Add(this.listBox1);

            this.ResumeLayout(false);


            btnUp.Click += BtnUp_Click;
            btnDown.Click += BtnDown_Click;
            btnNOR.Click += BtnNOR_Click;

            this.listBox1.DoubleClick += ListBox1_DoubleClick;
        }

        //-------------------------------------------------------------
        private void ListBox1_DoubleClick(object sender, EventArgs e)
        {
            if ((Control.ModifierKeys & Keys.Shift) == Keys.Shift)
            {
                if (m_targetChr < 0) return;
                int si = listBox1.SelectedIndex;
                if (si < 0) return;
                int adr1 = m_adrIS + Wiz.CHR_OFFSET * m_targetChr + si;
                int adr2 = m_adrItm + Wiz.CHR_OFFSET * m_targetChr + si;

                int v = (int)m_wiz123SFC.State.GetByte(adr2);


                using (ItemEditDlg dlg = new ItemEditDlg())
                {
                    dlg.SetItems(Wiz.WIZITEM[(int)m_wiz123SFC.Scenario], v);
                    if (dlg.ShowDialog() == DialogResult.OK)
                    {
                        m_wiz123SFC.State.SetByte(adr1, 0);
                        m_wiz123SFC.State.SetByte(adr2, (byte)dlg.SelectedIndex);
                        GetValue();
                        listBox1.SelectedIndex = si;

                    }
                }
            }
        }

        //-------------------------------------------------------------
        private void BtnNOR_Click(object sender, EventArgs e)
        {
            ToNor();
        }

        //-------------------------------------------------------------
        private void BtnDown_Click(object sender, EventArgs e)
        {
            ItemDown();
        }

        //-------------------------------------------------------------
        private void BtnUp_Click(object sender, EventArgs e)
        {
            ItemUp();
        }

        //-------------------------------------------------------------
        public void SwapItem(int idx0, int idx1)
        {
            if (m_targetChr < 0) return;
            if (idx0 == idx1) return;
            if ((idx0 < 0) || (idx0 >= m_itemCount) || (idx1 < 0) || (idx1 >= m_itemCount)) return;
            byte ii0 = m_wiz123SFC.State.GetByte(m_adrIS + Wiz.CHR_OFFSET * m_targetChr + idx0);
            byte ic0 = m_wiz123SFC.State.GetByte(m_adrItm + Wiz.CHR_OFFSET * m_targetChr + idx0);
            byte ii1 = m_wiz123SFC.State.GetByte(m_adrIS + Wiz.CHR_OFFSET * m_targetChr + idx1);
            byte ic1 = m_wiz123SFC.State.GetByte(m_adrItm + Wiz.CHR_OFFSET * m_targetChr + idx1);

            m_wiz123SFC.State.SetByte(m_adrIS + Wiz.CHR_OFFSET * m_targetChr + idx0, ii1);
            m_wiz123SFC.State.SetByte(m_adrItm + Wiz.CHR_OFFSET * m_targetChr + idx0, ic1);
            m_wiz123SFC.State.SetByte(m_adrIS + Wiz.CHR_OFFSET * m_targetChr + idx1, ii0);
            m_wiz123SFC.State.SetByte(m_adrItm + Wiz.CHR_OFFSET * m_targetChr + idx1, ic0);

        }
        //-------------------------------------------------------------
        public void ItemUp()
        {
            int si = listBox1.SelectedIndex;
            if (si > 0)
            {
                SwapItem(si, si - 1);
                GetValue();
                listBox1.SelectedIndex = si - 1;
            }

        }
        //-------------------------------------------------------------
        public void ItemDown()
        {
            int si = listBox1.SelectedIndex;
            if ( (si >= 0)&&(si <m_itemCount-1))
            {
                SwapItem(si, si + 1);
                GetValue();
                listBox1.SelectedIndex = si + 1;
            }

        }
        //-------------------------------------------------------------
        public void ToNor()
        {

            if (m_targetChr < 0) return;
            int si = listBox1.SelectedIndex;
            if (si < 0) return;
            int adr = m_adrIS + Wiz.CHR_OFFSET * m_targetChr + si;
            byte b = m_wiz123SFC.State.GetByte(adr);
            if (b != 0)
            {
                b = 0;
            }
            else
            {
                b = 0x80;
            }
            m_wiz123SFC.State.SetByte(adr, b);
            GetValue();
            listBox1.SelectedIndex = si;

        }
        //-------------------------------------------------------------
        public void GetValue()
        {
            this.SuspendLayout();
            listBox1.Items.Clear();
            m_targetChr = -1;
            m_itemCount = 0;
            if (m_wiz123SFC != null)
            {
                int idx = m_wiz123SFC.SelectedIndex;
                m_targetChr = idx;
                if ((idx >= 0)&&(m_wiz123SFC.CharEnabled(idx) == true))
                {
                    //アイテムの個数
                    int ic = (int)m_wiz123SFC.State.GetByte(m_adrICNT + Wiz.CHR_OFFSET * idx);
                    m_itemCount = ic;
                    if (ic>0)
                    {
                        if (ic > Wiz.CHR_ITEMCNTMAX) ic = Wiz.CHR_ITEMCNTMAX;

                        for ( int i=0; i<ic; i++)
                        {
                            int v1 = (int)m_wiz123SFC.State.GetByte(m_adrIS + Wiz.CHR_OFFSET * idx + i);
                            int v2 = (int)m_wiz123SFC.State.GetByte(m_adrItm + Wiz.CHR_OFFSET * idx + i);
                            if ((v2 < 0)|| (v2 > Wiz.WIZ3_ITEMCOUNT)) v2 = 0;

                            bool shiki = ((v1 & 0x20) == 0x20);
                            bool noroi = ((v1 & 0x40) == 0x40);
                            bool soubi = ((v1 & 0x80) == 0x80);

                            string s = "";
                            if (soubi)
                            {
                                s += "＊";
                            }
                            else if (noroi)
                            {
                                s += "呪";
                            }
                            else
                            {
                                s += "  ";
                            }
                            if (shiki) s += " 未識別:";
                            s += Wiz.WIZITEM[(int)m_wiz123SFC.Scenario][v2];
                            listBox1.Items.Add(s);
                        }

                    }
                }
            }
            this.ResumeLayout(false);
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
                    m_wiz123SFC.ScenarioChanged += M_wiz123SFC_ChangeScenariovent;
                }
            }
        }
        //-------------------------------------------------------------
        private void M_wiz123SFC_ChangeScenariovent(object sender, EventArgs e)
        {
            GetValue();
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
        }

    }
}

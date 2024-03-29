﻿using System;
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
    public partial class WizCharNameEdit : Form
    {
        private string[] m_Names = new string[20];
        public string [] Names
        {
            get { return m_Names; }
            set { m_Names = value; }
        }
        byte[] temp1 = new byte[] { 0x7B, 0x9B, 0x79, 0x01 };
        byte[] temp2 = new byte[] { 0x9B, 0xFD, 0x9C, 0x31 };

        private List<byte> m_nameOrg = new List<byte>();
        private List<byte> m_name = new List<byte>();

        public byte[] CharNameCode
        {
            get { return m_name.ToArray(); }
            set
            {
                int cnt = value.Length;
                m_nameOrg.Clear();
                m_name.Clear();

                if(cnt>0)
                {
                    for ( int i=0;i<cnt;i++)
                    {
                        m_nameOrg.Add( value[i]);
                        m_name.Add(value[i]);
                    }
                }
                NameChk();
                this.Invalidate();

            }
        }

        private WIZSCN m_scn = WIZSCN.FC1;
        public WIZSCN SCN
        {
            get { return m_scn; }
            set { m_scn = value; SizeChk(); this.Invalidate(); }
        }
        private int m_LeftM = 20;
        public int LeftM
        {
            get { return m_LeftM; }
            set { m_LeftM = value; SizeChk(); this.Invalidate(); }
        }
        private int m_TopM = 120;
        public int TopM
        {
            get { return m_TopM; }
            set { m_TopM = value; SizeChk(); this.Invalidate(); }
        }
        private int m_MWidth = 25;
        public int MWidth
        {
            get { return m_MWidth; }
            set { m_MWidth = value; SizeChk(); this.Invalidate(); }
        }
        private int m_MHeight = 25;
        public int MHeight
        {
            get { return m_MHeight; }
            set { m_MHeight = value; SizeChk(); this.Invalidate(); }
        }




        // *******************************************************************
        public WizCharNameEdit()
        {
            this.SetStyle(
          ControlStyles.DoubleBuffer |
          ControlStyles.UserPaint |
          ControlStyles.AllPaintingInWmPaint,
          true);
            this.ForeColor = Color.White;
            this.BackColor = Color.Black;

            this.Font = new Font(this.Font.FontFamily, 12, FontStyle.Bold);

            InitializeComponent();
            this.AutoScaleMode = AutoScaleMode.None;
 
            this.StartPosition = FormStartPosition.CenterParent;

            SizeChk();
        }
        // *******************************************************************
        private void SizeChk()
        {
            int w = 0;
            int h = 0;
            int t = 0;
            int linc = 0;
            if (m_scn== WIZSCN.FC1)
            {
                linc = 10;
            }
            else
            {
                linc = 14;

            }
            w = m_LeftM * 2 + m_MWidth * 0x10;
            h = m_TopM + m_MHeight * linc + 70;
            t = m_TopM + m_MHeight * linc + 10;

            this.ClientSize = new Size(w, h);

            int l = this.ClientSize.Width - btnOK.Width - 20;
            btnOK.Location = new Point(l, t);
            l -= btnCancel.Width + 10;
            btnCancel.Location = new Point(l, t);
        }
        // *******************************************************************
        private void NameClear()
        {
            m_name.Clear();
            NameChk();
            this.Invalidate();
        }
        // *******************************************************************
        private void NameBS()
        {
            if(m_name.Count<=1)
            {
                m_name.Clear();
            }
            else
            {
                m_name.RemoveAt(m_name.Count - 1);
            }

            NameChk();
            this.Invalidate();
        }
        // *******************************************************************
        private bool CanSetName(string s)
        {
            bool ret = true;
            if (s == "") return false;
            if (m_Names.Length <= 0) return ret;
            for ( int i=0; i< m_Names.Length;i++)
            {
                if(m_Names[i]==s)
                {
                    ret = false;
                    break;
                }
            }
            return ret;
        }
        // *******************************************************************
        private void NameChk()
        {
            string s0 = WizString.CodeToString(m_scn, m_nameOrg.ToArray());
            string s1 = WizString.CodeToString(m_scn, m_name.ToArray());
            this.Text = s0 + "/" + s1;
            bool ret = ((m_name.Count > 0) && (s0 != s1));
            if(ret)
            {
                ret = CanSetName(s1);
            }
            btnOK.Enabled = ret;
        }
        // *******************************************************************
        protected override void OnPaint(PaintEventArgs e)
        {
            //base.OnPaint(e);
            Graphics g = e.Graphics;
            SolidBrush sb = new SolidBrush(this.BackColor);
            Pen pn = new Pen(this.ForeColor);
            StringFormat sf = new StringFormat();
            sf.LineAlignment = StringAlignment.Center;
            sf.Alignment = StringAlignment.Near;
            try
            {
                sb.Color = Color.Black;
                g.FillRectangle(sb, new Rectangle(0, 0, this.Width, this.Height));
                int x = 20;
                int y = 20;
                sb.Color = Color.White;
                g.DrawString(WizString.CodeToString(m_scn, m_nameOrg.ToArray()),this.Font,sb, x, y);
                y += 25;
                g.DrawString(WizString.CodeToString(m_scn, m_name.ToArray()), this.Font, sb, x, y);

                sb.Color = Color.White;
                Rectangle rct = new Rectangle(0, 0, 0, 0);
                sf.Alignment = StringAlignment.Center;

                int target = 0;

                if (m_scn==WIZSCN.FC1)
                {
                    target = WizString.Wiz1FCStringStart;
                    y = m_TopM;
                    for ( int j=0; j<0x10;j++)
                    {
                        x = m_LeftM;
                        for (int i = 0; i < 0x10; i++)
                        {
                            rct = new Rectangle(x, y, m_MWidth, m_MHeight);
                            g.DrawString(WizString.Wiz1FCStrings[target], this.Font, sb, rct, sf);
                            target++;
                            if (target >= WizString.Wiz1FCStringSize) break;
                            x += m_MWidth;

                        }
                        if (target >= WizString.Wiz1FCStringSize) break;

                        y += m_MHeight;
                    }
                }
                else
                {
                    target = WizString.Wiz2FCStringStart;
                    y = m_TopM;
                    for (int j = 0; j < 0x10; j++)
                    {
                        x = m_LeftM;
                        for (int i = 0; i < 0x10; i++)
                        {
                            rct = new Rectangle(x, y, m_MWidth, m_MHeight);
                            g.DrawString(WizString.Wiz2FCStrings[target], this.Font, sb, rct, sf);
                            target++;
                            if (target >= WizString.Wiz2FCStringSize) break;
                            x += m_MWidth;
                        }
                        if (target >= WizString.Wiz2FCStringSize) break;
                        y += m_MHeight;
                    }
                }


            }
            finally
            {
                sb.Dispose();
                pn.Dispose();
            }


        }

        private void btnClear_Click(object sender, EventArgs e)
        {
            NameClear();
        }

        private void btnBS_Click(object sender, EventArgs e)
        {
            NameBS();
        }
        // *******************************************************************
        protected override void OnMouseDown(MouseEventArgs e)
        {
            int x = (e.X - m_LeftM) / m_MWidth;
            int y = (e.Y - m_TopM) / m_MHeight;
            int lc = 0;
            if(m_scn== WIZSCN.FC1)
            {
                lc = 10;
            }
            else
            {
                lc = 14;
            }
            if ((x >= 0) && (x < 0x10) && (y >= 0) && (y < lc))
            {
                int idx = x + y * 0x10;
                if (m_scn != WIZSCN.FC1)
                {
                    idx += WizString.Wiz2FCStringStart;
                }
                if(m_name.Count<8)
                {
                    m_name.Add((byte)idx);
                    NameChk();
                    this.Invalidate();
                }
            }
            base.OnMouseDown(e);

        }
        // *********************************************************
        protected override void OnFormClosing(FormClosingEventArgs e)
        {
            

            base.OnFormClosing(e);
        }
    }
}

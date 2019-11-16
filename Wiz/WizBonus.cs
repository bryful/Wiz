using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Drawing;
using System.Data;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using System.Drawing.Drawing2D;


namespace WizEdit
{
    public class WizBonus : Control
    {
        public const int BounusCount = 6;
        private int[] m_Bounus = new int[BounusCount];
        private bool m_IsDrawFrame = false;
        public bool IsDrawFrame
        {
            get { return m_IsDrawFrame; }
            set { m_IsDrawFrame = value; this.Invalidate(); }
        }
        private bool m_IsJapan = true;
        public bool IsJapan
        {
            get { return m_IsJapan; }
            set { m_IsJapan = value; this.Invalidate(); }
        }
        private string[] m_CapTblJ = new string[]
        {
            "ちから",
            "ちえ" ,
            "しんこうしん",
            "せいめいりょく",
            "すばやさ",
            "うんのつよさ"
        };
        private string[] m_CapTblE = new string[]
       {
            "STRENGTH",
            "I.Q." ,
            "PIETY",
            "VITALITY",
            "AGILITY",
            "LUCK"
       };
        private int m_LineHeight = 18;
        public int LineHeight
        {
            get { return m_LineHeight; }
            set { m_LineHeight = value; SizeChk();  this.Invalidate(); }
        }
        private int m_CaptionWidth = 130;
        public int CaptionWidth
        {
            get { return m_CaptionWidth; }
            set { m_CaptionWidth = value; SizeChk();  this.Invalidate(); }
        }
        private int m_ValueWidth = 70;
        public int ValueWidth
        {
            get { return m_ValueWidth; }
            set { m_ValueWidth = value; SizeChk();  this.Invalidate(); }
        }
        // *************************************************************************
        #region state
        private WizNesState m_state = null;
        public WizNesState WizNesState
        {
            get { return m_state; }
            set
            {
                m_state = value;
                if (m_state != null)
                {
                    m_state.ChangeCurrentChar += M_state_ChangeCurrentChar;
                    m_state.FinishedLoadFile += M_state_FinishedLoadFile;
                }
                GetInfo();
            }
        }
        private void M_state_FinishedLoadFile(object sender, EventArgs e)
        {
            GetInfo();
        }

        private void M_state_ChangeCurrentChar(object sender, CurrentCharEventArgs e)
        {
            GetInfo();
        }
        #endregion
        // *************************************************************************
        public WizBonus()
        {
            this.BackColor = Color.Black;
            this.ForeColor = Color.White;
            SizeChk();
        }
        // *************************************************************************
        public void SizeChk()
        {
            int h = m_LineHeight * 6;
            int w = m_CaptionWidth + m_ValueWidth;
            this.MinimumSize = new Size(w, h);
        }
        // *************************************************************************
        public void GetInfo()
        {
            for (int i = 0; i < BounusCount; i++) m_Bounus[i] = 0;
            if (m_state!=null)
            { 
                byte[] r = m_state.CharBounus;
                for (int i = 0; i < BounusCount; i++) m_Bounus[i] = r[i];
            }
            this.Invalidate();
        }
        // *************************************************************************
        protected override void OnPaint(PaintEventArgs e)
        {
            Graphics g = e.Graphics;
            //base.OnPaint(e);
            SolidBrush sb = new SolidBrush(this.BackColor);
            StringFormat sf = new StringFormat();
            sf.LineAlignment = StringAlignment.Center;
            sf.Alignment = StringAlignment.Near;
            Pen pn = new Pen(this.ForeColor);
            pn.Width = 2;
            try
            {
                Rectangle rct = new Rectangle(0, 0, this.Width, this.Height);
                g.FillRectangle(sb, rct);

                if(m_IsDrawFrame==true)
                {
                    pn.Color = Color.DarkGray;
                    g.DrawRectangle(pn, rct);
                    int x = m_CaptionWidth;
                    g.DrawLine(pn,x, 0, x, this.Height);
                    x += m_ValueWidth;
                    g.DrawLine(pn, x, 0, x, this.Height);
                }


                sb.Color = this.ForeColor;
                sf.Alignment = StringAlignment.Far;
                for ( int i=0; i< BounusCount; i++)
                {
                    rct = new Rectangle(0, m_LineHeight * i, m_CaptionWidth, m_LineHeight);
                    string s = "";
                    if (m_IsJapan) s = m_CapTblJ[i]; else s = m_CapTblE[i];
                    g.DrawString(s, this.Font, sb, rct, sf);

                    rct = new Rectangle(m_CaptionWidth, m_LineHeight * i, m_ValueWidth, m_LineHeight);

                    g.DrawString(m_Bounus[i].ToString(), this.Font, sb, rct, sf);


                }


            }
            finally
            {
                sb.Dispose();
            }

        }
        // *************************************************************************
    }
}

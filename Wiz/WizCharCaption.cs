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
    public class WizCharCaption : Control
    {
        public event EventHandler NameClicked;
        protected virtual void OnNameClicked(EventArgs e){NameClicked?.Invoke(this, e);}
        public event EventHandler LevelClicked;
        protected virtual void OnLevelClicked(EventArgs e) { LevelClicked?.Invoke(this, e); }
        public event EventHandler AlgClicked;
        protected virtual void OnAlgClicked(EventArgs e) { AlgClicked?.Invoke(this, e); }
        public event EventHandler ClassClicked;
        protected virtual void OnClassClicked(EventArgs e) { ClassClicked?.Invoke(this, e); }
        public event EventHandler RaceClicked;
        protected virtual void OnRaceClicked(EventArgs e) { RaceClicked?.Invoke(this, e); }

        private bool m_IsDrawFrame = true;
        public bool IsDrawFrame
        {
            get { return m_IsDrawFrame; }
            set { m_IsDrawFrame = value; this.Invalidate(); }
        }
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
                    m_state.CurrentCharChanged += M_state_ChangeCurrentChar;
                    m_state.LoadFileFinished += M_state_ValueChanged;
                    m_state.ValueChanged += M_state_ValueChanged;
                }
                this.Invalidate();
            }
        }

        private void M_state_ValueChanged(object sender, EventArgs e)
        {
            this.Invalidate();
        }
        private void M_state_ChangeCurrentChar(object sender, CurrentCharEventArgs e)
        {
            this.Invalidate();
        }
        #endregion

        private int m_WName = 120;
        public int WidthName
        {
            get { return m_WName; }
            set { m_WName = value; SizeChk(); this.Invalidate(); }
        }
        private int m_WLevel = 100;
        public int WidthLevel
        {
            get { return m_WLevel; }
            set { m_WLevel = value; SizeChk(); this.Invalidate(); }
        }
        private int m_WAlg = 40;
        public int WidthAlg
        {
            get { return m_WAlg; }
            set { m_WAlg = value; SizeChk(); this.Invalidate(); }
        }
        private int m_WClass = 40;
        public int WidthClass
        {
            get { return m_WClass; }
            set { m_WClass = value; SizeChk(); this.Invalidate(); }
        }
        private int m_WRace = 75;
        public int WidthRace
        {
            get { return m_WRace; }
            set { m_WRace = value; SizeChk(); this.Invalidate(); }
        }
        // ****************************************************************
        public Point AlgPoint
        {
            get { return new Point(this.Left + m_WName + m_WLevel, this.Top); }
        }
        public Point ClassPoint
        {
            get { return new Point(this.Left + m_WName + m_WLevel+m_WAlg, this.Top); }
        }
        public Point RacePoint
        {
            get { return new Point(this.Left + m_WName + m_WLevel + m_WAlg+m_WClass, this.Top); }
        }
        // ****************************************************************
        public WizCharCaption()
        {
            this.BackColor = Color.Black;
            this.ForeColor = Color.White;

            SizeChk();
        }
        // ****************************************************************
        public void SizeChk()
        {
            int w = m_WName + m_WLevel + m_WAlg + m_WClass + m_WRace;
            int h = this.MinimumSize.Height;
            this.MinimumSize = new Size(w, h);
        }
        // ****************************************************************
        protected override void OnPaint(PaintEventArgs e)
        {
            base.OnPaint(e);

            SolidBrush sb = new SolidBrush(this.BackColor);
            Pen pn = new Pen(this.ForeColor);
            pn.Width = 2;
            StringFormat sf = new StringFormat();
            sf.Alignment = StringAlignment.Near;
            sf.LineAlignment = StringAlignment.Center;
            Graphics g = e.Graphics;
            try
            {
                Rectangle rct = new Rectangle(new Point(0, 0), this.Size);
                g.FillRectangle(sb, rct);
                int x = 0;
                int h = this.Height;

                if (m_IsDrawFrame==true)
                {
                    pn.Color = Color.DarkGray;
                    g.DrawRectangle(pn, rct);
                    x = m_WName;
                    g.DrawLine(pn, x, 0, x, h);
                    x += m_WLevel;
                    g.DrawLine(pn, x, 0, x, h);
                    x += m_WAlg;
                    g.DrawLine(pn, x, 0, x, h);
                    x += m_WClass;
                    g.DrawLine(pn, x, 0, x, h);
                    x += m_WRace;
                    g.DrawLine(pn, x, 0, x, h);

                    pn.Color = this.ForeColor;
                }
                if ((m_state!=null)&&(m_state.CharCurrent>=0))
                {
                    sb.Color = this.ForeColor;
                    //name
                    x = 0;
                    rct = new Rectangle(x, 0, m_WName, h);
                    g.DrawString(m_state.CharName,this.Font, sb, rct, sf);
                    //Level
                    x += m_WName;
                    rct = new Rectangle(x, 0, m_WLevel, h);
                    g.DrawString("L", this.Font, sb, rct, sf);
                    sf.Alignment = StringAlignment.Far;
                    g.DrawString(String.Format("{0}",m_state.CharLevel), this.Font, sb, rct, sf);
                    sf.Alignment = StringAlignment.Near;
                    //Alg
                    x += m_WLevel;
                    rct = new Rectangle(x, 0, m_WAlg, h);
                    sf.Alignment = StringAlignment.Far;
                    g.DrawString(m_state.CharAlgStr[0]+"-", this.Font, sb, rct, sf);
                    sf.Alignment = StringAlignment.Near;
                    //Class
                    x += m_WAlg;
                    rct = new Rectangle(x, 0, m_WClass, h);
                    g.DrawString(m_state.CharClassStr , this.Font, sb, rct, sf);
                    x += m_WClass;
                    rct = new Rectangle(x, 0, m_WRace, h);
                    g.DrawString(m_state.CharRaceStr, this.Font, sb, rct, sf);

                }
            }
            finally
            {
                sb.Dispose();
            }
        }
        // *****************************************************************************************
        protected override void OnMouseDown(MouseEventArgs e)
        {
            int x = e.X;
            if (x >= 0)
            {
                int[] w = new int [5];
                w[0] = m_WName;
                w[1] = w[0] + m_WLevel;
                w[2] = w[1] + m_WAlg;
                w[3] = w[2] + m_WClass;
                w[4] = w[3] + m_WRace;
                if (x < w[0]) { OnNameClicked(new EventArgs()); }
                else if (x < w[1]) { OnLevelClicked(new EventArgs()); }
                else if (x < w[2]) { OnAlgClicked(new EventArgs()); }
                else if (x < w[3]) { OnClassClicked(new EventArgs()); }
                else if (x < w[4]) { OnRaceClicked(new EventArgs()); }
            }
            base.OnMouseDown(e);
        }
        // *****************************************************************************************
    }
}

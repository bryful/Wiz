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

namespace WizFCEdit
{
    public class WizStatus : Control
    {
        // 0:OK, 1:ASLEEP, 2:AFRAID, 3:PARALY, 4:STONED, 5:DEAD, 6:ASHED, 7:LOST
        static public string[] m_statusStrJ = new string[]
        {
            "OK",
            "ねむっている",
            "おそれている",
            "まひしている",
            "いしになった",
            "しんでいる",
            "はいになった",
            "うしなわれた"
        };
        static public readonly string[] m_statusStrE = new string[]
        {
            "OK",
            "ASLEEP",
            "AFRAID",
            "PARALY",
            "STONED",
            "DEAD",
            "ASHED",
            "LOST"
        };

        private WIZSTATUS m_status = WIZSTATUS.OK;
        public bool IsEdit = true;
        private bool m_IsJapan = false;
        public bool IsJapan
        {
            get { return m_IsJapan; }
            set { m_IsJapan = value; this.Invalidate(); }
        }
        private bool m_IsDrawFrame = false;
        public bool IsDrawFrame
        {
            get { return m_IsDrawFrame; }
            set { m_IsDrawFrame = value; this.Invalidate(); }
        }
        private int m_CaptionWidth = 100;
        public int CaptionWidth
        {
            get { return m_CaptionWidth; }
            set { m_CaptionWidth = value; this.Invalidate(); }
        }
        public Point StatusPoint
        {
            get { return new Point(m_CaptionWidth+ this.Left, this.Top); }
        }
        // *************************************************************************
        #region state
        private WizFCState m_state = null;
        public WizFCState WizNesState
        {
            get { return m_state; }
            set
            {
                m_state = value;
                if (m_state != null)
                {
                    m_state.CurrentCharChanged += M_state_ChangeCurrentChar;
                    m_state.LoadFileFinished += M_state_FinishedLoadFile;
                    m_state.ValueChanged += M_state_FinishedLoadFile;
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
        public void GetInfo()
        {
            if (m_state != null)
            {
                m_status = m_state.CharStatus;
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

                if (m_IsDrawFrame == true)
                {
                    pn.Color = Color.DarkGray;
                    g.DrawRectangle(pn, rct);
                    int x = m_CaptionWidth;
                    g.DrawLine(pn, x, 0, x, this.Height);
                }

                rct = new Rectangle(0, 0, m_CaptionWidth, this.Height);
                sb.Color = this.ForeColor;

                string s = "";
                if (m_IsJapan)
                {
                    s = "じょうたい";
                }
                else
                {
                    s = "STATUS";
                }
                g.DrawString(s, this.Font, sb, rct, sf);

                rct = new Rectangle(m_CaptionWidth, 0, this.Width - m_CaptionWidth, this.Height);

                s = "";
                if (m_IsJapan)
                {
                    s = m_statusStrJ[(int)m_status];
                }
                else
                {
                    s = m_statusStrE[(int)m_status];
                }

                g.DrawString(s, this.Font, sb, rct, sf);

            }
            finally
            {
                sb.Dispose();
            }

        }
        // *************************************************************************
        protected override void OnMouseDown(MouseEventArgs e)
        {
            base.OnMouseDown(e);

            if (e.X < m_CaptionWidth) return;

            if (m_state == null) return;
            if (IsEdit == false) return;
            WizComboBox cmb = new WizComboBox();
            int ox = cmb.OffsetPoint.X;
            int oy = cmb.OffsetPoint.Y;
            cmb.Name = "A";
            cmb.Location = new Point(this.Left + m_CaptionWidth - ox, this.Top - oy);
            cmb.Size = new Size(130, this.Height * 3);
            for (int i = 0; i < m_statusStrE.Length; i++)
            {
                if (m_IsJapan)
                {
                    cmb.Add(m_statusStrJ[i]);
                }
                else
                {
                    cmb.Add(m_statusStrE[i]);
                }
            }
            cmb.SelectedIndex = (int)m_state.CharStatus;
            cmb.IsListMode = true;
            cmb.VisibleChanged += Cmb_VisibleChanged;
            this.Parent.Controls.Add(cmb);
            cmb.BringToFront();
            cmb.Visible = true;
            
        }

        private void Cmb_VisibleChanged(object sender, EventArgs e)
        {
            if (m_state == null) return;
            WizComboBox w = (WizComboBox)sender;
            if (w.SelectedIndex >= 0)
            {
                WIZSTATUS o = m_state.CharStatus;
                WIZSTATUS r = (WIZSTATUS)w.SelectedIndex;

                if (o != r)
                {
                    m_state.CharStatus = r;
                    this.Invalidate();
                }
            }
            WizComboBox.MeDelete(this.Parent.Controls, w);
        }
    }
}

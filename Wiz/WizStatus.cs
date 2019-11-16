﻿using System;
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
    }
}

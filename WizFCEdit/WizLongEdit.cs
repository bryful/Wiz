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
    public enum WizLongEditMode
    {
        Gold,
        Exp,
        HP,
        HPMax
    }
    public class WizLongEdit :Control
    {


        public event EventHandler ValueChanged;
        protected virtual void OnValueChanged(EventArgs e) { ValueChanged?.Invoke(this, e); }

        private WizLongEditMode m_Mode = WizLongEditMode.Gold;
        public WizLongEditMode Mode
        {
            get { return m_Mode; }
            set
            {
                if (m_Mode !=value)
                {
                    m_Mode = value;
                    switch(m_Mode)
                    {
                        case WizLongEditMode.Gold:
                        case WizLongEditMode.Exp:
                            m_MaxValue = 999999999999;
                            m_NumKeta = 12;
                            break;
                        case WizLongEditMode.HP:
                        case WizLongEditMode.HPMax:
                            m_MaxValue = 0xFFFF; //65535
                            m_NumKeta = 5;
                            break;
                    }


                    GetInfo();
                    this.Invalidate();
                }
            }
        }

        private ulong m_MaxValue = 0x999999999999;
        private int m_NumKeta = 12;


        private ulong m_Value = 0;
        public ulong Value
        {
            get { return m_Value; }
            set
            {
                if(SetValue(value))
                {
                    OnValueChanged(new EventArgs());
                    this.Invalidate();
                }
            }
        }
        public bool SetValue(ulong v)
        {
            bool ret = false;
            if (v > m_MaxValue) v = m_MaxValue;

            if (m_Value != v)
            {
                m_Value = v;
                SetInfo();
                ret = true;
            }
            return ret;
        }
      
        private int m_ArrowHeight = 5;
        public int ArrowHeight
        {
            get { return m_ArrowHeight; }
            set
            {
                int v = value;
                if (v < 5) v = 5;
                if(m_ArrowHeight != v)
                {
                    m_ArrowHeight = v;
                    this.Invalidate();
                }
            }
        }


        private int m_NumWidth = 10;
        public int NumWidth
        {
            get { return m_NumWidth; }
            set {
                int v = value;
                if (v < 5) v = 5;
                if (m_NumWidth != v)
                {
                    m_NumWidth = v;
                    this.Invalidate();
                }
            }
        }

        private int m_ClearWidth = 10;
        public int ClearWidth
        {
            get { return m_ClearWidth; }
            set
            {
                int v = value;
                if (v < 5) v = 5;
                if (m_ClearWidth!=v)
                {
                    m_ClearWidth = v;
                    this.Invalidate();
                }
            }
        }

        private bool m_IsEdit = true;
        public bool IsEdit 
        {
            get { return m_IsEdit; }
            set
            {
                if(m_IsEdit!=value)
                {
                    m_IsEdit = value;
                    this.Invalidate();
                }
            }
        }
        private ISPUSHED m_IsPushed = ISPUSHED.None;

        private enum ISPUSHED
        {
            None=0,
            Draw,
            UP,
            Down
        }
        private int m_TagetKeta = 0;
        private WizFCState m_state = null;
        public WizFCState WizFCState
        {
            get { return m_state; }
            set
            {
                m_state = value;
                if(m_state!=null)
                {
                    m_state.ValueChanged += M_state_ValueChanged;
                    m_state.LoadFileFinished += M_state_ValueChanged;
                    m_state.CurrentCharChanged += M_state_CurrentCharChanged;
                }
                GetInfo();
            }
        }

        private void M_state_CurrentCharChanged(object sender, CurrentCharEventArgs e)
        {
            GetInfo();
            this.Invalidate();
        }

        private void M_state_ValueChanged(object sender, EventArgs e)
        {
            GetInfo();
            this.Invalidate();
        }
        private void GetInfo()
        {
            if (m_state == null) return;
            switch (m_Mode)
            {
                case WizLongEditMode.Gold:
                    SetValue((ulong)m_state.CharGold);
                    break;
                case WizLongEditMode.Exp:
                    SetValue((ulong)m_state.CharExp);
                    break;
                case WizLongEditMode.HP:
                    SetValue((ulong)m_state.CharHP);
                    break;
                case WizLongEditMode.HPMax:
                    SetValue((ulong)m_state.CharHPMax);
                    break;
            }

        }
        private void SetInfo()
        {
            if (m_state == null) return;
            if (m_IsEdit == false) return;
            switch (m_Mode)
            {
                case WizLongEditMode.Gold:
                    m_state.CharGold = (long)m_Value;
                    break;
                case WizLongEditMode.Exp:
                    m_state.CharExp = (long)m_Value;
                    break;
                case WizLongEditMode.HP:
                    m_state.CharHP = (ushort)m_Value;
                    break;
                case WizLongEditMode.HPMax:
                    m_state.CharHPMax = (ushort)m_Value;
                    break;
            }

        }
        // ********************************************************************
        public WizLongEdit()
        {
            this.SetStyle(
             ControlStyles.DoubleBuffer |
             ControlStyles.UserPaint |
             ControlStyles.AllPaintingInWmPaint,
             true);

            this.BackColor = Color.Black;
            this.ForeColor = Color.White;

            this.TextChanged += WizLongEdit_TextChanged;
        }
        // ********************************************************************
        private void WizLongEdit_TextChanged(object sender, EventArgs e)
        {
            this.Invalidate();
        }
        // ********************************************************************
        protected override void OnPaint(PaintEventArgs e)
        {
            //base.OnPaint(e);
            SolidBrush sb = new SolidBrush(this.BackColor);
            StringFormat sf = new StringFormat();
            sf.Alignment = StringAlignment.Near;
            sf.LineAlignment = StringAlignment.Center;
            try
            {
                Graphics g = e.Graphics;
                Rectangle rct = new Rectangle(0, 0, this.Width, this.Height);
                g.FillRectangle(sb, rct);

                int h = this.Height - m_ArrowHeight * 2;
                if (this.Text != "")
                {
                    sb.Color = this.ForeColor;
                    rct = new Rectangle(0, m_ArrowHeight, this.Width, h);
                    g.DrawString(this.Text, this.Font, sb, rct, sf);
                }
                //数字の表示
                sf.Alignment = StringAlignment.Center;
                rct = new Rectangle(this.Width - m_NumWidth- m_ClearWidth, m_ArrowHeight, m_NumWidth, h);
                if (m_IsPushed==ISPUSHED.None)
                {
                    string s = m_Value.ToString();
                    int ln = s.Length;
                    for (int i = 0; i < ln; i++)
                    {
                        g.DrawString(s[ln - i - 1].ToString(), this.Font, sb, rct, sf);
                        rct.Location = new Point(rct.X - m_NumWidth, rct.Y);
                    }
                }
                else
                {
                    ulong vv = m_Value;
                    for (int i = 0; i < m_NumKeta; i++)
                    {
                        long vv2 = (long)(vv % 10);
                        g.DrawString(vv2.ToString() , this.Font, sb, rct, sf);
                        rct.Location = new Point(rct.X - m_NumWidth, rct.Y);
                        vv /= 10;
                    }
                    rct = new Rectangle(this.Width - m_ClearWidth + 2, m_ArrowHeight, m_ClearWidth-2, h);
                   
                    g.DrawString("C", this.Font, sb, rct, sf);

                }

                if (IsEdit)
                {
                    if ( (m_TagetKeta >= 0)&& (m_TagetKeta < m_NumKeta))
                    {
                        sb.Color = this.ForeColor;
                        int l = this.Width - m_NumWidth * (m_NumKeta - m_TagetKeta) - m_ClearWidth;
                        int h0 = m_ArrowHeight;
                        int h1 = this.Height - m_ArrowHeight;
                        Point[] UpA = new Point[]
                        {
                            new Point(l,h0),
                            new Point(l+ m_NumWidth/2,0),
                            new Point(l+m_NumWidth,h0)
                        };
                        Point[] DownA = new Point[]
                        {
                            new Point(l,h1),
                            new Point(l+ m_NumWidth/2,this.Height),
                            new Point(l+m_NumWidth,h1)
                        };
                        switch (m_IsPushed)
                        {
                            case ISPUSHED.UP:
                                rct = new Rectangle(l, 0, m_NumWidth, m_ArrowHeight+1);
                                g.FillRectangle(sb, rct);
                                g.FillPolygon(sb, DownA);
                                sb.Color = this.BackColor;
                                g.FillPolygon(sb, UpA);
                                break;
                            case ISPUSHED.Down:
                                rct = new Rectangle(l, h1-1, m_NumWidth, m_ArrowHeight+1);
                                g.FillRectangle(sb, rct);
                                g.FillPolygon(sb, UpA);
                                sb.Color = this.BackColor;
                                g.FillPolygon(sb, DownA);
                                break;
                            case ISPUSHED.Draw:
                                g.FillPolygon(sb, UpA);
                                g.FillPolygon(sb, DownA);
                                break;
                        }
                    }
                }
            }
            finally
            {
                sb.Dispose();
                sf.Dispose();
                
            }
        }
        protected override void OnMouseEnter(EventArgs e)
        {
            base.OnMouseEnter(e);
            if (m_IsEdit)
            {
                m_IsPushed = ISPUSHED.Draw;
                m_TagetKeta = -1;
                this.Invalidate();
            }
        }
        protected override void OnMouseLeave(EventArgs e)
        {
            base.OnMouseLeave(e);
            if (m_IsEdit)
            {
                m_TagetKeta = -1;
                m_IsPushed = ISPUSHED.None;
                this.Invalidate();
            }
        }

        protected override void OnMouseMove(MouseEventArgs e)
        {
            base.OnMouseMove(e);
            if (m_IsEdit)
            {
                if (m_IsPushed== ISPUSHED.Draw)
                {
                    if ((m_IsPushed != ISPUSHED.UP) && (m_IsPushed != ISPUSHED.Down))
                    {
                        m_TagetKeta = ((e.X - (this.Width - m_NumWidth * m_NumKeta - m_ClearWidth)) / m_NumWidth);
                        this.Invalidate();
                    }
                }
            }
        }
        protected override void OnMouseDown(MouseEventArgs e)
        {
            base.OnMouseDown(e);
            if (m_IsEdit)
            {
                if (m_TagetKeta >= m_NumKeta)
                {
                    m_Value = 0;
                    this.Invalidate();
                }
                else if (m_TagetKeta >= 0)
                {
                    if (e.Y < this.Height / 2)
                    {
                        m_IsPushed = ISPUSHED.UP;
                    }
                    else
                    {
                        m_IsPushed = ISPUSHED.Down;

                    }
                    ValueKetaSet();
                    this.Invalidate();
                }

            }
        }
        protected override void OnMouseUp(MouseEventArgs e)
        {
            base.OnMouseUp(e);
            if (m_IsEdit)
            {
                m_IsPushed = ISPUSHED.Draw;
                this.Invalidate();
            }
        }
   
        private void ValueKetaSet()
        {
            if ((m_TagetKeta < 0)||(m_TagetKeta>=m_NumKeta)) return;

            int[] tbl = new int[m_NumKeta];

            ulong v = m_Value;
            for ( int i=0;i< m_NumKeta; i++)
            {
                tbl[i] = (int)(v % 10);
                v /= 10;
            }
            int idx = m_NumKeta - m_TagetKeta - 1;
            if(m_IsPushed== ISPUSHED.UP)
            {
                tbl[idx] += 1;
                if(tbl[idx]>9)
                {
                    if (idx == m_NumKeta - 1)
                    {
                        for (int i = 0; i < m_NumKeta; i++)
                        {
                            tbl[i] = 9;
                        }
                    }
                    else
                    {
                        for (int i = 0; i < idx; i++) tbl[i] = 0;
                    }
                }
            }
            else if (m_IsPushed == ISPUSHED.Down)
            {
                tbl[idx] -= 1;
                if (tbl[idx] < 0) tbl[idx] = 0;

            }
            v = 0;
            for (int i = m_NumKeta-1; i >=0 ; i--)
            {
                v = v * 10 + (ulong)tbl[i];
            }

            if (SetValue(v))
            {
                OnValueChanged(new EventArgs());
                this.Invalidate();
            }
        }


    }
}

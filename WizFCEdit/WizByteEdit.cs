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
    public enum WizByteEditMode
    {
        Age = 0,
        AC,
        Strength,
        IQ,
        Piety,
        Vitality,
        Agility,
        Luck,
        Week
    }
    public class WizByteEdit :Control
    {


        public event EventHandler ValueChanged;
        protected virtual void OnValueChanged(EventArgs e) { ValueChanged?.Invoke(this, e); }

        private WizByteEditMode m_Mode = WizByteEditMode.Age;
        public WizByteEditMode Mode
        {
            get { return m_Mode; }
            set
            {
                if (m_Mode !=value)
                {
                    m_Mode = value;
                    GetInfo();
                    this.Invalidate();
                }
            }
        }

        private bool m_IsUnsigned = true;
        private bool IsUnsigned
        {
            get { return m_IsUnsigned; }
            set
            {
                if (m_IsUnsigned != value)
                {
                    m_IsUnsigned = value;
                    if (m_IsUnsigned == true)
                    {
                        if (m_Value < 0) m_Value = 0;
                    }
                    else
                    {
                        if (m_Value > 128) m_Value = 128;
                    }
                    this.Invalidate();
                }
            }

        }
        private int m_Value = 0;
        public int Value
        {
            get { return m_Value; }
            set
            {
                if(SetValue(value))
                {
                    OnValueChanged(new EventArgs());
                }
            }
        }
        public bool SetValue(int v)
        {
            bool ret = false;
            if (m_IsUnsigned == true)
            {
                if (v < 0) v = 0;
                else if (v > 0xFF) v = 0xFF;
            }
            else
            {
                if (v < -127) v = -127;
                else if (v > 128) v = 128;
            }
            if (m_Value != v)
            {
                m_Value = v;
                SetInfo();
                ret = true;
            }
            return ret;
        }
        public void ValuePlus()
        {
            if (SetValue(m_Value + 1))
            {
                OnValueChanged(new EventArgs());
            }

        }
        public void ValueMinus()
        {
            if (SetValue(m_Value - 1))
            {
                OnValueChanged(new EventArgs());
            }
        }

        private int m_ArrowWidth = 10;
        public int ArrowWidth
        {
            get { return m_ArrowWidth; }
            set
            {
                int v = value;
                if( m_ArrowWidth!=v)
                {
                    m_ArrowWidth = v;
                    this.Invalidate();
                }
            }
        }

        private int m_CaptionWidth = 130;
        public int CaptionWidth
        {
            get { return m_CaptionWidth; }
            set
            {
                int v = value;
                if (m_CaptionWidth != v)
                {
                    m_CaptionWidth = v;
                    this.Invalidate();
                }
            }
        }
        private bool m_CaptionLeft = true;
        public bool CaptionLeft
        {
            get { return m_CaptionLeft; }
            set
            {
                if(m_CaptionLeft!=value)
                {
                    m_CaptionLeft = value;
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
                case WizByteEditMode.Age:
                    IsUnsigned = false;
                    SetValue((int)m_state.CharAge);
                    break;
                case WizByteEditMode.AC:
                    IsUnsigned = false;
                    SetValue((int)m_state.CharAC);
                    break;
                case WizByteEditMode.Strength:
                    IsUnsigned = true;
                    SetValue((int)m_state.CharStrength);
                    break;
                case WizByteEditMode.IQ:
                    IsUnsigned = true;
                    SetValue((int)m_state.CharIQ);
                    break;
                case WizByteEditMode.Piety:
                    IsUnsigned = true;
                    SetValue((int)m_state.CharPiety);
                    break;
                case WizByteEditMode.Vitality:
                    IsUnsigned = true;
                    SetValue((int)m_state.CharVitarity);
                    break;
                case WizByteEditMode.Agility:
                    IsUnsigned = true;
                    SetValue((int)m_state.CharAgility);
                    break;
                case WizByteEditMode.Luck:
                    IsUnsigned = true;
                    SetValue((int)m_state.CharLuck);
                    break;
                case WizByteEditMode.Week:
                    IsUnsigned = true;
                    SetValue((int)m_state.CharWeek);
                    break;
            }

        }
        private void SetInfo()
        {
            if (m_state == null) return;
            if (m_IsEdit == false) return;
            switch (m_Mode)
            {
                case WizByteEditMode.Age:
                    m_state.CharAge = (sbyte)m_Value;
                    break;
                case WizByteEditMode.AC:
                    m_state.CharAC = (sbyte)m_Value;
                    break;
                case WizByteEditMode.Strength:
                    m_state.CharStrength = (byte)m_Value;
                    break;
                case WizByteEditMode.IQ:
                    m_state.CharStrength = (byte)m_Value;
                    break;
                case WizByteEditMode.Piety:
                    m_state.CharPiety = (byte)m_Value;
                    break;
                case WizByteEditMode.Vitality:
                    m_state.CharVitarity = (byte)m_Value;
                    break;
                case WizByteEditMode.Agility:
                    m_state.CharAgility = (byte)m_Value;
                    break;
                case WizByteEditMode.Luck:
                    m_state.CharLuck = (byte)m_Value;
                    break;
                case WizByteEditMode.Week:
                    m_state.CharWeek = (byte)m_Value;
                    break;
            }

        }
        // ********************************************************************
        public WizByteEdit()
        {
            this.SetStyle(
             ControlStyles.DoubleBuffer |
             ControlStyles.UserPaint |
             ControlStyles.AllPaintingInWmPaint, //|
             //ControlStyles.Selectable|
             //ControlStyles.UserMouse,
             true);

            this.BackColor = Color.Black;
            this.ForeColor = Color.White;

            this.TextChanged += WizByteEdit_TextChanged;
        }
        // ********************************************************************
        private void WizByteEdit_TextChanged(object sender, EventArgs e)
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

                if (this.Text != "")
                {
                    sb.Color = this.ForeColor;
                    rct = new Rectangle(0, 0, m_CaptionWidth, this.Height);
                    if (m_CaptionLeft)
                        sf.Alignment = StringAlignment.Near;
                    else
                        sf.Alignment = StringAlignment.Far;
                    g.DrawString(this.Text, this.Font, sb, rct, sf);
                }
                //数字の表示
                sf.Alignment = StringAlignment.Far;
                rct = new Rectangle(0, 0, this.Width-m_ArrowWidth, this.Height);
                g.DrawString(m_Value.ToString(), this.Font, sb, rct, sf);


                if (m_IsEdit)
                {
                    sb.Color = this.ForeColor;
                    int h = this.Height / 2;
                    int w = m_ArrowWidth - 1;
                    int l = this.Width - m_ArrowWidth + 1;
                    Point[] UpA = new Point[]
                    {
                    new Point(l,h-1),
                    new Point(l+w/2,0),
                    new Point(l+w,h-1)
                    };
                    Point[] DownA = new Point[]
                    {
                    new Point(l,h+1),
                    new Point(l+w/2,this.Height-1),
                    new Point(l+w,h+1)
                    };
                    switch (m_IsPushed)
                    {
                        case ISPUSHED.UP:
                            rct = new Rectangle(l, 0, m_ArrowWidth, this.Height / 2);
                            g.FillRectangle(sb, rct);
                            g.FillPolygon(sb, DownA);
                            sb.Color = this.BackColor;
                            g.FillPolygon(sb, UpA);
                            break;
                        case ISPUSHED.Down:
                            rct = new Rectangle(l, h, m_ArrowWidth, this.Height / 2);
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
            finally
            {
                sb.Dispose();
            }
        }
        protected override void OnMouseDown(MouseEventArgs e)
        {
            base.OnMouseDown(e);
            if (m_IsEdit)
            {
                int x = e.X - (this.Width - m_ArrowWidth);
                if (x > 0)
                {
                    if (e.Y < this.Height / 2)
                    {
                        m_IsPushed = ISPUSHED.UP;
                        ValuePlus();
                    }
                    else
                    {
                        m_IsPushed = ISPUSHED.Down;
                        ValueMinus();
                    }
                }

                this.Invalidate();
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
   
        protected override void OnMouseEnter(EventArgs e)
        {
            base.OnMouseEnter(e);
            if (m_IsEdit)
            {
                m_IsPushed = ISPUSHED.Draw;
                this.Invalidate();
            }
        }
        protected override void OnMouseLeave(EventArgs e)
        {
            base.OnMouseLeave(e);
            if (m_IsEdit)
            {
                m_IsPushed = ISPUSHED.None;
                this.Invalidate();
            }
        }

    }
}

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
    public class WizMPEdit :Control
    {
   
        public event EventHandler ValueChanged;
        protected virtual void OnValueChanged(EventArgs e) { ValueChanged?.Invoke(this, e); }



        private int m_Value = 0;
        public int Value
        {
            get { return m_Value; }
            set
            {
                int v = value;
                if (v < 0) v = 0;
                else if (v > 0x0F) v = 0x0F;
                if (m_Value != v)
                {
                    m_Value = v;
                    OnValueChanged(new EventArgs());
                    this.Invalidate();
                }
            }
        }
        public void ValuePlus()
        {
            Value = m_Value + 1;

        }
        public void ValueMinus()
        {
            Value = m_Value - 1;
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
        
        // ********************************************************************
        public WizMPEdit()
        {
            this.SetStyle(
             ControlStyles.DoubleBuffer |
             ControlStyles.UserPaint |
             ControlStyles.AllPaintingInWmPaint, //|
             true);

            this.BackColor = Color.Black;
            this.ForeColor = Color.White;
            this.Size = new Size(22, 20);

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

                //数字の表示
                sf.Alignment = StringAlignment.Far;
                sb.Color = this.ForeColor;
                rct = new Rectangle(0, 0, this.Width-m_ArrowWidth, this.Height);
                g.DrawString(String.Format("{0:X1}",m_Value), this.Font, sb, rct, sf);


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

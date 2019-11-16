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
    public enum BTN
    {
        BTN0=0,
        BTN1,
        BTN2,
        BTN3,
        BTN4,
        BTN5,
        BTN6,
        BTN7,
        BTN8,
        BTN9,
        BTN_CLR,
        BTN_BS,
        BTN_PLS,
        BTN_MNS,
        BTN_CANCEL,
        BTN_ENTER,
        BTN_COUNT
    }
    public class MyButton : Button
    {
        public MyButton() : base()
        {
            this.SetStyle(ControlStyles.Selectable, false);
            this.BackColor = this.BackColor;
            this.ForeColor = this.ForeColor;
            this.FlatStyle = FlatStyle.Flat;
        }
    }
    public class WizValueEditor :WizBoxControl
    {
        public event EventHandler OKClicked;
        protected virtual void OnOKClicked(EventArgs e) { OKClicked?.Invoke(this, e); }
        public event EventHandler CancelClicked;
        protected virtual void OnCancelClicked(EventArgs e) { CancelClicked?.Invoke(this, e); }

        private long m_Value = 0;
        public long Value
        {
            get { return m_Value; }
            set
            {
                long v = value;
                if (v < m_ValueMin) v = m_ValueMin;
                else if (v > m_ValueMax) v = m_ValueMax;
                m_Value = m_ValueOrg = v;

                m_OrgValue.Text = m_ValueOrg.ToString();
                m_EditValue.Text = m_Value.ToString();

            }
        }

        private long m_ValueOrg = 0;
        private long m_ValueMin = 0;
        public long ValueMin
        {
            get { return m_ValueMin; }
            set
            {
                m_ValueMin = value;
                if (m_Value < m_ValueMin) m_Value = m_ValueMin;
                if (m_ValueOrg < m_ValueMin) m_ValueOrg = m_ValueMin;
                m_OrgValue.Text = m_ValueOrg.ToString();
                m_EditValue.Text = m_Value.ToString();
            }
        }
        private long m_ValueMax = 0xFFFFFFFFFFFF;
        public long ValueMax
        {
            get { return m_ValueMax; }
            set
            {
                m_ValueMax = value;
                if (m_Value > m_ValueMax) m_Value = m_ValueMax;
                if (m_ValueOrg > m_ValueMax) m_ValueOrg = m_ValueMax;
                m_OrgValue.Text = m_ValueOrg.ToString();
                m_EditValue.Text = m_Value.ToString();
            }
        }
        public string Caption
        {
            get { return m_Caption.Text; }
            set { m_Caption.Text = value; }
        }

        private Label m_OrgValue = new Label();
        private Label m_EditValue = new Label();

        private Label m_Caption = new Label();

        private MyButton[] m_Btns = new MyButton[(int)BTN.BTN_COUNT];
        //-------------------------------------------------------
        public WizValueEditor()
        {
            this.BackColor = Color.Black;
            this.ForeColor = Color.White;

            this.Size = new Size(250, 310);
            this.MinimumSize = this.Size;
            this.MaximumSize = this.Size;

            SetupLabel(m_Caption);
            m_Caption.RightToLeft = RightToLeft.No;
            m_Caption.Text = "Untitled";
            SetupLabel(m_OrgValue);
            SetupLabel(m_EditValue);

            for ( int i= (int)BTN.BTN0;i<(int)BTN.BTN_COUNT;i++)
            {
                m_Btns[i] = NewButton((BTN)i);
            }


            SizeChk();




            this.Controls.Add(m_Caption);
            this.Controls.Add(m_OrgValue);
            this.Controls.Add(m_EditValue);

            for (int i = (int)BTN.BTN0; i < (int)BTN.BTN_COUNT; i++)
            {
                this.Controls.Add(m_Btns[i]);
            }

        }
        //-------------------------------------------------------
        private void SizeChk()
        {
            m_Caption.Location = new Point(20, 20);
            m_Caption.Size = new Size(this.Width - 40, 20);

            m_OrgValue.Location = new Point(20, 45);
            m_OrgValue.Size = new Size(this.Width-40, 20);

            m_EditValue.Location = new Point(20, 70);
            m_EditValue.Size = new Size(this.Width - 40, 20);

        }

        //-------------------------------------------------------
        private void SetupLabel(Label lb)
        {
            lb.BackColor = this.BackColor;
            lb.ForeColor = this.ForeColor;
            lb.Font = new Font(this.Font.FontFamily, 14,FontStyle.Bold);
            lb.AutoSize = false;
            lb.RightToLeft = RightToLeft.Yes;
            lb.Text = "0";
        }
        //-------------------------------------------------------
        private MyButton NewButton(BTN v)
        {
            MyButton ret = new MyButton();
            ret.Tag = v;

            int x = 30;
            int y = 105;
            int xa = 40;
            int ya = 40;
            int x2 = x + 140;
            int x3 = x + 110;

            if (v <= BTN.BTN9)
            {
                ret.Size = new Size(30, 30);
                ret.Text = ((int)v).ToString();
                switch(v)
                {
                    case BTN.BTN7:
                        ret.Location = new Point(x, y);
                        break;
                    case BTN.BTN8:
                        ret.Location = new Point(x+xa, y);
                        break;
                    case BTN.BTN9:
                        ret.Location = new Point(x+xa*2, y);
                        break;
                    case BTN.BTN4:
                        ret.Location = new Point(x, y+ya);
                        break;
                    case BTN.BTN5:
                        ret.Location = new Point(x + xa, y + ya);
                        break;
                    case BTN.BTN6:
                        ret.Location = new Point(x + xa * 2, y + ya);
                        break;
                    case BTN.BTN1:
                        ret.Location = new Point(x, y + ya*2);
                        break;
                    case BTN.BTN2:
                        ret.Location = new Point(x + xa, y + ya * 2);
                        break;
                    case BTN.BTN3:
                        ret.Location = new Point(x + xa * 2, y + ya * 2);
                        break;
                    case BTN.BTN0:
                        ret.Location = new Point(x, y + ya * 3);
                        break;
                }
            }
            else if (v == BTN.BTN_CLR)
            {
                ret.Size = new Size(50, 30);
                ret.Location = new Point(x2, y);
                ret.Text = "CLR";
            }
            else if (v == BTN.BTN_BS)
            {
                ret.Size = new Size(50, 30);
                ret.Location = new Point(x2, y + ya);
                ret.Text = "BS";
            }
            else if (v == BTN.BTN_PLS)
            {
                ret.Size = new Size(50, 30);
                ret.Location = new Point(x2, y + ya * 2);
                ret.Text = "++";
            }
            else if (v == BTN.BTN_MNS)
            {
                ret.Size = new Size(50, 30);
                ret.Location = new Point(x2, y + ya * 3);
                ret.Text = "--";
            }
            else if (v == BTN.BTN_CANCEL)
            {
                ret.Size = new Size(80, 30);
                ret.Location = new Point(x, y + ya * 4);
                ret.Text = "CANCEL";
            }
            else if (v == BTN.BTN_ENTER)
            {
                ret.Size = new Size(80, 30);
                ret.Location = new Point(x3, y + ya * 4);
                ret.Text = "OK";
            }

            ret.BackColor = this.BackColor;
            ret.ForeColor = this.ForeColor;
            ret.FlatStyle = FlatStyle.Flat;

            ret.Click += Ret_Click;
            return ret;
        }
        // ******************************************************
        private void Ret_Click(object sender, EventArgs e)
        {
            Button b = (Button)sender;

            BTN btn = (BTN)b.Tag;
            if((btn>=BTN.BTN0)&&(btn<=BTN.BTN9))
            {
                SetNum((int)btn);
            }
            else if(btn == BTN.BTN_CLR)
            {
                ClrNum();
            }else if(btn == BTN.BTN_BS)
            {
                BSNum();
            }else if(btn == BTN.BTN_PLS)
            {
                PlusNum();
            }
            else if (btn == BTN.BTN_MNS)
            {
                MinusNum();
            }else if (btn == BTN.BTN_ENTER)
            {
                OnOKClicked(new EventArgs());
            }
            else if (btn == BTN.BTN_CANCEL)
            {
                OnCancelClicked(new EventArgs());
            }


        }
        public void SetNum(int v)
        {
            v = v % 10;
            m_Value = m_Value * 10 + v;
            if (m_Value > m_ValueMax) m_Value = m_ValueMax;
            m_EditValue.Text = m_Value.ToString();

        }
        public void ClrNum()
        {
            m_Value = 0;
            if (m_Value < m_ValueMin) m_Value = m_ValueMin;
            m_EditValue.Text = m_Value.ToString();

        }
        public void BSNum()
        {
            m_Value = m_Value/10;
            m_EditValue.Text = m_Value.ToString();

        }
        public void PlusNum()
        {
            m_Value += 1;
            if (m_Value > m_ValueMax) m_Value = m_ValueMax;
            m_EditValue.Text = m_Value.ToString();
        }
        public void MinusNum()
        {
            m_Value -= 1;
            if (m_Value < m_ValueMin) m_Value = m_ValueMin;
            m_EditValue.Text = m_Value.ToString();
        }
        //-------------------------------------------------------
        protected override void OnSizeChanged(EventArgs e)
        {
            SizeChk();
            base.OnSizeChanged(e);
        }
        protected override void OnPreviewKeyDown(PreviewKeyDownEventArgs e)
        {
            base.OnPreviewKeyDown(e);
            Keys k = e.KeyCode;
            KeyExec(k);
        }
        //-------------------------------------------------------
        public void KeyExec(Keys k)
        {
            if ((k >= Keys.NumPad0) && (k <= Keys.NumPad9))
            {
                SetNum((int)k - (int)Keys.NumPad0);
            }
            else if ((k >= Keys.D0) && (k <= Keys.D9))
            {
                SetNum((int)k - (int)Keys.D0);
            }
            else if (k == Keys.Clear)
            {
                ClrNum();
            }
            else if (k == Keys.Back)
            {
                BSNum();
            }
            else if ((k == Keys.Enter) || (k == Keys.Return))
            {
                OnOKClicked(new EventArgs());
            }
            else if (k == Keys.Escape)
            {
                OnCancelClicked(new EventArgs());
            }
        }
        //-------------------------------------------------------
    }
}

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
    public class WizItemList : Control
    {
        public bool IsEditID = true;
        public bool IsEditInd = true;
        public bool IsEditCurse = true;
        public bool IsEditEqu = true;

        public event EventHandler ItemClicked;
        protected virtual void OnItemClicked(EventArgs e) { ItemClicked?.Invoke(this, e); }

        public event EventHandler IndClicked;
        protected virtual void OnIndClicked(EventArgs e) { IndClicked?.Invoke(this, e); }

        public event EventHandler CurseClicked;
        protected virtual void OnCurseClicked(EventArgs e) { CurseClicked?.Invoke(this, e); }

        public event EventHandler EquClicked;
        protected virtual void OnEquClicked(EventArgs e) { EquClicked?.Invoke(this, e); }

        private int m_SelectedIndex = -1;
        public int SelectedIndex
        {
            get { return m_SelectedIndex; }
        }

        public WizItemList()
        {
            this.ForeColor = Color.White;
            this.BackColor = Color.Black;
            this.SetStyle(
             ControlStyles.DoubleBuffer |
             ControlStyles.UserPaint |
             ControlStyles.AllPaintingInWmPaint,
             true);
        }

        WizItem[] m_items = new WizItem[0];
        private bool m_IsDrawFrame = false;
        public bool IsDrawFrame
        {
            get { return m_IsDrawFrame; }
            set { m_IsDrawFrame = value; this.Invalidate(); }
        }
        private int m_LineHeight = 24;
        public int LineHeight
        {
            get { return m_LineHeight; }
            set { m_LineHeight = value; SizeChk();  this.Invalidate(); }
        }
        private int m_StWidth = 18;
        public int StWidth
        {
            get { return m_StWidth; }
            set { m_StWidth = value; this.Invalidate(); }
        }

        // *************************************************************************
        public int ItemID
        {
            get
            {
                int idx = m_SelectedIndex;
                if (idx < 0) idx = 0;
                if (m_items.Length <= 0)
                {
                    return 0;
                }
                else
                {
                    return m_items[idx].ID;
                }
            }
            set
            {
                if (m_SelectedIndex < 0) return;
                if (m_items.Length <= 0) return;
                if (m_SelectedIndex < m_items[0].ItemCount)
                {
                    m_items[m_SelectedIndex].ID = (byte)value;
                }
            }
        }
        // *************************************************************************
        public void SizeChk()
        {
            int h = m_LineHeight * 8;
            int w = this.MinimumSize.Width;
            this.MinimumSize = new Size(w, h);
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
        private void SetItemID(byte v)
        {
            if(m_SelectedIndex>=0)
            {
                if (m_items[m_SelectedIndex].ID!=v)
                {
                    m_items[m_SelectedIndex].ID = v;
                    m_state.SetCharItemFromIndex(m_state.CharCurrent, m_SelectedIndex, m_items[m_SelectedIndex]);
                }
            }
        }
        // *************************************************************************
        private void ChangeItemInd()
        {
            if (m_SelectedIndex >= 0)
            {
                m_items[m_SelectedIndex].Indeterminate = !m_items[m_SelectedIndex].Indeterminate;
                m_state.SetCharItemFromIndex(m_state.CharCurrent, m_SelectedIndex, m_items[m_SelectedIndex]);
            }
        }
        // *************************************************************************
        private void ChangeItemCurse()
        {
            if (m_SelectedIndex >= 0)
            {
                m_items[m_SelectedIndex].Curse = !m_items[m_SelectedIndex].Curse;
                m_state.SetCharItemFromIndex(m_state.CharCurrent, m_SelectedIndex, m_items[m_SelectedIndex]);
            }
        }
        // *************************************************************************
        private void ChangeItemEquipment()
        {
            if (m_SelectedIndex >= 0)
            {
                m_items[m_SelectedIndex].Equipment = !m_items[m_SelectedIndex].Equipment;
                m_state.SetCharItemFromIndex(m_state.CharCurrent, m_SelectedIndex, m_items[m_SelectedIndex]);
            }
        }
        // *************************************************************************
        public void GetInfo()
        {
            if(m_state!=null)
            {
                m_items = m_state.CharItems;
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
                    int y = m_LineHeight;
                    for (int i = 0; i <= 8; i++)
                    {
                        g.DrawLine(pn, 0, y, this.Width, y);
                        y += m_LineHeight;
                    }
                    int x = m_StWidth;
                    for (int i = 0; i < 3; i++)
                    {
                        g.DrawLine(pn, x, 0, x, this.Height);
                        x += m_StWidth;
                    }

                }
                sb.Color = this.ForeColor;
                sf.Alignment = StringAlignment.Near;

                if(m_items.Length>0)
                {
                    int t = m_StWidth * 3;
                    int w = this.Width - t;
                    for ( int i=0;i<m_items.Length;i++)
                    {
                        rct = new Rectangle(t, m_LineHeight*i, w, m_LineHeight);
                        g.DrawString(m_items[i].CaptionText, this.Font, sb, rct, sf);

                        rct = new Rectangle(0, m_LineHeight * i, m_StWidth, m_StWidth);
                        if (m_items[i].Indeterminate==true)
                        {
                            g.DrawString("未", this.Font, sb, rct, sf);
                        }
                        rct = new Rectangle(m_StWidth, m_LineHeight * i, m_StWidth, m_StWidth);
                        if (m_items[i].Curse == true)
                        {
                            g.DrawString("呪", this.Font, sb, rct, sf);
                        }
                        rct = new Rectangle(m_StWidth*2, m_LineHeight * i, m_StWidth, m_StWidth);
                        if (m_items[i].Equipment == true)
                        {
                            g.DrawString("*", this.Font, sb, rct, sf);
                        }
                    }
                }
            }
            finally
            {
                sb.Dispose();
            }

        }
        // *****************************************************************************
        protected override void OnMouseDown(MouseEventArgs e)
        {
            m_SelectedIndex = -1;
            if (m_items.Length > 0)
            {
                int y = e.Y / m_LineHeight;
                if (y < m_items.Length)
                {
                    m_SelectedIndex = y;
                    if (m_SelectedIndex>=0)
                    {
                        int x = e.X / m_StWidth;
                        if (x >= 3)
                        {
                            if(IsEditID)
                            {
                                ShowItemSelect();
                            }
                        }
                        else if(x==0)
                        {
                            if (IsEditInd)
                            {
                                ChangeItemInd();
                            }
                        }
                        else if (x == 1)
                        {
                            if (IsEditCurse)
                            {
                                ChangeItemCurse();
                            }
                        }
                        else if (x == 2)
                        {
                            if (IsEditEqu)
                            {
                                ChangeItemEquipment();
                            }
                        }

                    }
                }



            }
            base.OnMouseDown(e);
        }
        // *****************************************************************************
        public Point ItemLocation
        {
            get
            {
                return new Point(m_StWidth * 3 +this.Left, this.Top);
            }
        }
        // *****************************************************************************
        public Size ItemSize
        {
            get
            {
                return new Size(this.Width , this.Height);
            }
        }
        // *****************************************************************************
        public void ShowItemSelect()
        {
            if (m_state == null) return;
            if (m_items.Length <= 0) return;
            if (IsEditID == false) return;
            if((m_SelectedIndex>=0)&&(m_SelectedIndex < m_items.Length))
            {
                int cp = m_StWidth * 3;
                WizItemSelect ise = new WizItemSelect();
                ise.Name = "A";
                ise.Items.AddRange(m_items[m_SelectedIndex].ItemNames);
                ise.Location = new Point(this.Left + cp, this.Top + m_LineHeight * m_SelectedIndex);
                ise.Size = new Size(this.Width - cp, m_LineHeight);
                ise.ItemID = m_items[m_SelectedIndex].ID;
                ise.IsListMode = true;
                ise.VisibleChanged += Ise_VisibleChanged;
                this.Parent.Controls.Add(ise);
                ise.BringToFront();
                ise.DroppedDown = true;
                ise.Visible = true;
            }
        }

        private void Ise_VisibleChanged(object sender, EventArgs e)
        {
            WizItemSelect ise = (WizItemSelect)sender;
            if (ise.ItemID >= 0)
            {
                SetItemID((byte)ise.ItemID);
            }
            WizItemSelect.MeDelete(this.Parent.Controls, ise);
        }
        // *****************************************************************************
    }
}

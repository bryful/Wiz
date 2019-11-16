using System;
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
    public enum WizFormMode
    {
        NONE = -1,
        CHARLIST = 0,
        ALG,
        CLASS,
        RACE,
        GOLD,
        COUNT
    }

    public partial class WizForm : Form
    {
        private WizFormMode m_Mode = WizFormMode.CHARLIST;
        private WizBox wb = new WizBox();
        private WizBox wbCap = new WizBox();

        #region Frames
        public int LeftMgn
        {
            get { return wb.LeftMargin; }
            set { wb.LeftMargin = value; this.Invalidate(); }
        }
        public int RightMgn
        {
            get { return wb.RightMargin; }
            set { wb.RightMargin = value; this.Invalidate(); }
        }
        public int BottomMgn
        {
            get { return wb.BottomMargin; }
            set { wb.BottomMargin = value; this.Invalidate(); }
        }
        public int TopMgn
        {
            get { return wb.TopMargin; }
            set { wb.TopMargin = value; CapSize(); this.Invalidate(); }
        }
        public int CaptionWidth
        {
            get { return wbCap.Width; }
            set { wbCap.Width = value; CapSize(); this.Invalidate(); }
        }
        public int CaptionHeight
        {
            get { return wbCap.Height; }
            set { wbCap.Height = value; CapSize(); this.Invalidate(); }
        }

        private string m_Caption = "Wizardry(FC) State File Editor";
        public string Caption
        {
            get { return m_Caption; }
            set { m_Caption = value; this.Invalidate(); }
        }
        #endregion

        private WizNesState m_state = null;
        public WizNesState WizNesState
        {
            get { return m_state; }
            set { m_state = value; }
        }
        private WizCharList m_CharList = null;
        public WizCharList WizCharList
        {
            get { return m_CharList; }
            set { m_CharList = value; }
        }
        private WizValueEditor m_ValueEditor = null;
        public WizValueEditor WizValueEditor
        {
            get { return m_ValueEditor; }
            set
            {
                m_ValueEditor = value;
                if(m_ValueEditor!=null)
                {
                    m_ValueEditor.OKClicked += M_ValueEditor_OKClicked;
                    m_ValueEditor.CancelClicked += M_ValueEditor_CancelClicked; ;
                }
            }
        }

        private void M_ValueEditor_CancelClicked(object sender, EventArgs e)
        {
            ValueEditorShow(false);
        }

        private void M_ValueEditor_OKClicked(object sender, EventArgs e)
        {
            ValueEditorOK();
        }


        #region ListBox
        private ListBox m_ListBox = null;
        public ListBox ListBox
        {
            get { return m_ListBox;}
            set
            {
                m_ListBox = value;
                if(m_ListBox!=null)
                {
                    //ListBoxShow(false);
                    m_ListBox.MouseDoubleClick += M_ListBox_MouseDoubleClick;
                    m_ListBox.KeyDown += M_ListBox_KeyDown;

                }
            }
        }
        private void ListBoxShow(bool b)
        {
            if (m_ListBox == null) return;
            m_ListBox.Enabled = b;
            m_ListBox.Visible = b;
            if(b==false)
            {
                SetMode(WizFormMode.CHARLIST);
            }
            else
            {
                m_ListBox.Focus();
            }

        }
        private void ValueEditorShow(bool b)
        {
            if (m_ValueEditor == null) return;
            m_ValueEditor.Location = new Point(330, 160);
            m_ValueEditor.Enabled = b;
            m_ValueEditor.Visible = b;
            if (b == false)
            {
                SetMode(WizFormMode.CHARLIST);
            }

        }
        private void M_ListBox_KeyDown(object sender, KeyEventArgs e)
        {
            if ((e.KeyData==Keys.Return)|| (e.KeyData == Keys.Enter))
            {
                ListBoxSelected();
            }
            else if (e.KeyData == Keys.Escape)
            {
                ListBoxShow(false);
            }
        }

        private void M_ListBox_MouseDoubleClick(object sender, MouseEventArgs e)
        {
            ListBoxSelected();
        }
        #endregion

        #region GOLD
        private WizParam m_WizGOLD = null;
        public WizParam WizGold
        {
            get { return m_WizGOLD; }
            set
            {
                m_WizGOLD = value;
                if(m_WizGOLD!=null)
                {
                    m_WizGOLD.MouseDown += M_WizGOLD_MouseDown;
                }
            }
        }

        private void M_WizGOLD_MouseDown(object sender, MouseEventArgs e)
        {
            EditGold();
        }
        #endregion

        #region CharCaption
        // **************************************************************************************
        private WizCharCaption m_CharCaption = null;
        public WizCharCaption WizCharCaption
        {
            get { return m_CharCaption; }
            set
            {
                m_CharCaption = value;
                if(m_CharCaption!=null)
                {
                    m_CharCaption.AlgClicked += M_CharCaption_AlgClicked;
                    m_CharCaption.ClassClicked += M_CharCaption_ClassClicked;
                    m_CharCaption.RaceClicked += M_CharCaption_RaceClicked;
                }
            }
        }
        // **************************************************************************************
        private void M_CharCaption_RaceClicked(object sender, EventArgs e)
        {
            EditRace();
        }
        private void M_CharCaption_ClassClicked(object sender, EventArgs e)
        {
            EditClass();
        }

        private void M_CharCaption_AlgClicked(object sender, EventArgs e)
        {
            EditAlg();
        }
        // **************************************************************************************
        public void EditAlg()
        {
            if ((m_state == null) || (m_ListBox == null) || (m_CharCaption == null)) return;
            m_ListBox.Location = m_CharCaption.AlgPoint;
            m_ListBox.Size = new Size(60, 50);
            m_ListBox.Items.Clear();
            m_ListBox.Items.Add("Good");
            m_ListBox.Items.Add("Neut");
            m_ListBox.Items.Add("Evil");
            m_ListBox.SelectedIndex = (int)m_state.CharAlg;
            SetMode(WizFormMode.ALG);
            ListBoxShow(true);
        }
        // **************************************************************************************
        public void EditClass()
        {
            if ((m_state == null) || (m_ListBox == null) || (m_CharCaption == null)) return;
            m_ListBox.Location = m_CharCaption.ClassPoint;
            m_ListBox.Size = new Size(40, 150);
            m_ListBox.Items.Clear();
            //0:FIG, 1:MAG, 2:PRI, 3:THI, 4:BIS, 5:SAM, 6:LOR, 7:NIN
            m_ListBox.Items.Add("FIG");
            m_ListBox.Items.Add("MAG");
            m_ListBox.Items.Add("PRI");
            m_ListBox.Items.Add("THI");
            m_ListBox.Items.Add("BIS");
            m_ListBox.Items.Add("SAM");
            m_ListBox.Items.Add("LOR");
            m_ListBox.Items.Add("NIN");
            m_ListBox.SelectedIndex = (int)m_state.CharClass;
            SetMode(WizFormMode.CLASS);
            ListBoxShow(true);
        }
        // **************************************************************************************
        public void EditRace()
        {
            if ((m_state == null) || (m_ListBox == null) || (m_CharCaption == null)) return;
            m_ListBox.Location = m_CharCaption.RacePoint;
            m_ListBox.Size = new Size(50, 100);
            m_ListBox.Items.Clear();
            m_ListBox.Items.Add("HUMAN");
            m_ListBox.Items.Add("ELF");
            m_ListBox.Items.Add("DWARF");
            m_ListBox.Items.Add("GNOME");
            m_ListBox.Items.Add("HOBIT");
            m_ListBox.SelectedIndex = (int)m_state.CharRace;
            SetMode(WizFormMode.RACE);
            ListBoxShow(true);
        }
        // **************************************************************************************
        public void EditGold()
        {
            if ((m_state == null) || (m_WizGOLD == null) || (m_ValueEditor == null)) return;

            m_ValueEditor.Caption = "GOLD";
            m_ValueEditor.Value = m_state.CharGold;

            SetMode(WizFormMode.GOLD);
            ValueEditorShow(true);
        }
        // **************************************************************************************
        #endregion
        private void ValueEditorOK()
        {
            if ((m_state == null) || (m_ValueEditor == null) ) return;
            switch (m_Mode)
            {
                case WizFormMode.GOLD:
                    break;
            }
            ValueEditorShow(false);
        }
        private void ListBoxSelected()
        {
            if ((m_state == null) || (m_ListBox == null)||(m_CharCaption==null)) return;
            switch (m_Mode)
            {
                case WizFormMode.ALG:
                    WIZALG a = (WIZALG)m_ListBox.SelectedIndex;
                    m_state.CharAlg = a;
                    m_CharCaption.Invalidate();
                    break;
                case WizFormMode.CLASS:
                    WIZCLASS c = (WIZCLASS)m_ListBox.SelectedIndex;
                    m_state.CharClass = c;
                    m_CharCaption.Invalidate();
                    break;
                case WizFormMode.RACE:
                    WIZRACE r = (WIZRACE)m_ListBox.SelectedIndex;
                    m_state.CharRace = r;
                    m_CharCaption.Invalidate();
                    break;
            }
            m_ListBox.Items.Clear();
            ListBoxShow(false);
        }
        public WizForm()
        {
            InitializeComponent();

            this.ForeColor = Color.White;
            this.BackColor = Color.Black;

            // 外枠の初期値
            wb.Rectangle = this.ClientRectangle;
            wb.TopMargin = 50;
            wb.LeftMargin = 20;
            wb.RightMargin = 20;
            wb.BottomMargin = 10;

            //Captionの初期値
            wbCap.Size = new Size(220, 40);

            this.AutoScaleMode = AutoScaleMode.None;
        }
        // *****************************************************************************
        protected override void InitLayout()
        {
            base.InitLayout();
        }
        // *****************************************************************************
        public void CapSize()
        {
            wb.Rectangle = this.ClientRectangle;
            wbCap.Left = this.ClientSize.Width / 2 - wbCap.Width / 2;
            wbCap.Top = wb.Top + wb.TopMargin - wbCap.Height/2;
        }
        // *****************************************************************************
        public void SetMode(WizFormMode m)
        {
            m_Mode = m;
            if (m_CharList != null)
            {
                m_CharList.IsActive = (m_Mode == WizFormMode.CHARLIST);
            }
        }
        // *****************************************************************************
        protected override void OnPaint(PaintEventArgs e)
        {
            wb.Graphics = e.Graphics;
            wb.Back = this.BackColor;
            wb.Fore = this.ForeColor;
            wb.DrawFrame();

            wbCap.Graphics = e.Graphics;
            wbCap.Back = this.BackColor;
            wbCap.Fore = this.ForeColor;
            wbCap.DrawFrame();

            SolidBrush sb = new SolidBrush(this.ForeColor);
            StringFormat sf = new StringFormat();
            sf.Alignment = StringAlignment.Center;
            sf.LineAlignment = StringAlignment.Center;
            try
            {
                e.Graphics.DrawString(m_Caption,this.Font, sb, wbCap.Rectangle, sf);
            }finally
            {
                sb.Dispose();
                sf.Dispose();
            }
            //base.OnPaint(e);


        }
        // *****************************************************************************
        protected override void OnSizeChanged(EventArgs e)
        {
            CapSize();
            base.OnSizeChanged(e);
            this.Invalidate();
        }
        // *****************************************************************************
        protected override bool ProcessCmdKey(ref Message msg, Keys keyData)
        {
            this.Text = keyData.ToString() + " / Pro";
            if ((m_state != null) && (m_CharList != null))
            {
                switch (m_Mode)
                {
                    case WizFormMode.CHARLIST:
                        if ((keyData == Keys.Up) || (keyData == Keys.A)) { m_state.CharCurrentUp(); }
                        else if ((keyData == Keys.Down) || (keyData == Keys.Z)) { m_state.CharCurrentDown(); }
                        break;
                    case WizFormMode.GOLD:
                        if(m_ValueEditor!=null)
                        {
                            m_ValueEditor.KeyExec(keyData);
                        }
                        break;
                }
            }
            return base.ProcessCmdKey(ref msg, keyData);
        }
 
    }
}

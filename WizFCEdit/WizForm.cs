using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace WizFCEdit
{
    public enum WizFormMode
    {
        NONE = -1,
        CHARLIST = 0,
        ALG,
        CLASS,
        RACE,
        GOLD,
        EP,
        HP,
        HPMax,
        Strength,
        IQ,
        Piety,
        Vitarity,
        Agility,
        Luck,
        Age,
        AC,
        Week,
        Status,
        Item,
        Level,
        Name,
        Spell,
        COUNT
    }

    public partial class WizForm : Form
    {
        private WizLimit m_Limit = new WizLimit();
        public bool [] LimitValues
        {
            get { return m_Limit.Values; }
            set
            {
                if (value.Length == (int)WizLimit.P.Count)
                {
                    m_Limit.Values = value;
                    EditChk();
                }
            }
        }
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


        private WizFCState m_state = null;
        public WizFCState WizNesState
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


        #region Name
        // **************************************************************************************
        private WizCharName m_CharName = null;
        public WizCharName WizCharName
        {
            get { return m_CharName; }
            set
            {
                m_CharName = value;
                if (m_CharName != null)
                {
                    m_CharName.IsEdit = m_Limit.IsName;
                }
            }
        }
        // **************************************************************************************
        #endregion

        #region CLASS
        // **************************************************************************************
        private WizCharClass m_WizCharClass = null;
        public WizCharClass WizCharClass
        {
            get { return m_WizCharClass; }
            set
            {
                m_WizCharClass = value;
                if (m_WizCharClass != null)
                {
                    m_WizCharClass.IsEditAlg = m_Limit.IsAlg;
                    m_WizCharClass.IsEditClass = m_Limit.IsClass;
                    m_WizCharClass.IsEditRace = m_Limit.IsRace;
                }
            }
        }
        // **************************************************************************************
        #endregion


        #region GOLD
        private WizLongEdit m_WizGOLD = null;
        public WizLongEdit WizGold
        {
            get { return m_WizGOLD; }
            set
            {
                m_WizGOLD = value;
                if(m_WizGOLD!=null)
                {
                    m_WizGOLD.IsEdit = m_Limit.IsGold;
                }
            }
        }

        #endregion

        #region Name
        private WizCharName m_WizName = null;
        public WizCharName WizName
        {
            get { return m_WizName; }
            set
            {
                m_WizName = value;
                if (m_WizName != null)
                {
                    m_WizName.IsEdit = m_Limit.IsName;
                }
            }
        }

        #endregion


        #region Level
        private WizLongEdit m_WizLevel = null;
        public WizLongEdit WizLevel
        {
            get { return m_WizLevel; }
            set
            {
                m_WizLevel = value;
                if (m_WizLevel != null)
                {
                    m_WizLevel.IsEdit = m_Limit.IsLevel;
                }
            }
        }

        #endregion

        #region EP
        private WizLongEdit m_WizEP = null;
        public WizLongEdit WizEP
        {
            get { return m_WizEP; }
            set
            {
                m_WizEP = value;
                if (m_WizEP != null)
                {
                    m_WizEP.IsEdit = m_Limit.IsExp;
                }
            }
        }
        #endregion

        #region HP
        private WizLongEdit m_WizHP = null;
        public WizLongEdit WizHP
        {
            get { return m_WizHP; }
            set
            {
                m_WizHP = value;
                if (m_WizHP != null)
                {
                    m_WizHP.IsEdit = m_Limit.IsHP;
                }
            }
        }
        #endregion

        #region HPMax
        private WizLongEdit m_WizHPMax = null;
        public WizLongEdit WizHPMax
        {
            get { return m_WizHPMax; }
            set
            {
                m_WizHPMax = value;
                if (m_WizHPMax != null)
                {
                    m_WizHPMax.IsEdit = m_Limit.IsHP;
                }
            }
        }
        #endregion

        #region STRENGTH
        private WizByteEdit m_WizStrength = null;
        public WizByteEdit WizStrength
        {
            get { return m_WizStrength; }
            set
            {
                m_WizStrength = value;
                if (m_WizStrength != null)
                {
                    m_WizStrength.IsEdit = m_Limit.IsParams;
                }
            }
        }
        #endregion

        #region IQ
        private WizByteEdit m_WizIQ = null;
        public WizByteEdit WizIQ
        {
            get { return m_WizIQ; }
            set
            {
                m_WizIQ = value;
                if (m_WizIQ != null)
                {
                    m_WizIQ.IsEdit = m_Limit.IsParams;
                }
            }
        }
        #endregion

        #region Piety
        private WizByteEdit m_WizPiety = null;
        public WizByteEdit WizPiety
        {
            get { return m_WizPiety; }
            set
            {
                m_WizPiety = value;
                if (m_WizPiety != null)
                {
                    m_WizPiety.IsEdit = m_Limit.IsParams;
                }
            }
        }
        #endregion

        #region Vitarity
        private WizByteEdit m_WizVitarity = null;
        public WizByteEdit WizVitarity
        {
            get { return m_WizVitarity; }
            set
            {
                m_WizVitarity = value;
                if (m_WizVitarity != null)
                {
                    m_WizVitarity.IsEdit = m_Limit.IsParams;
                }
            }
        }
        #endregion

        #region Agility
        private WizByteEdit m_WizAgility = null;
        public WizByteEdit WizAgility
        {
            get { return m_WizAgility; }
            set
            {
                m_WizAgility = value;
                if (m_WizAgility != null)
                {
                    m_WizAgility.IsEdit = m_Limit.IsParams;
                }
            }
        }
        #endregion

        #region Luck
        private WizByteEdit m_WizLuck = null;
        public WizByteEdit WizLuck
        {
            get { return m_WizLuck; }
            set
            {
                m_WizLuck = value;
                if (m_WizLuck != null)
                {
                    m_WizLuck.IsEdit = m_Limit.IsParams;
                }
            }
        }
        #endregion

        #region SepllList
        private WizSpellList m_SpellList = null;
        public WizSpellList WizSpellList
        {
            get { return m_SpellList; }
            set
            {
                m_SpellList = value;
                if(m_SpellList!=null)
                {

                }
            }
        }
        #endregion



        #region AGE
        private WizByteEdit m_WizAge = null;
        public WizByteEdit WizAge
        {
            get { return m_WizAge; }
            set
            {
                m_WizAge = value;
                if (m_WizAge != null)
                {
                    m_WizAge.IsEdit = m_Limit.IsAge;
                }
            }
        }
        #endregion

        #region AC
        private WizByteEdit m_WizAC = null;
        public WizByteEdit WizAC
        {
            get { return m_WizAC; }
            set
            {
                m_WizAC = value;
                if (m_WizAC != null)
                {
                    m_WizAC.IsEdit = m_Limit.IsAC;
                }
            }
        }
        #endregion

        #region Week
        private WizByteEdit m_WizWeek = null;
        public WizByteEdit WizWeek
        {
            get { return m_WizWeek; }
            set
            {
                m_WizWeek = value;
                if (m_WizWeek != null)
                {
                    m_WizWeek.IsEdit = m_Limit.IsWeek;
                }
            }
        }
        #endregion


        #region Items
        private WizItemList m_ItemList = null;
        public WizItemList WizItemList
        {
            get { return m_ItemList; }
            set
            {
                m_ItemList = value;
                if (m_ItemList != null)
                {
                    m_ItemList.IndClicked += M_ItemList_IndClicked;
                    m_ItemList.CurseClicked += M_ItemList_CurseClicked;
                    m_ItemList.EquClicked += M_ItemList_EquClicked;

                }
            }
        }

        private void M_ItemList_EquClicked(object sender, EventArgs e)
        {
            if (m_Mode != WizFormMode.CHARLIST) return;
            if (m_Limit.IsItemEqip == false) return;
            int c_idx = m_state.CharCurrent;
            int i_idx = m_ItemList.SelectedIndex;

            WizItem wi = m_state.CharItemFromIndex(c_idx, i_idx);
            wi.Equipment = !wi.Equipment;
            m_state.SetCharItemFromIndex(c_idx, i_idx, wi);
        }

        private void M_ItemList_CurseClicked(object sender, EventArgs e)
        {
            if (m_Mode != WizFormMode.CHARLIST) return;
            if (m_Limit.IsItemCur == false) return;
            int c_idx = m_state.CharCurrent;
            int i_idx = m_ItemList.SelectedIndex;

            WizItem wi = m_state.CharItemFromIndex(c_idx, i_idx);
            wi.Curse = !wi.Curse;
            m_state.SetCharItemFromIndex(c_idx, i_idx, wi);
        }

        private void M_ItemList_IndClicked(object sender, EventArgs e)
        {
            if (m_Mode != WizFormMode.CHARLIST) return;
            if (m_Limit.IsItemInd == false) return;
            int c_idx = m_state.CharCurrent;
            int i_idx = m_ItemList.SelectedIndex;

            WizItem wi = m_state.CharItemFromIndex(c_idx, i_idx);
            wi.Indeterminate = !wi.Indeterminate;
            m_state.SetCharItemFromIndex(c_idx, i_idx, wi);
        }


        #endregion


        #region Status
        private WizStatus m_WizStatus = null;
        public WizStatus WizStatus
        {
            get { return m_WizStatus; }
            set
            {
                m_WizStatus = value;
                if (m_WizStatus != null)
                {
                    m_WizStatus.IsEdit = m_Limit.IsStatus;
                }
            }
        }
        #endregion

       

  
        // **************************************************************************************
        public void EditSpellList()
        {
            if (m_state == null) return;
            if (m_SpellList == null) return;
            if (m_Mode != WizFormMode.CHARLIST) return;
            if (m_Limit.IsSpell == false) return;

            m_Mode = WizFormMode.Spell;
            m_SpellList.Location = new Point(70, 200);
            m_SpellList.Visible = true;
            m_SpellList.Enabled = true;

        }
        // **************************************************************************************
        /// <summary>
        /// 
        /// </summary>
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
                    default:
                        break;
                }
            }
            return base.ProcessCmdKey(ref msg, keyData);
        }
        // *****************************************************************************
        public void ShowSettings()
        {
            if (m_Mode != WizFormMode.CHARLIST) return;
            WizSettingDialog dlg = new WizSettingDialog();
            dlg.StartPosition = FormStartPosition.CenterParent;
            dlg.WizLimit = m_Limit;
            if(m_state!=null) dlg.SCN = m_state.RES_SCN;
            if(dlg.ShowDialog()==DialogResult.OK)
            {
                m_Limit = dlg.WizLimit;
                EditChk();
            }
            if (m_state != null) m_state.RES_SCN = dlg.SCN;

        }
        private void EditChk()
        {
            if (m_WizName != null) m_WizName.IsEdit = m_Limit.IsName;
            if (m_WizLevel != null) m_WizLevel.IsEdit = m_Limit.IsLevel;
            if (m_WizGOLD != null) m_WizGOLD.IsEdit = m_Limit.IsGold;
            if (m_WizEP != null) m_WizEP.IsEdit = m_Limit.IsExp;
            if (m_WizHP != null) m_WizHP.IsEdit = m_Limit.IsHP;
            if (m_WizHPMax != null) m_WizHPMax.IsEdit = m_Limit.IsHP;
            if (m_WizAge!=null) m_WizAge.IsEdit = m_Limit.IsAge;
            if (m_WizWeek != null) m_WizWeek.IsEdit = m_Limit.IsWeek;
            if (m_WizAC != null) m_WizAC.IsEdit = m_Limit.IsAC;
            if (m_WizStrength != null) m_WizStrength.IsEdit = m_Limit.IsParams;
            if (m_WizIQ != null) m_WizIQ.IsEdit = m_Limit.IsParams;
            if (m_WizPiety != null) m_WizPiety.IsEdit = m_Limit.IsParams;
            if (m_WizVitarity != null) m_WizVitarity.IsEdit = m_Limit.IsParams;
            if (m_WizAgility != null) m_WizAgility.IsEdit = m_Limit.IsParams;
            if (m_WizLuck != null) m_WizLuck.IsEdit = m_Limit.IsParams;
            if (m_WizCharClass != null)
            {
                m_WizCharClass.IsEditAlg = m_Limit.IsAlg;
                m_WizCharClass.IsEditClass = m_Limit.IsClass;
                m_WizCharClass.IsEditRace = m_Limit.IsRace;
            }
            if (m_WizStatus != null) m_WizStatus.IsEdit = m_Limit.IsStatus;
        }
        public void CharCurrentDataUp()
        {
            if (m_Mode != WizFormMode.CHARLIST) return;
            if (m_Limit.IsSort == false) return;
            m_state.CurrentDataUp();
        }
        public void CharCurrentDataDown()
        {
            if (m_Mode != WizFormMode.CHARLIST) return;
            if (m_Limit.IsSort == false) return;
            m_state.CurrentDataDown();
        }

    }
}

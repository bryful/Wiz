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
        public WizLimit WizLimit
        {
            get { return m_Limit; }
            set { m_Limit = value; }
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

        #region WizValueEditor
        private WizValueEditor m_ValueEditor = null;
        public WizValueEditor WizValueEditor
        {
            get { return m_ValueEditor; }
            set
            {
                m_ValueEditor = value;
                if (m_ValueEditor != null)
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
        #endregion

        private void ValueEditorOK()
        {
            if ((m_state == null) || (m_ValueEditor == null)) return;
            switch (m_Mode)
            {
                case WizFormMode.GOLD:
                    m_state.CharGold = m_ValueEditor.Value;
                    break;
                case WizFormMode.EP:
                    m_state.CharExp = m_ValueEditor.Value;
                    break;
                case WizFormMode.HP:
                    m_state.CharHP = (int)m_ValueEditor.Value;
                    break;
                case WizFormMode.HPMax:
                    m_state.CharHPMax = (int)m_ValueEditor.Value;
                    break;
                case WizFormMode.Strength:
                    m_state.CharStrength = (int)m_ValueEditor.Value;
                    break;
                case WizFormMode.IQ:
                    m_state.CharIQ = (int)m_ValueEditor.Value;
                    break;
                case WizFormMode.Piety:
                    m_state.CharPiety = (int)m_ValueEditor.Value;
                    break;
                case WizFormMode.Vitarity:
                    m_state.CharVitarity = (int)m_ValueEditor.Value;
                    break;
                case WizFormMode.Agility:
                    m_state.CharAgility = (int)m_ValueEditor.Value;
                    break;
                case WizFormMode.Luck:
                    m_state.CharLuck = (int)m_ValueEditor.Value;
                    break;
                case WizFormMode.Age:
                    m_state.CharAge = (sbyte)m_ValueEditor.Value;
                    break;
                case WizFormMode.AC:
                    m_state.CharAC = (sbyte)m_ValueEditor.Value;
                    break;
                case WizFormMode.Week:
                    m_state.CharWeek = (byte)m_ValueEditor.Value;
                    break;
                case WizFormMode.Level:
                    m_state.CharLevel = (int)m_ValueEditor.Value;
                    break;
            }
            ValueEditorShow(false);
        }
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
        private void ListBoxSelected()
        {
            if ((m_state == null) || (m_ListBox == null) ) return;
            switch (m_Mode)
            {
                case WizFormMode.ALG:
                    WIZALG a = (WIZALG)m_ListBox.SelectedIndex;
                    m_state.CharAlg = a;
                    break;
                case WizFormMode.CLASS:
                    WIZCLASS c = (WIZCLASS)m_ListBox.SelectedIndex;
                    if (m_state.CharClass != c)
                    {
                        m_state.CharClass = c;
                        if (m_Limit.LevelInit == true)
                        {
                            m_state.CharLevel = 1;
                            m_state.CharExp = 0;
                        }
                    }
                    break;
                case WizFormMode.RACE:
                    WIZRACE r = (WIZRACE)m_ListBox.SelectedIndex;
                    m_state.CharRace = r;
                    break;
                case WizFormMode.Status:
                    WIZSTATUS s = (WIZSTATUS)m_ListBox.SelectedIndex;
                    m_state.CharStatus = s;
                    break;
                case WizFormMode.Item:
                    int id = m_ListBox.SelectedIndex;
                    int i_idx = m_ItemList.SelectedIndex;
                    int c_idx = m_state.CharCurrent;
                    WizItem wi = m_state.CharItemFromIndex(c_idx, i_idx);
                    if(wi.ID !=id)
                    {
                        wi.ID = (byte)id;
                        m_state.SetCharItemFromIndex(c_idx, i_idx,wi);
                    }
                    break;
            }
            m_ListBox.Items.Clear();
            ListBoxShow(false);
        }
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

        #region EP
        private WizParam m_WizEP = null;
        public WizParam WizEP
        {
            get { return m_WizEP; }
            set
            {
                m_WizEP = value;
                if (m_WizEP != null)
                {
                    m_WizEP.MouseDown += M_WizEP_MouseDown;
                }
            }
        }

        private void M_WizEP_MouseDown(object sender, MouseEventArgs e)
        {
            EditEP();
        }
        #endregion

        #region HP
        private WizHP m_WizHP = null;
        public WizHP WizHP
        {
            get { return m_WizHP; }
            set
            {
                m_WizHP = value;
                if (m_WizHP != null)
                {
                    m_WizHP.HPClicked += M_WizHP_HPClicked;
                    m_WizHP.HPMaxClicked += M_WizHP_HPMaxClicked;
                }
            }
        }

        private void M_WizHP_HPMaxClicked(object sender, EventArgs e)
        {
            EditHPMax();
        }

        private void M_WizHP_HPClicked(object sender, EventArgs e)
        {
            EditHP();
        }
        #endregion

        #region Bounus
        private WizBonus m_WizBonus = null;
        public WizBonus WizBonus
        {
            get { return m_WizBonus; }
            set
            {
                m_WizBonus = value;
                if (m_WizBonus != null)
                {
                    m_WizBonus.StrengthClicked += M_WizBonus_StrengthClicked;
                    m_WizBonus.IQClicked += M_WizBonus_IQClicked;
                    m_WizBonus.PietyClicked += M_WizBonus_PietyClicked;
                    m_WizBonus.VitarityClicked += M_WizBonus_VitarityClicked;
                    m_WizBonus.AgilityClicked += M_WizBonus_AgilityClicked;
                    m_WizBonus.LuckClicked += M_WizBonus_LuckClicked;
                }
            }
        }

        private void M_WizBonus_LuckClicked(object sender, EventArgs e)
        {
            EditLuck();
        }

        private void M_WizBonus_AgilityClicked(object sender, EventArgs e)
        {
            EditAgility();
        }

        private void M_WizBonus_VitarityClicked(object sender, EventArgs e)
        {
            EditVitarity();
        }

        private void M_WizBonus_PietyClicked(object sender, EventArgs e)
        {
            EditPiety();
        }

        private void M_WizBonus_IQClicked(object sender, EventArgs e)
        {
            EditIQ();
        }

        private void M_WizBonus_StrengthClicked(object sender, EventArgs e)
        {
            EditStrength();
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
                    m_CharCaption.NameClicked += M_CharCaption_NameClicked;
                    m_CharCaption.AlgClicked += M_CharCaption_AlgClicked;
                    m_CharCaption.ClassClicked += M_CharCaption_ClassClicked;
                    m_CharCaption.RaceClicked += M_CharCaption_RaceClicked;
                    m_CharCaption.LevelClicked += M_CharCaption_LevelClicked;
                }
            }
        }

        private void M_CharCaption_NameClicked(object sender, EventArgs e)
        {
            EditName();
        }

        // **************************************************************************************
        private void M_CharCaption_LevelClicked(object sender, EventArgs e)
        {
            EditLevel();
        }

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
        #endregion

        #region AGE
        private WizParam m_WizAge = null;
        public WizParam WizAge
        {
            get { return m_WizAge; }
            set
            {
                m_WizAge = value;
                if (m_WizAge != null)
                {
                    m_WizAge.MouseDown += M_WizAge_MouseDown;
                }
            }
        }

        private void M_WizAge_MouseDown(object sender, MouseEventArgs e)
        {
            EditAge();
        }
        #endregion

        #region AC
        private WizParam m_WizAC = null;
        public WizParam WizAC
        {
            get { return m_WizAC; }
            set
            {
                m_WizAC = value;
                if (m_WizAC != null)
                {
                    m_WizAC.MouseDown += M_WizAC_MouseDown;
                }
            }
        }

        private void M_WizAC_MouseDown(object sender, MouseEventArgs e)
        {
            EditAC();
        }
        #endregion

        #region Week
        private WizParam m_WizWeek = null;
        public WizParam WizWeek
        {
            get { return m_WizWeek; }
            set
            {
                m_WizWeek = value;
                if (m_WizWeek != null)
                {
                    m_WizWeek.MouseDown += M_WizWeek_MouseDown;
                }
            }
        }

        private void M_WizWeek_MouseDown(object sender, MouseEventArgs e)
        {
            EditWeek();
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
                    m_ItemList.ItemClicked += M_ItemList_ItemClicked;
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

        private void M_ItemList_ItemClicked(object sender, EventArgs e)
        {
            EditItem(m_ItemList.SelectedIndex);
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
                    m_WizStatus.MouseDown += M_WizStatus_MouseDown;
                }
            }
        }

        private void M_WizStatus_MouseDown(object sender, MouseEventArgs e)
        {
            EditStatus();
        }
        #endregion

        // **************************************************************************************
        public void EditAlg()
        {
            if (m_Mode != WizFormMode.CHARLIST) return;
            if ((m_state == null) || (m_ListBox == null) || (m_CharCaption == null)) return;
            if (m_Limit.IsAlg == false) return;
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
            if (m_Mode != WizFormMode.CHARLIST) return;
            if ((m_state == null) || (m_ListBox == null) || (m_CharCaption == null)) return;
            if (m_Limit.IsClass == false) return;

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
            if (m_Mode != WizFormMode.CHARLIST) return;
            if ((m_state == null) || (m_ListBox == null) || (m_CharCaption == null)) return;
            if (m_Limit.IsRace == false) return;

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
            if (m_Mode != WizFormMode.CHARLIST) return;
            if ((m_state == null) || (m_WizGOLD == null) || (m_ValueEditor == null)) return;
            if (m_Limit.IsGold == false) return;

            m_ValueEditor.Caption = "GOLD";
            m_ValueEditor.ValueMin = 0;
            m_ValueEditor.ValueMax = 999999999999;
            m_ValueEditor.Value = m_state.CharGold;
            SetMode(WizFormMode.GOLD);
            ValueEditorShow(true);
        }
        // **************************************************************************************
        public void EditEP()
        {
            if (m_Mode != WizFormMode.CHARLIST) return;
            if ((m_state == null) || (m_WizEP == null) || (m_ValueEditor == null)) return;
            if (m_Limit.IsExp == false) return;

            m_ValueEditor.Caption = "E.P.";
            m_ValueEditor.ValueMin = 0;
            m_ValueEditor.ValueMax = 999999999999;
            m_ValueEditor.Value = m_state.CharExp;
            SetMode(WizFormMode.EP);
            ValueEditorShow(true);
        }
        // **************************************************************************************
        public void EditHP()
        {
            if (m_Mode != WizFormMode.CHARLIST) return;
            if ((m_state == null) || (m_WizHP == null) || (m_ValueEditor == null)) return;
            if (m_Limit.IsHP == false) return;

            m_ValueEditor.Caption = "HP";
            m_ValueEditor.ValueMin = 0;
            m_ValueEditor.ValueMax = m_state.CharHPMax;
            m_ValueEditor.Value = m_state.CharHP;
            SetMode(WizFormMode.HP);
            ValueEditorShow(true);
        }
        // **************************************************************************************
        public void EditHPMax()
        {
            if (m_Mode != WizFormMode.CHARLIST) return;
            if ((m_state == null) || (m_WizHP == null) || (m_ValueEditor == null)) return;
            if (m_Limit.IsHP == false) return;

            m_ValueEditor.Caption = "HP Max";
            m_ValueEditor.ValueMin = 0;
            m_ValueEditor.ValueMax = 99999999;
            m_ValueEditor.Value = m_state.CharHPMax;
            SetMode(WizFormMode.HPMax);
            ValueEditorShow(true);
        }
        // **************************************************************************************
        public void EditStrength()
        {
            if (m_Mode != WizFormMode.CHARLIST) return;
            if ((m_state == null) || (m_WizBonus == null) || (m_ValueEditor == null)) return;
            if (m_Limit.IsParams == false) return;

            m_ValueEditor.Caption = "ちから";
            m_ValueEditor.ValueMin = 0;
            m_ValueEditor.ValueMax = 30;
            m_ValueEditor.Value = m_state.CharStrength;
            SetMode(WizFormMode.Strength);
            ValueEditorShow(true);
        }
        // **************************************************************************************
        public void EditIQ()
        {
            if (m_Mode != WizFormMode.CHARLIST) return;
            if ((m_state == null) || (m_WizBonus == null) || (m_ValueEditor == null)) return;
            if (m_Limit.IsParams == false) return;

            m_ValueEditor.Caption = "ちえ";
            m_ValueEditor.ValueMin = 0;
            m_ValueEditor.ValueMax = 30;
            m_ValueEditor.Value = m_state.CharIQ;
            SetMode(WizFormMode.IQ);
            ValueEditorShow(true);
        }
        // **************************************************************************************
        public void EditPiety()
        {
            if (m_Mode != WizFormMode.CHARLIST) return;
            if ((m_state == null) || (m_WizBonus == null) || (m_ValueEditor == null)) return;
            if (m_Limit.IsParams == false) return;

            m_ValueEditor.Caption = "しんこうしん";
            m_ValueEditor.ValueMin = 0;
            m_ValueEditor.ValueMax = 30;
            m_ValueEditor.Value = m_state.CharPiety;
            SetMode(WizFormMode.Piety);
            ValueEditorShow(true);
        }
        // **************************************************************************************
        public void EditVitarity()
        {
            if (m_Mode != WizFormMode.CHARLIST) return;
            if ((m_state == null) || (m_WizBonus == null) || (m_ValueEditor == null)) return;
            if (m_Limit.IsParams == false) return;

            m_ValueEditor.Caption = "せいめいりょく";
            m_ValueEditor.ValueMin = 0;
            m_ValueEditor.ValueMax = 30;
            m_ValueEditor.Value = m_state.CharVitarity;
            SetMode(WizFormMode.Vitarity);
            ValueEditorShow(true);
        }
        // **************************************************************************************
        public void EditAgility()
        {
            if (m_Mode != WizFormMode.CHARLIST) return;
            if ((m_state == null) || (m_WizBonus == null) || (m_ValueEditor == null)) return;
            if (m_Limit.IsParams == false) return;

            m_ValueEditor.Caption = "すばやさ";
            m_ValueEditor.ValueMin = 0;
            m_ValueEditor.ValueMax = 30;
            m_ValueEditor.Value = m_state.CharAgility;
            SetMode(WizFormMode.Agility);
            ValueEditorShow(true);
        }
        // **************************************************************************************
        public void EditLuck()
        {
            if (m_Mode != WizFormMode.CHARLIST) return;
            if ((m_state == null) || (m_WizBonus == null) || (m_ValueEditor == null)) return;
            if (m_Limit.IsParams == false) return;

            m_ValueEditor.Caption = "うんのつよさ";
            m_ValueEditor.ValueMin = 0;
            m_ValueEditor.ValueMax = 30;
            m_ValueEditor.Value = m_state.CharLuck;
            SetMode(WizFormMode.Luck);
            ValueEditorShow(true);
        }
        // **************************************************************************************
        public void EditAge()
        {
            if (m_Mode != WizFormMode.CHARLIST) return;
            if ((m_state == null) || (m_WizAge == null) || (m_ValueEditor == null)) return;
            if (m_Limit.IsParams == false) return;

            m_ValueEditor.Caption = "AGE";
            m_ValueEditor.ValueMin = -128;
            m_ValueEditor.ValueMax = 127;
            m_ValueEditor.Value = m_state.CharAge;
            SetMode(WizFormMode.Age);
            ValueEditorShow(true);
        }
        // **************************************************************************************
        public void EditAC()
        {
            if (m_Mode != WizFormMode.CHARLIST) return;
            if ((m_state == null) || (m_WizAC == null) || (m_ValueEditor == null)) return;
            if (m_Limit.IsAC == false) return;

            m_ValueEditor.Caption = "AC";
            m_ValueEditor.ValueMin = -128;
            m_ValueEditor.ValueMax = 127;
            m_ValueEditor.Value = m_state.CharAC;
            SetMode(WizFormMode.AC);
            ValueEditorShow(true);
        }
        // **************************************************************************************
        public void EditStatus()
        {
            if (m_Mode != WizFormMode.CHARLIST) return;
            if ((m_state == null) || (m_ListBox == null) || (m_WizStatus == null)) return;
            if (m_Limit.IsStatus == false) return;

            m_ListBox.Location = m_WizStatus.StatusPoint;
            m_ListBox.Size = new Size(m_WizStatus.Width- m_WizStatus.CaptionWidth, 150);
            m_ListBox.Items.Clear();
            m_ListBox.Items.Add("OK");
            m_ListBox.Items.Add("ねむっている");
            m_ListBox.Items.Add("おそれている");
            m_ListBox.Items.Add("まひしている");
            m_ListBox.Items.Add("いしになった");
            m_ListBox.Items.Add("しんでいる");
            m_ListBox.Items.Add("はいになった");
            m_ListBox.Items.Add("うしなわれた");
            m_ListBox.SelectedIndex = (int)m_state.CharStatus;
            SetMode(WizFormMode.Status);
            ListBoxShow(true);
        }
        // **************************************************************************************
        public void EditItem(int v)
        {
            if (m_Mode != WizFormMode.CHARLIST) return;
            if ((m_state == null) || (m_ListBox == null) || (m_ItemList == null)) return;
            if (m_Limit.IsItem == false) return;

            m_ListBox.Location = m_ItemList.ItemLocation;
            m_ListBox.Size = m_ItemList.ItemSize;
            m_ListBox.Items.Clear();
            m_ListBox.Items.AddRange(m_state.ItemList);
            m_ListBox.SelectedIndex = (int)m_ItemList.ItemID;
            SetMode(WizFormMode.Item);
            ListBoxShow(true);
        }
        // **************************************************************************************
        public void EditWeek()
        {
            if (m_Mode != WizFormMode.CHARLIST) return;
            if ((m_state == null) || (m_WizWeek == null) || (m_ValueEditor == null)) return;
            if (m_Limit.IsWeek == false) return;

            m_ValueEditor.Caption = "Week";
            m_ValueEditor.ValueMin = 0;
            m_ValueEditor.ValueMax = 53;
            m_ValueEditor.Value = m_state.CharWeek;
            SetMode(WizFormMode.Week);
            ValueEditorShow(true);
        }
        // **************************************************************************************
        public void EditLevel()
        {
            if (m_Mode != WizFormMode.CHARLIST) return;
            if ((m_state == null) || (m_CharCaption == null) || (m_ValueEditor == null)) return;
            if (m_Limit.IsLevel == false) return;

            m_ValueEditor.Caption = "Level";
            m_ValueEditor.ValueMin = 0;
            m_ValueEditor.ValueMax = 0xFFFF;
            m_ValueEditor.Value = m_state.CharLevel;
            SetMode(WizFormMode.Level);
            ValueEditorShow(true);
        }
        // **************************************************************************************
        public void EditName()
        {
            if (m_state == null) return;
            if (m_Mode != WizFormMode.CHARLIST) return;
            if (m_Limit.IsName == false) return;

            m_Mode = WizFormMode.Name;
            WizNameEdit dlg = new WizNameEdit();
            dlg.SCN = m_state.SCN;
            dlg.CharNameCode = m_state.CharNameCode;
            if (dlg.ShowDialog() == DialogResult.OK)
            {
                m_state.CharNameCode = dlg.CharNameCode;
            }
            m_Mode = WizFormMode.CHARLIST;
            this.Invalidate();
        }
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
                        if(m_ValueEditor!=null)
                        {
                            m_ValueEditor.KeyExec(keyData);
                        }
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
            }
            if (m_state != null) m_state.RES_SCN = dlg.SCN;

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

using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace WizEdit
{
    public enum WizParamMode
    {
        Gold=0,
        Exp,
        Age,
        AC,
        Week
    }
    public class WizParam : WizTextBox
    {
        private WizParamMode m_Mode = WizParamMode.Gold;
        public WizParamMode Mode
        {
            get { return m_Mode; }
            set { m_Mode = value; GetInfo(); }
        }

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
                    m_state.CurrentCharChanged += M_state_ChangeCurrentChar;
                    m_state.LoadFileFinished += M_state_FinishedLoadFile;
                    m_state.ValueChanged += M_state_FinishedLoadFile;
                    GetInfo();
                }
            }
        }
        private void GetInfo()
        {
            switch (m_Mode)
            {
                case WizParamMode.Gold:
                    this.NearText = "GOLD";
                    if (m_state != null)
                    {
                        this.Value = m_state.CharGold;
                    }
                    break;
                case WizParamMode.Exp:
                    this.NearText = "E.P.";
                    if (m_state != null)
                    {
                        this.FarText = m_state.CharExp.ToString();
                    }
                    break;
                case WizParamMode.Age:
                    this.NearText = "AGE";
                    if (m_state != null)
                    {
                        this.FarText = m_state.CharAge.ToString();
                    }
                    break;
                case WizParamMode.AC:
                    this.NearText = "A.C.";
                    if (m_state != null)
                    {
                        this.FarText = m_state.CharAC.ToString();
                    }
                    break;
                case WizParamMode.Week:
                    this.NearText = "Week";
                    if (m_state != null)
                    {
                        this.FarText = m_state.CharWeek.ToString();
                    }
                    break;
            }

            if (m_Mode==WizParamMode.Gold)
            {
            }
            else
            {

            }
            this.Invalidate();
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
        // ********************************************************************************
        public WizParam()
        {
            GetInfo();
        }
        // ********************************************************************************
    }
}

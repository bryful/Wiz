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
    public class WizNameBox : WizTextBox
    {
        #region state
        private WizNesState m_state = null;
        public WizNesState WizNesState
        {
            get { return m_state; }
            set
            {
                m_state = value;
                if (m_state!=null)
                {
                    this.NearText = m_state.CharName;
                    m_state.ChangeCurrentChar += M_state_ChangeCurrentChar;
                    m_state.FinishedLoadFile += M_state_FinishedLoadFile;
                    this.Invalidate();
                }
            }
        }

        private void M_state_FinishedLoadFile(object sender, EventArgs e)
        {
            this.NearText = m_state.CharName;
            this.Invalidate();
        }

        private void M_state_ChangeCurrentChar(object sender, CurrentCharEventArgs e)
        {
            this.NearText = m_state.CharName;
            this.Invalidate();
        }
        #endregion

        // *********************************************************************
        public WizNameBox()
        {

        }
        // *********************************************************************
        protected override void InitLayout()
        {
            base.InitLayout();
            this.SetSize(new Size(120, 24));
        }
 
        // *********************************************************************
    }
}

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

    public class WizDump : ListBox
    {
        private byte[] m_data = new byte[0];
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
                    m_state.ChangeCurrentChar += M_state_ChangeCurrentChar;
                    m_state.FinishedLoadFile += M_state_FinishedLoadFile;
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
        public void GetInfo()
        {
            this.Items.Clear();
            if (m_state != null)
            {
                m_data = m_state.CharData;
                if (m_data.Length > 0)
                {
                    string[] cap = new string[m_data.Length];
                    for ( int i=0; i<m_data.Length;i++)
                    {
                        cap[i] = String.Format("{0:X4} - {1:X2} ", i,m_data[i]);
                    }

                    this.SuspendLayout();
                    this.Items.AddRange(cap);
                    this.ResumeLayout();
                }


            }

        }

    }
}

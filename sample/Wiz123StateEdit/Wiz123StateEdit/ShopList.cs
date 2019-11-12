using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Drawing;
using System.Data;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace Wiz123StateEdit
{
    public class ShopList : ListBox
    {
        private Snes9xWiz123SFC m_wiz123sfc = null;
        private int m_Adr = 0x0161;
        
        //-------------------------------------------------------------
        public ShopList()
        {
            BackColor = Color.Black;
            ForeColor = Color.White;
            this.DoubleClick += ShopList_DoubleClick;
        }

        //-------------------------------------------------------------
        private void ShopList_DoubleClick(object sender, EventArgs e)
        {
            if ((Control.ModifierKeys & Keys.Shift) == Keys.Shift)
                ValueUp();
        }

        //-------------------------------------------------------------
        public void GetValue()
        {
            if (m_wiz123sfc == null) return;

            this.SuspendLayout();
            this.Items.Clear();

            int no = (int)m_wiz123sfc.Scenario;

            for(int i=0; i<Wiz.ITEM_COUNT[no];i++)
            {
                byte v = m_wiz123sfc.State.GetByte(m_Adr + i);
                string s = "";
                s = string.Format("{0:X2}: {1}", v, Wiz.WIZITEM[no][i]);
                this.Items.Add(s);
             }
        }
        //-------------------------------------------------------------
        public Snes9xWiz123SFC Wiz123sfc
        {
            get { return m_wiz123sfc; }
            set
            {
                m_wiz123sfc = value;
                if (m_wiz123sfc != null)
                {
                    m_wiz123sfc.LoadFileEvent += M_wiz123sfc_LoadFileEvent;
                    m_wiz123sfc.ScenarioChanged += M_wiz123sfc_ScenarioChanged;
                }
            }
        }

        //-------------------------------------------------------------
        private void M_wiz123sfc_ScenarioChanged(object sender, EventArgs e)
        {
            GetValue();
        }

        //-------------------------------------------------------------
        private void M_wiz123sfc_LoadFileEvent(object sender, EventArgs e)
        {
            GetValue();
        }
        //-------------------------------------------------------------
        private void ValueUp()
        {
            if (m_wiz123sfc == null) return;
            int si = this.SelectedIndex;
            if (si < 0) return;

            byte v = m_wiz123sfc.State.GetByte(m_Adr + si);
            if (v == 0) v = 1;
            else if (v < 0x7F) v = 0x7F;
            else v = 0;

            m_wiz123sfc.State.SetByte(m_Adr + si, v);

            this.Items[si] = string.Format("{0:X2}: {1}", v, Wiz.WIZITEM[(int)m_wiz123sfc.Scenario][si]);

        }


    }
}

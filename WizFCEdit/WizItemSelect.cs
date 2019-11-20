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
    public class WizItemSelect : ComboBox
    {
        public WizItemSelect()
        {
                   this.ForeColor = Color.White;
            this.BackColor = Color.Black;
            this.DropDownStyle = ComboBoxStyle.DropDownList;
            this.FlatStyle = FlatStyle.Flat;
        }
    }
}

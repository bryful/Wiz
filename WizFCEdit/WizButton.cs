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
    public class WizButton : Button
    {
        public WizButton() : base()
        {
            this.SetStyle(ControlStyles.Selectable, false);
            this.BackColor = Color.Black;
            this.ForeColor = Color.White;
            this.FlatStyle = FlatStyle.Flat;
        }
    }
}

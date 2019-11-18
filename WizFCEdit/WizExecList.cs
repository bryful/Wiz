using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Drawing;
using System.Data;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace WizFCEdit
{
    public class WizExecList :WizSelectControl
    {
        public WizExecList()
        {
            this.AddItem("Change Alg");
            this.AddItem("Change Class");
            this.AddItem("Change Race");

        }
    }
}

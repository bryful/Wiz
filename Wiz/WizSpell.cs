using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace WizEdit
{
    public class WizSpell
    {
        public byte[] Data = null;
        public int Adr = 0;
        public WizSpell(byte []d,int a)
        {
            Data = d;
            Adr = a;
        }

        public byte[] Spell = new byte[7];
        public byte[] CastCount = new byte[7];
        public byte[] CastMax = new byte[7];
    }
}

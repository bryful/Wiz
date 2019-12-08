using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace WizEdit
{
    #region Const
    public enum WIZSCN
    {
        NO = 0,
        FC1,
        FC2,
        FC3,
        SFC1,
        SFC2,
        SFC3,
        SFC5,
        GBC1,
        GBC2,
        GBC3

    }

    public enum WIZFILE
    {
        NONE = 0,
        STATE,
        SAVE,
        ROM
    }


    public enum WIZRACE
    {
        HUMAN = 0,
        ELF,
        DWARF,
        GNOME,
        HOBIT
    }
    public enum WIZCLASS
    {
        // 0:FIG, 1:MAG, 2:PRI, 3:THI, 4:BIS, 5:SAM, 6:LOR, 7:NIN
        FIG = 0,
        MAG,
        PRI,
        THI,
        BIS,
        SAM,
        LOR,
        NIN
    }
    public enum WIZALG
    {
        // 0:善, 1:中立, 2:悪
        GOOD = 0,
        NEUT,
        EVIL
    }

    public enum WIZSTATUS
    {
        // 0:OK, 1:ASLEEP, 2:AFRAID, 3:PARALY, 4:STONED, 5:DEAD, 6:ASHED, 7:LOST
        OK = 0,
        ASLEEP,
        AFRAID,
        PARALY,
        STONED,
        DEAD,
        ASHED,
        LOST
    }


    #endregion


    public class MagicPoint
    {
        public byte[] NowP = new byte[7];
        public byte[] MaxP = new byte[7];
        public byte[] Learning = new byte[7];
        public byte[] Learning2 = new byte[7];
        public MagicPoint()
        {
            Clear();
        }
        public void Clear()
        {
            for (int i = 0; i < 7; i++)
            {
                NowP[i] = 0;
                MaxP[i] = 0;
                Learning[i] = 0;
                Learning2[i] = 0;

            }
        }
    }
    public class WizConst
    {

    }
}

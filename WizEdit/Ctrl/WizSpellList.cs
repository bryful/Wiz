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
    public class WizSpellList : WizBoxControl
    {
        private byte[] m_spell = new byte[7];
        public byte[] Spell
        {
            get { return m_spell; }
            set
            {

                if((value.Length==7)||(value.Length == 14))
                {
                    bool b = false;
                    if(value.Length== m_spell.Length)
                    {
                        for ( int i=0; i< m_spell.Length;i++)
                        {
                            if(value[i]!=m_spell[i])
                            {
                                b = true;
                                break;
                            }
                        }
                    }
                    else
                    {
                        b = true;

                    }
                    if(b)
                    {
                        m_spell = value;
                        if(m_spell.Length==7)
                        {
                            m_scn = WIZSCN.FC1;
                        }
                        this.Invalidate();
                    }

                }
            }
        }
        private WIZSCN m_scn = WIZSCN.FC1;
        public WIZSCN SCN
        {
            get { return m_scn; }
            set
            {
                if(m_scn!=value)
                {
                    m_scn = value;
                    this.Invalidate();
                }
            }
        }

        #region prop
        private int m_TopMgn = 40;
        public int TopMgn
        {
            get { return m_TopMgn; }
            set { m_TopMgn = value; this.Invalidate(); }
        }
        private int m_LeftMgn = 30;
        public int LeftMgn
        {
            get { return m_LeftMgn; }
            set { m_LeftMgn = value; this.Invalidate(); }
        }

        private int m_LineHeight = 24;
        public int LineHeight
        {
            get { return m_LineHeight; }
            set { m_LineHeight = value; this.Invalidate(); }
        }
        private int m_SpellWidth = 100;
        public int SpellWidth
        {
            get { return m_SpellWidth; }
            set { m_SpellWidth = value; this.Invalidate(); }
        }
        public int LineHeightALL
        {
            get { return m_LineHeight * 5; }
        }
        #endregion

        // **********************************************************************

        // **********************************************************************

        #region Data
        /*
    static public readonly string[][] Wiz1FCSpell = new string[][]
    {
        new string[]{"ハリト","モグレフ","カティノ","デュマピック","ディルト","ソピック","マハリト","モリト"},
        new string[]{"モーリス","ダルト","ラハリト","マモーリス","	マカニト","マダルト","ラカニト","ジルワン"},
        new string[]{"マゾピック","ハマン","マロール","マハマン","ティルトウェイト","カルキ","ディオス","バディオス"},
        new string[]{"ミルワ","ポーフィック","マツ","カルフォ","マニフォ","モンティノ","ロミルワ","ディアルコ"},
        new string[]{"ラツマピック","バマツ","ディアル","バディアル	","ラツモフィス","マポーフィック","ディアルマ","バディアルマ"},
        new string[]{"リトカン","カンディ","ディ","バディ","ロルト","マディ","マバディ","ロクトフェイト"},
        new string[]{"マリクト","カドルト"}
    };

    public readonly int[][] Wiz1FCSpellTo = new int[7][]
    {
        new int[]{0x0001,0x0002,0x0004,0x0008,0x0101,0x0102,0x0201,0x0202},
        new int[]{0x0301,0x0302,0x0304,0x0401,0x0402,0x0404,0x0501,0x0502},
        new int[]{0x0504,0x0508,0x0601,0x0602,0x0604,0x0701,0x0702,0x0704},
        new int[]{0x0708,0x0710,0x0801,0x0802,0x0804,0x0808,0x0901,0x0902},
        new int[]{0x0904,0x0908,0x0A01,0x0A02,0x0A04,0x0A08,0x0B01,0x0B02},
        new int[]{0x0B04,0x0B08,0x0B10,0x0B20,0x0C01,0x0C02,0x0C04,0x0C08},
        new int[]{0x0D01, 0x0D02}
    };
     public readonly int[][] Wiz1FCSpellFrom = new int[14][]
    {
        new int[]{0x0001,0x0002,0x0004,0x0008},
        new int[]{0x0010,0x0020},
        new int[]{0x0040,0x0080},
        new int[]{0x0101,0x0102,0x0104},
        new int[]{0x0108,0x0110,0x0120},
        new int[]{0x0140,0x0180,0x0201,0x0202},
        new int[]{0x0204,0x0208,0x0210},

        new int[]{0x0220,0x0240,0x0280,0x0301,0x0302},
        new int[]{0x0304,0x0308,0x0310,0x0320},
        new int[]{0x0340,0x0380,0x0401,0x0402},
        new int[]{0x0404,0x0408,0x0410,0x0420},
        new int[]{0x0440,0x0480,0x0501,0x0502,0x0504,0x0508},
        new int[]{0x0510,0x0520,0x0540,0x0580},
        new int[]{ 0x0601, 0x0602 }
     };      */
        static public readonly string[][] Wiz1FCSpellM = new string[][]
        {
            new string[]{"ハリト","モグレフ","カティノ","デュマピック"},
            new string[]{"ディルト","ソピック"},
            new string[]{"マハリト","モリト"},
            new string[]{"モーリス","ダルト","ラハリト"},
            new string[]{"マモーリス","マカニト","マダルト"},
            new string[]{"ラカニト","ジルワン","マゾピック","ハマン"},
            new string[]{"マロール", "マハマン", "ティルトウェイト" }
        };
        static public readonly string[][] Wiz1FCSpellP = new string[][]
       {
            new string[]{"カルキ","ディオス","バディオス","ミルワ","ポーフィック"},
            new string[]{"マツ","カルフォ","マニフォ","モンティノ"},
            new string[]{"ロミルワ","ディアルコ","ラテュマピック","バマツ"},
            new string[]{"ディアル","バディアル","ラテュモフィス","マポーフィック"},
            new string[]{"ディアルマ","バディアルマ","リトカン","カンディ","ディ","バディ"},
            new string[]{"ロルト","マディ","マバディ","ロクトフェイト"},
            new string[]{"マリクト", "カドルト"}
       };
 

        static public readonly string[][] Wiz2FCSpellM = new string[][]
        {
            new string[]{"ハリト","モグレフ","カティノ","デュマピック"},
            new string[]{"ディルト","ソピック"},
            new string[]{"マハリト","モリト"},
            new string[]{"モーリス","ダルト","ラハリト"},
            new string[]{"マモーリス","マカニト","マダルト"},
            new string[]{"ラカニト","ジルワン","マゾピック","ハマン"},
            new string[]{"マロール","マハマン","ティルトウェイト"}

        };
        static public readonly string[][] Wiz2FCSpellP = new string[][]
        {
            new string[]{"カルキ","ディオス","バディオス","ミルワ","ポーフィック"},
            new string[]{"マツ","カルフォ","マニフォ","モンティノ"},
            new string[]{"ロミルワ","ディアルコ","ラツマピック","バマツ"},
            new string[]{"ディアル","バディアル","ラツモフィス","マポーフィック"},
            new string[]{"ディアルマ","バディアルマ","リトカン","カンディ","ディ","バディ"},
            new string[]{"ロルト","マディ","マバディ","ロクトフェイト"},
            new string[]{"マリクト","カドルト"},

        };

        static public readonly string[][] Wiz3FCSpellM = new string[][]
        {
            new string[]{"ハリト","モグレフ","カティノ","デュマピック"},
            new string[]{"ディルト","ソピック","メリト"},
            new string[]{"マハリト","モリト","モーリス"},
            new string[]{"ツザリク","ダルト","ラハリト"},
            new string[]{"マモーリス","マカニト","マダルト","ジルワン"},
            new string[]{"ラカニト","マゾピック","ハマン","ラダルト"},
            new string[]{"マロール","マハマン","ティルトウェイト"},

        };
        static public readonly string[][] Wiz3FCSpellP = new string[][]
        {
            new string[]{"カルキ","ディオス","バディオス","ミルワ","ポーフィック"},
            new string[]{"マツ","カルフォ","マニフォ","モンティノ","カンディ"},
            new string[]{"ディアル","バディアル","ディアルコ","ラツマピック"},
            new string[]{"ロミルワ","リトカン","バマツ","ラツモフィス","マポーフィック"},
            new string[]{"ディアルマ","バディアルマ","ディ","バディ"},
            new string[]{"ロルト","マディ","マバディ","ロクトフェイト"},
            new string[]{"マリクト","カドルト"},

        };
        static public readonly string[][] Wiz1SFCSpellM = new string[][]
        {
            new string[]{"ハリト","モグレフ","カティノ","デュマピック"},
            new string[]{"ディルト","ソピック"},
            new string[]{"マハリト","モリト"},
            new string[]{"モーリス","ダルト","ラハリト"},
            new string[]{"マモーリス","マカニト","マダルト"},
            new string[]{"ラカニト","ジルワン","マゾピック","ハマン"},
            new string[]{"マロール", "マハマン", "ティルトウェイト"}
        };
        static public readonly string[][] Wiz1SFCSpellP = new string[][]
        {
            new string[]{"カルキ","ディオス","バディオス","ミルワ","ポーフィック"},
            new string[]{"マツ","カルフォ","マニフォ","モンティノ"},
            new string[]{"ロミルワ","ディアルコ","ラツマピック","バマツ"},
            new string[]{"ディアル","バディアル","ラツモフィス","マポーフィック"},
            new string[]{"ディアルマ","バディアルマ","リトカン","カンディ","ディ","バディ"},
            new string[]{"ロルト","マディ","マバディ","ロクトフェイト"},
            new string[]{"マリクト", "カドルト" }
        };
        static public readonly string[][] Wiz3SFCSpellM = new string[][]
        {
            new string[]{"ハリト","モグレフ","カティノ","デュマピック"},
            new string[]{"ディルト","ソピック","メリト"},
            new string[]{"マハリト","モリト","モーリス"},
            new string[]{"ツザリク","ダルト","ラハリト"},
            new string[]{"マモーリス","マカニト","マダルト","ジルワン"},
            new string[]{"ラカニト","マゾピック","ハマン","ラダルト"},
            new string[]{"マハマン","ティルトウェイト"}
        };
        static public readonly string[][] Wiz3SFCSpellP = new string[][]
        {
            new string[]{"カルキ","ディオス","バディオス","ミルワ","ポーフィック"},
            new string[]{"マツ","カルフォ","マニフォ","モンティノ","カンディ"},
            new string[]{"ディアル","バディアル","ディアルコ","ラツマピック"},
            new string[]{"ロミルワ","リトカン","バマツ","ラツモフィス","マポーフィック"},
            new string[]{"ディアルマ","バディアルマ","ディ","バディ"},
            new string[]{"ロルト","マディ","マバディ","ロクトフェイト"},
            new string[]{ "マリクト", "カドルト" }
        };
        static public readonly string[][] Wiz5SFCSpellM = new string[][]
        {
            new string[]{"カティノ","ハリト","デュマピック","モグレフ"},
            new string[]{"ポンチ","メリト","デスト","モーリス","ボラツ"},
            new string[]{"カリフィック","マハリト","コルツ","カンティオス"},
            new string[]{"ツザリク","ラハリト","リトフェイト","ロクド"},
            new string[]{"ソコルディ","マダルト","パリオス","バスカイアー","バコルツ"},
            new string[]{"マモグレフ","ジルワン","ロカラ","ラダルト"},
            new string[]{"マロール", "マハマン", "ティルトウェイト", "アブリエル", "マウジウツ"}
        };
        static public readonly string[][] Wiz5SFCSpellP = new string[][]
        {
            new string[]{"ディオス","バディオス","ミルワ","カルキ","ポーフィック"},
            new string[]{"カツ","カルフォ","モンティノ","カンディ"},
            new string[]{"ラツマピック","ディアルコ","バマツ","ロミルワ","ハカニド"},
            new string[]{"ディアル","バディアル","ラツモフィス","マポーフィック","バリコ"},
            new string[]{"ディアルマ","バディ","ディ","バモルディ","モガト"},
            new string[]{"ロクトフェイト","マディ","ラバディ","カカメン"},
            new string[]{"マバリコ", "カドルト", "イハロン", "バカディ"}
        };
        static public readonly string[][] WizGBCSpellM = new string[][]
        {
            new string[]{"ハリト","モグレフ","カティノ","デュマピック"},
            new string[]{"メリト","ディルト","ソピック"},
            new string[]{"マハリト","モリト","モーリス","カンディ"},
            new string[]{"ラハリト","マモリト","ダルト"},
            new string[]{"マダルト","マカニト","マモーリス","ジルワン"},
            new string[]{"ラダルト","ラカニト","マソピック","ハマン"},
            new string[]{"ティルトウェイト", "マロール", "マハマン"}
        };
        static public readonly string[][] WizGBCSpellP = new string[][]
        {
            new string[]{"ディオス","バディオス","カルキ","ポーフィック","ミルワ"},
            new string[]{"モンティノ","マニフォ","マツ","カルフォ"},
            new string[]{"ディアル","バディアル","ディアルコ","ラツマピック"},
            new string[]{"ラツモフィス","リトカン","バマツ","マポーフィック","ロミルワ"},
            new string[]{"ディアルマ","バディアルマ","ディ","バディ"},
            new string[]{"マディ","マバディ","ロルト","ロクトフェイト"},
            new string[]{ "マリクト", "バカディ", "カドルト" }
        };
        #endregion

        // **********************************************************************
        public WizSpellList()
        {
            this.ForeColor = Color.White;
            this.BackColor = Color.Black;

            this.Font = new Font(this.Font.FontFamily, 12);

            this.Size = new Size(700, 400);
           
            this.SetStyle(
           ControlStyles.DoubleBuffer |
           ControlStyles.UserPaint |
           ControlStyles.AllPaintingInWmPaint,
           true);

        }
        // **********************************************************************
        protected override void OnPaint(PaintEventArgs e)
        {
            base.OnPaint(e);

            //if (m_state == null) return;

            if (m_spell.Length <= 0) return;

            Graphics g = e.Graphics;

            SolidBrush sb = new SolidBrush(this.BackColor);
            StringFormat sf = new StringFormat
            {
                LineAlignment = StringAlignment.Center
            };

            try
            {
                switch (m_scn)
                {
                    case WIZSCN.FC1:
                        DrawSpell(g, sb, sf,Wiz1FCSpellM,Wiz1FCSpellP);
                        break;
                    case WIZSCN.FC2:
                        DrawSpell(g, sb, sf, Wiz2FCSpellM, Wiz2FCSpellP);
                        break;
                    case WIZSCN.FC3:
                        DrawSpell(g, sb, sf, Wiz3FCSpellM, Wiz3FCSpellP);
                        break;
                    case WIZSCN.SFC1:
                    case WIZSCN.SFC2:
                        DrawSpell(g, sb, sf, Wiz1SFCSpellM, Wiz1SFCSpellP);
                        break;
                    case WIZSCN.SFC3:
                        DrawSpell(g, sb, sf, Wiz3SFCSpellM, Wiz3SFCSpellP);
                        break;
                    case WIZSCN.SFC5:
                        DrawSpell(g, sb, sf, Wiz5SFCSpellM, Wiz5SFCSpellP);
                        break;
                    case WIZSCN.GBC1:
                    case WIZSCN.GBC2:
                    case WIZSCN.GBC3:
                        DrawSpell(g, sb, sf, WizGBCSpellM, WizGBCSpellP);
                        break;
                }

            }
            finally
            {
                sb.Dispose();
                sf.Dispose();
            }

        }
       
        // **********************************************************************
        private void DrawSpell(Graphics g, SolidBrush sb, StringFormat sf,string [][] m,string [][] p)
        {
            if (m_spell.Length != 14) return;
            sf.Alignment = StringAlignment.Near;
            sf.LineAlignment = StringAlignment.Center;

            sb.Color = this.ForeColor;

            Rectangle rct;
            int cnt = 0;
            int x = m_LeftMgn;
            int y = m_TopMgn;
            for (int j = 0; j < 7; j++)
            {
                cnt = m[j].Length;
                byte b = m_spell[j];

                y = m_TopMgn;
                for (int i = 0; i < cnt; i++)
                {
                    rct = new Rectangle(x, y, m_SpellWidth, m_LineHeight);

                    if ((b & 0x01) == 1)
                    {
                        sb.Color = Color.Yellow;
                    }
                    else
                    {
                        sb.Color = Color.DarkGray;
                    }
                    g.DrawString(m[j][i], this.Font, sb, rct, sf);

                    b = (byte)(b >> 1);
                    y += m_LineHeight;

                }
                x += m_SpellWidth;
            }
            cnt = 0;
            x = m_LeftMgn;
            y = LineHeightALL;
            for (int j = 0; j < 7; j++)
            {
                cnt = p[j].Length;
                byte b = m_spell[j + 7];

                y = LineHeightALL + m_TopMgn;
                for (int i = 0; i < cnt; i++)
                {
                    rct = new Rectangle(x, y, m_SpellWidth, m_LineHeight);

                    if ((b & 0x01) == 1)
                    {
                        sb.Color = Color.Yellow;
                    }
                    else
                    {
                        sb.Color = Color.DarkGray;
                    }
                    g.DrawString(p[j][i], this.Font, sb, rct, sf);

                    b = (byte)(b >> 1);
                    y += m_LineHeight;
                }
                x += m_SpellWidth;
            }
        }
        // **********************************************************************
        protected override void OnMouseDown(MouseEventArgs e)
        {
            base.OnMouseDown(e);
            int x = (e.X - m_LeftMgn) / m_SpellWidth;
            if ((x < 0) || (x >= 7)) return;
            int y = (e.Y - m_TopMgn) / m_LineHeight;
            if ((y < 0) || (y >= 11)) return;

            int cnt = 0;
           
            bool isM = true;
            if (y>=5)
            {
                isM = false;
                y = y - 5;
                 
            }
            string[][] m = null;
            string[][] p = null;
            switch (m_scn)
            {
                case WIZSCN.FC1: m = Wiz1FCSpellM; p = Wiz1FCSpellP; break;
                case WIZSCN.FC2: m = Wiz2FCSpellM; p = Wiz2FCSpellP; break;
                case WIZSCN.FC3: m = Wiz3FCSpellM; p = Wiz3FCSpellP; break;
                case WIZSCN.SFC1:
                case WIZSCN.SFC2: m = Wiz1SFCSpellM; p = Wiz1SFCSpellP; break;
                case WIZSCN.SFC3: m = Wiz3SFCSpellM; p = Wiz3SFCSpellP; break;
                case WIZSCN.SFC5: m = Wiz5SFCSpellM; p = Wiz5SFCSpellP; break;
                case WIZSCN.GBC1:
                case WIZSCN.GBC2:
                case WIZSCN.GBC3: m = WizGBCSpellM; p = WizGBCSpellP; break;
            }
            if (isM)
            {
                cnt = m[x].Length;
                if (y < cnt)
                {
                    byte a2 = (byte)(0x01 << y);
                    m_spell[x] = (byte)(m_spell[x] ^ a2);
                    this.Invalidate();
                }
            }
            else
            {
                cnt = p[x].Length;
                if (y < cnt)
                {
                    byte a2 = (byte)(0x01 << y);
                    m_spell[x + 7] = (byte)(m_spell[x + 7] ^ a2);
                    this.Invalidate();
                }
            }
            



        }
        // **********************************************************************
        public void GetALL()
        {
            for (int i=0; i<m_spell.Length;i++)
            {
                m_spell[i] = 0xFF;
            }
            this.Invalidate();
        }
        public void ForgetALL()
        {
            for (int i = 0; i < m_spell.Length; i++)
            {
                m_spell[i] = 0;
            }
            this.Invalidate();
        }
        // **********************************************************************
        static public byte [] SpellBaseCount(WIZSCN scn)
        {
            byte[] ret = new byte[14];
            for (int i = 0; i < 14; i++) ret[i] = 0;

            string[][] m = null;
            string[][] p = null;

            switch (scn)
            {
                case WIZSCN.FC1:
                    m = Wiz1FCSpellM;
                    p = Wiz1FCSpellP;
                    break;
                case WIZSCN.FC2:
                    m = Wiz2FCSpellM;
                    p = Wiz2FCSpellP;
                    break;
                case WIZSCN.FC3:
                    m = Wiz3FCSpellM;
                    p = Wiz3FCSpellP;
                    break;
                case WIZSCN.SFC1:
                case WIZSCN.SFC2:
                    m = Wiz1SFCSpellM;
                    p = Wiz1SFCSpellP;
                    break;
                case WIZSCN.SFC3:
                    m = Wiz3SFCSpellM;
                    p = Wiz3SFCSpellP;
                    break;
                case WIZSCN.SFC5:
                    m = Wiz5SFCSpellM;
                    p = Wiz5SFCSpellP;
                    break;
                case WIZSCN.GBC1:
                case WIZSCN.GBC2:
                case WIZSCN.GBC3:
                    m = WizGBCSpellM;
                    p = WizGBCSpellP;
                    break;
            }

            for (int i = 0; i < 7; i++)
            {
                int v = m[i].Length & 0xF;
                ret[i] = (byte)(v);
                v = p[i].Length & 0xF;
                ret[i + 7] = (byte)(v);
            }
            return ret;
        }
    }
}

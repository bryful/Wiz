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
        private readonly string[][] WizFC1Spell = new string[][]
        {
            new string[]{"ハリト","モグレフ","カティノ","デュマピック","ディルト","ソピック","マハリト","モリト"},
            new string[]{"モーリス","ダルト","ラハリト","マモーリス","	マカニト","マダルト","ラカニト","ジルワン"},
            new string[]{"マゾピック","ハマン","マロール","マハマン","ティルトウェイト","カルキ","ディオス","バディオス"},
            new string[]{"ミルワ","ポーフィック","マツ","カルフォ","マニフォ","モンティノ","ロミルワ","ディアルコ"},
            new string[]{"ラツマピック","バマツ","ディアル","バディアル	","ラツモフィス","マポーフィック","ディアルマ","バディアルマ"},
            new string[]{"リトカン","カンディ","ディ","バディ","ロルト","マディ","マバディ","ロクトフェイト"},
            new string[]{"マリクト","カドルト"}
        };

        private readonly string[][] Wiz2FCSpellM = new string[][]
        {
            new string[]{"ハリト","モグレフ","カティノ","デュマピック"},
            new string[]{"ディルト","ソピック"},
            new string[]{"マハリト","モリト"},
            new string[]{"モーリス","ダルト","ラハリト"},
            new string[]{"マモーリス","マカニト","マダルト"},
            new string[]{"ラカニト","ジルワン","マゾピック","ハマン"},
            new string[]{"マロール","マハマン","ティルトウェイト"}

        };
        private readonly string[][] Wiz2FCSpellP = new string[][]
        {
            new string[]{"カルキ","ディオス","バディオス","ミルワ","ポーフィック"},
            new string[]{"マツ","カルフォ","マニフォ","モンティノ"},
            new string[]{"ロミルワ","ディアルコ","ラツマピック","バマツ"},
            new string[]{"ディアル","バディアル","ラツモフィス","マポーフィック"},
            new string[]{"ディアルマ","バディアルマ","リトカン","カンディ","ディ","バディ"},
            new string[]{"ロルト","マディ","マバディ","ロクトフェイト"},
            new string[]{"マリクト","カドルト"},

        };

        private readonly string[][] Wiz3FCSpellM = new string[][]
        {
            new string[]{"ハリト","モグレフ","カティノ","デュマピック"},
            new string[]{"ディルト","ソピック","メリト"},
            new string[]{"マハリト","モリト","モーリス"},
            new string[]{"ツザリク","ダルト","ラハリト"},
            new string[]{"マモーリス","マカニト","マダルト","ジルワン"},
            new string[]{"ラカニト","マゾピック","ハマン","ラダルト"},
            new string[]{"マロール","マハマン","ティルトウェイト"},

        };
        private readonly string[][] Wiz3FCSpellP = new string[][]
        {
            new string[]{"カルキ","ディオス","バディオス","ミルワ","ポーフィック"},
            new string[]{"マツ","カルフォ","マニフォ","モンティノ","カンディ"},
            new string[]{"ディアル","バディアル","ディアルコ","ラツマピック"},
            new string[]{"ロミルワ","リトカン","バマツ","ラツモフィス","マポーフィック"},
            new string[]{"ディアルマ","バディアルマ","ディ","バディ"},
            new string[]{"ロルト","マディ","マバディ","ロクトフェイト"},
            new string[]{"マリクト","カドルト"},

        };
        private readonly string[][] Wiz1SFCSpellM = new string[][]
        {
            new string[]{"ハリト","モグレフ","カティノ","デュマピック"},
            new string[]{"ディルト","ソピック"},
            new string[]{"マハリト","モリト"},
            new string[]{"モーリス","ダルト","ラハリト"},
            new string[]{"マモーリス","マカニト","マダルト"},
            new string[]{"ラカニト","ジルワン","マゾピック","ハマン"},
            new string[]{"マロール", "マハマン", "ティルトウェイト"}
        };
        private readonly string[][] Wiz1SFCSpellP = new string[][]
        {
            new string[]{"カルキ","ディオス","バディオス","ミルワ","ポーフィック"},
            new string[]{"マツ","カルフォ","マニフォ","モンティノ"},
            new string[]{"ロミルワ","ディアルコ","ラツマピック","バマツ"},
            new string[]{"ディアル","バディアル","ラツモフィス","マポーフィック"},
            new string[]{"ディアルマ","バディアルマ","リトカン","カンディ","ディ","バディ"},
            new string[]{"ロルト","マディ","マバディ","ロクトフェイト"},
            new string[]{"マリクト", "カドルト" }
        };
        private readonly string[][] Wiz3SFCSpellM = new string[][]
        {
            new string[]{"ハリト","モグレフ","カティノ","デュマピック"},
            new string[]{"ディルト","ソピック","メリト"},
            new string[]{"マハリト","モリト","モーリス"},
            new string[]{"ツザリク","ダルト","ラハリト"},
            new string[]{"マモーリス","マカニト","マダルト","ジルワン"},
            new string[]{"ラカニト","マゾピック","ハマン","ラダルト"},
            new string[]{"マハマン","ティルトウェイト"}
        };
        private readonly string[][] Wiz3SFCSpellP = new string[][]
        {
            new string[]{"カルキ","ディオス","バディオス","ミルワ","ポーフィック"},
            new string[]{"マツ","カルフォ","マニフォ","モンティノ","カンディ"},
            new string[]{"ディアル","バディアル","ディアルコ","ラツマピック"},
            new string[]{"ロミルワ","リトカン","バマツ","ラツモフィス","マポーフィック"},
            new string[]{"ディアルマ","バディアルマ","ディ","バディ"},
            new string[]{"ロルト","マディ","マバディ","ロクトフェイト"},
            new string[]{ "マリクト", "カドルト" }
        };
        private readonly string[][] Wiz5SFCSpellM = new string[][]
        {
            new string[]{"カティノ","ハリト","デュマピック","モグレフ"},
            new string[]{"ポンチ","メリト","デスト","モーリス","ボラツ"},
            new string[]{"カリフィック","マハリト","コルツ","カンティオス"},
            new string[]{"ツザリク","ラハリト","リトフェイト","ロクド"},
            new string[]{"ソコルディ","マダルト","パリオス","バスカイアー","バコルツ"},
            new string[]{"マモグレフ","ジルワン","ロカラ","ラダルト"},
            new string[]{"マロール", "マハマン", "ティルトウェイト", "アブリエル", "マウジウツ"}
        };
        private readonly string[][] Wiz5SFCSpellP = new string[][]
        {
            new string[]{"ディオス","バディオス","ミルワ","カルキ","ポーフィック"},
            new string[]{"カツ","カルフォ","モンティノ","カンディ"},
            new string[]{"ラツマピック","ディアルコ","バマツ","ロミルワ","ハカニド"},
            new string[]{"ディアル","バディアル","ラツモフィス","マポーフィック","バリコ"},
            new string[]{"ディアルマ","バディ","ディ","バモルディ","モガト"},
            new string[]{"ロクトフェイト","マディ","ラバディ","カカメン"},
            new string[]{"マバリコ", "カドルト", "イハロン", "バカディ"}
        };
        private readonly string[][] WizGBCSpellM = new string[][]
        {
            new string[]{"ハリト","モグレフ","カティノ","デュマピック"},
            new string[]{"メリト","ディルト","ソピック"},
            new string[]{"マハリト","モリト","モーリス","カンディ"},
            new string[]{"ラハリト","マモリト","ダルト"},
            new string[]{"マダルト","マカニト","マモーリス","ジルワン"},
            new string[]{"ラダルト","ラカニト","マソピック","ハマン"},
            new string[]{"ティルトウェイト", "マロール", "マハマン"}
        };
        private readonly string[][] WizGBCSpellP = new string[][]
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
            StringFormat sf = new StringFormat();
            sf.LineAlignment = StringAlignment.Center;

            try
            {
                switch (m_scn)
                {
                    case WIZSCN.FC1:
                        DrawSpellFC1(g, sb, sf);
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
        private void DrawSpellFC1(Graphics g, SolidBrush sb, StringFormat sf)
        {
            if (m_spell.Length != 7) return;
            sf.Alignment = StringAlignment.Near;
            sf.LineAlignment = StringAlignment.Center;

            sb.Color = this.ForeColor;

            Rectangle rct;
            int cnt = WizFC1Spell[0].Length;
            int x = m_LeftMgn;

            for (int j = 0; j < 7; j++)
            {
                cnt = WizFC1Spell[j].Length;
                byte b = m_spell[j];

                for (int i = 0; i < cnt; i++)
                {
                    rct = new Rectangle(x, m_TopMgn + m_LineHeight * i, m_SpellWidth, m_LineHeight);

                    if ((b & 0x01) == 1)
                    {
                        sb.Color = Color.Yellow;
                    }
                    else
                    {
                        sb.Color = Color.DarkGray;
                    }
                    g.DrawString(WizFC1Spell[j][i], this.Font, sb, rct, sf);

                    b = (byte)(b >> 1);

                }
                x += m_SpellWidth;
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
            if(m_scn==WIZSCN.FC1)
            {
                cnt = WizFC1Spell[x].Length;
                if (y >= cnt) return;
                byte a = (byte)(0x01 << y);
                m_spell[x] = (byte)(m_spell[x] ^ a);
                this.Invalidate();
            }
            else
            {
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
    }
}

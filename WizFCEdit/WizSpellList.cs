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
                            m_scn = WIZSCN.S1;
                        }
                        this.Invalidate();
                    }

                }
            }
        }
        private WIZSCN m_scn = WIZSCN.S1;
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
        #endregion

        // **********************************************************************

        // **********************************************************************

        #region Data
        private readonly string[][] Wiz1Spell = new string[][]
        {
            new string[]{"ハリト","モグレフ","カティノ","デュマピック","ディルト","ソピック","マハリト","モリト"},
            new string[]{"モーリス","ダルト","ラハリト","マモーリス","	マカニト","マダルト","ラカニト","ジルワン"},
            new string[]{"マゾピック","ハマン","マロール","マハマン","ティルトウェイト","カルキ","ディオス","バディオス"},
            new string[]{"ミルワ","ポーフィック","マツ","カルフォ","マニフォ","モンティノ","ロミルワ","ディアルコ"},
            new string[]{"ラツマピック","バマツ","ディアル","バディアル	","ラツモフィス","マポーフィック","ディアルマ","バディアルマ"},
            new string[]{"リトカン","カンディ","ディ","バディ","ロルト","マディ","マバディ","ロクトフェイト"},
            new string[]{"マリクト","カドルト"}
        };

        private readonly string[][] Wiz2SpellM = new string[][]
        {
            new string[]{"ハリト","モグレフ","カティノ","デュマピック"},
            new string[]{"ディルト","ソピック"},
            new string[]{"マハリト","モリト"},
            new string[]{"モーリス","ダルト","ラハリト"},
            new string[]{"マモーリス","マカニト","マダルト"},
            new string[]{"ラカニト","ジルワン","マゾピック","ハマン"},
            new string[]{"マロール","マハマン","ティルトウェイト"}

        };
        private readonly string[][] Wiz2SpellP = new string[][]
        {
            new string[]{"カルキ","ディオス","バディオス","ミルワ","ポーフィック"},
            new string[]{"マツ","カルフォ","マニフォ","モンティノ"},
            new string[]{"ロミルワ","ディアルコ","ラツマピック","バマツ"},
            new string[]{"ディアル","バディアル","ラツモフィス","マポーフィック"},
            new string[]{"ディアルマ","バディアルマ","リトカン","カンディ","ディ","バディ"},
            new string[]{"ロルト","マディ","マバディ","ロクトフェイト"},
            new string[]{"マリクト","カドルト"},

        };

        private readonly string[][] Wiz3SpellM = new string[][]
        {
            new string[]{"ハリト","モグレフ","カティノ","デュマピック"},
            new string[]{"ディルト","ソピック","メリト"},
            new string[]{"マハリト","モリト","モーリス"},
            new string[]{"ツザリク","ダルト","ラハリト"},
            new string[]{"マモーリス","マカニト","マダルト","ジルワン"},
            new string[]{"ラカニト","マゾピック","ハマン","ラダルト"},
            new string[]{"マロール","マハマン","ティルトウェイト"},

        };
        private readonly string[][] Wiz3SpellP = new string[][]
        {
            new string[]{"カルキ","ディオス","バディオス","ミルワ","ポーフィック"},
            new string[]{"マツ","カルフォ","マニフォ","モンティノ","カンディ"},
            new string[]{"ディアル","バディアル","ディアルコ","ラツマピック"},
            new string[]{"ロミルワ","リトカン","バマツ","ラツモフィス","マポーフィック"},
            new string[]{"ディアルマ","バディアルマ","ディ","バディ"},
            new string[]{"ロルト","マディ","マバディ","ロクトフェイト"},
            new string[]{"マリクト","カドルト"},

        };
        #endregion

        // **********************************************************************
        public WizSpellList()
        {
            this.ForeColor = Color.White;
            this.BackColor = Color.Black;

            this.Font = new Font(this.Font.FontFamily, 12);

            this.Size = new Size(700, 300);
            //this.MinimumSize = this.Size;
            //this.MaximumSize = this.Size;

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
                    case WIZSCN.S1:
                        DrawSpell1(g, sb, sf);
                        break;
                    case WIZSCN.S2:
                        DrawSpell2(g, sb, sf);
                        break;
                    case WIZSCN.S3:
                        DrawSpell3(g, sb, sf);
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
        private void DrawSpell1(Graphics g, SolidBrush sb, StringFormat sf)
        {
            if (m_spell.Length != 7) return;
            sf.Alignment = StringAlignment.Near;
            sf.LineAlignment = StringAlignment.Center;

            sb.Color = this.ForeColor;

            Rectangle rct;
            int cnt = Wiz1Spell[0].Length;
            int x = m_LeftMgn;

            for (int j = 0; j < 7; j++)
            {
                cnt = Wiz1Spell[j].Length;
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
                    g.DrawString(Wiz1Spell[j][i], this.Font, sb, rct, sf);

                    b = (byte)(b >> 1);

                }
                x += m_SpellWidth;
            }
        }
        // **********************************************************************
        private void DrawSpell2(Graphics g, SolidBrush sb, StringFormat sf)
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
                cnt = Wiz2SpellM[j].Length;
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
                    g.DrawString(Wiz2SpellM[j][i], this.Font, sb, rct, sf);

                    b = (byte)(b >> 1);
                    y += m_LineHeight;

                }
                x += m_SpellWidth;
            }
            cnt = 0;
            x = m_LeftMgn;
            for (int j = 0; j < 7; j++)
            {
                cnt = Wiz2SpellP[j].Length;
                byte b = m_spell[j + 7];

                y = m_LineHeight * 4 + m_TopMgn;
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
                    g.DrawString(Wiz2SpellP[j][i], this.Font, sb, rct, sf);

                    b = (byte)(b >> 1);
                    y += m_LineHeight;
                }
                x += m_SpellWidth;
            }
        }
        // **********************************************************************
        private void DrawSpell3(Graphics g, SolidBrush sb, StringFormat sf)
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
                cnt = Wiz3SpellM[j].Length;
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
                    g.DrawString(Wiz3SpellM[j][i], this.Font, sb, rct, sf);

                    b = (byte)(b >> 1);
                    y += m_LineHeight;

                }
                x += m_SpellWidth;
            }
            cnt = 0;
            x = m_LeftMgn;
            for (int j = 0; j < 7; j++)
            {
                cnt = Wiz3SpellP[j].Length;
                byte b = m_spell[j + 7];

                y = m_LineHeight * 4 + m_TopMgn;
                for (int i = 0; i < cnt; i++)
                {
                    rct = new Rectangle(x, y, m_SpellWidth, m_LineHeight);

                    if ((b & 0x01) == 1)
                    {
                        sb.Color =Color.Yellow;
                    }
                    else
                    {
                        sb.Color = Color.DarkGray;
                    }
                    g.DrawString(Wiz3SpellP[j][i], this.Font, sb, rct, sf);

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
            if ((y < 0) || (y >= 10)) return;

            int cnt = 0;
            switch (m_scn)
            {
                case WIZSCN.S1:
                    cnt = Wiz1Spell[x].Length;
                    if (y >= cnt) return;
                    byte a = (byte)(0x01 << y);
                    m_spell[x] = (byte)(m_spell[x] ^ a);
                    this.Invalidate();
                    break;
                case WIZSCN.S2:
                    if(y<4)
                    {
                        cnt = Wiz2SpellM[x].Length;
                        if(y<cnt)
                        {
                            byte a2 = (byte)(0x01 << y);
                            m_spell[x] = (byte)(m_spell[x] ^ a2);
                            this.Invalidate();
                        }
                    }
                    else
                    {
                        y -= 4;
                        cnt = Wiz2SpellP[x].Length;
                        if (y < cnt)
                        {
                            byte a2 = (byte)(0x01 << y);
                            m_spell[x+7] = (byte)(m_spell[x+7] ^ a2);
                            this.Invalidate();
                        }
                    }
                    break;
                case WIZSCN.S3:
                    if (y < 4)
                    {
                        cnt = Wiz3SpellM[x].Length;
                        if (y < cnt)
                        {
                            byte a2 = (byte)(0x01 << y);
                            m_spell[x] = (byte)(m_spell[x] ^ a2);
                            this.Invalidate();
                        }
                    }
                    else
                    {
                        y -= 4;
                        cnt = Wiz3SpellP[x].Length;
                        if (y < cnt)
                        {
                            byte a2 = (byte)(0x01 << y);
                            m_spell[x + 7] = (byte)(m_spell[x + 7] ^ a2);
                            this.Invalidate();
                        }
                    }
                    break;
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

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
    public class WizBox
    {
        public int LeftMargin = 5;
        public int RightMargin = 5;
        public int TopMargin = 5;
        public int BottomMargin = 5;
        public int Corner = 5;
        public int LineWidth = 3;

        public Color BackColor = Color.Black;
        public Color ForeColor = Color.White;

        public Graphics Graphics = null;
        public int Left = 0;
        public int Top = 0;
        public int Width = 0;
        public int Height = 0;
        public Size Size
        {
            get { return new Size(Width, Height); }
            set { Width = value.Width;Height = value.Height; }
        }
        public Point Location
        {
            get { return new Point(Left, Top); }
            set { Left = value.X; Top = value.Y; }
        }
        public Rectangle Rectangle
        {
            get { return new Rectangle(Left, Top, Width, Height); }
            set
            {
                Left = value.Left;
                Top = value.Top;
                Width = value.Width;
                Height = value.Height;
            }
        }

        public WizBox()
        {

        }
        public void FillFrame()
        {
            if (Graphics == null) return;
            if ((Width <= 0) || (Height <= 0)) return;
            SolidBrush sb = new SolidBrush(BackColor);

            try
            {
                Graphics.FillRectangle(sb, new Rectangle(Left, Top, Width, Height));
                /*
                Point[] ps = {
                    new Point(Left + LeftMargin, Top + TopMargin+Corner),
                    new Point(Left + LeftMargin+Corner, Top + TopMargin),
                    new Point(Left + Width - RightMargin - Corner, Top + TopMargin),
                    new Point(Left + Width - RightMargin , Top + TopMargin+Corner),
                    new Point(Left + Width - RightMargin , Top + Height-BottomMargin-Corner),
                    new Point(Left + Width - LeftMargin - Corner, Top + Height - BottomMargin),
                    new Point(Left + LeftMargin + Corner, Top + Height -  BottomMargin),
                    new Point(Left + LeftMargin , Top + Height - BottomMargin - Corner)
                    };
                Graphics.FillPolygon(sb,ps);
                */
            }
            finally
            {
                sb.Dispose();
            }
        }
        public void DrawFrame()
        {
            if (Graphics == null) return;
            if ((Width <= 0) || (Height <= 0)) return;
            SolidBrush sb = new SolidBrush(BackColor);
            Pen pn = new Pen(ForeColor);
            pn.Width = LineWidth;
            pn.LineJoin = LineJoin.Round;

            try
            {
                //塗りつぶし
                Graphics.FillRectangle(sb, new Rectangle(Left, Top, Width, Height));
                if (LineWidth > 0)
                {
                    Point[] ps = {
                        new Point(Left + LeftMargin, Top + TopMargin+Corner),
                        new Point(Left + LeftMargin+Corner, Top + TopMargin),
                        new Point(Left + Width - RightMargin - Corner, Top + TopMargin),
                        new Point(Left + Width - RightMargin , Top + TopMargin+Corner),
                        new Point(Left + Width - RightMargin , Top + Height-BottomMargin-Corner),
                        new Point(Left + Width - LeftMargin - Corner, Top + Height - BottomMargin),
                        new Point(Left + LeftMargin + Corner, Top + Height -  BottomMargin),
                        new Point(Left + LeftMargin , Top + Height - BottomMargin - Corner)
                        };
                    Graphics.DrawPolygon(pn, ps);
                }

            }
            finally
            {
                sb.Dispose();
                pn.Dispose();
            }
        }
    }
    public class WizU
    {
        /// <summary>
        /// 30x20の右矢印の描画
        /// 描画はYのセンター
        /// </summary>
        /// <param name="g"></param>
        /// <param name="x"></param>
        /// <param name="y"></param>
        static public void DrawCursor(Graphics g, SolidBrush sb,int x, int y)
        {
            int[,] p = new int[,] { { 0, -2 }, { 8, -2 }, { 8, -6 }, { 20, 0 }, { 8, 6 }, { 8, 2 }, { 0, 2 } };
            Point[] ps = {
                new Point(p[0,0]+x,p[0,1]+y),
                new Point(p[1,0]+x,p[1,1]+y),
                new Point(p[2,0]+x,p[2,1]+y),
                new Point(p[3,0]+x,p[3,1]+y),
                new Point(p[4,0]+x,p[4,1]+y),
                new Point(p[5,0]+x,p[5,1]+y),
                new Point(p[6,0]+x,p[6,1]+y) };

            g.FillPolygon(sb, ps);

        }
        static public void DrawCursor(Graphics g, SolidBrush sb, Point pt)
        {
            DrawCursor(g, sb, pt.X, pt.Y);
        }
        // ***********************************************************************
        //
        // ***********************************************************************
        static public int FromWizHex(byte v)
        {
            int p0 = v & 0xF;
            if (p0 > 0x09) p0 = 0x09;
            int p1 = (v >> 4) & 0xF;
            if (p1 > 0x09) p1 = 0x09;
            return p1 * 10 + p0;
        }
        static public byte ToWizHex(int v)
        {
            byte p0 = (byte)(v % 10);
            byte p1 = (byte)((v / 10) % 10);

            return (byte)(((p1 << 4) | p0) & 0xFF);
        }
        // ***************************************************
        static public long WizHexToLong(byte[] v)
        {
            long ret = 0;
             for ( int i=0; i<v.Length;i++)
            {
                ret = (ret * 100) + FromWizHex(v[i]);
            }
            return ret;
        }
        // ***************************************************
        static public byte[] LongToWizHex(long v)
        {
            byte [] ret = new byte[6];
            if (v < 0) v = 0;
            else if (v > 0xFFFFFFFFFFFF) v = 0xFFFFFFFFFFFF;

            for ( int i = 5; i>=0;i--)
            {
                ret[i] = ToWizHex((int)(v % 100));
                v /= 100;
            }

            return ret;
        }
    }
}

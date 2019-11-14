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

        public Color Back = Color.Black;
        public Color Fore = Color.White;

        public Graphics Graphics = null;
        public int Width = 0;
        public int Height = 0;

        public Size Size
        {
            get { return new Size(Width, Height); }
            set
            {
                Width = value.Width;
                Height = value.Height;
            }
        }
        public WizBox()
        {

        }
        public void DrawFrame()
        {
            if (Graphics == null) return;
            if ((Width <= 0) || (Height <= 0)) return;
            SolidBrush sb = new SolidBrush(Back);
            Pen pn = new Pen(Fore);
            pn.Width = LineWidth;
            pn.LineJoin = LineJoin.Round;

            try
            {
                //塗りつぶし
                Graphics.FillRectangle(sb, new Rectangle(0,0,Width,Height));
                if (LineWidth > 0)
                {
                    Point[] ps = {
                        new Point(LeftMargin, TopMargin+Corner),
                        new Point(LeftMargin+Corner, TopMargin),
                        new Point(Width - RightMargin - Corner, TopMargin),
                        new Point(Width - RightMargin , TopMargin+Corner),
                        new Point(Width - RightMargin , Height-BottomMargin-Corner),
                        new Point(Width - LeftMargin - Corner, Height - BottomMargin),
                        new Point(LeftMargin + Corner, Height -  BottomMargin),
                        new Point(LeftMargin , Height - BottomMargin - Corner)
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
        /// </summary>
        /// <param name="g"></param>
        /// <param name="x"></param>
        /// <param name="y"></param>
        static public void DrawCursor(Graphics g, SolidBrush sb,int x, int y)
        {
            int[,] p = new int[,] { { 0, 7 },{ 9, 6 },{ 9, 1 },{ 23, 10 },{ 9, 18 },{ 9, 12 },{ 0, 12 } };
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
    }
}

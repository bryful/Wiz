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

using System.IO;
namespace WizFCEdit
{
    public class PicData
    {
        public Bitmap bmp = null;
        public string name = "";
    }
    public class WizPictureBox :WizBoxControl
    {
        private List<PicData> m_PicDatas = new List<PicData>();

        private WizFCState m_state = null;
        public WizFCState WizNesState
        {
            get { return m_state; }
            set
            {
                m_state = value;
                if(m_state!=null)
                {
                    m_state.CurrentCharChanged += M_state_CurrentCharChanged;
                    m_state.LoadFileFinished += M_state_LoadFileFinished;
                    m_state.ValueChanged += M_state_ValueChanged;
                }
                this.Invalidate();
            }
        }

        private void M_state_ValueChanged(object sender, EventArgs e)
        {
            this.Invalidate();
        }

        private void M_state_LoadFileFinished(object sender, EventArgs e)
        {
            this.Invalidate();
        }

        private void M_state_CurrentCharChanged(object sender, CurrentCharEventArgs e)
        {
            this.Invalidate();
        }

        public WizPictureBox()
        {
 
            this.SetStyle(
                ControlStyles.DoubleBuffer |
                ControlStyles.UserPaint |
                ControlStyles.AllPaintingInWmPaint,
                true);
            this.Size = new Size(120, 120);
            this.MinimumSize = this.Size;
            this.MaximumSize = this.Size;

            this.LineWidth = 2;
            ListupFiles();

        }
        //----------------------------------------------------
        public void SetBmp(Image img)
        {
  
            this.Invalidate();
        }
        //----------------------------------------------------
        public int FindName(string nm)
        {
            int ret = 0;
            if (m_PicDatas.Count <= 0) return -1;
            if (nm == "") return ret;

            for (int i=1;i< m_PicDatas.Count;i++)
            {
                if(m_PicDatas[i].name==nm)
                {
                    ret = i;
                    break;
                }
            }

            return ret;
        }
        //----------------------------------------------------
        protected override void OnPaint(PaintEventArgs e)
        {
            base.OnPaint(e);
            if(m_state!=null)
            {
                int i = FindName(m_state.CharName);
                if(i>=0)
                {
                    e.Graphics.DrawImage(m_PicDatas[i].bmp, 10, 10);
                }
            }

        }
        public void ListupFiles()
        {
            m_PicDatas.Clear();

            m_PicDatas.Add(LoadResPicData(Properties.Resources._000, "_000"));
            m_PicDatas.Add(LoadResPicData(Properties.Resources.せんし１, "せんし１"));
            m_PicDatas.Add(LoadResPicData(Properties.Resources.せんし２, "せんし２"));
            m_PicDatas.Add(LoadResPicData(Properties.Resources.せんし３, "せんし３"));
            m_PicDatas.Add(LoadResPicData(Properties.Resources.そうりょ１, "そうりょ１"));
            m_PicDatas.Add(LoadResPicData(Properties.Resources.とうぞく１, "とうそ゛く１"));
            m_PicDatas.Add(LoadResPicData(Properties.Resources.まほうつかい１, "まほうつかい１"));
            m_PicDatas.Add(LoadResPicData(Properties.Resources.まほうつかい２, "まほうつかい２"));
            try
            {
                string path = Path.GetDirectoryName(Application.ExecutablePath);

                path = Path.Combine(path, "pic");
                if (Directory.Exists(path) == false)
                {
                    Directory.CreateDirectory(path);
                }
                string[] files = Directory.GetFiles(path, "*.*", SearchOption.AllDirectories);
                foreach (string s in files)
                {
                    string e = Path.GetExtension(s).ToLower();
                    if ((e == ".jpg") || (e == ".png") || (e == ".bmp"))
                    {
                        PicData pd = LoadPicData(s);
                        if (pd.name != "")
                        {
                            m_PicDatas.Add(pd);
                        }

                    }
                }
            }
            catch
            {

            }
        }
        public string NameChk(string s)
        {
            string ret = s;
            if(s.Length<8)
            {
                int ln = 8 - s.Length;
                for (int i=0;i<ln;i++)
                {
                    ret += "　";
                }
            }
            return ret;
        }
        public PicData LoadPicData(string s)
        {
            PicData ret = new PicData();
            try
            {
                Image img = Image.FromFile(s);
                ret.bmp = new Bitmap(100, 100);
                Graphics g = Graphics.FromImage(ret.bmp);
                int w = img.Width;
                if (img.Width > img.Height) w = img.Height;
                g.DrawImage(img, new Rectangle(0, 0, 100, 100), new Rectangle(0, 0, w, w), GraphicsUnit.Pixel);
                ret.name = Path.GetFileNameWithoutExtension(s);
            }
            catch
            {
                ret.name = "";
                ret.bmp = null;
            }
            return ret;
        }
        public PicData LoadResPicData(Bitmap bmp,string nm)
        {
            PicData ret = new PicData();
            try
            {
                ret.bmp = new Bitmap(100, 100);
                Graphics g = Graphics.FromImage(ret.bmp);
                int w = bmp.Width;
                if (bmp.Width > bmp.Height) w = bmp.Height;
                g.DrawImage(bmp, new Rectangle(0, 0, 100, 100), new Rectangle(0, 0, w, w), GraphicsUnit.Pixel);
                ret.name = nm;
            }
            catch
            {
                ret.name = "";
                ret.bmp = null;
            }
            return ret;
        }
    }
}

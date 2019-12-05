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
namespace WizEdit
{
    
    public class WizPictureBox :WizBoxControl
    {
        public class PicData
        {
            public Bitmap bmp = null;
            public string name = "";
        }
        private List<PicData> m_PicDatas = new List<PicData>();

        private string  m_PictureFolder = "";
        public string PicureFolderPath
        {
            get { return m_PictureFolder; }
            set
            {
                m_PictureFolder = value;
                ListupFiles();
                this.Invalidate();
            }
        }


        private WizData m_state = null;
        public WizData WizNesState
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
        public int FindNameSub(string nm)
        {
            int ret = -1;
            for (int i = 0; i < m_PicDatas.Count; i++)
            {
                if (m_PicDatas[i].name == nm)
                {
                    ret = i;
                    break;
                }
            }
            return ret;
        }
        //----------------------------------------------------
        public int FindName(string nm,WIZCLASS cls)
        {

            int ret = -1;
            if (m_PicDatas.Count <= 0) return -1;
            if ((nm == "-- NONE --")||(nm==""))
            {
                nm = "_None";
            }
            ret = FindNameSub(nm);
            if (ret == -1)
            {
                switch (cls)
                {
                    case WIZCLASS.FIG: nm = "FIG"; break;
                    case WIZCLASS.MAG: nm = "MAG"; break;
                    case WIZCLASS.PRI: nm = "PRI"; break;
                    case WIZCLASS.THI: nm = "THI"; break;
                    case WIZCLASS.BIS: nm = "BIS"; break;
                    case WIZCLASS.SAM: nm = "SAM"; break;
                    case WIZCLASS.LOR: nm = "LOR"; break;
                    case WIZCLASS.NIN: nm = "NIN"; break;
                }
                ret = FindNameSub(nm);
                if (ret == -1)
                {
                    nm = "_None";
                    ret = FindNameSub(nm);
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
                int i = FindName(m_state.CharName,m_state.CharClass);
                if(i>=0)
                {
                    e.Graphics.DrawImage(m_PicDatas[i].bmp, 10, 10);
                }
            }

        }
        // *****************************************************************************************************
        public void ListupFiles()
        {
            m_PicDatas.Clear();
            try
            {
                //画像フォルダがあるか確認なければ作る
                if (m_PictureFolder != "")
                {
                    //検索して画像のリストアップ
                    string[] files = Directory.GetFiles(m_PictureFolder, "*.*", SearchOption.AllDirectories);
                    foreach (string s in files)
                    {
                        string e = Path.GetExtension(s).ToLower();
                        if ((e == ".jpg") || (e == ".png") || (e == ".bmp"))
                        {
                            PicData pd = LoadPicData(s);
                            if (pd.name != "")
                            {
                                m_PicDatas.Add(pd);
                                if (m_PicDatas.Count > 30) break;
                            }

                        }
                    }
                }
            }
            catch
            {

            }
            m_PicDatas.Add(LoadResPicData(Properties.Resources._None, "_None"));
                m_PicDatas.Add(LoadResPicData(Properties.Resources.FIG, "FIG"));
                m_PicDatas.Add(LoadResPicData(Properties.Resources.MAG, "MAG"));
                m_PicDatas.Add(LoadResPicData(Properties.Resources.PRI, "PRI"));
                m_PicDatas.Add(LoadResPicData(Properties.Resources.BIS, "BIS"));
                m_PicDatas.Add(LoadResPicData(Properties.Resources.LOR, "LOR"));
                m_PicDatas.Add(LoadResPicData(Properties.Resources.SAM, "SAM"));
                m_PicDatas.Add(LoadResPicData(Properties.Resources.THI, "THI"));
                m_PicDatas.Add(LoadResPicData(Properties.Resources.NIN, "NIN"));
                m_PicDatas.Add(LoadResPicData(Properties.Resources.あ, "あ"));
                m_PicDatas.Add(LoadResPicData(Properties.Resources.あいね, "あいね"));
                m_PicDatas.Add(LoadResPicData(Properties.Resources.ひびき, "ひひ゛き"));
                m_PicDatas.Add(LoadResPicData(Properties.Resources.まいか, "まいか"));
                m_PicDatas.Add(LoadResPicData(Properties.Resources.まひる, "まひる"));
                m_PicDatas.Add(LoadResPicData(Properties.Resources.みお, "みお"));
                m_PicDatas.Add(LoadResPicData(Properties.Resources.ゆめ, "ゆめ"));
                m_PicDatas.Add(LoadResPicData(Properties.Resources.らき, "らき"));
                m_PicDatas.Add(LoadResPicData(Properties.Resources.アリシア, "アリシア"));
                m_PicDatas.Add(LoadResPicData(Properties.Resources.エルザ, "エルサ゛"));
                m_PicDatas.Add(LoadResPicData(Properties.Resources.カレン, "カレン"));
                m_PicDatas.Add(LoadResPicData(Properties.Resources.ミライ, "ミライ"));
           
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

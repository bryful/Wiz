﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

using System.Windows.Forms;

namespace Wiz5StateEdit
{
    public class Snes9xWizFive : ListBox
    {
        public event EventHandler LoadFileEvent;

        private Snes9xState m_state = new Snes9xState();
        private bool[] m_charEnabled = new bool[20];
        //---------------------------------------
        public Snes9xWizFive()
        {
            this.BackColor = System.Drawing.Color.Black;
            this.Font = new System.Drawing.Font("ＭＳ ゴシック", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(128)));
            this.ForeColor = System.Drawing.Color.White;
            this.Name = "snes9xWizFive";

            for (int i = 0; i < 20; i++) m_charEnabled[i] = false;
        }
        //
        //---------------------------------------
        public void Clear()
        {
            m_state.Clear();
            this.Items.Clear();
            for (int i = 0; i < 20; i++) m_charEnabled[i] = false;
            //OnLoadFileEvent(EventArgs.Empty);

        }
        //---------------------------------------
        public string GetCharName(int idx)
        {
            if (idx < 0) idx = 0;
            if (idx > 19) idx = 19;
            int cnt = (int)m_state.GetByte( 0x1001 + idx * 0x80);
            if ((cnt <= 0) || (cnt > 8)) return "";

            byte[] ba = m_state.GetByteArray(0x1002 + (idx * 0x80), cnt);

            return ByteArrayToStr(ba);

        }
        //---------------------------------------
        public string ByteToChr(byte b)
        {
            string[] rets = new string[]
            {
                "　","！","”","＃","＄","％","＆","’","（","）","＊","＋","，","－","．","／",
                "０","１","２","３","４","５","６","７","８","９","：","；","＜","＝","＞","？",
                "＠","Ａ","Ｂ","Ｃ","Ｄ","Ｅ","Ｆ","Ｇ","Ｈ","Ｉ","Ｊ","Ｋ","Ｌ","Ｍ","Ｎ","Ｏ",
                "Ｐ","Ｑ","Ｒ","Ｓ","Ｔ","Ｕ","Ｖ","Ｗ","Ｘ","Ｙ","Ｚ","[ ","￥"," ]","＾","＿",
                "｀","ａ","ｂ","ｃ","ｄ","ｅ","ｆ","ｇ","ｈ","ｉ","ｊ","ｋ","ｌ","ｍ","ｎ","ｏ",
                "ｐ","ｑ","ｒ","ｓ","ｔ","ｕ","ｖ","ｗ","ｘ","ｙ","ｚ","｛","　","｝","￣","　",
                "♣ ","♥ ","🍀 ","♦ ","○","●","を","ぁ","ぃ","ぅ","ぇ","ぉ","ゃ","ゅ","ょ","っ",
                "　","あ","い","う","え","お","か","き","く","け","こ","さ","し","す","せ","そ",
                "of","。","　","　","、","・","ヲ","ァ","ィ","ゥ","ェ","ォ","ャ","ュ","ョ","ッ",
                "－","ア","イ","ウ","エ","オ","カ","キ","ク","ケ","コ","サ","シ","ス","セ","ソ",
                "タ","チ","ツ","テ","ト","ナ","ニ","ヌ","ネ","ノ","ハ","ヒ","フ","ヘ","ホ","マ",
                "ミ","ム","メ","モ","ヤ","ユ","ヨ","ラ","リ","ル","レ","ロ","ワ","ン","゛","ﾟ",
                "た","ち","つ","て","と","な","に","ぬ","ね","の","は","ひ","ふ","へ","ほ","ま",
                "み","む","め","も","や","ゆ","よ","ら","り","る","れ","ろ","わ","ん","〟","。"
            };
            int idx = (int)b;
            if ((idx < 0x20) || (idx > 0xFF)) return "**";
            idx -= 0x20;
            return rets[idx];
        }
        //---------------------------------------
        public string ByteArrayToStr(byte[] ba)
        {
            string ret = "";

            if (ba.Length>0)
            {
                for ( int i=0; i<ba.Length; i++)
                {
                    ret += ByteToChr(ba[i]);
                }
            }
            return ret;
        }
        //---------------------------------------
        public bool Load(string p)
        {
            bool ret = m_state.Load(p);
            this.Items.Clear();
            if (ret== true)
            {
                for (int i=0; i<20;i++)
                {
                    string n = GetCharName(i);
                    m_charEnabled[i] = (n != "");
                    this.Items.Add(n);
                }
                this.SelectedIndex = 0;
                OnLoadFileEvent(EventArgs.Empty);
            }
            return ret;
        }
        //---------------------------------------
        protected virtual void OnLoadFileEvent(EventArgs e)
        {
            if (LoadFileEvent != null)
            {
                LoadFileEvent(this, e);
            }
        }
        //---------------------------------------
        public Snes9xState State
        {
            get { return m_state; }
        }
        public bool CharEnabled(int idx)
        {
            if ((idx < 0) || (idx >= 20)) return false;
            return m_charEnabled[idx];
        }
    }
}
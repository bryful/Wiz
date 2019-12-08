using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace WizEdit
{
    public class WizLimit
    {
        public event EventHandler ValueChanged;
        protected virtual void OnValueChanged(EventArgs e) { ValueChanged?.Invoke(this, e); }

        public bool LevelInit = true;

        public enum P
        {
            Level=0,
            Alg,
            Class,
            Race,
            Gold,
            Exp,
            Age,
            Week,
            HP,
            AC,
            Params,
            Status,
            MagicPoint,
            Spell,
            Item,
            ItemEqip,
            ItemInd,
            ItemCur,
            Name,
            Sort,
            Rip,
            Mark,
            Count
        };
        private bool[] m_values = new bool[(int)P.Count];
        public WizLimit()
        {
            Init();
        }
        public void Init()
        {
            for (int i = 0; i < m_values.Length; i++) m_values[i] = false;
            m_values[(int)P.Alg] = true;
            m_values[(int)P.Class] = true;
            m_values[(int)P.Race] = true;
            m_values[(int)P.Age] = true;
            m_values[(int)P.Params] = true;
            m_values[(int)P.Status] = true;
            LevelInit = true;
        }
        public void CopyFrom(WizLimit wl)
        {
            for (int i = 0; i < m_values.Length; i++)
            {
                m_values[i] = wl.m_values[i];
            }
            LevelInit = wl.LevelInit;
        }

        public bool IsLevel
        {
            get { return m_values[(int)P.Level]; }
            set { m_values[(int)P.Level] = value; }
        }
        public bool IsName
        {
            get { return m_values[(int)P.Name]; }
            set { m_values[(int)P.Name] = value; }
        }
        public bool IsAlg
        {
            get { return m_values[(int)P.Alg]; }
            set { m_values[(int)P.Alg] = value; }
        }
        public bool IsClass
        {
            get { return m_values[(int)P.Class]; }
            set { m_values[(int)P.Class] = value; }
        }
        public bool IsRace
        {
            get { return m_values[(int)P.Race]; }
            set { m_values[(int)P.Race] = value; }
        }
        public bool IsGold
        {
            get { return m_values[(int)P.Gold]; }
            set { m_values[(int)P.Gold] = value; }
        }
        public bool IsExp
        {
            get { return m_values[(int)P.Exp]; }
            set { m_values[(int)P.Exp] = value; }
        }
        public bool IsAge
        {
            get { return m_values[(int)P.Age]; }
            set { m_values[(int)P.Age] = value; }
        }
        public bool IsWeek
        {
            get { return m_values[(int)P.Week]; }
            set { m_values[(int)P.Week] = value; }
        }
        public bool IsHP
        {
            get { return m_values[(int)P.HP]; }
            set { m_values[(int)P.HP] = value; }
        }
        public bool IsAC
        {
            get { return m_values[(int)P.AC]; }
            set { m_values[(int)P.AC] = value; }
        }
        public bool IsParams
        {
            get { return m_values[(int)P.Params]; }
            set { m_values[(int)P.Params] = value; }
        }
        public bool IsStatus
        {
            get { return m_values[(int)P.Status]; }
            set { m_values[(int)P.Status] = value; }
        }
        public bool IsItem
        {
            get { return m_values[(int)P.Item]; }
            set { m_values[(int)P.Item] = value; }
        }
        public bool IsItemEqip
        {
            get { return m_values[(int)P.ItemEqip]; }
            set { m_values[(int)P.ItemEqip] = value; }
        }
        public bool IsItemInd
        {
            get { return m_values[(int)P.ItemInd]; }
            set { m_values[(int)P.ItemInd] = value; }
        }
        public bool IsItemCur
        {
            get { return m_values[(int)P.ItemCur]; }
            set { m_values[(int)P.ItemCur] = value; }
        }
        public bool IsMagicPoint
        {
            get { return m_values[(int)P.MagicPoint]; }
            set { m_values[(int)P.MagicPoint] = value; }
        }
        public bool IsSpell
        {
            get { return m_values[(int)P.Spell]; }
            set { m_values[(int)P.Spell] = value; }
        }
        public bool IsSort
        {
            get { return m_values[(int)P.Sort]; }
            set { m_values[(int)P.Sort] = value; }
        }
        public bool IsRip
        {
            get { return m_values[(int)P.Rip]; }
            set { m_values[(int)P.Rip] = value; }
        }
        public bool IsMark
        {
            get { return m_values[(int)P.Mark]; }
            set { m_values[(int)P.Mark] = value; }
        }
        public bool[] Values
        {
            get { return m_values; }
            set
            {
                if (value.Length == (int)P.Count)
                {
                    m_values = value;
                }
            }
        }

    }
}

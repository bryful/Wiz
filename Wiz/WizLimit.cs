using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace WizEdit
{
    public class WizLimit
    {
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
            Bounus,
            Status,
            Item,
            ItemEqip,
            ItemInd,
            ItemCur,
            MagicPoint,
            Spell,
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
            m_values[(int)P.Bounus] = true;
            m_values[(int)P.Status] = true;
        }
        public void CopyFrom(WizLimit wl)
        {
            for (int i = 0; i < m_values.Length; i++)
            {
                m_values[i] = wl.m_values[i];
            }
        }

        public bool IsLevel
        {
            get { return m_values[(int)P.Level]; }
            set { m_values[(int)P.Level] = value; }
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
        public bool IsBounus
        {
            get { return m_values[(int)P.Bounus]; }
            set { m_values[(int)P.Bounus] = value; }
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


    }
}

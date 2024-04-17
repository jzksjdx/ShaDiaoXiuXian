using System.Collections;
using System.Collections.Generic;
using GameFramework.DataTable;
using UnityEngine;

namespace GameMain
{
    public class FollowerData : BattleUnitData
    {
        [SerializeField] private int m_Level = 1;
        [SerializeField] private float m_Attack = 3;
        [SerializeField] private float m_Defense = 1;
        [SerializeField] private float m_Speed = 1;
        [SerializeField] private float m_MaxHealth = 10;
        [SerializeField] private float m_MaxMana = 100;

        [SerializeField] private float m_Health = 10;
        [SerializeField] private float m_Mana = 100;


        public FollowerData(int entityId, int typeId) : base(entityId, typeId, CampType.Player)
        {
            IDataTable<DRFollower> dtFollower = GameEntry.DataTable.GetDataTable<DRFollower>();
            DRFollower drFollower = dtFollower.GetDataRow(TypeId);
            if (drFollower == null) { return; }

            m_Level = drFollower.Id;
            m_Attack = drFollower.Attack;
            m_Defense = drFollower.Defense;
            m_Speed = drFollower.Speed;
            m_MaxHealth = drFollower.MaxHealth;
            m_MaxMana = drFollower.MaxMana;

            m_Health = m_MaxHealth;
            m_Mana = m_MaxMana;
        }

        public int Level
        {
            get { return m_Level; }
        }

        public float Attack
        {
            get { return m_Attack; }
        }

        public float Speed
        {
            get { return m_Speed; }
        }

        public float MaxMana
        {
            get { return m_MaxMana; }
        }

        public float Health
        {
            get { return m_Health; }
        }

        public float Mana
        {
            get { return m_Mana; }
        }
    }
}


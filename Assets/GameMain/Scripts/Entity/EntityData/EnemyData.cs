using System.Collections;
using System.Collections.Generic;
using GameFramework.DataTable;
using GameMain;
using UnityEngine;

namespace GameMain
{
    public class EnemyData : BattleUnitData
    {
        [SerializeField] private int m_Level = 1;
        [SerializeField] private float m_Attack = 3;
        [SerializeField] private float m_Defense = 1;
        [SerializeField] private float m_Speed = 1;
        [SerializeField] private float m_MaxHealth = 10;
        [SerializeField] private float m_MaxMana = 100;

        [SerializeField] private float m_Health = 10;
        [SerializeField] private float m_Mana = 100;


        public EnemyData(int entityId, int typeId) : base(entityId, typeId, CampType.Enemy)
        {
            IDataTable<DREnemy> dtEnemy = GameEntry.DataTable.GetDataTable<DREnemy>();
            DREnemy drEnemy = dtEnemy.GetDataRow(TypeId);
            if (drEnemy == null) { return; }

            m_Level = drEnemy.Id;
            m_Attack = drEnemy.Attack;
            m_Defense = drEnemy.Defense;
            m_Speed = drEnemy.Speed;
            m_MaxHealth = drEnemy.MaxHealth;
            m_MaxMana = drEnemy.MaxMana;

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


using System;
using System.Collections;
using System.Collections.Generic;
using GameFramework.DataTable;
using UnityEngine;
using UnityGameFramework.Runtime;

namespace GameMain
{
    [Serializable]
    public class SkillData : AccessoryObjectData
    {
        [SerializeField] protected int m_Level = 1;
        [SerializeField] protected float m_Cd = 2;
        [SerializeField] protected float m_AtkAttribute = 0.1f;
        [SerializeField] protected float m_Defense = 0f;
        [SerializeField] protected float m_HealthRegen = 0f;
        [SerializeField] protected float m_ManaRegen = 0f;
        [SerializeField] protected int m_UpgradeCost= 100;
        [SerializeField] protected float m_SpdAttribute = 0f;
        [SerializeField] protected float m_ManaCost = 3f;
        [SerializeField] protected float m_Speed = 10f;
        [SerializeField] protected int m_Amount = 1;
        [SerializeField] protected float m_Range = 1;
        [SerializeField] protected int m_MinPeople = 1;

        public SkillData(int entityId, int typeId, int ownerId, CampType ownerCamp)
            : base(entityId, typeId, ownerId, ownerCamp)
        {
            
        }
    }

}

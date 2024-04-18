using System;
using System.Collections;
using System.Collections.Generic;
using GameFramework.DataTable;
using UnityEngine;
using UnityEngine.SocialPlatforms;
using UnityGameFramework.Runtime;

namespace GameMain
{
    [Serializable]
    public class SkillSwordData : SkillData
    {

        public SkillSwordData(int entityId, int typeId, int level, int ownerId, CampType ownerCamp)
            : base(entityId, typeId, ownerId, ownerCamp)
        {
            //IDataTable<DataRowBase> dtSkill = GameEntry.DataTable.GetDataTable<DataRowBase>();
            IDataTable<DRSkillSword> dtSkill = GameEntry.DataTable.GetDataTable<DRSkillSword>();
            DRSkillSword drSkill = dtSkill.GetDataRow(level);
            if (drSkill == null)
            {
                return;
            }
            m_Level = level;
            m_Cd = drSkill.Defense;
            m_AtkAttribute = drSkill.AtkAttribute;
            m_Defense = drSkill.Defense;
            m_HealthRegen = drSkill.HealthRegen;
            m_ManaRegen = drSkill.ManaRegen;
            m_UpgradeCost = drSkill.UpgradeCost;
            m_SpdAttribute = drSkill.SpdAttribute;
            m_ManaCost = drSkill.ManaCost;
            m_Speed = drSkill.Speed;
            m_Amount = drSkill.Amount;
            m_Range = drSkill.Range;
            m_MinPeople = drSkill.MinPeople;

        }
    }

}

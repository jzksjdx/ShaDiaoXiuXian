using System;
using UnityEngine;
using UnityGameFramework.Runtime;

namespace GameMain
{
    public class Skill : Entity
    {
        private Entity ownerEntity;
        public Entity OwnerEntity
        {
            get
            {
                if (ownerEntity == null)
                {
                    ownerEntity = GameEntry.Entity.GetEntity(m_SkillData.OwnerId).Logic as Entity;
                }

                return ownerEntity;
            }

        }

        [SerializeField] public SkillData m_SkillData = null;

#if UNITY_2017_3_OR_NEWER
        protected override void OnInit(object userData)
#else
        protected internal override void OnInit(object userData)
#endif
        {
            base.OnInit(userData);
        }

#if UNITY_2017_3_OR_NEWER
        protected override void OnShow(object userData)
#else
        protected internal override void OnShow(object userData)
#endif
        {
            base.OnShow(userData);

            m_SkillData = userData as SkillData;
            if (m_SkillData == null)
            {
                Log.Error("Skill data is invalid.");
                return;
            }

            var ownerEntity = GameEntry.Entity.GetEntity(m_SkillData.OwnerId);
            if (ownerEntity == null)
            {
                Log.Fatal("技能组件附加失败，因为OwnerEntity不存在");
                return;
            }


            var battleUnit = ownerEntity.Logic as BattleUnit;
            //GameEntry.Entity.AttachEntity(Entity, m_SkillData.OwnerId, battleUnit.GetBattleUnitData().GetWeaponPath(m_WeaponData.SlotIndex));

            //if (WeaponAttack == null)//避免对象池重复添加
            //    AddAttackLogicComponent(m_WeaponData.AttackLogicComponent);
            //else
            //{
            //    WeaponAttack.Init(this);
            //}
        }

        protected override void OnUpdate(float elapseSeconds, float realElapseSeconds)
        {
            base.OnUpdate(elapseSeconds, realElapseSeconds);


        }

    }

}

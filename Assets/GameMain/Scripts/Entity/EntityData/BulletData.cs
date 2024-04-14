﻿//------------------------------------------------------------
// Game Framework
// Copyright © 2013-2021 Jiang Yin. All rights reserved.
// Homepage: https://gameframework.cn/
// Feedback: mailto:ellan@gameframework.cn
//------------------------------------------------------------

using System;
using GameFramework.DataTable;
using UnityEngine;
using UnityEngine.Serialization;

namespace GameMain
{
    [Serializable]
    public class BulletData : EntityData
    {
        [SerializeField]
        private int m_OwnerId = 0;

        [SerializeField]
        private CampType m_OwnerCamp = CampType.Unknown;

        [SerializeField]
        private int m_weaponIndex = 0;

        [SerializeField]
        private float m_Speed = 0f;

        [SerializeField]
        private float m_keepTime = 1f;

        public int fireSoundId;
        
        public int[] hideSoundIds;
       
        public int fireEffectId;
       
        public int hideEffectId;

        public bool useGravity;
        [FormerlySerializedAs("trigger")] public bool isTrigger;

        [FormerlySerializedAs("bulletStrategy")] public string bulletStrategyComp;
        public string specialData;
        public BulletData(int entityId, int typeId, int ownerId, CampType ownerCamp, int weaponIndex, float speed,float keepTime)
            : base(entityId, typeId)
        {
            m_OwnerId = ownerId;
            m_OwnerCamp = ownerCamp;
            m_weaponIndex = weaponIndex;
            m_Speed = speed;
            this.m_keepTime = keepTime;
            
            IDataTable<DRBullet> table = GameEntry.DataTable.GetDataTable<DRBullet>();
            DRBullet element = table.GetDataRow(TypeId);
            if (element == null)
            {
                return;
            }

            fireSoundId = element.FireSoundId;
            
            
            string[] hideSoundIdsArr = element.HideSoundIdArrStr.Split(',');
            hideSoundIds = Array.ConvertAll(hideSoundIdsArr, int.Parse);


            fireEffectId = element.FireEffectId;
           
            hideEffectId = element.FireSoundId;

            bulletStrategyComp = element.StrategyComponent;
            useGravity = element.UseGravity;
            isTrigger = element.IsTrigger;

            specialData = element.SpecialData;
        }

        public int OwnerId
        {
            get
            {
                return m_OwnerId;
            }
        }

        public CampType OwnerCamp
        {
            get
            {
                return m_OwnerCamp;
            }
        }

        public int WeaponIndex
        {
            get
            {
                return m_weaponIndex;
            }
        }

        public float Speed
        {
            get
            {
                return m_Speed;
            }
        }

        public float KeepTime
        {
            get
            {
                return m_keepTime;
            }
        }
    }
}

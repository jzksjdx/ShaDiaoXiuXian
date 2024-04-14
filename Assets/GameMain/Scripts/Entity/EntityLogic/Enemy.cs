using System.Collections;
using System.Collections.Generic;
using GameFramework;
using GameMain;
using UnityEngine;
using UnityGameFramework.Runtime;
using GameEntry = GameMain.GameEntry;

namespace GameMain
{
    public class Enemy : Entity
    {
        [SerializeField] private EnemyData m_EnemyData = null;

#if UNITY_2017_3_OR_NEWER
        protected override void OnInit(object userData)
#else
        protected internal override void OnInit(object userData)
#endif
        {
            base.OnInit(userData);
        }

        protected override void OnShow(object userData)
        {
            m_EnemyData = userData as EnemyData;

            if (m_EnemyData == null)
            {
                Log.Error("Enemy data is Invalid");
                return;
            }
            CachedTransform.position = m_EnemyData.Position;
        }

        protected override void OnUpdate(float elapseSeconds, float realElapseSeconds)
        {
            base.OnUpdate(elapseSeconds, realElapseSeconds);



        }
    }

}

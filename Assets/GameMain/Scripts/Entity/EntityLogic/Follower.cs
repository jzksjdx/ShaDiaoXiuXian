using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityGameFramework.Runtime;

namespace GameMain
{
    public class Follower : BattleUnit
    {
        [SerializeField] private FollowerData m_FollowerData = null;
        private Vector3 playerBaseLocation = new Vector3(0, 0, 11f); // 宗门位置
        private float speedFactor = 5f; // 随便设的 让速度看着正常

        Rigidbody rb;

        private float patrolTimer = 0f;
        private bool isWalking = false;
        private Vector3 walkDirection = Vector3.zero;
        private float patrolWalkTime = 3f;
        private float patrolStayTime = 3f;

#if UNITY_2017_3_OR_NEWER
        protected override void OnInit(object userData)
#else
        protected internal override void OnInit(object userData)
#endif
        {
            base.OnInit(userData);
            rb = GetComponent<Rigidbody>();
        }

        protected override void OnShow(object userData)
        {
            m_FollowerData = userData as FollowerData;

            if (m_FollowerData == null)
            {
                Log.Error("Follower data is Invalid");
                return;
            }
            CachedTransform.position = m_FollowerData.Position;
        }

        protected override void OnUpdate(float elapseSeconds, float realElapseSeconds)
        {
            base.OnUpdate(elapseSeconds, realElapseSeconds);
            // 巡逻
            HandlePatrolling(elapseSeconds);
        }

        private void HandlePatrolling(float elapseSeconds)
        {
            patrolTimer += elapseSeconds;
            if (isWalking && patrolTimer < patrolWalkTime)
            {
                //CachedTransform.Translate(walkDirection * speedFactor * m_FollowerData.Speed * elapseSeconds);
                if (rb)
                {
                    rb.velocity = walkDirection * m_FollowerData.Speed * speedFactor;
                }
            }
            else if (isWalking && patrolTimer >= patrolWalkTime)
            {
                patrolTimer = 0f;
                isWalking = false;
            }
            else if (!isWalking && patrolTimer < patrolStayTime)
            {
                //啥都不干
            }
            else if (!isWalking && patrolTimer >= patrolStayTime)
            {
                patrolTimer = 0f;
                walkDirection = new Vector3(Random.Range(0f, 1f), 0, Random.Range(0f, 1f)).normalized;
                isWalking = true;
                Log.Debug("Change to Walk, weapon num: " + m_Weapons.Count);
                //var weapon = GetWeaponByIndex(0);
                //if (weapon != null)
                //{
                //    weapon.HandleAnimEvent("Shoot", 1f);
                //} else
                //{
                //    Log.Debug("No weapon");
                //}
            }
        }

    }

}

//------------------------------------------------------------
// Game Framework
// Copyright © 2013-2021 Jiang Yin. All rights reserved.
// Homepage: https://gameframework.cn/
// Feedback: mailto:ellan@gameframework.cn
//------------------------------------------------------------


using GameFramework.Event;
using UnityEngine;
using UnityGameFramework.Runtime;

namespace GameMain
{

    public class GameLevel1 : GameBase
    {
        private float m_EnemyTimer = 0f;
        private float m_EnemySpawnTime = 5f; // 敌人生成时间

        private float m_FollowerTimer = 0f;
        private float m_FollowerSpawnTime = 5f; // 弟子生成时间


        public override void Update(float elapseSeconds, float realElapseSeconds)
        {
            base.Update(elapseSeconds, realElapseSeconds);
            // GameBase
            if (GameOver || GameWin)
                return;
            CheckGameOverOrWin();

            // GameLevel1
            // 生成弟子
            HandleFollowerSpawn(elapseSeconds);

            // 定时生成敌人
            HandleEnemySpawn(elapseSeconds);
        }

        private void HandleFollowerSpawn(float elapseSeconds)
        {
            m_FollowerTimer += elapseSeconds;
            if (m_FollowerTimer >= m_FollowerSpawnTime)
            {
                m_FollowerTimer = 0f;
                // 生成在宗门附近
                Vector3 followerPosition = new Vector3(0, 0, 0);
                followerPosition.x = Random.Range(-7f, 7f);
                followerPosition.z = Random.Range(-6f, 6f);

                GameEntry.Entity.ShowFollower(new FollowerData(GameEntry.Entity.GenerateSerialId(), 20003)
                {
                    Position = followerPosition
                });

            }
        }

        private void HandleEnemySpawn(float elapseSeconds)
        {
            m_EnemyTimer += elapseSeconds;
            if (m_EnemyTimer >= m_EnemySpawnTime)
            {
                m_EnemyTimer = 0f;
                Vector3 enemyPosition = new Vector3(0, 0, 0);
                enemyPosition.x = Random.Range(0f, 1f) > 0.5f ? -36.5f : 36.5f;
                enemyPosition.z = Random.Range(-6.8f, 10.5f);

                GameEntry.Entity.ShowEnemy(new EnemyData(GameEntry.Entity.GenerateSerialId(), 20004)
                {
                    Position = enemyPosition
                });

            }
        }

        
    }
}

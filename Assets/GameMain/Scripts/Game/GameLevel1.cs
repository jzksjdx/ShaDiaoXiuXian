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
        private float m_ElapseSeconds = 0f;
        private float m_EnemyGenerationTime = 5f;

        public override void Update(float elapseSeconds, float realElapseSeconds)
        {
            base.Update(elapseSeconds, realElapseSeconds);
            // GameBase
            if (GameOver || GameWin)
                return;
            CheckGameOverOrWin();

            // GameLevel1
            // 定时生成敌人
            m_ElapseSeconds += elapseSeconds;
            if (m_ElapseSeconds >= m_EnemyGenerationTime)
            {
                m_ElapseSeconds = 0f;
                Vector3 enemyPosition = new Vector3(0, 0, 0);
                enemyPosition.x = Random.Range(0f, 1f) > 0.5f ? -36.5f : 36.5f;
                enemyPosition.z = Random.Range(-6.8f, 10.5f);

                GameEntry.Entity.ShowEnemy(new EnemyData(GameEntry.Entity.GenerateSerialId(), 20003)
                {
                    Position = enemyPosition
                });

            }
        }




    }
}

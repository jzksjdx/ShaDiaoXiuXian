//------------------------------------------------------------
// Game Framework
// Copyright © 2013-2021 Jiang Yin. All rights reserved.
// Homepage: https://gameframework.cn/
// Feedback: mailto:ellan@gameframework.cn
//------------------------------------------------------------


using GameFramework.Event;

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
                GameEntry.Entity.ShowEnemy(new EnemyData(GameEntry.Entity.GenerateSerialId(), 20003)
                {
                    Position = new UnityEngine.Vector3(100, 100, 100),
                });;

            }
        }




    }
}

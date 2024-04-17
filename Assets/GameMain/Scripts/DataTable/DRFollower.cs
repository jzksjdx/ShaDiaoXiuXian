//------------------------------------------------------------
// Game Framework
// Copyright © 2013-2021 Jiang Yin. All rights reserved.
// Homepage: https://gameframework.cn/
// Feedback: mailto:ellan@gameframework.cn
//------------------------------------------------------------
// 此文件由工具自动生成，请勿直接修改。
// 生成时间：2024-04-16 20:25:10.613
//------------------------------------------------------------

using GameFramework;
using System;
using System.Collections.Generic;
using System.IO;
using System.Text;
using UnityEngine;
using UnityGameFramework.Runtime;

namespace GameMain
{
    /// <summary>
    /// 等级属性。
    /// </summary>
    public class DRFollower : DataRowBase
    {
        private int m_Id = 0;

        /// <summary>
        /// 获取等级。
        /// </summary>
        public override int Id
        {
            get
            {
                return m_Id;
            }
        }

        /// <summary>
        /// 获取攻击力。
        /// </summary>
        public float Attack
        {
            get;
            private set;
        }

        /// <summary>
        /// 获取防御力。
        /// </summary>
        public float Defense
        {
            get;
            private set;
        }

        /// <summary>
        /// 获取速度/s。
        /// </summary>
        public float Speed
        {
            get;
            private set;
        }

        /// <summary>
        /// 获取最大血量。
        /// </summary>
        public float MaxHealth
        {
            get;
            private set;
        }

        /// <summary>
        /// 获取血量回复速度/s。
        /// </summary>
        public float HealthRegen
        {
            get;
            private set;
        }

        /// <summary>
        /// 获取最大法力值。
        /// </summary>
        public float MaxMana
        {
            get;
            private set;
        }

        /// <summary>
        /// 获取法力回复速度/s。
        /// </summary>
        public float ManaRegen
        {
            get;
            private set;
        }

        /// <summary>
        /// 获取进阶需要的灵石。
        /// </summary>
        public int UpgradeCost
        {
            get;
            private set;
        }

        public override bool ParseDataRow(string dataRowString, object userData)
        {
            string[] columnStrings = dataRowString.Split(DataTableExtension.DataSplitSeparators);
            for (int i = 0; i < columnStrings.Length; i++)
            {
                columnStrings[i] = columnStrings[i].Trim(DataTableExtension.DataTrimSeparators);
            }

            int index = 0;
            index++;
            m_Id = int.Parse(columnStrings[index++]);
            index++;
            Attack = float.Parse(columnStrings[index++]);
            Defense = float.Parse(columnStrings[index++]);
            Speed = float.Parse(columnStrings[index++]);
            MaxHealth = float.Parse(columnStrings[index++]);
            HealthRegen = float.Parse(columnStrings[index++]);
            MaxMana = float.Parse(columnStrings[index++]);
            ManaRegen = float.Parse(columnStrings[index++]);
            UpgradeCost = int.Parse(columnStrings[index++]);

            GeneratePropertyArray();
            return true;
        }

        public override bool ParseDataRow(byte[] dataRowBytes, int startIndex, int length, object userData)
        {
            using (MemoryStream memoryStream = new MemoryStream(dataRowBytes, startIndex, length, false))
            {
                using (BinaryReader binaryReader = new BinaryReader(memoryStream, Encoding.UTF8))
                {
                    m_Id = binaryReader.Read7BitEncodedInt32();
                    Attack = binaryReader.ReadSingle();
                    Defense = binaryReader.ReadSingle();
                    Speed = binaryReader.ReadSingle();
                    MaxHealth = binaryReader.ReadSingle();
                    HealthRegen = binaryReader.ReadSingle();
                    MaxMana = binaryReader.ReadSingle();
                    ManaRegen = binaryReader.ReadSingle();
                    UpgradeCost = binaryReader.Read7BitEncodedInt32();
                }
            }

            GeneratePropertyArray();
            return true;
        }

        private void GeneratePropertyArray()
        {

        }
    }
}

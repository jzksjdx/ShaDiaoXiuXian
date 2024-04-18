//------------------------------------------------------------
// Game Framework
// Copyright © 2013-2021 Jiang Yin. All rights reserved.
// Homepage: https://gameframework.cn/
// Feedback: mailto:ellan@gameframework.cn
//------------------------------------------------------------
// 此文件由工具自动生成，请勿直接修改。
// 生成时间：2024-04-18 00:28:17.991
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
    /// 飞剑术Skill_Sword。
    /// </summary>
    public class DRSkillSword : DataRowBase
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
        /// 获取CD。
        /// </summary>
        public float Cd
        {
            get;
            private set;
        }

        /// <summary>
        /// 获取附加攻击力。
        /// </summary>
        public float AtkAttribute
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
        /// 获取回复血量。
        /// </summary>
        public float HealthRegen
        {
            get;
            private set;
        }

        /// <summary>
        /// 获取回复精神。
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

        /// <summary>
        /// 获取附加的速度。
        /// </summary>
        public float SpdAttribute
        {
            get;
            private set;
        }

        /// <summary>
        /// 获取消耗的法力。
        /// </summary>
        public float ManaCost
        {
            get;
            private set;
        }

        /// <summary>
        /// 获取飞行速度。
        /// </summary>
        public float Speed
        {
            get;
            private set;
        }

        /// <summary>
        /// 获取数量。
        /// </summary>
        public int Amount
        {
            get;
            private set;
        }

        /// <summary>
        /// 获取范围。
        /// </summary>
        public float Range
        {
            get;
            private set;
        }

        /// <summary>
        /// 获取时间。
        /// </summary>
        public float Duration
        {
            get;
            private set;
        }

        /// <summary>
        /// 获取需要人数。
        /// </summary>
        public int MinPeople
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
            Cd = float.Parse(columnStrings[index++]);
            AtkAttribute = float.Parse(columnStrings[index++]);
            Defense = float.Parse(columnStrings[index++]);
            HealthRegen = float.Parse(columnStrings[index++]);
            ManaRegen = float.Parse(columnStrings[index++]);
            UpgradeCost = int.Parse(columnStrings[index++]);
            SpdAttribute = float.Parse(columnStrings[index++]);
            ManaCost = float.Parse(columnStrings[index++]);
            Speed = float.Parse(columnStrings[index++]);
            index++;
            Amount = int.Parse(columnStrings[index++]);
            Range = float.Parse(columnStrings[index++]);
            Duration = float.Parse(columnStrings[index++]);
            MinPeople = int.Parse(columnStrings[index++]);

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
                    Cd = binaryReader.ReadSingle();
                    AtkAttribute = binaryReader.ReadSingle();
                    Defense = binaryReader.ReadSingle();
                    HealthRegen = binaryReader.ReadSingle();
                    ManaRegen = binaryReader.ReadSingle();
                    UpgradeCost = binaryReader.Read7BitEncodedInt32();
                    SpdAttribute = binaryReader.ReadSingle();
                    ManaCost = binaryReader.ReadSingle();
                    Speed = binaryReader.ReadSingle();
                    Amount = binaryReader.Read7BitEncodedInt32();
                    Range = binaryReader.ReadSingle();
                    Duration = binaryReader.ReadSingle();
                    MinPeople = binaryReader.Read7BitEncodedInt32();
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

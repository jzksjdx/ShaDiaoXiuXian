using System.Collections;
using System.Collections.Generic;
using GameFramework.DataTable;
using GameMain;
using UnityEngine;




[System.Serializable]
public class BattleUnitData : TargetableObjectData
{
    
    
    [SerializeField]
    private List<WeaponData> m_WeaponDatas = new List<WeaponData>();

    [SerializeField]
    private List<ArmorData> m_ArmorDatas = new List<ArmorData>();

    [SerializeField]
    private float m_MaxHealth = 0;

    [SerializeField]
    private float m_Defense = 0;

    [SerializeField]
    private int m_DeadEffectId = 0;

    [SerializeField]
    private int m_DeadSoundId = 0;

    private string weaponPath0;
    private string weaponPath1;
    private string weaponPath2;
    
    public string GetWeaponPath(int index)
    {
        switch (index)
        {
            case 0:
                return weaponPath0;
            case 1:
                return weaponPath1;
            case 2:
                return weaponPath2;
        }

        return "";
    }

    public BattleUnitData(int entityId, int typeId, CampType camp) : base(entityId, typeId, camp)
    {
        IDataTable<DRBattleUnit> dtBattleUnits = GameEntry.DataTable.GetDataTable<DRBattleUnit>();
        DRBattleUnit drBattleUnit = dtBattleUnits.GetDataRow(TypeId);
        if (drBattleUnit == null)
        {
            return;
        }
        
        weaponPath0 = drBattleUnit.WeaponPath0;
        weaponPath1 = drBattleUnit.WeaponPath1;
        weaponPath2 = drBattleUnit.WeaponPath2;
        
        for (int index = 0, weaponId = 0; (weaponId = drBattleUnit.GetWeaponIdAt(index)) > 0; index++)
        {
            AttachWeaponData(new WeaponData(GameEntry.Entity.GenerateSerialId(), weaponId, Id, Camp,index));
        }

        for (int index = 0, armorId = 0; (armorId = drBattleUnit.GetArmorIdAt(index)) > 0; index++)
        {
            AttachArmorData(new ArmorData(GameEntry.Entity.GenerateSerialId(), armorId, Id, Camp));
        }

        m_DeadEffectId = drBattleUnit.DeadEffectId;
        m_DeadSoundId = drBattleUnit.DeadSoundId;

        HP = m_MaxHealth;
    }

    /// <summary>
    /// 最大生命。
    /// </summary>
    public override float MaxHealth
    {
        get
        {
            return m_MaxHealth;
        }
    }

    /// <summary>
    /// 防御。
    /// </summary>
    public float Defense
    {
        get
        {
            return m_Defense;
        }
    }

    

    public int DeadEffectId
    {
        get
        {
            return m_DeadEffectId;
        }
    }

    public int DeadSoundId
    {
        get
        {
            return m_DeadSoundId;
        }
    }
    
    public List<WeaponData> GetAllWeaponDatas()
    {
        return m_WeaponDatas;
    }

  
    public void AttachWeaponData(WeaponData weaponData)
    {
        if (weaponData == null)
        {
            return;
        }

        if (m_WeaponDatas.Contains(weaponData))
        {
            return;
        }
        m_WeaponDatas.Add(weaponData);
    }

    public void DetachWeaponData(WeaponData weaponData)
    {
        if (weaponData == null)
        {
            return;
        }

        m_WeaponDatas.Remove(weaponData);
    }

    public List<ArmorData> GetAllArmorDatas()
    {
        return m_ArmorDatas;
    }

    public void AttachArmorData(ArmorData armorData)
    {
        if (armorData == null)
        {
            return;
        }

        if (m_ArmorDatas.Contains(armorData))
        {
            return;
        }

        m_ArmorDatas.Add(armorData);
        RefreshData();
    }

    public void DetachArmorData(ArmorData armorData)
    {
        if (armorData == null)
        {
            return;
        }

        m_ArmorDatas.Remove(armorData);
        RefreshData();
    }

    private void RefreshData()
    {
        m_MaxHealth = 0;
        m_Defense = 0;
        for (int i = 0; i < m_ArmorDatas.Count; i++)
        {
            m_MaxHealth += m_ArmorDatas[i].MaxHP;
            m_Defense += m_ArmorDatas[i].Defense;
        }

        if (HP > m_MaxHealth)
        {
            HP = m_MaxHealth;
        }
    }
}

using System.Collections;
using System.Collections.Generic;
using GameFramework;
using GameMain;
using UnityEngine;
using UnityGameFramework.Runtime;
using GameEntry = GameMain.GameEntry;

public class Player : BattleUnit
{
    private PlayerData playerData;


    protected override void OnShow(object userData)
    {
        Log.Debug("Player on show");
        playerData=userData as PlayerData;

        if (playerData == null)
        {
            Log.Error("PlayerData is Invalid");
            return;
        }

        Name = Utility.Text.Format("Player ({0})", Id);
        CachedTransform.SetLocalScaleX(2);
        CachedTransform.SetLocalScaleY(2);
        CachedTransform.SetLocalScaleZ(2);
    }

    protected override void OnUpdate(float elapseSeconds, float realElapseSeconds)
    {
        base.OnUpdate(elapseSeconds, realElapseSeconds);
        

        float horizontal = Input.GetAxis("Horizontal");
        float vertical= Input.GetAxis("Vertical");

        Vector3 moveDirection = new Vector3(horizontal, 0, vertical).normalized;
        transform.Translate(10 * elapseSeconds * moveDirection);
        
        //攻击
        if (Input.GetMouseButtonDown(0))
        {
            var weapon = GetWeaponByIndex(0);
            if (weapon != null)
            {
                weapon.HandleAnimEvent("Shoot",1f);
            }
        }
        
        if (Input.GetMouseButtonDown(1))
        {
            var weapon = GetWeaponByIndex(1);
            if (weapon != null)
            {
                weapon.HandleAnimEvent("Shoot",1f);
            }
        }
    }

    public override void ApplyDamage(BattleUnit attacker, float damageHP)
    {
        base.ApplyDamage(attacker, damageHP);
        GameEntry.CameraShake.ShakeCamera(0.3f,0.5f,0.3f);

        GameEntry.Sound.PlaySound(20000,transform.position);
    }
}

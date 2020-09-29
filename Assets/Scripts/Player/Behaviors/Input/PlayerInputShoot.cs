using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerInputShoot : PlayerShoot
{
    [SerializeField]
    private PlayerData playerData;

    private KeyCode leftKey, rightKey, shootKey;

    public void SetKeys(KeyCode left, KeyCode right, KeyCode shoot)
    {
        leftKey = left;
        rightKey = right;
        shootKey = shoot;
    }

    protected override void Init()
    {
        base.Init();
        SetKeys(playerData.Left, playerData.Right, playerData.Shoot);
    }

    protected override float AimDirection()
    {
        if (Input.GetKey(leftKey))
        {
            return -1;
        }

        if (Input.GetKey(rightKey))
        {
            return 1;
        }

        return 0;
    }

    protected override bool ShouldShoot()
    {
        return Input.GetKeyDown(shootKey);
    }
}

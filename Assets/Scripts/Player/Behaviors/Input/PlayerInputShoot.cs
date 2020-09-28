using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerInputShoot : PlayerShoot
{
    [SerializeField]
    private KeyCode leftKey, rightKey, shootKey;

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

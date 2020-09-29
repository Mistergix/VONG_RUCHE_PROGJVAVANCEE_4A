using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerRandomShooter : PlayerShoot
{
    [SerializeField]
    [Range(0, 1)]
    private float shootProba = 0.5f;
    protected override float AimDirection()
    {
        return Random.Range(-1, 2);
    }

    protected override bool ShouldShoot()
    {
        return shootProba > Random.value;
    }
}

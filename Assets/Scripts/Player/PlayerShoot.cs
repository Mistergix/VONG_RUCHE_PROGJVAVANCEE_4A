using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public abstract class PlayerShoot : MonoBehaviour
{
    [SerializeField]
    private float shootCoolDown, aimSpeed, upwardShootForce;

    [SerializeField]
    private Transform aimStart, aimEnd;

    [SerializeField]
    private GameObject bulletPrefab;

    private float aimQuantity;

    private bool canShoot;

    private float AimQuantity { get => aimQuantity; 
        set {
            aimQuantity = Mathf.Clamp01(value);
        } }

    // Start is called before the first frame update
    void Start()
    {
        Init();
        canShoot = true;
        AimQuantity = 0;
    }

    protected virtual void Init() { }

    protected abstract bool ShouldShoot();
    protected abstract float AimDirection();

    internal void HandleShoot()
    {
        if(! canShoot)
        {
            return;
        }

        if(! ShouldShoot())
        {
            return;
        }

        StartCoroutine(Shoot());
    }

    internal void Aim()
    {
        float sign;

        if(AimDirection() == 0)
        {
            sign = 0;
        }
        else
        {
            sign = Math.Sign(AimDirection());
        }


        AimQuantity += sign * aimSpeed * Time.deltaTime;
    }

    private Vector3 BulletLandSpot()
    {
        return Vector3.Lerp(aimStart.position, aimEnd.position, AimQuantity);
    }

    private void OnDrawGizmos()
    {
        Gizmos.DrawCube(BulletLandSpot(), Vector3.one * 0.3f);
    }

    private void InstantiateBullet()
    {
        //TODO use a pool
        // Add Bullet behavior
        Instantiate(bulletPrefab, aimStart.position, Quaternion.identity);
    }

    private IEnumerator Shoot()
    {
        canShoot = false;

        InstantiateBullet();

        yield return new WaitForSeconds(shootCoolDown);

        canShoot = true;
    }
}

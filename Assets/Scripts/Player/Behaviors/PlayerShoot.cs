using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public abstract class PlayerShoot : MonoBehaviour
{
    [SerializeField]
    private float shootCoolDown, aimSpeed, bulletHeight;

    [Range(2, 100)]
    [SerializeField]
    private int trajectoryPrecision = 10;

    [SerializeField]
    private PoolManager bulletPool;

    [SerializeField]
    private Transform aimStart, aimEnd, bulletSpawn;

    [SerializeField]
    private GameObject bulletPrefab;

    [SerializeField]
    private LineRenderer bulletLineRenderer;

    private float aimQuantity;

    private bool canShoot;

    private Vector3 parabola;

    private bool isLeft;
    public int Id { get; set; }

    private void Visualize()
    {
        Vector3[] positions = new Vector3[trajectoryPrecision];
        Vector3 start = bulletSpawn.position;
        Vector3 end = BulletLandSpot();

        positions[0] = start;

        for (int i = 1; i < trajectoryPrecision - 1; i++)
        {
            float t = (float)i / (trajectoryPrecision - 1);
            Vector3 lerp = Vector3.Lerp(start, end, t);
            lerp.y = Geometry.CalulateParabolaWithTurningPoint(parabola, lerp.x);
            positions[i] = lerp;
        }


        positions[trajectoryPrecision - 1] = end;

        bulletLineRenderer.SetPositions(positions);
    }

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
        parabola = Vector3.zero;
        bulletLineRenderer.transform.parent = null;
        bulletLineRenderer.transform.position = Vector3.zero;
        bulletLineRenderer.positionCount = trajectoryPrecision;
        bulletPool.transform.parent = null;

        isLeft = GetComponent<Player>().IsLeft;
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

        if(! isLeft)
        {
            sign *= -1;
        }


        AimQuantity += sign * aimSpeed * Time.deltaTime;

        parabola = GetParabola();

        Visualize();
    }

    private Vector3 BulletLandSpot()
    {
        Vector3 lerp = Vector3.Lerp(aimStart.position, aimEnd.position, AimQuantity);
        lerp.y = 0;
        return lerp;
    }

    private void OnDrawGizmos()
    {
        Gizmos.DrawCube(BulletLandSpot(), Vector3.one * 0.3f);
    }

    private Vector3 GetParabola()
    {
        return Geometry.GetParabola(bulletSpawn.position, BulletLandSpot(), bulletHeight);
    }

    private void InstantiateBullet()
    {
        GameObject bullet = bulletPool.RequestACopy();

        bullet.GetComponent<Bullet>().Initialize(parabola, bulletSpawn.position, BulletLandSpot(), isLeft);
        bullet.GetComponent<Bullet>().Id = Id;
    }

    private IEnumerator Shoot()
    {
        canShoot = false;

        InstantiateBullet();

        yield return new WaitForSeconds(shootCoolDown);

        canShoot = true;
    }
}

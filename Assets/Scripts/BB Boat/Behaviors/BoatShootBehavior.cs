using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BoatShootBehavior : BoatBehavior
{
    private PoolManager boatBulletPool;
    
    private float timeBeforeShootMinimum = .2f;
    private float timeBeforeShootMaximum = 1f;

    private float timeBeforeShootCounter = 0f;

    private Transform firePoint;
    private bool shootOnce = false;

    private Boat boat;
    private void Start() {
        boatBulletPool = GetComponentInChildren<PoolManager>();
        if (boatBulletPool.transform.parent != null) {
            boatBulletPool.transform.parent = null;
            boatBulletPool.transform.localScale = Vector3.one;
        }
        //Récupère le point de tir du BB boat
        foreach (Transform fp in transform) {
            if (fp.CompareTag("Fire Point")) {
                firePoint = fp;
            }
        }

        boat = GetComponent<Boat>();
        if (boat.Direction().Equals(Vector3.left)) {
            float pos = firePoint.transform.localPosition.x;
            firePoint.transform.localPosition = new Vector3(-pos, transform.position.y, 0f);
        }

        timeBeforeShootCounter = Random.Range(timeBeforeShootMinimum, timeBeforeShootMaximum);
    }
    /// <summary>
    /// Un tir avant le milieu, peut toucher les bébé bateaux ennemis et joueur
    /// </summary>
    public override void Execute()
    {
        timeBeforeShootCounter -= Time.deltaTime;
        if (timeBeforeShootCounter <= 0 && !shootOnce) {
            shootOnce = true;
            InstantiateBullet();
        }
    }

    public void InstantiateBullet() {
        GameObject bbullet = boatBulletPool.RequestACopy();
        bbullet.GetComponent<BoatBullet>().Init(GetComponent<Boat>().Direction());
        bbullet.transform.position = new Vector3(firePoint.position.x, firePoint.position.y, firePoint.position.z);
    }

    private void OnDisable() {
        Reset();
    }

    public void Reset() {
        shootOnce = false;
        timeBeforeShootCounter = Random.Range(timeBeforeShootMinimum, timeBeforeShootMaximum);
    }
}

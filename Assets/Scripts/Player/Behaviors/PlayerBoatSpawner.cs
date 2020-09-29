using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public abstract class PlayerBoatSpawner : MonoBehaviour
{
    [SerializeField]
    private float spawnCoolDown;
    [SerializeField]
    private PoolManager boatPool;
    [SerializeField]
    private Transform boatSpawn;

    private bool canSpawn;

    private void Start()
    {
        Init();
        canSpawn = true;
        boatPool.transform.parent = null;
    }

    protected virtual void Init()
    {
        
    }

    protected abstract bool ShouldSpawn();

    internal void HandleBoatSpawn()
    {
        if (!canSpawn)
        {
            return;
        }

        if (!ShouldSpawn())
        {
            return;
        }

        StartCoroutine(Spawn());
    }

    private IEnumerator Spawn()
    {
        canSpawn = false;

        InstantiateBoat();

        yield return new WaitForSeconds(spawnCoolDown);

        canSpawn = true;
    }

    private void InstantiateBoat()
    {
        GameObject boat = boatPool.RequestACopy();
        boat.transform.position = boatSpawn.position;
    }
}

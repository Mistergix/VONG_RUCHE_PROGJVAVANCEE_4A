﻿using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public abstract class PlayerBoatSpawner : MonoBehaviour
{
    [SerializeField]
    private float boatSpeed;
    [SerializeField]
    private float spawnCoolDown;
    [SerializeField]
    private PoolManager boatPool;
    [SerializeField]
    private Transform boatSpawn;

    private bool canSpawn;

    private bool isLeft;

    private PlayerData playerData;

    public virtual void Init()
    {
        canSpawn = true;
        boatPool.transform.parent = null;

        Player player = GetComponent<Player>();

        isLeft = player.IsLeft;
        playerData = player.PlayerDataInstance;
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

        playerData.SpawnEvent.Raise();

        yield return new WaitForSeconds(spawnCoolDown);

        canSpawn = true;
    }

    private void InstantiateBoat()
    {
        GameObject boatGo = boatPool.RequestACopy();
        boatGo.transform.position = new Vector3(boatSpawn.position.x, 0, boatSpawn.position.z);
        BoatForwardBehavior forwardBe = boatGo.AddComponent<BoatForwardBehavior>();

        forwardBe.Speed = boatSpeed;
        forwardBe.Priority = 10;

        Boat boat = boatGo.GetComponent<Boat>();

        boat.IsLeft = isLeft;
        boat.transform.position = boatSpawn.position;
        boat.OnBorderPassedEvent = playerData.BoatBorderEvent;
    }
}

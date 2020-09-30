using System;
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

    private PlayerLevelSystem levelSystem;

    private bool canSpawn;

    private bool isLeft;

    private PlayerData playerData;

    public PlayerData PlayerDataInstance { get => playerData; private set => playerData = value; }
    public float SpawnCooldown { get => spawnCoolDown; private set => spawnCoolDown = value; }

    public virtual void Init()
    {
        canSpawn = true;
        boatPool.transform.parent = null;

        Player player = GetComponent<Player>();

        isLeft = player.IsLeft;
        PlayerDataInstance = player.PlayerDataInstance;

        levelSystem = GetComponent<PlayerLevelSystem>();
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

        PlayerDataInstance.SpawnEvent.Raise();

        yield return new WaitForSeconds(spawnCoolDown);

        canSpawn = true;
    }

    private void InstantiateBoat()
    {
        GameObject boatGo = boatPool.RequestACopy();
        boatGo.transform.position = new Vector3(boatSpawn.position.x, 0, boatSpawn.position.z);

        Boat boat = boatGo.GetComponent<Boat>();

        levelSystem.LevelupBoat(boat);

        boat.IsLeft = isLeft;
        boat.OnBorderPassedEvent = PlayerDataInstance.BoatBorderEvent;
    }
}

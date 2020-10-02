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

    [SerializeField]
    private PlayerLevelSystem levelSystem;

    private bool canSpawn;

    private bool isLeft;

    private Player player;
    private PlayerData playerData;

    public PlayerData PlayerDataInstance { get => playerData; private set => playerData = value; }
    public float SpawnCooldown { get => spawnCoolDown; private set => spawnCoolDown = value; }
    private float spawnCooldownCounter;
    public void ChangeSpawnCooldown(float newCD) {
        spawnCoolDown = newCD;
    }

    public virtual void Init()
    {
        canSpawn = true;
        boatPool.transform.parent = null;

        player = GetComponent<Player>();

        isLeft = player.IsLeft;
        PlayerDataInstance = player.PlayerDataInstance;
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

        if (Time.timeScale == 0f) {
            return;
        }
        StartCoroutine(Spawn());
    }

    private IEnumerator Spawn()
    {
        canSpawn = false;
        spawnCooldownCounter = 0;
        InstantiateBoat();
        PlayerDataInstance.SpawnEvent.Raise();

        while (spawnCooldownCounter < player.SpawnCoolDown) {
            spawnCooldownCounter += Time.deltaTime;

            yield return new WaitForEndOfFrame();
        }
        canSpawn = true;
    }

    private void InstantiateBoat()
    {
        GameObject boatGo = boatPool.RequestACopy();
        boatGo.GetComponent<Boat>().Initialize(player, boatSpawn);

        Boat boat = boatGo.GetComponent<Boat>();

        levelSystem.LevelupBoat(boat);

        boat.IsLeft = isLeft;
        boat.OnBorderPassedEvent = PlayerDataInstance.BoatBorderEvent;
    }
}

﻿using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Player : MonoBehaviour
{
    [SerializeField]
    private int maxLife;
    private PlayerMovement playerMovement;
    private PlayerShoot playerShoot;
    private PlayerBoatSpawner playerBoatSpawner;

    private int level;

    public bool IsLeft { get => PlayerDataInstance.IsLeft; }
    public PlayerData PlayerDataInstance { get; set; }
    public int MaxLife { get => maxLife; private set => maxLife = value; }
    public int CurrentLife { get; private set; }

    public float ShootCooldown { get => playerShoot.ShootCoolDown; }
    public float SpawnCoolDown { get => playerBoatSpawner.SpawnCooldown; private set => playerBoatSpawner.ChangeSpawnCooldown(value); }
    public int Level { get => level; private set => level = value; }

    public float ShootX { get => playerShoot.XMax; }
    public bool GamePaused { get; set; }
    [SerializeField]
    private GameEvent pause;
    public void OverHeal()
    {
        MaxLife++;
        CurrentLife++;
        PlayerDataInstance.TakeDamageEvent.Raise();
    }

    public void ReduceCD() {
        if (SpawnCoolDown > 1) {
            SpawnCoolDown -= .5f;
        }
    }

    public void Init(PlayerData playerData)
    {
        PlayerDataInstance = playerData;
        playerMovement = GetComponent<PlayerMovement>();
        playerShoot = GetComponent<PlayerShoot>();
        playerBoatSpawner = GetComponent<PlayerBoatSpawner>();
        CurrentLife = MaxLife;

        playerMovement.Init();
        playerShoot.Init();
        playerBoatSpawner.Init();

        GamePaused = true;

        Level = 1;
    }

    private void Update()
    {
        //if (GamePaused) {
        //    return;
        //}
        playerMovement.HandleMove();
        playerShoot.Aim();
        playerShoot.HandleShoot();
        playerBoatSpawner.HandleBoatSpawn();
    }

    public void TakeDamage(int damage)
    {
        CurrentLife -= damage;

        PlayerDataInstance.TakeDamageEvent.Raise();

        if (CurrentLife <= 0) {
            gameObject.SetActive(false);
        }
    }

    public void LevelUp()
    {
        Level++;
        PlayerDataInstance.LevelUpEvent.Raise();
    }

    public void isPause() {
        GamePaused = !GamePaused;
    }
}

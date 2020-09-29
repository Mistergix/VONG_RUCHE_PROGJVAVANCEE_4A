using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Player : MonoBehaviour
{
    private PlayerData playerData;
    
    [SerializeField]
    private int maxLife;

    private int currentLife;

    private PlayerMovement playerMovement;
    private PlayerShoot playerShoot;
    private PlayerBoatSpawner playerBoatSpawner;

    public bool IsLeft { get => PlayerDataInstance.IsLeft; }
    public PlayerData PlayerDataInstance { get => playerData; set => playerData = value; }
    public int MaxLife { get => maxLife; private set => maxLife = value; }
    public int CurrentLife { get => currentLife; private set => currentLife = value; }

    public float ShootCooldown { get => playerShoot.ShootCoolDown; }
    public float SpawnCoolDown { get => playerBoatSpawner.SpawnCooldown; }

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
    }

    private void Update()
    {
        playerMovement.HandleMove();
        playerShoot.Aim();
        playerShoot.HandleShoot();
        playerBoatSpawner.HandleBoatSpawn();
    }

    public void TakeDamage(int damage)
    {
        CurrentLife -= damage;

        playerData.TakeDamageEvent.Raise();

        if (CurrentLife <= 0) {
            gameObject.SetActive(false);
        }
    }
}

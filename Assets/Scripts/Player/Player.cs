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
    
    public void Init(PlayerData playerData)
    {
        PlayerDataInstance = playerData;
        playerMovement = GetComponent<PlayerMovement>();
        playerShoot = GetComponent<PlayerShoot>();
        playerBoatSpawner = GetComponent<PlayerBoatSpawner>();
        currentLife = maxLife;

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
        currentLife -= damage;

        playerData.TakeDamageEvent.Raise();

        if (currentLife <= 0) {
            gameObject.SetActive(false);
        }
    }
}

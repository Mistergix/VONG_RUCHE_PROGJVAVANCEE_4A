using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Player : MonoBehaviour
{
    [SerializeField]
    private PlayerData playerData;

    private PlayerMovement playerMovement;
    private PlayerShoot playerShoot;
    private PlayerBoatSpawner playerBoatSpawner;

    private void Start()
    {
        playerMovement = GetComponent<PlayerMovement>();
        playerShoot = GetComponent<PlayerShoot>();
        playerBoatSpawner = GetComponent<PlayerBoatSpawner>();
    }

    private void Update()
    {
        playerMovement.HandleMove();
        playerShoot.Aim();
        playerShoot.HandleShoot();
        playerBoatSpawner.HandleBoatSpawn();
    }
}

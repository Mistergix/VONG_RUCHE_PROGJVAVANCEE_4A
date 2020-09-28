﻿using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Player : MonoBehaviour
{
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
        playerShoot.HandleShoot();
        playerBoatSpawner.HandleBoatSpawn();
    }
}

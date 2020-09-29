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

    [SerializeField]
    private int m_id;
    public int Id {
        get { return m_id; }
        set { m_id = value; }
    }
    
    public void Init(PlayerData playerData)
    {
        PlayerDataInstance = playerData;
        playerMovement = GetComponent<PlayerMovement>();
        playerShoot = GetComponent<PlayerShoot>();
        playerBoatSpawner = GetComponent<PlayerBoatSpawner>();

        playerBoatSpawner.GetComponent<PlayerShoot>().Id = Id;
        playerBoatSpawner.GetComponent<PlayerBoatSpawner>().Id = Id;
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
        if (currentLife <= 0) {
            gameObject.SetActive(false);
        }
    }
}

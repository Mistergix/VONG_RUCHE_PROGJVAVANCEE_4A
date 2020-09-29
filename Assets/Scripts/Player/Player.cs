using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Player : MonoBehaviour
{
    [SerializeField]
    private PlayerData playerData;
    
    [SerializeField]
    private int maxLife;

    private int currentLife;


    private PlayerMovement playerMovement;
    private PlayerShoot playerShoot;
    private PlayerBoatSpawner playerBoatSpawner;

    public bool IsLeft { get => playerData.IsLeft; }
    [SerializeField]
    public int Id {
        get { return m_id; }
        set { m_id = value; }
    }
    public int m_id;
    private void Start()
    {
        playerMovement = GetComponent<PlayerMovement>();
        playerShoot = GetComponent<PlayerShoot>();
        playerBoatSpawner = GetComponent<PlayerBoatSpawner>();

        playerBoatSpawner.GetComponent<PlayerShoot>().Id = Id;
        playerBoatSpawner.GetComponent<PlayerBoatSpawner>().Id = Id;
        currentLife = maxLife;
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

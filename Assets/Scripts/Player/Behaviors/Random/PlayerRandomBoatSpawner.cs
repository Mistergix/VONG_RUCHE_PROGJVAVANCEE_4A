using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerRandomBoatSpawner : PlayerBoatSpawner
{
    [SerializeField]
    [Range(0, 1)]
    private float spawnProba = 0.5f;
    protected override bool ShouldSpawn()
    {
        return spawnProba > Random.value;
    }
}

using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerLevelSystem : MonoBehaviour
{
    [SerializeField]
    private float boatSpeed = 5f;

    private Player player;

    private void Start()
    {
        player = GetComponent<Player>();
    }

    public void LevelupBoat(Boat boat)
    {
        GameObject boatGo = boat.gameObject;

        int level = Mathf.Clamp(player.Level, 1, 3);

        BoatForwardBehavior forwardBe = boatGo.AddComponent<BoatForwardBehavior>();

        forwardBe.Speed = boatSpeed;
        forwardBe.Priority = 10;
    }
}

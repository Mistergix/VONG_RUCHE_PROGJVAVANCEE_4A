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
        player = GetComponentInParent<Player>();
    }

    public void LevelupBoat(Boat boat)
    {
        GameObject boatGo = boat.gameObject;

        int level = Mathf.Clamp(player.Level, 1, 3);

        if (level >= 1 && ! boatGo.TryGetComponent(out BoatForwardBehavior boatForwardBehavior))
        {
            BoatForwardBehavior forwardBe = boatGo.AddComponent<BoatForwardBehavior>();

            forwardBe.Speed = boatSpeed;
            forwardBe.Priority = 10;
        }


        if (level >= 2 && !boatGo.TryGetComponent(out BoatDodgeBehavior boatDodgeBehavior1))
        {
            BoatDodgeBehavior boatDodgeBehavior = boatGo.AddComponent<BoatDodgeBehavior>();
            boatDodgeBehavior.Priority = 1;
        }

        if(level >= 3 && !boatGo.TryGetComponent(out BoatShootBehavior boatShoot))
        {
            BoatShootBehavior boatShootBehavior = boatGo.AddComponent<BoatShootBehavior>();
            boatShootBehavior.Priority = 5;
        }

        boat.Level = level;
        boat.ResetBehavior();
    }
}

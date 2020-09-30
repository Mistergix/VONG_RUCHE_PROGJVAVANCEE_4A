using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GameOver : MonoBehaviour
{
    [SerializeField]
    private GameEvent gameOver;

    private Player leftBoat, rightBoat;

    public void Init(Player leftBoat, Player rightBoat) {
        this.leftBoat = leftBoat;
        this.rightBoat = rightBoat;
    }

    public void CheckIfRightPlayerIsDead() {
        if (rightBoat.CurrentLife <= 0) {
            gameOver.Raise();
        }
    }
    
    public void CheckIfLeftPlayerIsDead() {
        if (leftBoat.CurrentLife <= 0) {
            gameOver.Raise();
        }
    }
}

using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GameOver : MonoBehaviour
{
    [SerializeField]
    private GameEvent gameOver;
    [SerializeField]
    private GameData mainData;

    private Player leftBoat, rightBoat;

    public void Init(Player leftBoat, Player rightBoat) {
        this.leftBoat = leftBoat;
        this.rightBoat = rightBoat;
    }

    public void CheckIfRightPlayerIsDead() {
        if (rightBoat.CurrentLife <= 0) {
            mainData.LeftWon = true;
            gameOver.Raise();
        }
    }
    
    public void CheckIfLeftPlayerIsDead() {
        if (leftBoat.CurrentLife <= 0) {
            mainData.LeftWon = false;
            gameOver.Raise();
        }
    }
}

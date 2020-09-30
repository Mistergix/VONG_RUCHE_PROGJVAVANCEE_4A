using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GameOver : MonoBehaviour
{
    private Player leftBoat, rightBoat;
    [SerializeField]
    private SceneLoading sceneLoader;

    public void Init(Player leftBoat, Player rightBoat) {
        this.leftBoat = leftBoat;
        this.rightBoat = rightBoat;
    }

    public void CheckIfRightPlayerIsDead() {
        if (rightBoat.CurrentLife <= 0) {
            sceneLoader.GameOver();
        }
    }
    
    public void CheckIfLeftPlayerIsDead() {
        if (leftBoat.CurrentLife <= 0) {
            sceneLoader.GameOver();
        }
    }
}

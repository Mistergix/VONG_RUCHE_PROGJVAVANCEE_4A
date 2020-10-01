using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class LevelManager : MonoBehaviour
{
    [SerializeField]
    private GameEvent gameOver;
    [SerializeField]
    private int boatPerLevel = 5, gameOverThresholdLevel = 4;

    private Player leftPlayer, rightPlayer;

    private int leftScore, rightScore;

    private int GameOverBoatNumber { get => boatPerLevel * gameOverThresholdLevel; }

    public void Init(Player lp, Player rp)
    {
        leftPlayer = lp;
        rightPlayer = rp;

        leftScore = 0;
        rightScore = 0;
    }

    public void OnLeftPlayerBoatPassed() {
        leftScore++;

        if(leftScore % boatPerLevel == 0)
        {
            leftPlayer.LevelUp();
        }

        if(leftScore >= GameOverBoatNumber)
        {
            gameOver.Raise();
        }
    }
    public void OnRightPlayerBoatPassed() {
        rightScore++;

        if (rightScore % boatPerLevel == 0)
        {
            rightPlayer.LevelUp();
        }

        if (rightScore >= GameOverBoatNumber)
        {
            gameOver.Raise();
        }
    }
}

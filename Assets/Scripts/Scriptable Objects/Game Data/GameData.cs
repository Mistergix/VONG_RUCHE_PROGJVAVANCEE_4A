using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[CreateAssetMenu(fileName = "Game Data", menuName = "Game Data", order =51)]
public class GameData : ScriptableObject
{
    private bool leftWon;

    public bool LeftWon { get => leftWon; set => leftWon = value; }
}

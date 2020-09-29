using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[CreateAssetMenu(fileName = "New Player Data", menuName = "Player/Data", order = 51)]
public class PlayerData : ScriptableObject
{
    [SerializeField]
    private KeyCode up, down, left, right, shoot, spawn;

    public KeyCode Up { get => up; private set => up = value; }
    public KeyCode Down { get => down; private set => down = value; }
    public KeyCode Left { get => left; private set => left = value; }
    public KeyCode Right { get => right; private set => right = value; }
    public KeyCode Shoot { get => shoot; private set => shoot = value; }
    public KeyCode Spawn { get => spawn; private set => spawn = value; }
}

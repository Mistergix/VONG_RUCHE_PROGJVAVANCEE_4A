using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[CreateAssetMenu(fileName = "New Player Data", menuName = "Player/Data", order = 51)]
public class PlayerData : ScriptableObject
{
    [SerializeField]
    private KeyCode up, down, left, right, shoot, spawn;

    [SerializeField]
    private bool isLeft;

    [SerializeField]
    private GameEvent takeDamageEvent, shootEvent, spawnEvent, boatBorderEvent;

    public KeyCode Up { get => up; private set => up = value; }
    public KeyCode Down { get => down; private set => down = value; }
    public KeyCode Left { get => left; private set => left = value; }
    public KeyCode Right { get => right; private set => right = value; }
    public KeyCode Shoot { get => shoot; private set => shoot = value; }
    public KeyCode Spawn { get => spawn; private set => spawn = value; }
    public bool IsLeft { get => isLeft; private set => isLeft = value; }
    public GameEvent TakeDamageEvent { get => takeDamageEvent; private set => takeDamageEvent = value; }
    public GameEvent ShootEvent { get => shootEvent; private set => shootEvent = value; }
    public GameEvent SpawnEvent { get => spawnEvent; private set => spawnEvent = value; }
    public GameEvent BoatBorderEvent { get => boatBorderEvent; private set => boatBorderEvent = value; }
}

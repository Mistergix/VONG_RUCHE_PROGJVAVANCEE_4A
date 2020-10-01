﻿using System.Collections;
using System.Collections.Generic;
using System.Linq;
using UnityEngine;

public class Boat : MonoBehaviour
{
    private List<BoatBehavior> behaviors;
    [SerializeField]
    private bool isLeft;

    private GameEvent onBorderPasseEvent;

    private int level;

    private Player player;
    public Player PlayerInstance { get => player; private set => player = value; }

    public bool IsLeft { get => isLeft; set => isLeft = value; }
    public GameEvent OnBorderPassedEvent { get => onBorderPasseEvent; set => onBorderPasseEvent = value; }
    public int Level { get => level; set => level = value; }

    [SerializeField]
    private LayerMask playerMask, wallMask, boatMask;

    private void Start()
    {
        Level = 0;
    }

    public void Initialize(Player player, Transform tf) {
        PlayerInstance = player;
        transform.position = new Vector3(tf.position.x, 0, tf.position.z);
    }

    // Start is called before the first frame update
    void OnEnable()
    {
        ResetBehavior();
    }

    public void ResetBehavior()
    {
        behaviors = GetComponentsInChildren<BoatBehavior>().ToList();
        behaviors.Sort(new BoatBehaviorComparer());
    }

    // Update is called once per frame
    void Update()
    {
        foreach (BoatBehavior behavior in behaviors)
        {
            behavior.Execute();
        }
    }

    public Vector3 Direction() {
        if (IsLeft) {
            return Vector3.right;
        } else {
            return Vector3.left;
        }
    }

    private void OnCollisionEnter(Collision collision) {
        if ((playerMask.value & (1 << collision.gameObject.layer)) > 0) {
            collision.gameObject.GetComponent<Player>().TakeDamage(1);
            PoolManager.RecycleGameObject(gameObject);
        } else if ((wallMask.value & (1 << collision.gameObject.layer)) > 0) {
            OnBorderPassedEvent.Raise();
            PoolManager.RecycleGameObject(gameObject);
        } else if ((boatMask.value & (1 << collision.gameObject.layer)) > 0) {
            PoolManager.RecycleGameObject(collision.gameObject);
            PoolManager.RecycleGameObject(gameObject);
        }
    }
}

using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public abstract class PlayerMovement : MonoBehaviour
{
    [SerializeField]
    private float speed;

    public float Speed { get => speed; private set => speed = value; }

    void Start()
    {
        Init();
    }

    protected virtual void Init()
    {

    }

    protected abstract Vector3 Direction();

    internal void HandleMove()
    {
        transform.position += Direction().normalized * speed * Time.deltaTime;
    }
}

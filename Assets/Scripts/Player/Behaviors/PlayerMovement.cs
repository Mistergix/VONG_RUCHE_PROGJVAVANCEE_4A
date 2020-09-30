using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public abstract class PlayerMovement : MonoBehaviour
{
    [SerializeField]
    private float speed;

    [SerializeField]
    [Range(0,1)]
    private float freeSpacePercentage;

    [SerializeField]
    private Transform moveMin, moveMax;

    private float moveQuantity;

    public float Speed { get => speed; private set => speed = value; }

    public virtual void Init()
    {
        float remaining = (1 - freeSpacePercentage) / 2;

        Camera main = Camera.main;

        Vector3 bottom = main.ViewportToWorldPoint(new Vector3(0, remaining, main.transform.position.y));
        Vector3 top = main.ViewportToWorldPoint(new Vector3(0, 1 - remaining, main.transform.position.y));

        moveMin.position = new Vector3(transform.position.x, transform.position.y, bottom.z);
        moveMax.position = new Vector3(transform.position.x, transform.position.y, top.z);
    }

    private void Update()
    {
    }

    protected abstract Vector3 Direction();

    internal void HandleMove()
    {
        transform.position += Direction().normalized * speed * Time.deltaTime;
    }
}

﻿using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Bullet : MonoBehaviour
{
    [SerializeField]
    private float timeToEnd;

    private Vector3 parabola;

    private float x;
    private float speed;

    private bool isLeft;

    private float sign;

    private Player player;

    [SerializeField]
    private LayerMask boatMask;

    public Player PlayerInstance { get => player; private set => player = value; }

    private void OnEnable()
    {
        StartCoroutine(Recycle(timeToEnd + 1));
    }

    IEnumerator Recycle(float lifeTime)
    {
        yield return new WaitForSeconds(lifeTime);

        PoolManager.RecycleGameObject(gameObject);
    }

    public void Initialize(Vector3 parabola, Vector3 start, Vector3 end, bool isLeft, Player player)
    {
        this.parabola = parabola;
        transform.position = start;
        x = transform.position.x;
        speed = Mathf.Abs(end.x - start.x) / timeToEnd;

        this.isLeft = isLeft;

        sign = isLeft ? 1 : -1;

        this.PlayerInstance = player;
    }

    private void Update()
    {
        x += sign * speed * Time.deltaTime;
        float y = Geometry.CalulateParabolaWithTurningPoint(parabola, x);

        transform.position = new Vector3(x, y, transform.position.z);
    }

    public void TouchedWater()
    {
        PoolManager.RecycleGameObject(gameObject);
    }

    private void OnCollisionEnter(Collision collision) {
        if ((boatMask.value & 1 << collision.gameObject.layer) > 0) {
            if (isLeft != collision.gameObject.GetComponent<Boat>().IsLeft) {
                PoolManager.RecycleGameObject(collision.gameObject);
                PoolManager.RecycleGameObject(gameObject);
            } else {
                PoolManager.RecycleGameObject(gameObject);
            }
        }
    }
}

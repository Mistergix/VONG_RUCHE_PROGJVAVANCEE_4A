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

    [SerializeField]
    private ParticleSystem foamSystem;

    private float moveQuantity;

    public float Speed { get => speed; private set => speed = value; }
    public float MoveQuantity { get => moveQuantity; private set => moveQuantity = Mathf.Clamp01(value); }

    public static float InverseLerp(Vector3 a, Vector3 b, Vector3 value)
    {
        Vector3 AB = b - a;
        Vector3 AV = value - a;
        return Vector3.Dot(AV, AB) / Vector3.Dot(AB, AB);
    }

    public virtual void Init()
    {
        float remaining = (1 - freeSpacePercentage) / 2;

        Camera main = Camera.main;

        Vector3 bottom = main.ViewportToWorldPoint(new Vector3(0, remaining, main.transform.position.y));
        Vector3 top = main.ViewportToWorldPoint(new Vector3(0, 1 - remaining, main.transform.position.y));

        moveMin.position = new Vector3(transform.position.x, transform.position.y, bottom.z);
        moveMax.position = new Vector3(transform.position.x, transform.position.y, top.z);

        MoveQuantity = InverseLerp(moveMin.position, moveMax.position, transform.position);

        moveMin.transform.parent = null;
        moveMax.transform.parent = null;

        foamSystem.Stop();

        lastDirection = 0;
    }

    protected abstract float UpDirection();

    private float lastDirection;

    internal void HandleMove()
    {
        float direction = UpDirection();

        if(lastDirection == 0 && direction != 0)
        {
            foamSystem.Play();
        }
        else if (lastDirection != 0 && direction == 0)
        {
            foamSystem.Stop();
        }

        lastDirection = direction;

        MoveQuantity += direction * speed * Time.deltaTime;

        transform.position = Vector3.Lerp(moveMin.position, moveMax.position, MoveQuantity);
    }
}

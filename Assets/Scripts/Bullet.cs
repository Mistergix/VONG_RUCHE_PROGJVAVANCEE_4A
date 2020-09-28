using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Bullet : MonoBehaviour
{
    [SerializeField]
    private float timeToEnd;

    private Vector3 parabola;

    private float x;
    private float speed;

    private void OnEnable()
    {
        StartCoroutine(Recycle(timeToEnd + 1));
    }

    IEnumerator Recycle(float lifeTime)
    {
        yield return new WaitForSeconds(lifeTime);

        PoolManager.RecycleGameObject(gameObject);
    }

    public void Initialize(Vector3 parabola, Vector3 start, Vector3 end)
    {
        this.parabola = parabola;
        transform.position = start;
        x = transform.position.x;
        speed = Mathf.Abs(end.x - start.x) / timeToEnd;
    }

    private void Update()
    {
        x += speed * Time.deltaTime;
        float y = Geometry.CalulateParabolaWithTurningPoint(parabola, x);

        transform.position = new Vector3(x, y, transform.position.z);
    }

    public void TouchedWater()
    {
        PoolManager.RecycleGameObject(gameObject);
    }
}

using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Bullet : MonoBehaviour
{
    [SerializeField]
    private float timeToEnd;

    private Vector3 parabola;

    [SerializeField]
    private GameObject explosionGameObject, ploufGameObject;

    private float x;
    private float speed;

    private bool isLeft;

    private float sign;
    [SerializeField]
    private LayerMask boatMask;

    public Player PlayerInstance { get; private set; }

    Coroutine recycleRoutine;

    private void Start()
    {
    }

    private void OnEnable()
    {
        recycleRoutine = StartCoroutine(Recycle(timeToEnd + 0));
    }

    IEnumerator Recycle(float lifeTime)
    {
        yield return new WaitForSeconds(lifeTime);

        Destroy(Instantiate(ploufGameObject, landSpot, Quaternion.identity), 2);

        PoolManager.RecycleGameObject(gameObject);
    }

    private void Explode()
    {
        Destroy(Instantiate(explosionGameObject, transform.position, Quaternion.identity), 2);
    }

    private Vector3 landSpot;

    public void Initialize(Vector3 parabola, Vector3 start, Vector3 end, bool isLeft, Player player)
    {
        this.parabola = parabola;
        transform.position = start;
        x = transform.position.x;
        speed = Mathf.Abs(end.x - start.x) / timeToEnd;

        this.isLeft = isLeft;

        sign = isLeft ? 1 : -1;

        this.PlayerInstance = player;
        landSpot = end;
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
        
        Explode();

        StopCoroutine(recycleRoutine);


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

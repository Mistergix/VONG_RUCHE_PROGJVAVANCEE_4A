using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BoatBullet : MonoBehaviour
{
    [SerializeField]
    private float speed;

    private Vector3 direction;

    [SerializeField]
    private LayerMask boatMask, playerMask, wallMask;

    public void Init(Vector3 direction) {
        this.direction = direction; 
    }
    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        transform.position += direction * speed * Time.deltaTime;
    }

    private void OnCollisionEnter(Collision collision) {
        if ((playerMask.value & 1 << collision.gameObject.layer) > 0) {
            collision.gameObject.GetComponent<Player>().TakeDamage(1);
            PoolManager.RecycleGameObject(gameObject);
        } else if ((boatMask.value & 1 << collision.gameObject.layer) > 0) {
            PoolManager.RecycleGameObject(gameObject);
            PoolManager.RecycleGameObject(collision.gameObject);
        } else if ((wallMask.value & 1 << collision.gameObject.layer) > 0) {
            PoolManager.RecycleGameObject(gameObject);
        }
    }
}

using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Bonus : MonoBehaviour
{
    [SerializeField]
    private LayerMask bulletMask, boatMask;
    [SerializeField]
    private float upForce = 0.25f;

    private BonusEvent bonusEvent;

    public void Init(BonusEvent eventBonus)
    {
        bonusEvent = eventBonus;
        elapsed = 0;
    }

    private void OnCollisionEnter(Collision collision)
    {
        if ((bulletMask.value & (1 << collision.gameObject.layer)) > 0)
        {
            if(collision.gameObject.TryGetComponent(out Bullet bullet))
            {
                bonusEvent.Raise(bullet.PlayerInstance);
            }

            PoolManager.RecycleGameObject(gameObject);
            PoolManager.RecycleGameObject(collision.gameObject);
        }
        else if ((boatMask.value & (1 << collision.gameObject.layer)) > 0)
        {
            PoolManager.RecycleGameObject(gameObject);
        }
    }

    float elapsed;

    private void Update()
    {
        transform.position += Vector3.up * Mathf.Sin(elapsed) * upForce * Time.deltaTime;
        elapsed += Time.deltaTime;
    }
}

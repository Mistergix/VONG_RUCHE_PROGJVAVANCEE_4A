using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Bonus : MonoBehaviour
{
    [SerializeField]
    private LayerMask bulletMask, boatMask;

    private BonusEvent bonusEvent;

    public void Init(BonusEvent eventBonus)
    {
        bonusEvent = eventBonus;
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
        }
        else if ((boatMask.value & (1 << collision.gameObject.layer)) > 0)
        {
            PoolManager.RecycleGameObject(gameObject);
        }
    }
}

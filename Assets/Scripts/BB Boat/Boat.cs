using System.Collections;
using System.Collections.Generic;
using System.Linq;
using UnityEngine;

public class Boat : MonoBehaviour
{
    private List<BoatBehavior> behaviors;
    [SerializeField]
    private bool isLeft;

<<<<<<< HEAD
    public bool IsLeft { get => isLeft; set => isLeft = value; }
=======
    [SerializeField]
    private LayerMask playerMask;
>>>>>>> DamagePlayers

    // Start is called before the first frame update
    void Start()
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
        }
    }
}

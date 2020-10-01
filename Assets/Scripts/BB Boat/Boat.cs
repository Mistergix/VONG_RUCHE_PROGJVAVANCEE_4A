using System.Collections;
using System.Collections.Generic;
using System.Linq;
using UnityEngine;

public class Boat : MonoBehaviour
{
    private List<BoatBehavior> behaviors;
    [SerializeField]
    private bool isLeft;
    [SerializeField]
    private GameObject renderer;
    [SerializeField]
    private GameObject explosionPrefab;

    public Player PlayerInstance { get; private set; }

    public bool IsLeft { get => isLeft;
        set
        {
            isLeft = value;

            if(isLeft)
            {
                renderer.transform.rotation = Quaternion.Euler(0, -90, 0);
            }
            else
            {
                renderer.transform.rotation = Quaternion.Euler(0, 90, 0);
            }
        }
    }
    public GameEvent OnBorderPassedEvent { get; set; }
    public int Level { get; set; }

    [SerializeField]
    private LayerMask playerMask, wallMask, boatMask;

    private void Start()
    {
        Level = 0;
    }

    public void Initialize(Player player, Transform tf) {
        PlayerInstance = player;
        transform.position = new Vector3(tf.position.x, 0, tf.position.z);
    }

    // Start is called before the first frame update
    void OnEnable()
    {
        ResetBehavior();
    }

    public void ResetBehavior()
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

    private void Explode()
    {
        Instantiate(explosionPrefab, transform.position, Quaternion.identity);
    }

    private void OnCollisionEnter(Collision collision) {
        if ((playerMask.value & (1 << collision.gameObject.layer)) > 0) {
            collision.gameObject.GetComponent<Player>().TakeDamage(1);
            PoolManager.RecycleGameObject(gameObject);
            Explode();
        } else if ((wallMask.value & (1 << collision.gameObject.layer)) > 0) {
            OnBorderPassedEvent.Raise();
            PoolManager.RecycleGameObject(gameObject);
        } else if ((boatMask.value & (1 << collision.gameObject.layer)) > 0) {
            PoolManager.RecycleGameObject(collision.gameObject);
            PoolManager.RecycleGameObject(gameObject);
            Explode();
        }
    }
}

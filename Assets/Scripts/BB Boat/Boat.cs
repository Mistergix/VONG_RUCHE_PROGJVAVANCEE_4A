using System.Collections;
using System.Collections.Generic;
using System.Linq;
using UnityEngine;

public class Boat : MonoBehaviour
{
    private List<BoatBehavior> behaviors;
    [SerializeField]
    private bool isLeft;

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
        if (isLeft) {
            return Vector3.right;
        } else {
            return Vector3.left;
        }
    }
}

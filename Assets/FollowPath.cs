using System.Collections;
using System.Collections.Generic;
using System.Linq;
using UnityEngine;

public class FollowPath : MonoBehaviour
{
    [SerializeField]
    private GameObject route;

    [SerializeField]
    private float speed;

    private List<Transform> waypoints;

    private int currentWaypointIndex;

    private int CurrentWaypointIndex
    {
        get => currentWaypointIndex;
        set
        {
            currentWaypointIndex = value % waypoints.Count;
        }
    }

    private int NextWaypointIndex { get  {
            return (CurrentWaypointIndex + 1) % waypoints.Count;
        } }

    private Transform CurrentWaypoint { get => waypoints[CurrentWaypointIndex]; }
    private Transform NextWaypoint { get => waypoints[NextWaypointIndex];  }
    public float Waypointcompletion { get => waypointcompletion; set => waypointcompletion = Mathf.Clamp01(value); }
    public float Speed { get => speed / 100; set => speed = value; }

    // Start is called before the first frame update
    void Start()
    {
        waypoints = route.GetComponentsInChildren<Transform>().ToList();

        waypoints.RemoveAt(0);

        CurrentWaypointIndex = 0;
        
        transform.position = CurrentWaypoint.position;

        transform.rotation = Quaternion.FromToRotation(-transform.forward, NextWaypoint.position);
    }

    float waypointcompletion = 0;

    // Update is called once per frame
    void Update()
    {
        transform.position = Vector3.Lerp(transform.position, NextWaypoint.position, Waypointcompletion);
        Waypointcompletion += Speed * Time.deltaTime / Vector3.Distance(CurrentWaypoint.position, NextWaypoint.position);

        if(Waypointcompletion == 1)
        {
            Waypointcompletion = 0;
            CurrentWaypointIndex++;
            transform.rotation = Quaternion.FromToRotation(-transform.forward, NextWaypoint.position);
        }
    }
}

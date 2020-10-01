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
    public float Speed { get => speed; set => speed = value; }

    private Vector3 Direction { get => NextWaypoint.position - transform.position; }

    // Start is called before the first frame update
    void Start()
    {
        waypoints = route.GetComponentsInChildren<Transform>().ToList();

        waypoints.RemoveAt(0);

        CurrentWaypointIndex = 0;
        
        transform.position = CurrentWaypoint.position;
    }

    float waypointcompletion = 0;
    [SerializeField]
    private float rotationSpeed;

    // Update is called once per frame
    void Update()
    {
        transform.position += Direction.normalized * Speed * Time.deltaTime;

        if (Vector3.Distance(transform.position, NextWaypoint.position) <= 0.5f)
        {
            CurrentWaypointIndex++;
        }

        if (Direction != Vector3.zero)
        {
            transform.rotation = Quaternion.Slerp(
                transform.rotation,
                Quaternion.LookRotation(-Direction),
                Time.deltaTime * rotationSpeed
            );
        }
    }
}

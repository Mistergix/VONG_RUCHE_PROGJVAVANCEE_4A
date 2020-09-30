using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BoatDodgeBehavior : BoatBehavior {
    private Boat boat;
    private ZoneDetection zoneDetection;

    private void Start() {

        zoneDetection = GetComponentInChildren<ZoneDetection>();

        boat = GetComponent<Boat>();
        if (boat.Direction().Equals(Vector3.left)) {
            float pos = zoneDetection.transform.localPosition.x;
            zoneDetection.transform.localPosition = new Vector3(-pos, transform.position.y, 0f);
        }
        zoneDetection.Init();
    }

    /// <summary>
    /// UNE FOIS SI suffisament proche du joueur, se décale un peu pour essayer de le toucher
    /// </summary>
    public override void Execute() {

        if (Vector3.Distance(transform.position, zoneDetection.PlayerPosition) >= 3.5f) {
            if (zoneDetection.DodgeOnce) {
                if ((boat.Direction().Equals(Vector3.left) && transform.position.x > zoneDetection.PlayerPosition.x) ||
                    (boat.Direction().Equals(Vector3.right) && transform.position.x < zoneDetection.PlayerPosition.x)) {
                    if (transform.position.z > zoneDetection.PlayerPosition.z || transform.position.z < zoneDetection.PlayerPosition.z) {
                        transform.position =
                            Vector3.MoveTowards(new Vector3(transform.position.x, transform.position.y, transform.position.z),
                            new Vector3(transform.position.x, transform.position.y, zoneDetection.PlayerPosition.z),
                            5f * Time.deltaTime);
                    }
                }
            }
        }
    }

    private void OnDisable() {
        zoneDetection = GetComponentInChildren<ZoneDetection>();
        Reset();
    }
    public void Reset() {
        zoneDetection.Init();
    }
}

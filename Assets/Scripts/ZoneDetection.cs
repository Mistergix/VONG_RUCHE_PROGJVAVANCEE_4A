using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ZoneDetection : MonoBehaviour
{
    [SerializeField]
    private LayerMask playerMask;
    public bool DodgeOnce { get; set; }
    public Vector3 PlayerPosition { get; set; }

    private void OnEnable() {
        PlayerPosition = new Vector3(Camera.main.orthographicSize*2 +5, Camera.main.orthographicSize*2 + 5, Camera.main.orthographicSize*2 + 5);
    }

    public void Init() {
        DodgeOnce = false;
    }
    private void OnTriggerEnter(Collider other) {
        if ((playerMask.value & 1 << other.gameObject.layer) > 0) {
            DodgeOnce = true;
            PlayerPosition = other.gameObject.transform.position;
        }
    }
}

using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class LaserPointerController : MonoBehaviour
{
    [SerializeField] LaserController laser;

    private void OnTriggerEnter(Collider other)
    {
        laser.enabled = true;
    }
    private void OnTriggerExit(Collider other)
    {
        laser.enabled = false;
    }

}

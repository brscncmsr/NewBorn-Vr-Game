using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MarkerAnimationController : MonoBehaviour
{
    public GameObject marker;

    private void OnTriggerEnter(Collider other)
    {
            marker.GetComponent<Animator>().enabled = false;
            marker.SetActive(false);
    }
    private void OnTriggerExit(Collider other)
    {
        marker.GetComponent<Animator>().enabled = true;
        marker.SetActive(true);
    }


}

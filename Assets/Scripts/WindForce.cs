using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class WindForce : MonoBehaviour
{
    [SerializeField]
    float windForce = 0;

    private void OnTriggerStay(Collider other)
    {
        var hitObj = other.gameObject;

        if (hitObj != null)
        {
            var rb = hitObj.GetComponent<Rigidbody>();
            var dir = new Vector3(windForce,0,0); ;
            rb.AddForce(dir);
        }
    }
}

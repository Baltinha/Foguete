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
            var dir = hitObj.transform.right;
            rb.AddForce(dir * windForce);
        }
    }
}

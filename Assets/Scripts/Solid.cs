using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Solid : MonoBehaviour
{
    public Foguete foguete;

    void OnTriggerEnter(Collider other)
    {
        if (other.CompareTag("Ground"))
        {
            foguete.body.isKinematic = true;
        }
    }
}
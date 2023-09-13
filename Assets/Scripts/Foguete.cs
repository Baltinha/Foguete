using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Foguete : MonoBehaviour
{
    [Header("Rigidbody object")]
    Rigidbody body;
    public float valueUp;
    public float valueDown;
    [Header("Timer")]
    public Timer timer;


    // Start is called before the first frame update
    void Start()
    {
        body = GetComponent<Rigidbody>();
    }

    // Update is called once per frame
    void FixedUpdate()
    {
        body.AddForce(transform.up * valueUp);


        if (timer.currentTimer >= 5.0 )
        {
            valueUp = 0;
            body.AddForce(transform.up * 0);
            body.drag = valueDown;

        }

    }

}

using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Foguete : MonoBehaviour
{
    [Header("Rigidbody object")]
    public float valueUp;
    public float valueDown;
    public float maxHeight;
    private Rigidbody body;
    [Header("Timer")]
    public Timer timer;
    [Header("Paraquedas")]
    public GameObject paraquedas;
    [Header("ParticleSystem")]
    public ParticleSystem fire;


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
            paraquedas.SetActive(true);
            valueUp = -valueDown * Time.deltaTime;
            body.AddForce(transform.up * 0);
            body.drag = valueDown;
            
        }

        if (body.velocity.y < 0)
        {
            
            maxHeight = body.velocity.y;
        }
    }

}

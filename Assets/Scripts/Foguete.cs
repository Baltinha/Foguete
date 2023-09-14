using System.Collections;
using System.Collections.Generic;
using Unity.VisualScripting;
using UnityEngine;

public class Foguete : MonoBehaviour
{
    [Header("Rigidbody object")]
    public float valueUp;
    public float valueDown;
    public float maxHeight;
    [HideInInspector]
    public Rigidbody body;
    [Header("Timer")]
    public Timer timer;
    [Header("Anoter objs")]
    public GameObject paraquedas;
    private PrimeiroEstagio primeiroEstagio;
    [Header("ParticleSystem")]
    public ParticleSystem fire;


    // Start is called before the first frame update
    void Start()
    {
        fire.Pause();
        fire.Clear();
        body = GetComponent<Rigidbody>();
        primeiroEstagio = GetComponentInChildren<PrimeiroEstagio>();
    }

    // Update is called once per frame
    void FixedUpdate()
    {
        //Vector3 vector3 = new Vector3(5,valueUp,0);
        body.AddForce(transform.up * valueUp);
        if (primeiroEstagio.fristComp == true) 
        {
            body.drag = valueDown;
            fire.Play();
        }
        if (timer.currentTimer >= 5.0 )
        {
            StopMove();
        }

        if (body.velocity.y < 0)
        {
            
            maxHeight = body.velocity.y;
        }
 

    }

    void StopMove() 
    {
        fire.Stop();
        paraquedas.SetActive(true);
        valueUp = -valueUp * Time.deltaTime;
        body.AddForce( transform.up * 0);
        body.drag = valueDown;
    }
}

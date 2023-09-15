using System.Collections;
using System.Collections.Generic;
using Unity.VisualScripting;
using UnityEngine;

public class SegundoEstagio : MonoBehaviour
{
    [Header("Rigidbody object")]
    public float valueDown;
    public float maxHeight;
    private float valueUp;
    [HideInInspector]
    public Rigidbody body;
    [Header("Timer")]
    public Timer timer;
    private bool noMove = true;
    [Header("Anoter objs")]
    public GameObject paraquedas;
    public PrimeiroEstagio primeiroEstagio;
    public Transform newPosition;
    [Header("ParticleSystem")]
    public ParticleSystem fire;


    // Start is called before the first frame update
    void Start()
    {
        fire.Pause();
        fire.Clear();
        body = GetComponent<Rigidbody>();

        valueUp = primeiroEstagio.valueUp;
    }

    // Update is called once per frame
    void FixedUpdate()
    {
        Vector3 vector3Inercia = new Vector3(0, valueUp,0);

        if (primeiroEstagio.fristComp == true && noMove == true) 
        {
            body.isKinematic = false;
            body.AddForce(vector3Inercia);
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
        Vector3 giro = new Vector3 (0,10,0);
        noMove = false;
        fire.Stop();
        paraquedas.SetActive(true);
        body.drag = valueDown;
        //body.AddRelativeTorque(giro);
    }

    void OnTriggerEnter(Collider other)
    {
        if (other.CompareTag("Ground"))
        {
           body.isKinematic = true;
        }
    }
}

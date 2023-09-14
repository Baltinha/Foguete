using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PrimeiroEstagio : MonoBehaviour
{
    [Header("Rigdyboad")]
    public float valueUp;
    public float valueDown;
    private Rigidbody compRigdy;
    [Header("ParticleSystem")]
    public ParticleSystem fire;
    public bool fristComp = false;
    [Header("Timer")]
    public Timer timer;
    void Start()
    {
        compRigdy = GetComponent<Rigidbody>();
    }

    // Update is called once per frame
    void FixedUpdate()
    {

        if (timer.currentTimer >= 2.5) 
        {
            Separetion();
        }
    }

    void Separetion() 
    {
        fire.Pause();
        fire.Clear();
        fristComp = true;
        compRigdy.isKinematic = false;
        compRigdy.drag = valueDown;

    }
}

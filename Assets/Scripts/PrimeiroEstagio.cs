using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class PrimeiroEstagio : MonoBehaviour
{
    [Header("Rigdyboad value")]
    public float valueUp;
    public float valueDown;
    private Rigidbody compRigdy;

    [Header("ParticleSystem")]
    public ParticleSystem fire;
    public bool fristComp = false;

    [Header("Timer")]
    public Timer timer;

    [Header("Sound")]
    [HideInInspector]
    public AudioSource somFoguete;

    void Start()
    {
        compRigdy = GetComponent<Rigidbody>();
        somFoguete = GetComponent<AudioSource>();
    }

    // Update is called once per frame
    void FixedUpdate()
    {
        if (fristComp == false)
        {
            StarMove();
        }

        if (timer.currentTimer >= 2.5) 
        {
            Separetion();
        }
    }

    #region ClassesMoves
    void StarMove() 
    {
        Vector3 vector3 = new Vector3(0, valueUp, 0);
        compRigdy.AddForce(vector3);
        somFoguete.Play();
    }
    void Separetion() 
    {
        this.transform.SetParent(null);
        fristComp = true;
        fire.Pause();
        fire.Clear();
        compRigdy.drag = valueDown;
    }
    #endregion


}

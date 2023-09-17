using System.Collections;
using System.Collections.Generic;
using Unity.VisualScripting;
using UnityEngine;

public class SegundoEstagio : MonoBehaviour
{
    [Header("Rigidbody value")]
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
    public Transform cameraTrasforme;

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

        if (primeiroEstagio.fristComp == true && noMove == true) 
        {
            StarMove();
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
    #region ClassesMoves
        
    void StarMove() 
    {
        Vector3 vector3Inercia = new Vector3(0, valueUp, 0);
        body.isKinematic = false;
        body.AddForce(vector3Inercia);
        fire.Play();
    } 

    void StopMove() 
    {
        Vector3 giro = new Vector3 (0,10,0);
        noMove = false;
        fire.Stop();
        primeiroEstagio.somFoguete.Stop();
        paraquedas.SetActive(true);
        body.drag = valueDown;
        cameraTrasforme.SetParent(null);
        this.transform.SetParent(null);
        this.transform.rotation = Quaternion.Euler((float)-88.72, (float)-88.404, (float)-192.914);
        cameraTrasforme.SetParent(this.transform);

    }
    #endregion
    #region Ontrigger
    void OnTriggerEnter(Collider other)
    {
        if (other.CompareTag("Ground"))
        {
           body.isKinematic = true;
           timer.stopTime = true;
        }
    }
    #endregion
}

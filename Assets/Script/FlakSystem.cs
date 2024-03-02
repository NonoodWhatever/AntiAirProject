using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class FlakSystem : MonoBehaviour
{
    //[SerializeField] Collider2D Kaboomzone;
    // For PlaneProx on
    [SerializeField] float KaboomDelay; 
    //(plan)
    //for PlaneProx off, make it changeable.
    //for PlaneProx on, keep it -0.4 to 0.4. This value should be finalized
    [SerializeField] GameObject Kablewie;
    ///public float BoomTime;
    // Explosion
    float KaboomTimer;
    [SerializeField] bool PlaneProx;
    [SerializeField] Rigidbody2D RB;
    [SerializeField] float SelfDestruct = 15f;
    [SerializeField] float VelocityOfBullet = 4f;
    bool PlaneNear = false;
  
    void Start()
    {
        RB = gameObject.GetComponent<Rigidbody2D>();
        KaboomTimer = Random.Range((KaboomDelay - 0.2f), (KaboomDelay + 0.2f));
        if (KaboomTimer <= 0 && PlaneProx == true)
        {
            KaboomTimer = 0.000005f;
        }
        //else if (KaboomTimer <= 0 && PlaneProx == false)
        //{
        //    KaboomTimer = BoomTime;
        //}
    }


    void Update()
    {
        RB.velocity = transform.up * VelocityOfBullet;
        SelfDestruct -= Time.deltaTime;
        if (PlaneProx == false)
        {
            KaboomTimer -= Time.deltaTime;
        }
        else if (PlaneNear == true && PlaneProx == true)
        {
            KaboomTimer -= Time.deltaTime;
        }
        if(KaboomTimer <= 0)
        {
            Instantiate(Kablewie, transform.position, transform.rotation);
            Destroy(gameObject);
        }
        if(SelfDestruct <= 0)
        {
            Destroy(gameObject);
        }
    }
   // private void OnCollisionEnter2D(Collision2D collision)
   // {
  //      if(collision.gameObject.tag == "Plane" && PlaneProx == true)
   //     {
   //         PlaneNear = true;
   //     }
  //  }
    private void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.gameObject.tag == "Plane" && PlaneProx == true)
        {
            PlaneNear = true;
        }
        if(collision.gameObject.tag == "Bomb")
        {
            Instantiate(Kablewie, transform.position, transform.rotation);
            Destroy(gameObject);
        }
    }
}

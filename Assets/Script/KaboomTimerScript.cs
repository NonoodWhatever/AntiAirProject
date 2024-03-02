using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class KaboomTimerScript : MonoBehaviour
{
    [SerializeField] float Timer;
    [SerializeField] bool PlaneBomb;
    [SerializeField] GameObject Effect;
    [SerializeField] Vector3 V3self;
    [SerializeField] string TagCheck;
    // Update is called once per frame
    void Update()
    {
        V3self = transform.position;
        Timer -= Time.deltaTime;
        if(Timer <= 0)
        {
            if (Effect != null && PlaneBomb == false)
            {
                Instantiate(Effect, V3self, Quaternion.identity);
            }
            Destroy(gameObject);
        }
        
            
    }
    private void OnCollisionEnter2D(Collision2D collision)
    {
        TagCheck = collision.gameObject.tag;
        print(TagCheck);
        if (PlaneBomb == true)
        {
            if(collision.gameObject.tag == "Bullet")
            {
                print("denied");
                if (Effect != null)
                {
                    Instantiate(Effect, V3self, Quaternion.identity);
                }
                Destroy(gameObject);
            }
            if (collision.gameObject.tag == "Player")
            {
                print("OW");
                if (Effect != null)
                {
                    Instantiate(Effect, V3self, Quaternion.identity);
                }
                Destroy(gameObject);
            }
        }
        
        
    }
    private void OnTriggerEnter2D(Collider2D collision)
    {
        TagCheck = collision.gameObject.tag;
        print(TagCheck);
        if (PlaneBomb == true)
        {
            if (collision.gameObject.tag == "Bullet")
            {
                print("denied");
                if (Effect != null)
                {
                    Instantiate(Effect, V3self, Quaternion.identity);
                }
                Destroy(gameObject);
            }
            if (collision.gameObject.tag == "Player")
            {
                print("OW");
                if (Effect != null)
                {
                    Instantiate(Effect, V3self, Quaternion.identity);
                }
                Destroy(gameObject);
            }
        }
    }
}

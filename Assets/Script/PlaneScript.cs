using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Animations;
public class PlaneScript : MonoBehaviour
{
    [SerializeField] Rigidbody2D SelfRB;
    [SerializeField] GameObject Bomb;
    [SerializeField] GameObject BombBay;
   // [SerializeField] GameObject BombSlot;
    [SerializeField] Vector3 BombBayV3;
    float BombTime;
    [SerializeField] float BombTimeMax;
    [SerializeField] float BombTimeMin;
    bool DroppedBomb;
    [SerializeField] Animator AnimeToPlay;
    [SerializeField] GameObject EffectOnDestroy;
    [SerializeField] Vector3 V3self;
    int PlaneKill;
    [SerializeField] float Speed = 2f;
    void Start()
    {
        
        SelfRB = gameObject.GetComponent<Rigidbody2D>();
        BombTimeMax = Random.Range(BombTimeMax - 0.1f, BombTimeMax + 0.1f);
        BombTimeMin = Random.Range(BombTimeMin - 0.1f, BombTimeMin + 0.1f);
        BombTime = Random.Range(BombTimeMin, BombTimeMax);
        DroppedBomb = true;
    }

    // Update is called once per frame
    void Update()
    {
        PlaneKill = PlayerPrefs.GetInt("PlaneKilled");
        V3self = transform.position;
        BombBayV3 = BombBay.transform.position;
        SelfRB.velocity = transform.right * Speed;
        BombTime -= Time.deltaTime;
        if(BombTime <= 0 && DroppedBomb == true && Bomb != null)
        {
            AnimeToPlay.SetBool("DroppedBomb", false);
               DroppedBomb = false;
        }

    }
    private void OnCollisionEnter2D(Collision2D collision)
    {
        if(collision.transform.tag == "Bouncer")
        {
            transform.Rotate(0, 180, 0);
        }
    }
    private void OnCollisionStay2D(Collision2D collision)
    {
        if (collision.transform.tag == "FlakExplosion")
        {
            Death();
        }
    }
    private void OnTriggerStay2D(Collider2D collision)
    {
        if(collision.transform.tag == "FlakExplosion")
        {
            Death();
        }
    }

    void Death()
    {
        if (EffectOnDestroy != null)
        {
            Instantiate(EffectOnDestroy, V3self, Quaternion.identity);
        }
        PlayerPrefs.SetInt("PlaneKilled", PlaneKill + 1);
        Destroy(gameObject);
        //PlayerPrefs.SetInt("PlaneKilled", +1);
        
    }
    public void DropBomb()
    {
        if (Bomb != null)
        {
            Instantiate(Bomb, BombBayV3, Quaternion.identity);
            // Instantiate(Bomb,BombBay.transform,true);
            BombTime = Random.Range(BombTimeMin, BombTimeMax);
            AnimeToPlay.SetBool("DroppedBomb", true);
            DroppedBomb = true;
        }
    }
}

using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class AimmingScript : MonoBehaviour
{
    [SerializeField] GameObject TurningPoint;
    [SerializeField] GameObject FiringPoint;
    [SerializeField] GameObject Bullet;
    [SerializeField] GameObject MuzzleFlash;
    //[SerializeField] float MinAngle;
    //[SerializeField] float MaxAngle;
    [SerializeField] float currentAngle;
    [SerializeField] float FireDelay;
    [SerializeField] float FireDelayCounter;
    [SerializeField] bool CHEAT1;
    // Start is called before the first frame update
    void Start()
    {
        FireDelayCounter = FireDelay;
    }

    // Update is called once per frame
    void Update()
    {
        if(FireDelay > 0)
        {
            FireDelayCounter -= Time.deltaTime;
        }
        currentAngle = TurningPoint.gameObject.transform.rotation.eulerAngles.z;
        if (Input.GetKey(KeyCode.A))
        {
            TurningPoint.gameObject.transform.Rotate(0,0,1);
        }
        else if (Input.GetKey(KeyCode.D))
        {
            TurningPoint.gameObject.transform.Rotate(0, 0, -1);
        }
        if(CHEAT1 == true && Input.GetKey(KeyCode.Space)) 
        {
            FireBullet();
        }
        else if (Input.GetKey(KeyCode.Space) && FireDelayCounter <= 0 && FireDelay > 0)
        {
            // BulletThing.transform.Translate(Vector2.up * 20f * Time.deltaTime);
            FireBullet();
            ///BulletRB.AddRelativeForce(FiringPoint.transform.up, ForceMode2D.Impulse);
            /// BulletRB.AddRelativeForce(transform.up * 10, ForceMode2D.Impulse);
            ///BulletRB.velocity = *5.0f;
            FireDelayCounter = FireDelay;
        }
        else if (Input.GetKeyDown(KeyCode.Space) && FireDelay <= 0)
        {
            FireBullet();
        }
        if(Input.GetKeyDown(KeyCode.Keypad1))
        {
            if(CHEAT1 == true)
            {
                CHEAT1 = false;
            }
            else
            {
                CHEAT1 = true;
            }
        }
        void FireBullet()
        {
            var BulletThing = Instantiate(Bullet, FiringPoint.gameObject.transform.position, FiringPoint.gameObject.transform.rotation);
            Rigidbody2D BulletRB = Bullet.GetComponent<Rigidbody2D>();
            Instantiate(MuzzleFlash, FiringPoint.gameObject.transform.position, FiringPoint.gameObject.transform.rotation);
        }
    }
}

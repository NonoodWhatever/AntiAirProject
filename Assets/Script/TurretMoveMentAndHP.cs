using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class TurretMoveMentAndHP : MonoBehaviour
{
    [SerializeField] Rigidbody2D Body;
    [SerializeField] float SpeedPower;
    [SerializeField] int HP;
    public int HPCounter;
    [SerializeField] bool CHEAT2;
    [SerializeField] int SceneSelector;
    // Start is called before the first frame update
    void Start()
    {
        HPCounter = HP;
    }

    // Update is called once per frame
    void Update()
    {
        if (CHEAT2 == true)
        {
            HPCounter = -1;
        }

        if (Input.GetKeyDown(KeyCode.Keypad2))
        {
            if(CHEAT2 == false) 
            { CHEAT2 = true; } 

            else if(CHEAT2 == true)
            { CHEAT2 = false; HPCounter = HP; }

           // HPCounter++;
        }
        if (Input.GetKey(KeyCode.LeftArrow))
        {
            Body.AddForce(transform.right * -SpeedPower);
        }
        else if (Input.GetKey(KeyCode.RightArrow))
        {
            Body.AddForce(transform.right * SpeedPower);
        }
        else if (Body.velocity.x < 0)
        {
            Body.AddForce(transform.right * SpeedPower);
        }
        else if (Body.velocity.x > 0)
        {
            Body.AddForce(transform.right * -SpeedPower);
        }
    }
    private void OnCollisionEnter2D(Collision2D collision)
    {
      
        if(collision.gameObject.tag == "Bomb")
        {
            HPCounter--;
           
            if(HPCounter == 0 )
            {
                HPCounter = HP;
                SceneManager.LoadScene(SceneSelector);
            }
        }
    }
    private void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.gameObject.tag == "Bomb")
        {
            HPCounter--;

            if (HPCounter == 0)
            {
                HPCounter = HP;
                SceneManager.LoadScene(SceneSelector);
            }
        }
    }
}

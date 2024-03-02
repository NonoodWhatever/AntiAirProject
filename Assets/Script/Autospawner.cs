using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Autospawner : MonoBehaviour
{
    [SerializeField] GameObject Plane;
    [SerializeField] int amount;
    [SerializeField] float TimerRepeater;
    [SerializeField] float ActivationTime;
    [SerializeField] Transform Area;
    [SerializeField] Vector3 Area3;
    float rng;

    int planereinforcement;
    float SpawnDelay;
    float ActiveTime;

    // Start is called before the first frame update
    void Start()
    {
           SpawnDelay = TimerRepeater;
    }

    // Update is called once per frame
    void Update()
    {
        if (Plane != null && amount > 0)
        {
            ActivationTime -= Time.deltaTime;
            if (ActivationTime <= 0)
            {

                if (SpawnDelay <= 0)
                {
                    //Area = gameObject.transform;
                    rng = Random.Range(-0.5f, 0.5f);
                     
                    SpawnDelay = TimerRepeater;
                    Instantiate(Plane, Area);
                    amount--;
                }
                else
                {
                    SpawnDelay -= Time.deltaTime;
                }
            }
        }
    }
    public void Restock(float StartTime, float NewSpawnTime, int Reinforcement)
    {

    }
}

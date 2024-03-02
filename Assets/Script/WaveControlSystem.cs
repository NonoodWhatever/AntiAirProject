using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class WaveControlSystem : MonoBehaviour
{
    [SerializeField] GameObject[] SpawnPoints;
    [SerializeField] int ReinforcementToAdd;
    [SerializeField] int Wave;
    int ReinforcementAmount;
    int AmountOfPlanes;
    float Timer;

    private void Start()
    {
        Timer = 300f;
           Wave = 1;
    }

    private void Update()
    {
        Timer -= Time.deltaTime;
       AmountOfPlanes = GameObject.FindGameObjectsWithTag("Planes").Length;
        if(AmountOfPlanes == 0)
        {
            Timer = 10f;
        }
        if(Timer <= 0)
        {
            NewWave();
        }
    }

    public void NewWave()
    {
        ReinforcementAmount = ReinforcementToAdd * Wave;
    }
}

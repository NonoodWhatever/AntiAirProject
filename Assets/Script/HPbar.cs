using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;
public class HPbar : MonoBehaviour
{
    [SerializeField] TurretMoveMentAndHP HPSystem;
    [SerializeField] int HP;
    [SerializeField] TMP_Text textt;    // Start is called before the first frame update
    void Start()
    {
        PlayerPrefs.SetInt("PlaneKilled",0);
    }

    // Update is called once per frame
    void Update()
    {
        HP = HPSystem.HPCounter;
        textt.text = "HP: " + HP;
    }
}

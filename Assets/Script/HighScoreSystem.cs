using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using TMPro;
public class HighScoreSystem : MonoBehaviour
{
    int PlaneKill;
    int MaxPlaneKill;
    int WaveSurvived;
    [SerializeField] TMP_Text LastKillText;
    private void Awake()
    {
        PlaneKill = PlayerPrefs.GetInt("PlaneKilled");
        MaxPlaneKill = PlayerPrefs.GetInt("HighPlaneKill");
    }
    void Start()
    {
        if(MaxPlaneKill < PlaneKill)
        {
            PlayerPrefs.SetInt("HighPlaneKill", PlaneKill);
        }
        else if (MaxPlaneKill >= PlaneKill)
        {
            PlayerPrefs.SetInt("HighPlaneKill", MaxPlaneKill);
        }
        LastKillText.text = "Plane Killed This Round: " + PlaneKill;
    }

    // Update is called once per frame
    void Update()
    {
        
    }
}

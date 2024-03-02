using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;
using TMPro;
using UnityEngine.UI;
//using System.IO;

public class MainMenuScript : MonoBehaviour
{
    [SerializeField] TMP_Text TextKillHigh;
    [SerializeField] TMP_Text TextKillLast;
    [SerializeField] TMP_Text TextSurviveHigh;
    [SerializeField] TMP_Text TextSurviveLast;
    [SerializeField] TMP_Text TextScorelHigh;
    [SerializeField] TMP_Text TextScoreLast;
    int HighPlayKill = 0;
    int PlaneKill = 0;
    int WaveLastSurvived;
    private void Awake()
    {
        print("Hello");
        if (PlayerPrefs.GetInt("HighPlaneKill") > 0)
        {
            HighPlayKill = PlayerPrefs.GetInt("HighPlaneKill");
        }
        if (PlayerPrefs.GetInt("PlaneKilled") >= 0)
        {
            PlaneKill = PlayerPrefs.GetInt("PlaneKilled");
        }
        //if (PlayerPrefs.GetInt("PlaneKilled") > 0)
        //{
        //    PlaneKill = PlayerPrefs.GetInt("PlaneKilled");
        //}
        //if (PlayerPrefs.GetInt("PlaneKilled") > 0)
        //{
        //    PlaneKill = PlayerPrefs.GetInt("PlaneKilled");
        //}
    }
    private void Start()
    {
        if (HighPlayKill < PlaneKill)
        {
            PlayerPrefs.SetInt("HighPlaneKill", PlaneKill);
        }
        else if (HighPlayKill >= PlaneKill)
        {
            PlayerPrefs.SetInt("HighPlaneKill", HighPlayKill);
        }
        PlayerPrefs.SetInt("HighPlaneKill", HighPlayKill);
        PlayerPrefs.SetInt("PlaneKilled", PlaneKill);
        TextKillLast.text = "Plane Killed Last Round: " + PlaneKill;
        TextKillHigh.text = "Plane Killed Best Round: " + HighPlayKill;

        //PlayerPrefs.SetInt("LastWaveSurvived", WaveLastSurvived);
        //PlayerPrefs.SetInt("LastWaveSurvived", WaveLastSurvived);
    }
    //public void LevelSelect(Scene LVL)
    //{
    //    SceneManager.LoadScene(1);
    //    SceneManager.SetActiveScene(LVL);
    //}
    public void QuitGame()
    {
        Application.Quit();
    }
    public void LevelPicker(int LVL)
    {
        SceneManager.LoadScene(LVL);
        //SceneManager.SetActiveScene(LVL);
    }
}

using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.SceneManagement;

public class EmercQuitButton : MonoBehaviour
{
    [SerializeField] GameObject Peekaboo;
    [SerializeField] int SceneNum;
    [SerializeField] bool Return;
    private void Awake()
    {
        if (Peekaboo != null)
        {
            Peekaboo.SetActive(false);
        }
    }
    private void Update()
    {
        if (Input.GetKeyDown(KeyCode.Escape))
        { if(Peekaboo != null)
            {
                Peekaboo.SetActive(true);
            }
            if (Return == true)
            {
                SceneManager.LoadScene(SceneNum);
            }
            else
            {
                Application.Quit();
            }
        }
    }
}

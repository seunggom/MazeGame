using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Pause : MonoBehaviour
{
    public GameObject PauseUI;
    public static bool IsPause;

    // Use this for initialization
    void Start()
    {
        PauseUI.SetActive(false);
        IsPause = false;
    }

    // Update is called once per frame
    void Update()
    {
        if (Input.GetKeyDown(KeyCode.Escape))
        {
            /*일시정지 활성화*/
            if (IsPause == false)
            {
                Time.timeScale = 0;
                IsPause = true;
                PauseUI.SetActive(true);
                return;
            }

            /*일시정지 비활성화*/
            if (IsPause == true)
            {
                Time.timeScale = 1;
                IsPause = false;
                PauseUI.SetActive(false);
                return;
            }
        }
    }
    public void Resume()
    {
        Time.timeScale = 1;
        IsPause = false;
        PauseUI.SetActive(false);
        return;
    }
}

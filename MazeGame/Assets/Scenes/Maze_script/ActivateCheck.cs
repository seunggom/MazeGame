using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ActivateCheck : MonoBehaviour
{
    public GameObject CheckUI;
    bool IsChecking;
    // Start is called before the first frame update
    void Start()
    {
        CheckUI.SetActive(false);
        IsChecking = false;
    }

    // Update is called once per frame
    void Update()
    {
        if (Input.GetKeyDown(KeyCode.F1))
        {
            if (IsChecking == false && Pause.IsPause==false)
            {
                IsChecking = true;
                CheckUI.SetActive(true);
                return;
            }
            if (IsChecking == true)
            {
                IsChecking = false;
                CheckUI.SetActive(false);
                return;
              }
        }
        if (Input.GetKeyDown(KeyCode.Escape))
        {
            if (IsChecking == true)
            { 
               CheckUI.SetActive(false);
               IsChecking = false;
               return;
            }
        }
    }
}

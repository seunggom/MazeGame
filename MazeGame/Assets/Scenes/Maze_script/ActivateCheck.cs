using System.Collections;
using System.Collections.Generic;
using UnityEngine;


public class ActivateCheck : MonoBehaviour
{
    public GameObject CheckUI;
    public GameObject Player;
    public Vector3 pos;
    public Vector3 start;
    public float temp;
    bool IsChecking;
    // Start is called before the first frame update
    void Start()
    {
        CheckUI.SetActive(false);
        IsChecking = false;
        Vector3 start = new Vector3(1.5f, 0.5f, 1.5f);
        Player = GameObject.Find("Player(Clone)");
    }

    // Update is called once per frame
    void Update()
    {
        pos = this.Player.transform.position;
        Debug.Log("위치 " + temp);
        temp = Vector3.Distance(pos, start);
        if (temp < 2.5)
        {
            if (Input.GetKeyDown(KeyCode.F1))
            {
                if (IsChecking == false && Pause.IsPause == false)
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
        else
        {
            IsChecking = false;
            CheckUI.SetActive(false);
            return;
        }
    }
}

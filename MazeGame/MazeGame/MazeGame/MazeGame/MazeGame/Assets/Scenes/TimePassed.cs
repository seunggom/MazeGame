using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class TimePassed : MonoBehaviour
{
    public float TimePass;
    public Text Text_Timer;

    void Update()
    {
        TimePass += Time.deltaTime;
        Text_Timer.text = "Time : " + Mathf.Floor(TimePass*100)/100;
    }
}

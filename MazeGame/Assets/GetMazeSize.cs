using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class GetMazeSize : MonoBehaviour
{
    public InputField InputSize;

    public void Input()
    {
        PlayerPrefs.SetInt("Size", int.Parse(InputSize.text));
    }
    
} 
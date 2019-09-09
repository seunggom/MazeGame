using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.UI;

public class SceneChanger : MonoBehaviour
{
    // Start is called before the first frame update
    void Start()
    {

    }

    // Update is called once per frame
    void Update()
    {

    }

    public void MoveScene(Button b)
    {
        if (b.name == "Game Start")
        {
            SceneManager.LoadScene("SampleScene");
        }
       
        else if (b.name == "Exit")
        {
            SceneManager.LoadScene("StartScene");
        }
    }
}

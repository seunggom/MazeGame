using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.SceneManagement;
public class passwordCheck : MonoBehaviour
{
    // Start is called before the first frame update
    
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    public void Check(Button b)
    {
        if (b.name == "Submit")
        {
            if (HintCapsule.password[0] == Password.return_password1() && HintCapsule.password[1] == Password.return_password2() && HintCapsule.password[2] == Password.return_password3() && HintCapsule.password[3] == Password.return_password4())
            {
                print("clear");
                SceneManager.LoadScene("StartScene");
            }
            else
                print("does not correct");
        }
    }
}

using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
//패스워드 입력하는 쪽
public class Password : MonoBehaviour
{
    public static int Password1;
    public static int Password2;
    public static int Password3;
    public static int Password4;

    // Start is called before the first frame update
    void Start()
    {

    }

    // Update is called once per frame
    void Update()
    {

    }

    public void OnValueChange(Dropdown drop)
    {
        int n = drop.value;

        switch (drop.name)
        {
            case "Password1":
                Password1 = n;
                print(n);
                break;
            case "Password2":
                Password2 = n;
                print(n);
                break;
            case "Password3":
                Password3 = n;
                print(n);
                break;
            case "Password4":
                Password4 = n;
                print(n);
                break;
        }
    }
    public static int return_password1()
    {
        return (Password1);
    }
    public static int return_password2()
    {
        return (Password2);
    }
    public static int return_password3()
    {
        return (Password3);
    }
    public static int return_password4()
    {
        return (Password4);
    }

    public void ChangeSetting()
    {

    }
}

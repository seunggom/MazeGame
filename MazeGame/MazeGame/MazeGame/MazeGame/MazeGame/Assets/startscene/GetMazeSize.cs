using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class GetMazeSize : MonoBehaviour
{
    public static int X_Size = 10;
    public static int Y_Size = 10;

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
            case "X":
                X_Size = 10 * n+10;
                Debug.Log(X_Size);
                break;
            case "Y":
                Y_Size = 10 * n+10;
                Debug.Log(Y_Size);
                break;
        }
    }

    public int GetSize_X()
    {
        return (X_Size);
    }

    public int GetSize_Y()
    {
        return (Y_Size);
    }

    public void ChangeSetting()
    {

    }
}

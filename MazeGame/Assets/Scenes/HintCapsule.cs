using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class HintCapsule : MonoBehaviour
{
    public static int X_mazeSize = GetMazeSize.X_Size;
    public static int Y_mazeSize = GetMazeSize.Y_Size;
    private short[] password = new short[4]; // 탈출을 위한 비밀 번호 4자리
    public GameObject capsule;
    public Material[] mats = new Material[10];

    // Start is called before the first frame update
    void Start()
    {
        password = MakePassword();
        print(password[0]);
        print(password[1]);
        print(password[2]);
        print(password[3]);
        CreateHintCapsule();
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    short[] MakePassword()
    {
        /*
         * Author : 김승연
         * Description: 탈출 비밀번호를 만들기 위한 함수. 각 네자리는 중복될 수 없음.
         * */
        short[] pw = new short[4] { -1, -1, -1, -1 };

        for (int i = 0; i < 4; i++)
        {
            pw[i] = (short)Random.Range(0, 10);
            for (int j = 0; j < i; j++)
            {
                while (pw[j] == pw[i])
                {
                    pw[i] = (short)Random.Range(0, 10);
                }
            }
        }

        return pw;
    }

    void CreateHintCapsule()
    {
        /*
         * Author : 김승연
         * Description: 탈출 비밀번호의 숫자 한개를 알려주는 캡슐을 총 4개 생성하는 함수
         * */
        int n = X_mazeSize / 10;
        

        for (int i = 0; i < 4; i++)
        {
            GameObject cap = Instantiate(capsule, new Vector3(0.5f + (3.0f * n) + 2 * i, 0.25f, 0.5f + Random.Range(Y_mazeSize / 2, Y_mazeSize)), Quaternion.identity);
            cap.GetComponent<Renderer>().material = mats[password[i]];
        }
    }
}

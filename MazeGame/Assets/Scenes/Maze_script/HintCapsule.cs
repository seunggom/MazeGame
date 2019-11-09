using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class HintCapsule : MonoBehaviour
{
    public static int X_mazeSize = GetMazeSize.X_Size;
    public static int Y_mazeSize = GetMazeSize.Y_Size;
    public static int[] password = new int[4]; // 탈출을 위한 비밀 번호 4자리      ++short로 선언된거 int로 다 바꿨고 static으로 선언시킴(비밀번호 확인하는 스크립트에서 쓰려고)
    public GameObject capsule;
    private GameObject[] _capsuleObj;
    public Material[] mats = new Material[10];
    public Texture[] texs = new Texture[10];
    private bool[] takeHint = new bool[4];
    private GameObject[] UI_HintImage = new GameObject[4];
    private int UI_count = 0;

    // Start is called before the first frame update
    void Start()
    {
        password = MakePassword();
        print(password[0]);
        print(password[1]);
        print(password[2]);
        print(password[3]);
        _capsuleObj = new GameObject[4];
        CreateHintCapsule();
        SettingStartHintUI();
    }

    // Update is called once per frame
    void Update()
    {
        if (!takeHint[0] || !takeHint[1] || !takeHint[2] || !takeHint[3]) deleteCapsule(_capsuleObj);
    }

    int[] MakePassword()
    {
        /*
         * Author : 김승연
         * Description: 탈출 비밀번호를 만들기 위한 함수. 각 네자리는 중복될 수 없음.
         * */
        int[] pw = new int[4] { -1, -1, -1, -1 };

        for (int i = 0; i < 4; i++)
        {
            pw[i] = (int)Random.Range(0, 10);
            for (int j = 0; j < i; j++)
            {
                while (pw[j] == pw[i])
                {
                    pw[i] = (int)Random.Range(0, 10);
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

        int[] shake_pw = new int[4];
        for (int i = 0; i < 4; i++)
        {
            shake_pw[i] = password[i];
        }

        bool[] used = new bool[4] { false, false, false, false };


        for (int i = 0; i < 4; i++)
        {
            int index = Random.Range(0, 4);
            while (used[index] == true) index = Random.Range(0, 4);
            used[index] = true;
            _capsuleObj[i] = Instantiate(capsule, new Vector3(0.5f + (3.0f * n) + 2 * i, 0.25f, 0.5f + Random.Range(Y_mazeSize / 2, Y_mazeSize)), Quaternion.identity);
            
            _capsuleObj[i].GetComponent<Renderer>().material = mats[password[index]];
            _capsuleObj[i].name = "capsule" + password[index];
            takeHint[i] = false;
        }
    }

    void deleteCapsule(GameObject[] capsule)
    {
        /*
         * Author : 김승연
         * Description: Player가 캡슐에 가까이 다가가면 캡슐 사라지고 화면에 획득한 캡슐 번호 뜨게 함
         * */
        Vector3 _capsulePos;
        GameObject player = GameObject.Find("Player(Clone)");

        for (int i = 0; i < 4; i++)
        {
            if (takeHint[i]) continue;
            _capsulePos = capsule[i].transform.position;
            if (Vector3.Distance(_capsulePos, player.transform.position) < 0.5f)
            {
                Destroy(_capsuleObj[i]);
                takeHint[i] = true;
                SettingUIWhenTakeHint(_capsuleObj[i]);
            }
        }
    }

    void SettingStartHintUI()
    {
        /*
        Author : 김승연
        Description : 처음에 UICanvas에 RawImage들을 안보이게 설정해놓음
        */

        for (int i = 0; i < 4; i++)
        {
            string name = "HintImage" + i;
            UI_HintImage[i] = GameObject.Find(name);
            UI_HintImage[i].transform.position = new Vector2(Screen.width - 60 * (i+1), Screen.height - 50);
            UI_HintImage[i].SetActive(false);
        }
    }

    void SettingUIWhenTakeHint(GameObject hintObj)
    {
        /*
        Author : 김승연
        Description : 힌트 얻었으면 UICanvas에 띄움
        */

        string name = hintObj.name;
        int num = (int)name[7] - 48; // ASCII 코드이기 때문에 48을 빼준다.
        Debug.Log("힌트를 얻었다! ->" + num);
        UI_HintImage[UI_count].SetActive(true);

        UI_HintImage[UI_count].GetComponent<RawImage>().texture = texs[num];
        UI_count++;


    }
}

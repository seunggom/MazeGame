using System.Collections;
using System.Collections.Generic;
using UnityEngine;


public struct Room
{
    public RoomInfo room_info;
    public bool[] wall;
}

public enum RoomInfo
{
    end = 0,
    potential = 1,
    pure = 2,
};

public class MakeMaze : MonoBehaviour
{
    public GameObject obj1; //ZCube
    public GameObject obj2; //XCube
    public static int X_mazeSize = GetMazeSize.X_Size;
    public static int Y_mazeSize = GetMazeSize.Y_Size;

    private short[] password = new short[4]; // 탈출을 위한 비밀 번호 4자리

    public Room[ , ] maze;

    Stack<int> roomStack0 = new Stack<int>();
    Stack<int> roomStack1 = new Stack<int>();

    // Start is called before the first frame update
    void Start()
    {
        DesignMaze();
        PrintMaze();
        space();
        password = MakePW();
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    void DesignMaze()
    {
        /*
         Author: 김승연
         When: 2019/07/29
         Description: 랜덤으로 미로를 생성하는 함수. 미로 구현은 recursive backtracking 알고리즘을 사용.
         */
        this.maze = new Room[X_mazeSize + 2, Y_mazeSize + 2];
        for (int i = 0; i < X_mazeSize+2; i++)
        {
            for (int  j= 0;j < Y_mazeSize+2; j++)
            {
                if (i == 0 || i == X_mazeSize + 1 || j == 0 || j == Y_mazeSize + 1)
                {
                    maze[i, j].room_info = RoomInfo.end;
                }
                else
                {
                    maze[i, j].room_info = RoomInfo.pure; // 초기 모든 방을 pure로 설정
                }
                maze[i, j].wall = new bool[4] { true, true, true, true }; // 값이 true이면 벽이 있다는 의미. 순서대로 상하좌우임.
            }
        }
        
        int x = 1;
        int y = 1;
        maze[x, y].room_info = RoomInfo.potential; // (0,0)은 미로 생성의 첫 시작점
        roomStack0.Push(x);
        roomStack1.Push(y);

       
        int a, b, dir, final_dir;
        
       
        while (roomStack0.Count > 0)
        {
            int opportunity = 1;

            a = x;
            b = y;
            dir = Random.Range(0, 4);
            
            while (opportunity <= 4)
            {
                a = x;
                b = y;
                switch (dir)
                {
                    case 0:
                        // 상
                        a--; break;
                    case 1:
                        // 하
                        a++; break;
                    case 2:
                        // 좌
                        b--; break;
                    case 3:
                        // 우
                        b++; break;
                }

                if (maze[a, b].room_info == RoomInfo.pure)
                {
                    final_dir = dir;
                    switch (final_dir)
                    {
                        case 0:
                            // 상
                            maze[x, y].wall[0] = false;
                            maze[a, b].wall[1] = false;
                            break;
                        case 1:
                            // 하
                            maze[x, y].wall[1] = false;
                            maze[a, b].wall[0] = false;
                            break;
                        case 2:
                            // 좌
                            maze[x, y].wall[2] = false;
                            maze[a, b].wall[3] = false;
                            break;
                        case 3:
                            // 우
                            maze[x, y].wall[3] = false;
                            maze[a, b].wall[2] = false;
                            break;
                    }

                    roomStack0.Push(a);
                    roomStack1.Push(b);
                    maze[a, b].room_info = RoomInfo.potential;
                    x = a;
                    y = b;
                    break;

                }

                opportunity++;
                dir++;
                if (dir == 4) dir = 0;

                if (opportunity == 5)
                {
                    x = roomStack0.Pop();
                    y = roomStack1.Pop();
                    maze[x, y].room_info = RoomInfo.end;
                    if (roomStack0.Count != 0)
                    {
                        // 스택의 가장 위에 있는 값을 얻고 싶은데 top() 함수가 없어서 아래와 같이 했음
                        x = roomStack0.Pop();
                        y = roomStack1.Pop();
                        roomStack0.Push(x);
                        roomStack1.Push(y);
                    }

                }
            }
            
        } // 스택 비었음
    }


    void PrintMaze()
    {
        /*
         Author: 김승연
         When: 2019/07/29
         Description: 랜덤으로 생성한 미로가 잘 구현되었는지 확인하기 위해 미로의 정보를 출력하는 함수.
         */
        for (int i = 0; i < X_mazeSize+2; i++)
        {
            string s = "";
            for (int j = 0; j < Y_mazeSize+2; j++)
            {
                s = s + maze[i, j].room_info + "(";
                for (int k = 0; k < 4; k++) if (maze[i, j].wall[k]) s = s + k;
                s = s + ") ";
            }
            print(s);
        }
    }

    void space()
    {
        /*
         * Author : 김대경
         * Description: 프리팹을 이용하여 벽을 생성하는 함수
         * */

        for(int i=1;i< X_mazeSize + 2; i++)
        {
            for(int j=0;j< Y_mazeSize + 1; j++)
            {
              
                if (j != 0)
                {
                    if (maze[i, j].wall[0] == true)
                    {
                        Instantiate(obj1, new Vector3(i, 0.5f, 0.5f + j), Quaternion.identity);
                    }
                }
                if (i != X_mazeSize+1)
                {
                    if (maze[i, j].wall[3] == true)
                    {
                        Instantiate(obj2, new Vector3(0.5f + i, 0.5f, 1 + j), Quaternion.identity);
                    }
                }
                
            }
        }
    }

    short[] MakePW()
    {
        short[] pw = new short[4];

        return pw;
    }

}



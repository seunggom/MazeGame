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
    public int X_mazeSize = 3;
    public int Y_mazeSize = 7;

    public Room[ , ] maze;

    Stack<Room> roomStack = new Stack<Room>();

    // Start is called before the first frame update
    void Start()
    {
        DesignMaze();
        PrintMaze();
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
        this.maze = new Room[X_mazeSize, Y_mazeSize];
        for (int i = 0; i < X_mazeSize; i++)
        {
            for (int  j= 0;j < Y_mazeSize; j++)
            {
                maze[i, j].room_info = RoomInfo.pure; // 초기 모든 방을 wall로 설정
                maze[i, j].wall = new bool[4] { true, true, true, true }; // 값이 true이면 벽이 있다는 의미. 순서대로 상하좌우임.
            }
        }
        int x = 0;
        int y = 0;
        maze[x, y].room_info = RoomInfo.potential; // (0,0)은 미로 생성의 첫 시작점
        roomStack.Push(maze[x, y]);

        int a, b, dir;
        while(roomStack.Count > 0)
        {
            do
            {
                a = x;
                b = y;
                dir = Random.Range(0, 4);
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
            } while (a < 0 || a >= X_mazeSize || b < 0 || b >= Y_mazeSize);

            switch(dir)
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





        }
    }


    void PrintMaze()
    {
        /*
         Author: 김승연
         When: 2019/07/29
         Description: 랜덤으로 생성한 미로가 잘 구현되었는지 확인하기 위해 미로의 정보를 출력하는 함수.
         */
        for (int i = 0; i < X_mazeSize; i++)
        {
            string s = "";
            for (int j = 0; j < Y_mazeSize; j++)
            {
                s = s + maze[i, j].room_info + "(";
                for (int k = 0; k < 4; k++) if (maze[i, j].wall[k]) s = s + k;
                s = s + ") ";
            }
            print(s);
        }
    }
}

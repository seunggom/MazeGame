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

    Stack<int>[] roomStack = new Stack<int>[2];

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
        roomStack[0].Push(x);
        roomStack[1].Push(y);

       
        int a, b, dir, final_dir;
        
       
        while (roomStack[0].Count > 0)
        {
            int opportunity = 1;

            a = x;
            b = y;
            dir = Random.Range(0, 4);
            
            while (opportunity <= 4)
            {
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

                    roomStack[0].Push(a);
                    roomStack[1].Push(b);
                    x = a;
                    y = b;
                    break;

                }

                opportunity++;
                dir++;
                if (dir == 4) dir = 0;

                if (opportunity == 5)
                {
                    roomStack[0].Pop();
                    roomStack[1].Pop();
                }
            }
            
        } // 스택 비었음

        /*
        int opportunity = 1;
        //bool canGo = false; // 갈 수 있는 방향이 있는지 알려주는 변수
        while (roomStack[0].Count > 0)
        {
            a = x;
            b = y;
            dir = Random.Range(0, 4);


            while (opportunity <= 4)
            {
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
                if (a >= 0 && a < X_mazeSize && b >= 0 && b < Y_mazeSize) // 미로 영역을 벗어나지 않는 경우
                {
                    if (maze[a, b].room_info == RoomInfo.pure)
                    {
                       
                        break;
                    }
                    else if (maze[a, b].room_info == RoomInfo.potential)
                    {
                       if (opportunity == 4) // 이 경우는 주변이 다 potential(1)이라는 의미임
                        {
                            maze[a, b].room_info = RoomInfo.end;
                            roomStack[0].Pop();
                            roomStack[1].Pop();
                        }
                    
                    }
                }
                else
                {
                    dir++;
                    if (dir == 4) dir = 0;
                    opportunity++;
                    // 랜덤으로 정해진 방향으로 가지 못하는 경우 다른 방향으로 갈 수 있는지 시도함.
                }
            }


            switch (dir)
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

            roomStack[0].Push(a);
            roomStack[1].Push(b);
            x = a;
            y = b;





        } // 미로 구현 끝
        */
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
}

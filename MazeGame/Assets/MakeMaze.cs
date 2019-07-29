using System.Collections;
using System.Collections.Generic;
using UnityEngine;

/*
public struct Room
{
    public RoomInfo room_info;
}*/

public enum RoomInfo
{
    road = 0,
    enterable = 1,
    wall = 2,
};

public class MakeMaze : MonoBehaviour
{
    public int X_mazeSize = 10;
    public int Y_mazeSize = 8;

    public RoomInfo[ , ] maze;

    Stack<RoomInfo> roomStack = new Stack<RoomInfo>();

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
        this.maze = new RoomInfo[X_mazeSize, Y_mazeSize];
        for (int i = 0; i < X_mazeSize; i++)
        {
            for (int  j= 0;j < Y_mazeSize; j++)
            {
                maze[i, j] = RoomInfo.wall; // 초기 모든 방을 wall로 설정
            }
        }

        int x = 0;
        int y = 0;
        maze[x, y] = RoomInfo.enterable; // (0,0)은 미로 생성의 첫 시작점
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
                s = s + maze[i, j] + " ";
            }
            print(s);
        }
    }
}

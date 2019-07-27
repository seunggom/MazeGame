using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public struct Room
{
    public RoomInfo room_info;
}

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

    public Room[ , ] maze;

    // Start is called before the first frame update
    void Start()
    {
        DesignMaze();
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    void DesignMaze()
    {
        this.maze = new Room[X_mazeSize, Y_mazeSize];
    }
}

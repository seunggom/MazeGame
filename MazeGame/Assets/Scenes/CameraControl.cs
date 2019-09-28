using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CameraControl : MonoBehaviour
{
    public Camera mapCam;
    Camera cam;
    int X_mapSize;
    int Y_mapSize;

    // Start is called before the first frame update
    void Start()
    {
        X_mapSize = MakeMaze.X_mazeSize;
        Y_mapSize = MakeMaze.Y_mazeSize;
        cam = GameObject.Instantiate(mapCam);

        
        cam.enabled = false;
    }

    // Update is called once per frame
    void Update()
    {
        if(Input.GetKeyDown(KeyCode.M))
        {
            Vector3 player_pos = GameObject.Find("Player(Clone)").transform.position;

            cam.transform.position = new Vector3(player_pos.x, 1.5f, player_pos.z);
            cam.transform.rotation = Quaternion.Euler(90.0f, 0.0f, 0.0f);
            cam.enabled = true;
        }
        if(Input.GetKeyUp(KeyCode.M))
        {
            cam.enabled = false;
        }
    }
}

using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Monster : MonoBehaviour
{
    public static int X_mazeSize = GetMazeSize.X_Size;
    public static int Y_mazeSize = GetMazeSize.Y_Size;
    private Rigidbody mobRigid;
    public GameObject mob;
    // Start is called before the first frame update
    void Start()
    {
        Mob();
    }

    // Update is called once per frame
    void Update()
    {
        
    }
    void Mob()
    {
        
            Instantiate(mob, new Vector3(0.5f + Random.Range(X_mazeSize / 2, X_mazeSize), 0.5f, 0.5f + Random.Range(Y_mazeSize / 2, Y_mazeSize)), Quaternion.identity);
        
    }
}

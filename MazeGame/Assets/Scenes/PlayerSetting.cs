using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerSetting : MonoBehaviour
{
    public GameObject Player;
    // Start is called before the first frame update
    void Start()
    {
        Instantiate(Player, new Vector3(1.5f, 0.1f, 1.5f), Quaternion.identity);
    }

    // Update is called once per frame
    void Update()
    {
        
    }
}

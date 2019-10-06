using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.AI;

public class MonsterMove : MonoBehaviour
{
    public float walkSpeed; //걷기 스피드

    private bool isAction; // 행동중인지 아닌지 판별
    private bool isWalking; // 걷는지 안 걷는지 판별

    public float walkTime; //걷기시간
    public float waitTime; //대기시간
    
    public Rigidbody mobRigid;
    public Animator anim;
    public BoxCollider boxCol;

    protected NavMeshAgent nav;

    private float currentTime;
    // Start is called before the first frame update
    void Start()
    {
        
        currentTime = waitTime;
        isAction = true;
        Move();
        
    }

    // Update is called once per frame
    void Update()
    {
        ElaseTime();
        Move();
    }

    private void Move()
    {
        if (isWalking)
        {
            nav = GetComponent<NavMeshAgent>();
        }
       
           
    }

    private void ElaseTime()
    {
        if (isAction)
        {
            currentTime -= Time.deltaTime;
            if (currentTime <= 0)
            {
                ReSet();
            }
        }
    }
    private void ReSet()
    {
        isWalking = false; isAction = true;
        RandomAction();
    }

    private void RandomAction()
    {
        isAction = true;

        int random = Random.Range(0, 2);

        if (random == 0)
            Wait();
        else if (random == 1)
            Walk();
    }

    private void Wait()
    {
        currentTime = waitTime;
        Debug.Log("대기");
    }
    private void Walk()
    {
        isWalking = true;
        Debug.Log("걷기");
        currentTime = walkTime;    
    }
}

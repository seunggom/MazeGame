using System.Collections;
using System.Collections.Generic;
using UnityEngine;
//김대경
public class Mob_Trace : MonoBehaviour
{

    public float speed = 0.1f;
    public float damping = 5.0f;
    
    private float currentTime =3.0f;

    private Transform tr; //몬스터 트랜스폼
    private Transform playerTr; //플레이어 트랜스폼

    private Vector3 movePos;

    private Rigidbody rigid;
    private bool tracePoint = false;


    // Start is called before the first frame update
    void Start()
    {
        rigid = gameObject.GetComponent<Rigidbody>();
        tr = GetComponent<Transform>();
        playerTr = GameObject.FindGameObjectWithTag("Player").GetComponent<Transform>();
    }

    // Update is called once per frame
    void Update()
    {
        float dist = Vector3.Distance(tr.position, playerTr.position);
        movePos = playerTr.position;

        if (dist <= 1.0f)
        {
            tracePoint=true; //추적상태 활성화
        }

        if (tracePoint == true)
        {
            Trace(); //추적상태 활성화시 추적
        }
        
    }
    
    void Trace()
    {
        
        Quaternion rot = Quaternion.LookRotation(movePos - tr.position); //플레이어 방향벡터 설정
        tr.rotation = Quaternion.Slerp(tr.rotation, rot, Time.deltaTime * damping); //방향 바라보기
        rigid.MovePosition(transform.position + (transform.forward * speed * Time.deltaTime)); //이동
        Debug.Log(movePos); //확인
        ElapseTime(); //시간경과
        if (currentTime <= 0)
            _reset();
    }
    void ElapseTime()
    {
        currentTime -= Time.deltaTime;
    }
    void _reset()
    {
        currentTime = 3.0f;
        tracePoint = false; //추적상태 초기화
        Destroy(this.gameObject);
        GameObject.Find("Monster").GetComponent<Monster>().Mob();
    }


}

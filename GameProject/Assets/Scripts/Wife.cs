﻿using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class Wife : MonoBehaviour
{
    public enum Unit_State
    {
        Normal_State,
        Find_State,
        Get_State,
    }

    private float TimeLeft = 5.0f;
    private float nextTime = 0.0f;

    private Transform wifeTr;
    private Transform playerTr;
    private Transform nodeTr;
    private Transform tempTr;
    private UnityEngine.AI.NavMeshAgent nvAgent; // 네비매쉬
    private float distance = 0; // 거리
    public bool Findflag = false; // 수색모드 on/off
    public float angry = 0; // 
    public Unit_State Current_State = Unit_State.Find_State; // 분노게이지 상승 on/off


    private float[] NodeDistance = new float[12]; // 노드-와이프간 거리 배열
    private Transform[] ArrNodeTr = new Transform[12]; // 노드 트랜스폼 배열
    private float ClosestDistance;
    public Transform ClosestNode; // 가장 가까운 노드
    // Use this for initialization

    public int ranNum = 0;
    public int choreNum;
    private float choreTime = 10.0f; // 집안일 하는 시간

    private RayInteraction PlayerRayFlag2;

    void Awake()
    {
        nvAgent = this.gameObject.GetComponent<UnityEngine.AI.NavMeshAgent>();

    }


    void Start()
    {
        //SceneManager.LoadScene(0);
        wifeTr = this.gameObject.GetComponent<Transform>();
        playerTr = GameObject.FindWithTag("Player").GetComponent<Transform>();


        PlayerRayFlag2 = GameObject.Find("Husband").gameObject.GetComponent<RayInteraction>();

        // 1층 노드
        ArrNodeTr[0] = GameObject.Find("MainRoom").GetComponent<Transform>();
        ArrNodeTr[1] = GameObject.Find("1stFloorBathroom").GetComponent<Transform>();
        ArrNodeTr[2] = GameObject.Find("Kitchen").GetComponent<Transform>();
        ArrNodeTr[3] = GameObject.Find("BoilerRoom").GetComponent<Transform>();
        ArrNodeTr[4] = GameObject.Find("InFrontOfTV").GetComponent<Transform>();
        ArrNodeTr[5] = GameObject.Find("MainHall").GetComponent<Transform>();
        // 2층 노드
        ArrNodeTr[6] = GameObject.Find("StudyRoom").GetComponent<Transform>();
        ArrNodeTr[7] = GameObject.Find("2ndFloorBathroom").GetComponent<Transform>();
        ArrNodeTr[8] = GameObject.Find("2ndFloorHall(1)").GetComponent<Transform>();
        ArrNodeTr[9] = GameObject.Find("2ndFloorHall(2)").GetComponent<Transform>();
        ArrNodeTr[10] = GameObject.Find("2ndFloorMainRoom(1)").GetComponent<Transform>();
        ArrNodeTr[11] = GameObject.Find("2ndFloorMainRoom(2)").GetComponent<Transform>();

        ranNum = Random.Range(0, 11);

        Closest();

        StartCoroutine(Angry_Control());
        StartCoroutine(State_Look());
        StartCoroutine(Ran_Generator());
        StartCoroutine(Status());
    }

    // Update is called once per frame
    void Update()
    {

        nvAgent.destination = Closest().position;

        distance = Vector3.Distance(Closest().position, wifeTr.position);
        //Vector3 vec = playerTr.position - wifeTr.position;

        //vec.Normalize();


        if (distance < 20)
        {
            Current_State = Unit_State.Get_State;
            State_Look();
        }
        else
        {
            Current_State = Unit_State.Find_State;
            State_Look();
        }

        if (distance < 2.0f)
        {
            //vec = playerTr.position - wifeTr.position;
            nvAgent.destination = wifeTr.position;
            StartCoroutine(Chase_Complete());
            //Looking(vec);
        }
    }

    public Transform Closest()
    {

        for (int a = 0; a < 12; a++)
        {
            NodeDistance[a] = Vector3.Distance(ArrNodeTr[a].position, playerTr.position); // 각 노드별 거리 배열에 입력
            //Debug.Log(NodeDistance[a]);
        }

        ClosestNode = ArrNodeTr[0]; // 가장 가까운 노드 디폴트값으로 0번 노드 설정
        ClosestDistance = NodeDistance[0]; // 가장 가까운 노드와의 거리 디폴트값으로 0번 노드와의 거리로 설정

        if (playerTr.position.y < 6.0f)
        {
            for (int b = 0; b < 6; b++)
            {
                if (NodeDistance[b] <= ClosestDistance) // 노드들 거리 비교하여 가장 가까운 노드를 ClosestNode로 저장
                {
                    ClosestDistance = NodeDistance[b];
                    ClosestNode = ArrNodeTr[b];
                }
            }
        }
        else
        {
            for (int c = 6; c < 12; c++)
            {
                if (NodeDistance[c] <= ClosestDistance) // 노드들 거리 비교하여 가장 가까운 노드를 ClosestNode로 저장
                {
                    ClosestDistance = NodeDistance[c];
                    ClosestNode = ArrNodeTr[c];
                }
            }
        }

        return ClosestNode; 
    }

    void Chore()
    {
        choreNum = ranNum;
        nvAgent.destination = ArrNodeTr[choreNum].position; // 목표위치는 난수로 생성된 노드로
        if (Vector3.Distance(ArrNodeTr[choreNum].position, wifeTr.position) < 2.0f || Findflag == true) // 해당 노드로 이동 완료했거나, 이동중 키입력을 받았다면, 멈추고 수색종료
        {

            nvAgent.destination = wifeTr.position;
            StartCoroutine(Chase_Complete());

        }
    }

    //void Looking(Vector3 vec)
    //{
    //    Quaternion q = Quaternion.LookRotation(vec);

    //    nvAgent.transform.rotation = q;
    //}

    public float RTRage()
    {
        return angry;
    }

    IEnumerator Angry_Control()
    {
        while (true)
        {
            if (angry >= 6 && Findflag == true)
                nvAgent.destination = tempTr.position; // tempTr로 설정한 이유는 분노가 6에 도달한 시점에 남편의 위치에서 가장 가까운 노드로 이동하게 하기 위해
            else
                nvAgent.destination = wifeTr.position;

            //if (State_identify())
            //{
            if (angry < 5) // 분노수치에 따라 속도가 변경
            {
                nvAgent.speed = 5;
            }
            else if (angry > 5 && angry < 6)
            {
                nvAgent.speed = 7;
            }
            else if (angry > 6 && angry < 8)
            {
                nvAgent.speed = 8;
            }
            else if (angry > 8 && angry < 10)
            {
                nvAgent.speed = 9;
            }
            // }

            if (Findflag == false)
            {
                Chore();
            }

            // 키가 눌리고 와이프-플레이어 거리가 35미만, 분노 10미만일 때
            if (Input.GetKey(KeyCode.Space) && Vector3.Distance(wifeTr.position, playerTr.position) < 35 && angry < 10 && PlayerRayFlag2.GetMoneyFlag() == true)
            {
                Findflag = true;
                angry += 0.1f;

                if (angry < 6)
                {
                    Findflag = false;
                }
            }
            if (Input.GetKeyDown(KeyCode.Space)) // 스페이스바가 KeyDown됐을 당시의 남편과 가장 가까운 노드로 이동
            {
                tempTr = Closest();
            }

            if (angry > 0 && Findflag == false)
            {
                angry -= 0.005f;
            }
            yield return new WaitForSeconds(0.01f);
        }
    }

    IEnumerator Status()
    {
        while (true)
        {
            Debug.Log("분노게이지:" + angry);
            Debug.Log("Speed :" + nvAgent.speed);
            yield return new WaitForSeconds(0.5f);
        }
    }

    IEnumerator Ran_Generator()
    {
        while (true)
        {
            if (Findflag == false)
            {
                ranNum = Random.Range(0, 11); // 난수생성

            }
            yield return new WaitForSeconds(choreTime);
        }
    }

    IEnumerator State_Look()
    {
        while (true)
        {
            if (Current_State == Unit_State.Find_State)
                Debug.Log("Find_State Activated");
            else if (Current_State == Unit_State.Get_State)
                Debug.Log("Get_State Activated");
            yield return new WaitForSeconds(0.5f);
        }
    }

    IEnumerator Chase_Complete()
    {
        yield return new WaitForSeconds(5.0f);
        Findflag = false;
    }

    public bool State_identify()
    {
        if (Current_State == Unit_State.Find_State)
            return false;
        return true;
    }
}

using System.Collections;
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

    private Transform wifeTr;
    private Transform playerTr;
    private Transform nodeTr;
    private Transform tempTr;
    private UnityEngine.AI.NavMeshAgent nvAgent;
    private float distance = 0;
    public bool Findflag = false; // 수색모드 on/off
    public float angry = 0;
    public Unit_State Current_State = Unit_State.Find_State; // 분노게이지 상승 on/off


    private float[] NodeDistance = new float[10]; // 노드-와이프간 거리 배열
    private Transform[] ArrNodeTr = new Transform[10]; // 노드 트랜스폼 배열
    private float ClosestDistance;
    public Transform ClosestNode; // 가장 가까운 노드
    // Use this for initialization

    public int ranNum = 0;
    public int choreNum;
    public bool choreFlag = false;
    public float timeSpan;
    private float choreTime = 30.0f; // 집안일 하는 시간

    void Start()
    {
        //SceneManager.LoadScene(0);
        wifeTr = this.gameObject.GetComponent<Transform>();
        playerTr = GameObject.FindWithTag("Player").GetComponent<Transform>();
        nvAgent = this.gameObject.GetComponent<UnityEngine.AI.NavMeshAgent>();


        ArrNodeTr[0] = GameObject.Find("MainRoom").GetComponent<Transform>();
        ArrNodeTr[1] = GameObject.Find("Bathroom").GetComponent<Transform>();
        ArrNodeTr[2] = GameObject.Find("Kitchen").GetComponent<Transform>();
        ArrNodeTr[3] = GameObject.Find("BoilerRoom").GetComponent<Transform>();
        ArrNodeTr[4] = GameObject.Find("InFrontOfTV").GetComponent<Transform>();
        ArrNodeTr[5] = GameObject.Find("MainHall").GetComponent<Transform>();

        ranNum = Random.Range(0, 5);

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

        if (Input.GetKeyDown(KeyCode.Escape)) SceneManager.LoadScene(1);

        distance = Vector3.Distance(Closest().position, wifeTr.position);
        //Vector3 vec = playerTr.position - wifeTr.position;

        //vec.Normalize();

        if (Input.GetKeyDown(KeyCode.C)) choreFlag = true;

        if (distance < 20)
        {
            Current_State = Unit_State.Get_State;
            State_Look();
            //StartCoroutine(Get_Time());
        }
        else
        {
            Current_State = Unit_State.Find_State;
            State_Look();
        }

        if (distance < 1)
        {
            //vec = playerTr.position - wifeTr.position;
            nvAgent.destination = wifeTr.position;
            StartCoroutine(Chase_Complete());
            //Looking(vec);
        }
    }

    public Transform Closest()
    {
        
        for (int a=0; a<6; a++)
        {
            NodeDistance[a] = Vector3.Distance(ArrNodeTr[a].position, playerTr.position); // 각 노드별 거리 배열에 입력
            //Debug.Log(NodeDistance[a]);
        }

        ClosestNode = ArrNodeTr[0]; // 가장 가까운 노드 디폴트값으로 0번 노드 설정
        ClosestDistance = NodeDistance[0]; // 가장 가까운 노드와의 거리 디폴트값으로 0번 노드와의 거리로 설정

        for (int b=0; b<6; b++)
        {
            if (NodeDistance[b] <= ClosestDistance)
            {
                ClosestDistance = NodeDistance[b];
                ClosestNode = ArrNodeTr[b];
            }         
        }

        return ClosestNode;
    }

    void Chore()
    {
        choreNum = ranNum;
        nvAgent.destination = ArrNodeTr[choreNum].position; // 목표위치는 난수로 생성된 노드로

        if (Vector3.Distance(ArrNodeTr[choreNum].position, wifeTr.position) == 0.0f)
        {
            nvAgent.destination = wifeTr.position;
            //choreFlag = true;
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
            if (angry == 6 && Findflag == true)
            {
                nvAgent.destination = Closest().position;
            }
            else if (angry > 6 && Findflag == true)
                nvAgent.destination = Closest().position;
            else
                nvAgent.destination = wifeTr.position;

            if (distance < 10 && State_identify())
            {
                if (angry < 3)
                {
                    nvAgent.speed = 5;
                }
                else if(angry < 4)
                {
                    nvAgent.speed = 6;
                }
                else if (angry < 6)
                {
                    nvAgent.speed = 7;
                }
                else if (angry < 8)
                {
                    nvAgent.speed = 8;
                }
                else if (angry < 10)
                {
                    nvAgent.speed = 9;
                }

            }

            if(Findflag == false)
            {
                Chore();
            }

            if (Input.GetKey(KeyCode.Space) && Vector3.Distance(wifeTr.position, playerTr.position)<25 && angry<10)
            {
                Findflag = true;
                angry += 0.1f;

                if (angry < 6)
                {
                    StartCoroutine(Chase_Complete());
                }
            }

            if (angry > 0 && Findflag == false)
                {
                    angry-= 0.005f;
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
            //if (choreFlag == true)
            //{
                ranNum = Random.Range(0, 5); // 난수생성
                //choreFlag = false;
            //}
            
            yield return new WaitForSeconds(10.0f);
        }

    }

    IEnumerator State_Look()
    {
        while (true)
        {
            if(Current_State == Unit_State.Find_State)
            Debug.Log("Find_State Activated");
            else if(Current_State == Unit_State.Get_State)
            Debug.Log("Get_State Activated");
            yield return new WaitForSeconds(0.5f);
        }
    }
    //IEnumerator Get_Time()
    //{
    //    yield return new WaitForSeconds(3.0f);
    //    Current_State = Unit_State.Find_State;
    //}

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

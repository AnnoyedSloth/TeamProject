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

    public Transform wifeTr;
    private Transform playerTr;
    private Transform tempTr;

    public UnityEngine.AI.NavMeshAgent nvAgent; // 네비매쉬
    private float distance = 0; // 거리
    private float WNDistance = 0;
    public bool Findflag = false; // 수색모드 on/off
    public float angry = 0; // 
    public Unit_State Current_State = Unit_State.Find_State; // 분노게이지 상승 on/off
    public bool isStaying;

    public bool isComplete;

    public bool DiedFlag;

    public AudioClip WalkSound;
    public AudioClip ChoreSound_Kitc;
    public AudioClip ChoreSound_Laun;
    public AudioClip ChoreSound_Vacc;
    public bool SoundFlag;

    private float[] NodeDistance = new float[12]; // 노드-와이프간 거리 배열
    private Transform[] ArrNodeTr = new Transform[12]; // 노드 트랜스폼 배열
    private float ClosestDistance;
    public Transform ClosestNode; // 가장 가까운 노드
    // Use this for initialization

    public int ranNum = 0;
    public int choreNum;
    private float choreTime = 15.0f; // 집안일 하는 시간

    private RayInteraction PlayerRayFlag2;

    public Animator mAnimator = null; //애니메이터 컨트롤

    public Sight Sight_Script;


    public float WHDistance;

    void Awake()
    {
        nvAgent = this.gameObject.GetComponent<UnityEngine.AI.NavMeshAgent>();
        mAnimator = gameObject.GetComponent<Animator>(); //애니메이션할 객체 얻기
    }

    void Start()
    {
        //SceneManager.LoadScene(0);
        Sight_Script = GameObject.Find("Wife/Head").gameObject.GetComponent<Sight>();
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
        StartCoroutine(Ran_Generator());
        StartCoroutine(AnimatorControl());
        StartCoroutine(WalkingSound());

        isStaying = false;
        isComplete = true; // Complete 코루틴 순차적으로 사용하기 위해 사용
        SoundFlag = true;
        DiedFlag = false;

        tempTr = ArrNodeTr[0];
    }

    // Update is called once per frame
    void Update()
    {

            nvAgent.destination = Closest().position;

            distance = Vector3.Distance(Closest().position, wifeTr.position);
            WNDistance = Vector3.Distance(tempTr.position, wifeTr.position);

            if (distance < 20)
            {
                Current_State = Unit_State.Get_State;
            }
            else
            {
                Current_State = Unit_State.Find_State;
            }

            if (WNDistance < 0.3f)
            {
                nvAgent.destination = wifeTr.position;
                isStaying = true;
                if (isComplete) StartCoroutine(Chase_Complete());
            }
            WHDistance = Vector3.Distance(wifeTr.position, playerTr.position);
    }

    public Transform Closest()
    {

        for (int a = 0; a < 12; a++)
        {
            NodeDistance[a] = Vector3.Distance(ArrNodeTr[a].position, playerTr.position); // 각 노드별 거리 배열에 입력
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

    public IEnumerator AnimatorControl()
    {
        while (true)
        {
            if (!Sight_Script.Cooltime)
            {
                mAnimator.SetBool("IsHit", false);
                Sight_Script.HitTime = false;
                if (!isStaying)
                {
                    if (angry >= 6)
                    {
                        mAnimator.SetBool("IsWalk", false);
                        mAnimator.SetBool("IsRun", true);
                        mAnimator.SetBool("IsIdle", false);
                    }
                    else
                    {
                        mAnimator.SetBool("IsWalk", true);
                        mAnimator.SetBool("IsRun", false);
                        mAnimator.SetBool("IsIdle", false);
                    }
                }
                else if (isStaying)
                {
                    mAnimator.SetBool("IsWalk", false);
                    mAnimator.SetBool("IsRun", false);
                    mAnimator.SetBool("IsIdle", true);
                }
            }
            else if (Sight_Script.Cooltime && !Sight_Script.HitTime && WHDistance <= 3.5)
            {
                mAnimator.SetBool("IsWalk", false);
                mAnimator.SetBool("IsRun", false);
                mAnimator.SetBool("IsIdle", false);
                mAnimator.SetBool("IsHit", true);
                yield return null;
                Sight_Script.HitTime = true;
                mAnimator.SetBool("IsHit", false);
                isStaying = true;
            }
            else if (!isStaying)
           {
                if (angry >= 6 && WHDistance>3)
                {
                    mAnimator.SetBool("IsWalk", false);
                    mAnimator.SetBool("IsRun", true);
                    mAnimator.SetBool("IsIdle", false);
                }
                else if(WHDistance>3)
                {
                    mAnimator.SetBool("IsWalk", true);
                    mAnimator.SetBool("IsRun", false);
                    mAnimator.SetBool("IsIdle", false);
                }
                else
                {
                    mAnimator.SetBool("IsWalk", false);
                    mAnimator.SetBool("IsRun", false);
                    mAnimator.SetBool("IsIdle", true);
                }
            }
            yield return null;
        }

    }

    void Chore()
    {
        choreNum = ranNum;
        nvAgent.destination = ArrNodeTr[choreNum].position; // 목표위치는 난수로 생성된 노드로
        if (Vector3.Distance(ArrNodeTr[choreNum].position, wifeTr.position) < 0.5f) // 해당 노드로 이동 완료했거나, 이동중 키입력을 받았다면, 멈추고 수색종료
        {
            isStaying = true;
            if(SoundFlag)StartCoroutine(ChoreSound());
            if (Findflag == true)
            {
                nvAgent.destination = wifeTr.position;
                //if(isComplete) StartCoroutine(Chase_Complete());
            }
        }
        else isStaying = false;
    }
    
    public float RTRage()
    {
        return angry;
    }

    public void isDied()
    {
        Findflag = true;
        DiedFlag = true;
        Debug.Log("You died");
    }

    IEnumerator Angry_Control()
    {
        while (true)
        {
            if (!DiedFlag)
            {
                if (angry >= 6 && Findflag == true)
                {
                    nvAgent.destination = tempTr.position; // tempTr로 설정한 이유는 분노가 6에 도달한 시점에 남편의 위치에서 가장 가까운 노드로 이동하게 하기 위해
                    isStaying = false;
                }
                else
                {
                    nvAgent.destination = wifeTr.position;
                }
            }
            else
            {
                if (WHDistance > 3.0f)
                {
                    isStaying = false;
                    nvAgent.destination = playerTr.position;
                }
                else if (WHDistance < 3.0f)
                {
                    nvAgent.destination = wifeTr.position;
                    isStaying = true;
                    if (isComplete) StartCoroutine(Chase_Complete());
                }
            }



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

            if (Vector3.Distance(nvAgent.destination, wifeTr.position) < 0.5f) isStaying = true;

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
                angry -= 0.0075f;
            }
            yield return new WaitForSeconds(0.01f);
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

    IEnumerator Chase_Complete()
    {
        isComplete = false;
        Debug.Log("Chase Completed!");
        yield return new WaitForSeconds(5.0f);
        Chore();
        Findflag = false;
        yield return new WaitForSeconds(3.0f);
        DiedFlag = false;
        isComplete = true;
    }

    IEnumerator WalkingSound()
    {
        while (true)
        {
            if (!isStaying)
            {
                if (mAnimator.GetBool("IsWalk"))
                {
                    AudioSource.PlayClipAtPoint(WalkSound, transform.position);
                    //Debug.Log("Walking");
                    yield return new WaitForSeconds(0.5f);
                }
                else
                {
                    AudioSource.PlayClipAtPoint(WalkSound, transform.position);
                    //Debug.Log("Running");
                    yield return new WaitForSeconds(0.2f);
                }
            }
            else
            {
                //Debug.Log("Staying");
                yield return new WaitForSeconds(1.0f);
            }
        }
    }

    IEnumerator ChoreSound()
    {
        SoundFlag = false;
        if (Vector3.Distance(wifeTr.position, ArrNodeTr[2].position) < 0.3f)
        {
            AudioSource.PlayClipAtPoint(ChoreSound_Kitc, transform.position);
        }
        else if(Vector3.Distance(wifeTr.position, ArrNodeTr[3].position) < 0.3f)
        {
            AudioSource.PlayClipAtPoint(ChoreSound_Laun, transform.position);
        }
        else
        {
            AudioSource.PlayClipAtPoint(ChoreSound_Vacc, transform.position);
        }
        yield return new WaitForSeconds(3.0f);
        SoundFlag = true;
    }

    public bool State_identify()
    {
        if (Current_State == Unit_State.Find_State)
            return false;
        return true;
    }
}
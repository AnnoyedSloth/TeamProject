using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class Wife : MonoBehaviour
{
    public enum Unit_State
    {
        Find_State,
        Get_State,
    }

    private Transform wifeTr;
    private Transform playerTr;
    private UnityEngine.AI.NavMeshAgent nvAgent;
    private float distance = 0;
    private float angle = 10;
    private bool flag = true;
    public float angry = 0;
    public Unit_State Current_State = Unit_State.Find_State;
    // Use this for initialization

    void Start()
    {
        //SceneManager.LoadScene(0);
        wifeTr = this.gameObject.GetComponent<Transform>();
        playerTr = GameObject.FindWithTag("Player").GetComponent<Transform>();
        nvAgent = this.gameObject.GetComponent<UnityEngine.AI.NavMeshAgent>();
      
        StartCoroutine(Angry_Control());
        StartCoroutine(State_Look());

    }

    // Update is called once per frame
    void Update()
    {

        //nvAgent.destination = playerTr.position;

        if (Input.GetKeyDown(KeyCode.Escape)) SceneManager.LoadScene(1);

        //  distance = nvAgent.remainingDistance; infinity라는 값이나와서 아래로 바꿈

        distance = Vector3.Distance(playerTr.position, wifeTr.position);
        Vector3 vec = playerTr.position - wifeTr.position;

        vec.Normalize();

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


        if (distance < 8)
        {
            vec = playerTr.position - wifeTr.position;
            nvAgent.destination = wifeTr.position;
            Looking(vec);
        }
    }

    void Looking(Vector3 vec)
    {
        Quaternion q = Quaternion.LookRotation(vec);

        nvAgent.transform.rotation = q;
    }

    IEnumerator Angry_Control()
    {
        while (true)
        {
            if (angry >= 3)
                nvAgent.destination = playerTr.position;
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
                
                if (angry <= 10)
                {
                    angry++;
                }
            }

                if (angry > 0 && Current_State == Unit_State.Find_State)
                {
                    Debug.Log("Minus!");
                    angry-= 0.5f;
                }

            Debug.Log("분노게이지:" + angry);
            Debug.Log("Speed :" + nvAgent.speed);
            yield return new WaitForSeconds(1.0f);
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
            yield return new WaitForSeconds(1.0f);
        }
    }
    //IEnumerator Get_Time()
    //{
    //    yield return new WaitForSeconds(3.0f);
    //    Current_State = Unit_State.Find_State;
    //}
    public bool State_identify()
    {
        if (Current_State == Unit_State.Find_State)
            return false;
        return true;
    }
}

using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class Wife2 : MonoBehaviour
{

    private Transform wifeTr;
    private Transform playerTr;
    private UnityEngine.AI.NavMeshAgent nvAgent;
    private float distance = 0;
    private float angle = 10;
    private Transform SearchPos;
    private bool flag = true;
    private int angry = 0;
    private Husband Husband_State;
    // Use this for initialization
    void Start()
    {
        //SceneManager.LoadScene(0);
        wifeTr = this.gameObject.GetComponent<Transform>();
        playerTr = GameObject.FindWithTag("Player").GetComponent<Transform>();
        nvAgent = this.gameObject.GetComponent<UnityEngine.AI.NavMeshAgent>();
        Husband_State = GameObject.Find("Husband").gameObject.GetComponent<Husband>();

        StartCoroutine(Angry_Control());

    }

    // Update is called once per frame
    void Update()
    {


        //nvAgent.destination = playerTr.position;

        if (Input.GetKeyDown(KeyCode.Escape)) SceneManager.LoadScene(1);

        //  distance = nvAgent.remainingDistance; infinity라는 값이나와서 아래로 바꿈

        distance = Vector3.Distance(playerTr.position, wifeTr.position);
        //Vector3 vec = playerTr.position - wifeTr.position;


        //vec.Normalize();


        if (distance < 8)
        {
            //vec = playerTr.position - SearchPos.position;
            //nvAgent.destination = wifeTr.position;
        }
        // else
        //  nvAgent.destination = playerTr.position; 
    }
    //void Looking(Vector3 vec)
    //{
    //    Quaternion q = Quaternion.LookRotation(vec);


    //    nvAgent.transform.rotation = q;
    //}

    IEnumerator Angry_Control()
    {
        while (true)
        {
            if (angry >= 3)
                nvAgent.destination = playerTr.position;
            else
                nvAgent.destination = wifeTr.position;

            if (distance < 20 && Husband_State.State_identify())
            {
                switch (angry)
                {
                    case 3:
                    case 4:
                        nvAgent.speed = 6;
                        break;
                    case 5:
                    case 6:
                        nvAgent.speed = 7;
                        break;
                    case 7:
                    case 8:
                        nvAgent.speed = 8;
                        break;
                    case 9:
                        nvAgent.speed = 9;
                        break;
                    case 10:
                        nvAgent.speed = 10;
                        break;
                    default:
                        nvAgent.speed = 5;
                        break;
                }
                if (angry <= 10)
                    angry++;

            }
            Debug.Log("분노게이지:" + angry);
            yield return new WaitForSeconds(1.0f);
        }
    }
}

using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Wife : MonoBehaviour {

    private Transform wifeTr;
    private Transform playerTr;
    private UnityEngine.AI.NavMeshAgent nvAgent;
    private float distance = 0;
    private float angle = 10;
    private Transform SearchPos;
    private bool flag = true;
    

	// Use this for initialization
	void Start () {
        wifeTr = this.gameObject.GetComponent<Transform>();
        playerTr = GameObject.FindWithTag("Player").GetComponent<Transform>();
  
        nvAgent = this.gameObject.GetComponent<UnityEngine.AI.NavMeshAgent>();

        nvAgent.destination = playerTr.position;
	}
	
	// Update is called once per frame
	void Update () {


        nvAgent.destination = playerTr.position;


        distance = nvAgent.remainingDistance;

        //Vector3 vec = playerTr.position - wifeTr.position;


        //vec.Normalize();


        if (distance < 8)
        {
            //vec = playerTr.position - SearchPos.position;
            nvAgent.destination = wifeTr.position;
            
        }
    }
    //void Looking(Vector3 vec)
    //{
    //    Quaternion q = Quaternion.LookRotation(vec);


    //    nvAgent.transform.rotation = q;
    //}

}

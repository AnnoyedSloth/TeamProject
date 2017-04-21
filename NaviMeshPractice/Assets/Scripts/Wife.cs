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
        
        SearchPos = wifeTr;
        RaycastHit hit;
        distance = nvAgent.remainingDistance;

        if (angle == 10) flag = false;
        else if (angle == -10) flag = true;

        if (flag == true) angle += 1;
        else angle -= 1;


        Vector3 vec = playerTr.position - wifeTr.position;
        Physics.Raycast(SearchPos.position, SearchPos.forward, out hit, 10.0f);

        vec.Normalize();

        transform.Rotate(SearchPos.up, angle * Time.deltaTime * 10);

        Debug.DrawRay(SearchPos.position, SearchPos.forward * 10, Color.green);



        if (distance < 8)
        {
            vec = playerTr.position - SearchPos.position;
            nvAgent.destination = wifeTr.position;

            if (hit.collider.tag == "Player")
            {
                Looking(vec);
            }
            
        }
    }

    void Looking(Vector3 vec)
    {
        Quaternion q = Quaternion.LookRotation(vec);


        nvAgent.transform.rotation = q;
    }

}

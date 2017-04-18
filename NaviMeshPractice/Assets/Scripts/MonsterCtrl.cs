using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MonsterCtrl : MonoBehaviour {

    private Transform monsterTr;
    private Transform playerTr;
    private UnityEngine.AI.NavMeshAgent nvAgent;
    private float distance = 0;
    private float angle = 0;

	// Use this for initialization
	void Start () {
        monsterTr = this.gameObject.GetComponent<Transform>();
        playerTr = GameObject.FindWithTag("Player").GetComponent<Transform>();
        nvAgent = this.gameObject.GetComponent<UnityEngine.AI.NavMeshAgent>();

        nvAgent.destination = playerTr.position;
	}
	
	// Update is called once per frame
	void Update () {

        distance = nvAgent.remainingDistance;

        Vector3 vec = playerTr.position - monsterTr.position;

        if (distance < 4)
        {
            Looking(vec);
            nvAgent.destination = monsterTr.position;
        }
    }

    void Looking(Vector3 vec)
    {

        vec.Normalize();
        Quaternion q = Quaternion.LookRotation(vec);

        nvAgent.transform.rotation = q;
    }

}

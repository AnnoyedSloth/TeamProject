using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Sight : MonoBehaviour {

    private Transform ThisTr;
    private Transform PlayerTr;
    public GameObject Player;

	// Use this for initialization
	void Start () {
        ThisTr = this.gameObject.GetComponent<Transform>();
        PlayerTr = GameObject.FindWithTag("Player").GetComponent<Transform>();
	}
	
	// Update is called once per frame
	void Update () {


        if (Input.GetKey(KeyCode.Space))
        {
            RaycastHit hit;

            Debug.DrawRay(ThisTr.position, ThisTr.forward * 10.0f, Color.green);

            if (Physics.Raycast(ThisTr.position, ThisTr.forward, out hit, 10.0f))
            {
                if (hit.collider.tag == "Player")
                {
                    Debug.Log("Raycast Hitted!");
                }
            }

        }

	}
}

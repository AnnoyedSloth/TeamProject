using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Interaction : MonoBehaviour {

    private Transform playerTr;
    private RaycastHit moneyHit;
    public Camera fpsCam;

	// Use this for initialization
	void Start () {
        playerTr = GameObject.FindWithTag("Player").GetComponent<Transform>();
        fpsCam = GetComponentInChildren<Camera>();
	}
	
	// Update is called once per frame
	void Update () {
        //if(Input.GetButtonDown)
        //Vector3 rayOrigin = fpsCam.ViewportToWorldPoint(new Vector3(0.5f, 0.5f, 0.0f));
        
        //Debug.DrawRay(rayOrigin, fpsCam.transform.forward , Color.red);
        //if (Physics.Raycast(rayOrigin, fpsCam.transform.forward, out moneyHit, 2.0f))
        //{
        //    if (moneyHit.collider.tag == "Money")
        //    {
        //        Debug.Log("Ray Hitted!");
        //    }
        //}
	}
}

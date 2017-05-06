using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Husband : MonoBehaviour
{



    public int Speed = 6;

    public Transform PlayerTr;
    // Use this for initialization
    void Start()
    {
        PlayerTr = this.gameObject.GetComponent<Transform>();


    }

    // Update is called once per frame
    void Update()
    {
        if (Input.GetKey(KeyCode.W) == true)
        {
            PlayerTr.transform.Translate(Vector3.forward * Speed * Time.deltaTime);
        }
        if (Input.GetKey(KeyCode.S) == true)
        {
            PlayerTr.transform.Translate(-Vector3.forward * Speed * Time.deltaTime);
        }
        if (Input.GetKey(KeyCode.A) == true)
        {
            PlayerTr.transform.Translate(Vector3.left * Speed * Time.deltaTime);
        }
        if (Input.GetKey(KeyCode.D) == true)
        {
            PlayerTr.transform.Translate(-Vector3.left * Speed * Time.deltaTime);
        }
    }
}

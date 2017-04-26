using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Sight : MonoBehaviour
{
    public GameObject Enemy;
    private Transform ThisTr;
    private Transform SightTr;
    private Transform SearchPos;
    private float value = 10;
    private float Torque = 10.0f;
    private bool flag = true;
    private RaycastHit hit;

    void Start()
    {
        ThisTr = this.gameObject.GetComponent<Transform>();
        SearchPos = ThisTr;
    }

    void FixedUpdate()
    {

        AngleCalc();

        transform.Rotate(SearchPos.up, Torque * Time.deltaTime * 20);
        Debug.DrawRay(SearchPos.position, SearchPos.forward * 10, Color.green);

        if (Physics.Raycast(SearchPos.position, SearchPos.forward, out hit, 10.0f))
        {
            if (hit.collider.tag == "Player")
            {

                if (Input.GetKeyDown(KeyCode.Space))
                {
                    Destroy(Enemy);
                }
            }
        }
    }

    void AngleCalc()
    {
        if (value == 20)
        {
            value = 0;
            Torque = -10;
            flag = false;
        }
        else if (value == -20)
        {
            value = 0;
            Torque = 10;
            flag = true;
        }
        if (flag == true) value += 1;
        else value -= 1;
    }
}
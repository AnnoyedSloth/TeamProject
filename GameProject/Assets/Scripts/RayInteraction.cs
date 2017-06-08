using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class RayInteraction : MonoBehaviour
{

    private Transform RayPlayerTr;
    private RaycastHit moneyHit;
    private bool MoneyFlag = false;

    Vector3 ray;

    public int HitNum;

    // Use this for initialization
    void Start()
    {
        RayPlayerTr = GameObject.FindWithTag("Player").gameObject.GetComponent<Transform>();
    }

    // Update is called once per frame
    void Update()
    {
        ray = Camera.main.ViewportToWorldPoint(new Vector3(0.5f, 0.5f, 0.0f));
        Debug.DrawRay(ray, Camera.main.transform.forward * 4, Color.yellow);

        if (Physics.Raycast(ray, Camera.main.transform.forward*4, out moneyHit, 2.0f))
        {
            if (moneyHit.collider.tag == "Money")
            {
                MoneyFlag = true;
                NameFind();
            }
        }
        else MoneyFlag = false;

    }

    void NameFind()
    {
        if (moneyHit.collider.name == "Kitchen_Table(1-0)") HitNum = 0;
        else if (moneyHit.collider.name == "Fridge(1-0)") HitNum = 1;
        else if (moneyHit.collider.name == "D_Table(1-0)") HitNum = 2;
        else if (moneyHit.collider.name == "TV_Stand(1-0)") HitNum = 3;
        else if (moneyHit.collider.name == "K-Table(1-0-1)") HitNum = 4;
        else if (moneyHit.collider.name == "K-Table(1-0-2)") HitNum = 5;
        else if (moneyHit.collider.name == "Sofa(1-0-1)") HitNum = 6;
        else if (moneyHit.collider.name == "Sofa(1-0-2)") HitNum = 7;
        else if (moneyHit.collider.name == "Washer(1-1)") HitNum = 8;
        else if (moneyHit.collider.name == "Closet(1-2)") HitNum = 9;
        else if (moneyHit.collider.name == "Desk(1-2)") HitNum = 10;
        else if (moneyHit.collider.name == "Washstand(1-3)") HitNum = 11;
        else if (moneyHit.collider.name == "Toilet(1-3)") HitNum = 12;
        else if (moneyHit.collider.name == "Closet(2-1)") HitNum = 13;
        else if (moneyHit.collider.name == "Desk(2-1)") HitNum = 14;
        else if (moneyHit.collider.name == "TV_Stand(2-1)") HitNum = 15;
        else if (moneyHit.collider.name == "Bed(2-1)") HitNum = 16;
        else if (moneyHit.collider.name == "Closet(2-3)") HitNum = 17;
        else if (moneyHit.collider.name == "Desk(2-3)") HitNum = 18;
        else if (moneyHit.collider.name == "Bed(2-3)") HitNum = 19;
        else if (moneyHit.collider.name == "Toilet(2-4)") HitNum = 20;
        else if (moneyHit.collider.name == "Washstand(2-4)") HitNum = 21;
    }

    public int GetHitNum()
    {
        return HitNum;
    }
    public bool GetMoneyFlag()
    {
        return MoneyFlag;
    }
}
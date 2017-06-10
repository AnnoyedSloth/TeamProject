using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;
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
    private ResourceUI resourcel;
    public MoneySystem Money;
    public bool Cooltimm = false;
    public int temp = 0; // MoneySystem전체금액 + 현재금액
    void Start()
    {
        ThisTr = this.gameObject.GetComponent<Transform>();
        SearchPos = ThisTr;
        resourcel = GameObject.Find("NumUIPrefab").gameObject.GetComponent<ResourceUI>();
        Money = GameObject.Find("Husband").gameObject.GetComponent<MoneySystem>();

    }

    void FixedUpdate()
    {

        AngleCalc();

        transform.Rotate(SearchPos.up, Torque * Time.deltaTime * 20);
        Debug.DrawRay(SearchPos.position, SearchPos.forward * 20, Color.green);

        if (Physics.Raycast(SearchPos.position, SearchPos.forward, out hit, 20.0f))
        {
            if (hit.collider.tag == "Player" )
            {
                if (SResource.Instance.Nmoney > 0 && Cooltimm == false)
                {
                    SResource.Instance.Nmoney = SResource.Instance.Nmoney / 2;
                    if(SResource.Instance.Nmoney % 10000 == 5000)
                    {
                        SResource.Instance.Nmoney += 5000;
                    }
                    resourcel.MoneyUpdate();
                    temp = 0;
                    for (int a = 0; a < 22; a++)
                    {
                        temp = temp + Money.RMoney[a].Amount;
                    }
                    temp = SResource.Instance.Nmoney + temp;
                    if (!(temp >= 200000))
                    {
                        SResource.Instance.IsFali = true;
                        SceneManager.LoadScene("CutScene");
                    }
                    if(SResource.Instance.Nmoney >= 200000)
                    {
                        SResource.Instance.IsFali = false;
                        SceneManager.LoadScene("CutScene");
                    }

                    Cooltimm = true;
                    StartCoroutine(CoolTime_Manager());
                }
                Debug.Log("You died");
                //Destroy(Enemy);
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

    IEnumerator CoolTime_Manager()
    {
        yield return new WaitForSeconds(3.0f);
        Cooltimm = false;
        StopCoroutine(CoolTime_Manager());
    }
}
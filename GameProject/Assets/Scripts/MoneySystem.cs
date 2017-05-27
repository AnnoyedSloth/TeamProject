using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MoneySystem : MonoBehaviour
{

    private RayInteraction RayInfo;
    private UIRootingSlider RootGauge_MS;

    public Money[] RMoney = new Money[22];
    public Money CastedMoney;

    public int CastNum;
    public bool UIFlag;

    public int totalMoney = 0;

    public class Money
    {
        public int Amount;
        public bool isRooted;

        public Money(int amt, bool irt)
        {
            // TODO: Complete member initialization
            this.Amount = amt;
            this.isRooted = irt;
        }
    }


    // Use this for initialization
    void Start()
    {

        RayInfo = GameObject.Find("Husband").gameObject.GetComponent<RayInteraction>();
        RootGauge_MS = GameObject.Find("UI").gameObject.GetComponent<UIRootingSlider>();

        for (int a = 0; a < 22; a++)
        {
            RMoney[a] = new Money(10000, false);
        }

    }

    // Update is called once per frame
    void Update()
    {
        if (RayInfo.GetMoneyFlag() == true)
        {
            CastNum = RayInfo.GetHitNum();
            if (RootGauge_MS.GetComp() == true)
            {
                totalMoney += RMoney[CastNum].Amount;
                RMoney[CastNum].Amount = 0;
               
                RMoney[CastNum].isRooted = true;
                Debug.Log(CastNum + "의 돈은 " + RMoney[CastNum].Amount);
            }
            else Debug.Log(CastNum + "의 돈은 " + RMoney[CastNum].Amount);
        }
    }
}
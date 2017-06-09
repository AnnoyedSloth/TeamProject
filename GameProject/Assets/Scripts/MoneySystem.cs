using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MoneySystem : MonoBehaviour
{
    private RayInteraction RayInfo;
    private UIRootingInfo RootInfo;
    public UIRootingSlider RootGauge_MS;
    public UIGeneral Gen;
    public ResourceUI resourcel;
    public Money[] RMoney = new Money[22];
    public Money CastedMoney;
    public int CastNum;
    public bool UIFlag;

    public AudioClip MoneyGet;
    private bool MGetFlag = true;


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
        resourcel = GameObject.Find("NumUIPrefab").gameObject.GetComponent<ResourceUI>();
        Gen = GameObject.Find("UI").gameObject.GetComponent<UIGeneral>();
        RootInfo = GameObject.Find("RootingImage").gameObject.GetComponent<UIRootingInfo>();


        RMoney[0] = new Money(20000, false); // Kitchen_Table(1-0)
        RMoney[1] = new Money(20000, false); // Fridge(1-0)
        RMoney[2] = new Money(30000, false); // D_Table(1-0)
        RMoney[3] = new Money(30000, false); // TV_Stand(1-0)
        RMoney[4] = new Money(30000, false); // K-Table(1-0-1)
        RMoney[5] = new Money(20000, false); // K-Table(1-0-2)
        RMoney[6] = new Money(30000, false); // Sofa(1-0-1)
        RMoney[7] = new Money(30000, false); // Sofa(1-0-2)
        RMoney[8] = new Money(100000, false); // Washer(1-1)
        RMoney[9] = new Money(10000, false); // Closet(1-2)
        RMoney[10] = new Money(10000, false); // Desk(1-2)
        RMoney[11] = new Money(10000, false); // Washstand(1-3)
        RMoney[12] = new Money(10000, false); // Toilet(1-3)
        RMoney[13] = new Money(10000, false); // Closet(2-1)
        RMoney[14] = new Money(10000, false); // Desk(2-1)
        RMoney[15] = new Money(10000, false); // TV_Stand(2-1)
        RMoney[16] = new Money(10000, false); // Bed(2-1)
        RMoney[17] = new Money(10000, false); // Closet(2-3)
        RMoney[18] = new Money(10000, false); // Desk(2-3)
        RMoney[19] = new Money(10000, false); // Bed(2-3)
        RMoney[20] = new Money(10000, false); // Toilet(2-4)
        RMoney[21] = new Money(10000, false); // Washstand(2-4)
    }

    // Update is called once per frame
    void Update()
    {
        if (RayInfo.GetMoneyFlag() == true)
        {
            CastNum = RayInfo.GetHitNum();
            RootGauge_MS.setGaugeRate(setSpeed(RMoney[CastNum].Amount));
            Gen.getObjStatus(RMoney[CastNum].Amount, RMoney[CastNum].isRooted);
            RootInfo.getInfo(RMoney[CastNum].Amount);
            if (RootGauge_MS.GetComp() == true)
            {
                if(MGetFlag)StartCoroutine(M_Get());
                SResource.Instance.Nmoney += RMoney[CastNum].Amount;
                resourcel.MoneyUpdate();
                totalMoney += RMoney[CastNum].Amount;
                RMoney[CastNum].Amount = 0;               
                RMoney[CastNum].isRooted = true;
            }
        }
    }

    private float setSpeed(float moneyAmount)
    {
        return 30000 / moneyAmount;
    }

    IEnumerator M_Get()
    {
        MGetFlag = false;
        AudioSource.PlayClipAtPoint(MoneyGet, transform.position);
        yield return new WaitForSeconds(1.0f);
        MGetFlag = true;
    }

}
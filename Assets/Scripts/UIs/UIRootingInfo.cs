using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class UIRootingInfo : MonoBehaviour
{
    public int UR_Price;

    public GameObject Text_A;
    public GameObject Text_B;
    public GameObject Text_C;

    public GameObject m_10000;
    public GameObject m_20000;
    public GameObject m_30000;
    public GameObject m_50000;
    public GameObject m_80000;
    public GameObject m_100000;

    void Start()
    {

    }
    // Update is called once per frame
    void Update()
    {
        if (UR_Price == 10000)
        {
            m_10000.SetActive(true);
            Text_A.SetActive(true);

            m_20000.SetActive(false);
            m_30000.SetActive(false);
            m_50000.SetActive(false);
            m_80000.SetActive(false);
            m_100000.SetActive(false);

            Text_B.SetActive(false);
            Text_C.SetActive(false);
        }
        else if (UR_Price == 20000)
        {
            m_20000.SetActive(true);
            Text_B.SetActive(true);

            m_10000.SetActive(false);
            m_30000.SetActive(false);
            m_50000.SetActive(false);
            m_80000.SetActive(false);
            m_100000.SetActive(false);
            Text_A.SetActive(false);
            Text_C.SetActive(false);
        }
        else if (UR_Price == 30000)
        {
            m_30000.SetActive(true);
            Text_B.SetActive(true);

            m_10000.SetActive(false);
            m_20000.SetActive(false);
            m_50000.SetActive(false);
            m_80000.SetActive(false);
            m_100000.SetActive(false);
            Text_A.SetActive(false);
            Text_C.SetActive(false);
        }
        else if (UR_Price == 50000)
        {
            m_50000.SetActive(true);
            Text_C.SetActive(true);

            m_10000.SetActive(false);
            m_20000.SetActive(false);
            m_30000.SetActive(false);
            m_80000.SetActive(false);
            m_100000.SetActive(false);
            Text_A.SetActive(false);
            Text_B.SetActive(false);
        }
        else if (UR_Price == 80000)
        {
            m_80000.SetActive(true);
            Text_C.SetActive(true);

            m_10000.SetActive(false);
            m_20000.SetActive(false);
            m_30000.SetActive(false);
            m_50000.SetActive(false);
            m_100000.SetActive(false);
            Text_A.SetActive(false);
            Text_B.SetActive(false);
        }
        else if (UR_Price == 100000)
        {
            m_100000.SetActive(true);
            Text_C.SetActive(true);

            m_10000.SetActive(false);
            m_20000.SetActive(false);
            m_30000.SetActive(false);
            m_50000.SetActive(false);
            m_80000.SetActive(false);
            Text_A.SetActive(false);
            Text_B.SetActive(false);
        }

    }

    public void getInfo(int money)
    {
        UR_Price = money;
    }

}

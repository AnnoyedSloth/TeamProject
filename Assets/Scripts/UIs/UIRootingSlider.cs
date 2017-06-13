using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class UIRootingSlider : MonoBehaviour {

    private Slider RootingSlider;
    float RootingGauge = 0.0f;
    float MaxGauge = 100.0f; // 게이지 최대수치
    public float GaugeRate = 1.0f; // 게이지 상승속도. 금액의 영향을 받음

    public bool isCompleted;

	// Use this for initialization
	void Start () {
        RootingSlider = GameObject.Find("RootingSlider").gameObject.GetComponent<Slider>();
        isCompleted = false;
        StartCoroutine(Rooting());
	}
	
	// Update is called once per frame
	void Update () {
        RootingSlider.value = RootingGauge;
	}

    public bool GetComp()
    {
        return isCompleted;
    }

    public void setGaugeRate(float GotGaugeRate)
    {
        GaugeRate = GotGaugeRate;
    }

    IEnumerator Rooting()
    {
        while (true)
        {
            if (Input.GetKey(KeyCode.Space))
            {
                RootingGauge += GaugeRate;
            }
            else
            {
                RootingGauge = 0.0f;
            }
            if (RootingGauge >= MaxGauge) isCompleted = true;
            else isCompleted = false;
        yield return new WaitForSeconds(0.01f);
        }
    }
}

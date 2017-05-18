using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class UIRootingSlider : MonoBehaviour {

    private Slider RootingSlider;
    float RootingGauge = 0.0f;
    float MaxGauge = 100.0f;
    public Color StartingGauge = Color.green;
    public Color EndGauge = Color.red;

	// Use this for initialization
	void Start () {
        RootingSlider = this.gameObject.GetComponent<Slider>();
        StartCoroutine(Rooting());
	}
	
	// Update is called once per frame
	void Update () {
        RootingSlider.value = RootingGauge;

	}

    IEnumerator Rooting()
    {
        while (true)
        {
            if (Input.GetKey(KeyCode.Space))
            {
                RootingGauge += 1.0f;
            }
            if (Input.GetKeyUp(KeyCode.Space))
            {
                RootingGauge = 0.0f;
            }
        yield return new WaitForSeconds(0.01f);
        }
    }
}

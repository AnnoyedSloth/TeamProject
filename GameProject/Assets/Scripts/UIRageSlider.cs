using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class UIRageSlider : MonoBehaviour {

    private Wife WifeRage;
    private Slider RageSlider;

	// Use this for initialization
	void Start () {
        WifeRage = gameObject.GetComponent<Wife>();
        RageSlider = this.gameObject.GetComponent<Slider>();
	}
	
	// Update is called once per frame
	void Update () {
        RageSlider.value = WifeRage.angry;
		
	}
}

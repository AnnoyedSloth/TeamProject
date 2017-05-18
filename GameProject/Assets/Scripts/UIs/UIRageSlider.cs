using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class UIRageSlider : MonoBehaviour {

    private Wife WifeRage;
    private Slider RageSlider;
    private float Rage;
    private float MaxRage = 10.0f;
    public Color PeaceMode = Color.green;
    public Color RageMode = Color.red;

	// Use this for initialization
	void Start () {
        WifeRage = GameObject.Find("Wife").gameObject.GetComponent<Wife>();
        RageSlider = this.gameObject.GetComponent<Slider>();
	}
	
	// Update is called once per frame
	void Update () {
        Rage = WifeRage.RTRage();
        RageSlider.value = Rage;
	}
}
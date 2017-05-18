using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.Events;

public class UIGuide : MonoBehaviour {

    //public Image Guide;
    public GameObject Panel;
    private Button GuideStart;
    private Button GuideExit;

	// Use this for initialization
	void Start () {
        Panel.SetActive(true);
        GuideStart = GameObject.Find("Start").gameObject.GetComponent<Button>();
        GuideExit = GameObject.Find("Exit").gameObject.GetComponent<Button>();
	}
	
	// Update is called once per frame
	void Update () {

        if (Input.GetKeyDown(KeyCode.F1))
        {
            Panel.SetActive(true);
        }
        else if (Input.GetKeyUp(KeyCode.F1))
        {
            Panel.SetActive(false);
        }
	}

    public void Click()
    {
        Panel.SetActive(false);
    }
}
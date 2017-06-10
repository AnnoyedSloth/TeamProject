using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class CutSceneImageManager : MonoBehaviour {

    public Image Fail_image;
    public Image Fail_font;
    public Image Success_image;
    public Image Success_font;
    // Use this for initialization
    void Start () {
		if(SResource.Instance.IsFali)
        {
            Fail_image.enabled = true;
            Fail_font.enabled = true;
            Success_image.enabled = false;
            Success_font.enabled = false;
        }
        else
        {
            Fail_image.enabled = false;
            Fail_font.enabled = false;
            Success_image.enabled = true;
            Success_font.enabled = true;

        }
	}
	
	// Update is called once per frame
	void Update () {
		
	}
}

using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.UI;

public class MainScene : MonoBehaviour {

    public Image BG; // 글씨있는거
    public Image BG2; // 글씨 없는거
	// Use this for initialization
	void Start () {
        BG.enabled = false;
        BG2.enabled = true;
        StartCoroutine(Image_Change());
	}
	
	// Update is called once per frame
	void Update () {
		
	}

    IEnumerator Image_Change()
    {
        while (true)
        {
            if (BG.enabled)
            {
                BG.enabled = false;
                BG2.enabled = true;
            }
            else
            {
                BG2.enabled = false;
                BG.enabled = true;
            }

            yield return new WaitForSeconds(1.0f);
        }
    }
    public void MainClick()
    {
        StopCoroutine(Image_Change());
        SceneManager.LoadScene("Difficulty");
    }
}

using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.EventSystems;
using UnityEngine.SceneManagement;

public class UIDifficulty : MonoBehaviour
{

    private bool isOver = false;

    public Image EasyImg;
    public Image NormalImg;
    public Image HardImg;

    public Button EasyBtn;
    public Button NormalBtn;
    public Button HardBtn;

	void Start () {

        EasyImg.enabled = true;
        NormalImg.enabled = false;
        HardImg.enabled = false;
        EasyBtn.enabled = true;
        NormalBtn.enabled = true;
        HardBtn.enabled = true;
	}

	void Update () {
		
	}

    public void MouseUpEasy(){

        EasyBtn.enabled = true;
        EasyImg.enabled = true;
        
        NormalImg.enabled = false;
        //NormalBtn.enabled = false;

        HardImg.enabled = false;
        //HardBtn.enabled = false;
    }

    public void MouseUpNormal()
    {

        EasyImg.enabled = false;
        //EasyBtn.enabled = false;

        NormalImg.enabled = true;
        NormalBtn.enabled = true;

        HardImg.enabled = false;
        //HardBtn.enabled = false;

    }

    public void MouseUpHard()
    {
        EasyImg.enabled = false;
        //EasyBtn.enabled = false;

        NormalImg.enabled = false;
        //NormalBtn.enabled = false;

        HardImg.enabled = true;
        HardBtn.enabled = true;
    }

    public void EasyClick()
    {
        SceneManager.LoadScene(1);
    }
}

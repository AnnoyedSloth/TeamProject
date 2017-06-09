using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.Events;
using UnityEngine.SceneManagement;

public class UIGeneral : MonoBehaviour
{

    private RayInteraction PlayerRayFlag;
    private MoneySystem MoneyInfo;

    //public Image Guide;
    public GameObject GuidePanel;

    public GameObject RSlider;
    public GameObject RImage;

    public GameObject ExitPanel;
    private bool ExitFlag = false;
    private bool PanelActiveFlag;

    public bool MS_RootFlag = false;
    public int MS_Money = 0;

    // Use this for initialization
    void Start()
    {
        PlayerRayFlag = GameObject.Find("Husband").gameObject.GetComponent<RayInteraction>();
        MoneyInfo = GameObject.Find("Husband").gameObject.GetComponent<MoneySystem>();

        GuidePanel.SetActive(true);
        RSlider.SetActive(false);
        RImage.SetActive(false);

        ExitPanel.SetActive(false);

        PanelActiveFlag = true;
        Time.timeScale = 0;
    }

    // Update is called once per frame
    void Update()
    {
        if (Input.GetKeyDown(KeyCode.F1))
        {
            GuidePanel.SetActive(true);
        }
        else if (Input.GetKeyUp(KeyCode.F1))
        {
            GuidePanel.SetActive(false);
        }

        if (PlayerRayFlag.GetMoneyFlag() == true && MS_RootFlag) // 레이캐스트가 적중했을 때
        {

            if (PanelActiveFlag) // 패널 액티브플래그
            {
                RImage.SetActive(true);
            }

            if (Input.GetKey(KeyCode.Space)) // 스페이스바가 눌렸을 때
            {
                PanelActiveFlag = false;
                RSlider.SetActive(true);
                RImage.SetActive(false);
            }
            else
            {
                PanelActiveFlag = true;
                RSlider.SetActive(false);
                RImage.SetActive(true);
            }
        }
        else
        {
            RImage.SetActive(false);
            RSlider.SetActive(false);
        }

        if (Input.GetKeyDown(KeyCode.Escape))
        {
            if (ExitFlag == false) // EXIT 창이 꺼져 있으면 키고 플래그 true로 설정
            {
                ExitPanel.SetActive(true);
                ExitFlag = true;
                Cursor.lockState = CursorLockMode.None;
                Time.timeScale = 0;
            }
            else
            {
                ExitPanel.SetActive(false); // EXIT 창이 켜져 있으면 끄고 플래그 false로 설정
                ExitFlag = false;
                Cursor.lockState = CursorLockMode.Locked;
                Time.timeScale = 1;
            }
        }

    }

    public void Click()
    {
        GuidePanel.SetActive(false); // 가이드패널 deactivate
        Cursor.lockState = CursorLockMode.Locked;
        Time.timeScale = 1;
    }

    public void ExitYes()
    {
        //SceneManager.LoadScene(0);
        Application.Quit();
    }

    public void ExitNo()
    {
        ExitPanel.SetActive(false); // EXIT 창 deactivate 하고 플래그 false로 설정
        ExitFlag = false;
        Cursor.lockState = CursorLockMode.Locked;
        Time.timeScale = 1;
    }

    public void getObjStatus(int amount, bool isRooted)
    {
        Debug.Log("getObjStatus Called");
        if (isRooted)
        {
            MS_RootFlag = false;
        }
        else
        {
            MS_RootFlag = true;
            MS_Money = amount;
        }
    }
}
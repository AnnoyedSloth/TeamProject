using System.Collections;
using System.Collections.Generic;
using UnityEngine.UI;
using UnityEngine.SceneManagement;
using UnityEngine;

public class ResourceUI : MonoBehaviour {

    public Image MTen;
    public Image MOne;
    public Image STen;
    public Image SOne;

    public Image Logo;

    public Image NHTM;
    public Image NTTM;
    public Image NTM;
    public Image NHM;
    public Image NTenM;
    public Image NOM;

    public Image POM;
    public Image PTenM;
    public Image PHM;
    public Image PTM;
    public Image PTTM;
    public Image PHTM;

    public GameObject Message;

    bool GoldEnough;

    // Use this for initialization
    void Start () {
        // Message.SetActive(false);
        SResource.Instance.TIME = 900;
     
        NumberUI.Instance.MUIUpdate(NHTM, NTTM, NTM, NHM, NTenM, NOM, SResource.Instance.Nmoney);
        NumberUI.Instance.MUIUpdate(PHTM, PTTM, PTM, PHM, PTenM, POM,SResource.Instance.Pmoney);
        StartCoroutine(UpdateTime());
    }

    // Update is called once per frame
    void Update () {

    }

    public IEnumerator UpdateTime()
    {
        while (true)
        {
            SResource.Instance.TIME -= 1;
            if(SResource.Instance.TIME <= 0)
            {
                SceneManager.LoadScene("GameOver");
                StopCoroutine(UpdateTime());
            }
            NumberUI.Instance.TUIUpdate(MTen, MOne, STen, SOne, SResource.Instance.TIME);
            yield return new WaitForSeconds(1.0f);
        }
    }
    void MessageOff()
    {
        Message.SetActive(false);
    }

    void MessageON()
    {
        Message.SetActive(true);
        Invoke("MessageOff",0.5f);
    }


}

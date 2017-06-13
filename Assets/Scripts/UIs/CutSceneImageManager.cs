using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.SceneManagement;
public class CutSceneImageManager : MonoBehaviour
{

    public Image Fail_image;
    public Image Fail_font;
    public Image Success_image;
    public Image Success_font;
    public Button Main;
    public Button Replay;

    // Use this for initialization
    void Start()
    {
        Cursor.lockState = CursorLockMode.None;
        SResource.Instance.Nmoney = 0;
        if (SResource.Instance.IsFali)
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
        Main.GetComponent<Image>().sprite = Resources.Load("CutScene/main_def", typeof(Sprite)) as Sprite;
        Replay.GetComponent<Image>().sprite = Resources.Load("CutScene/replay_def", typeof(Sprite)) as Sprite;




    }

    // Update is called once per frame
    void Update()
    {

    }

    public void Main_Click()
    {
        Main.image.GetComponent<Image>().sprite = Resources.Load("CutScene/main_click", typeof(Sprite)) as Sprite;

        SceneManager.LoadScene("Main");

    }

    public void Replay_Click()
    {
        Replay.image.GetComponent<Image>().sprite = Resources.Load("CutScene/replay_click", typeof(Sprite)) as Sprite;
        SceneManager.LoadScene("InGame");
    }
}

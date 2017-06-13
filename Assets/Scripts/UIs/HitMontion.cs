using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
public class HitMontion : MonoBehaviour
{

    public bool IsLoad = false;
    public Image temp;
    // Use this for initialization

    void Start()
    {
        temp.enabled = false;
    }

    // Update is called once per frame
    void Update()
    {
        if (IsLoad)
        {
            StartCoroutine(Image_Swith(0));
        }
    }

    public IEnumerator Image_Swith(int i)
    {
        IsLoad = false;
        temp.enabled = true;
        while (true)
        {
            i++;
            switch (i)
            {
                case 0:
                    temp.GetComponent<Image>().sprite = Resources.Load("Hit_Motion/Hit_Motion_PNG_Sequence (1)", typeof(Sprite)) as Sprite;
                    break;
                case 1:
                    temp.GetComponent<Image>().sprite = Resources.Load("Hit_Motion/Hit_Motion_PNG_Sequence (2)", typeof(Sprite)) as Sprite;
                    break;
                case 2:
                    temp.GetComponent<Image>().sprite = Resources.Load("Hit_Motion/Hit_Motion_PNG_Sequence (3)", typeof(Sprite)) as Sprite;
                    break;
                case 3:
                    temp.GetComponent<Image>().sprite = Resources.Load("Hit_Motion/Hit_Motion_PNG_Sequence (4)", typeof(Sprite)) as Sprite;
                    break;
                case 4:
                    temp.GetComponent<Image>().sprite = Resources.Load("Hit_Motion/Hit_Motion_PNG_Sequence (5)", typeof(Sprite)) as Sprite;
                    break;
                case 5:
                    temp.GetComponent<Image>().sprite = Resources.Load("Hit_Motion/Hit_Motion_PNG_Sequence (6)", typeof(Sprite)) as Sprite;
                    break;
                case 6:
                    temp.GetComponent<Image>().sprite = Resources.Load("Hit_Motion/Hit_Motion_PNG_Sequence (7)", typeof(Sprite)) as Sprite;
                    break;
                case 7:
                    temp.GetComponent<Image>().sprite = Resources.Load("Hit_Motion/Hit_Motion_PNG_Sequence (8)", typeof(Sprite)) as Sprite;
                    break;
                case 8:
                    temp.GetComponent<Image>().sprite = Resources.Load("Hit_Motion/Hit_Motion_PNG_Sequence (9)", typeof(Sprite)) as Sprite;
                    break;
                case 9:
                    temp.GetComponent<Image>().sprite = Resources.Load("Hit_Motion/Hit_Motion_PNG_Sequence (10)", typeof(Sprite)) as Sprite;
                    break;
                case 10:
                    temp.GetComponent<Image>().sprite = Resources.Load("Hit_Motion/Hit_Motion_PNG_Sequence (11)", typeof(Sprite)) as Sprite;
                    break;
                case 11:
                    temp.GetComponent<Image>().sprite = Resources.Load("Hit_Motion/Hit_Motion_PNG_Sequence (12)", typeof(Sprite)) as Sprite;
                    break;
                case 12:
                    temp.GetComponent<Image>().sprite = Resources.Load("Hit_Motion/Hit_Motion_PNG_Sequence (13)", typeof(Sprite)) as Sprite;
                    break;
                case 13:
                    temp.GetComponent<Image>().sprite = Resources.Load("Hit_Motion/Hit_Motion_PNG_Sequence (14)", typeof(Sprite)) as Sprite;
                    break;
                case 14:
                    temp.GetComponent<Image>().sprite = Resources.Load("Hit_Motion/Hit_Motion_PNG_Sequence (15)", typeof(Sprite)) as Sprite;
                    break;
                case 15:
                    temp.GetComponent<Image>().sprite = Resources.Load("Hit_Motion/Hit_Motion_PNG_Sequence (16)", typeof(Sprite)) as Sprite;
                    break;
                case 16:
                    temp.GetComponent<Image>().sprite = Resources.Load("Hit_Motion/Hit_Motion_PNG_Sequence (17)", typeof(Sprite)) as Sprite;
                    break;
                case 17:
                    temp.GetComponent<Image>().sprite = Resources.Load("Hit_Motion/Hit_Motion_PNG_Sequence (18)", typeof(Sprite)) as Sprite;
                    break;
                case 18:
                    temp.GetComponent<Image>().sprite = Resources.Load("Hit_Motion/Hit_Motion_PNG_Sequence (19)", typeof(Sprite)) as Sprite;
                    break;
                case 19:
                    temp.GetComponent<Image>().sprite = Resources.Load("Hit_Motion/Hit_Motion_PNG_Sequence (20)", typeof(Sprite)) as Sprite;
                    break;
                case 20:
                    temp.GetComponent<Image>().sprite = Resources.Load("Hit_Motion/Hit_Motion_PNG_Sequence (21)", typeof(Sprite)) as Sprite;
                    break;
                case 21:
                    temp.GetComponent<Image>().sprite = Resources.Load("Hit_Motion/Hit_Motion_PNG_Sequence (22)", typeof(Sprite)) as Sprite;
                    break;
                case 22:
                    temp.GetComponent<Image>().sprite = Resources.Load("Hit_Motion/Hit_Motion_PNG_Sequence (23)", typeof(Sprite)) as Sprite;
                    break;
                case 23:
                    temp.GetComponent<Image>().sprite = Resources.Load("Hit_Motion/Hit_Motion_PNG_Sequence (24)", typeof(Sprite)) as Sprite;
                    break;
                case 24:
                    temp.GetComponent<Image>().sprite = Resources.Load("Hit_Motion/Hit_Motion_PNG_Sequence (25)", typeof(Sprite)) as Sprite;
                    break;
                case 25:
                    temp.GetComponent<Image>().sprite = Resources.Load("Hit_Motion/Hit_Motion_PNG_Sequence (26)", typeof(Sprite)) as Sprite;
                    break;
                case 26:
                    temp.GetComponent<Image>().sprite = Resources.Load("Hit_Motion/Hit_Motion_PNG_Sequence (27)", typeof(Sprite)) as Sprite;
                    break;
                case 27:
                    temp.GetComponent<Image>().sprite = Resources.Load("Hit_Motion/Hit_Motion_PNG_Sequence (28)", typeof(Sprite)) as Sprite;
                    break;
                case 28:
                    temp.GetComponent<Image>().sprite = Resources.Load("Hit_Motion/Hit_Motion_PNG_Sequence (29)", typeof(Sprite)) as Sprite;
                    break;
                case 29:
                    temp.GetComponent<Image>().sprite = Resources.Load("Hit_Motion/Hit_Motion_PNG_Sequence (30)", typeof(Sprite)) as Sprite;
                    break;
                case 30:
                    temp.GetComponent<Image>().sprite = Resources.Load("Hit_Motion/Hit_Motion_PNG_Sequence (31)", typeof(Sprite)) as Sprite;
                    break;
                case 31:
                    temp.GetComponent<Image>().sprite = Resources.Load("Hit_Motion/Hit_Motion_PNG_Sequence (32)", typeof(Sprite)) as Sprite;
                    break;
                case 32:
                    temp.GetComponent<Image>().sprite = Resources.Load("Hit_Motion/Hit_Motion_PNG_Sequence (33)", typeof(Sprite)) as Sprite;
                    break;
                case 33:
                    temp.GetComponent<Image>().sprite = Resources.Load("Hit_Motion/Hit_Motion_PNG_Sequence (34)", typeof(Sprite)) as Sprite;
                    break;
                case 34:
                    temp.GetComponent<Image>().sprite = Resources.Load("Hit_Motion/Hit_Motion_PNG_Sequence (35)", typeof(Sprite)) as Sprite;
                    break;
                case 35:
                    temp.GetComponent<Image>().sprite = Resources.Load("Hit_Motion/Hit_Motion_PNG_Sequence (36)", typeof(Sprite)) as Sprite;
                    break;
                case 36:
                    temp.GetComponent<Image>().sprite = Resources.Load("Hit_Motion/Hit_Motion_PNG_Sequence (37)", typeof(Sprite)) as Sprite;
                    break;
                case 37:
                    temp.GetComponent<Image>().sprite = Resources.Load("Hit_Motion/Hit_Motion_PNG_Sequence (38)", typeof(Sprite)) as Sprite;
                    break;
                case 38:
                    temp.GetComponent<Image>().sprite = Resources.Load("Hit_Motion/Hit_Motion_PNG_Sequence (39)", typeof(Sprite)) as Sprite;
                    break;
                case 39:
                    temp.GetComponent<Image>().sprite = Resources.Load("Hit_Motion/Hit_Motion_PNG_Sequence (40)", typeof(Sprite)) as Sprite;
                    break;
                case 40:
                    temp.GetComponent<Image>().sprite = Resources.Load("Hit_Motion/Hit_Motion_PNG_Sequence (41)", typeof(Sprite)) as Sprite;
                    break;
                case 41:
                    temp.GetComponent<Image>().sprite = Resources.Load("Hit_Motion/Hit_Motion_PNG_Sequence (42)", typeof(Sprite)) as Sprite;
                    break;
                case 42:
                    temp.GetComponent<Image>().sprite = Resources.Load("Hit_Motion/Hit_Motion_PNG_Sequence (43)", typeof(Sprite)) as Sprite;
                    break;
                case 43:
                    temp.GetComponent<Image>().sprite = Resources.Load("Hit_Motion/Hit_Motion_PNG_Sequence (44)", typeof(Sprite)) as Sprite;
                    break;
                case 44:
                    temp.GetComponent<Image>().sprite = Resources.Load("Hit_Motion/Hit_Motion_PNG_Sequence (45)", typeof(Sprite)) as Sprite;
                    break;
                case 45:
                    temp.GetComponent<Image>().sprite = Resources.Load("Hit_Motion/Hit_Motion_PNG_Sequence (46)", typeof(Sprite)) as Sprite;
                    break;
                case 46:
                    temp.GetComponent<Image>().sprite = Resources.Load("Hit_Motion/Hit_Motion_PNG_Sequence (47)", typeof(Sprite)) as Sprite;
                    break;
                case 47:
                    temp.GetComponent<Image>().sprite = Resources.Load("Hit_Motion/Hit_Motion_PNG_Sequence (48)", typeof(Sprite)) as Sprite;
                    break;
                case 48:
                    temp.GetComponent<Image>().sprite = Resources.Load("Hit_Motion/Hit_Motion_PNG_Sequence (49)", typeof(Sprite)) as Sprite;
                    break;
                case 49:
                    temp.enabled = false;
                    IsLoad = false;
                    StopCoroutine(Image_Swith(0));
                    yield return null;
                    break;
            }
            i++;
            yield return new WaitForSeconds(0.1f);
        }
    }
}
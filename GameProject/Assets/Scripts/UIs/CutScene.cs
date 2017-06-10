using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
public class CutScene : MonoBehaviour {

    public Image Font_image;
    Color color;
    float a=0;
    void Start()
    {
        color = Font_image.color;
        color.a = a;
        StartCoroutine(alpha());
    }


    void Update()
    {

    }

    IEnumerator alpha()
    {
        while (true)
        {
            if (a != 1)
            {
                a += 0.01f;
                color.a = a;
                Font_image.color = color;
            }
            else
                StopCoroutine(alpha());
            yield return new WaitForSeconds(0.01f);
        }
    }
}

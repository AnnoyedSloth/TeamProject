using System.Collections;
using System.Collections.Generic;
using UnityEngine.UI;
using UnityEngine;

public class NumberUI
{

    private static NumberUI instance = null;
    public static NumberUI Instance
    {
        get
        {
            if (instance == null)
                instance = new NumberUI();

            return instance;
        }
    }
    private NumberUI()
    {

    }

    public void TUIUpdate(Image MTen, Image MOne, Image STen, Image SOne, int Init)
    {
        int MTemp = Init / 60;
        int STemp = Init % 60;

        if (MTen != null)
        {
            if (MTemp >= 10)
            {
                SetImage(MTen, MTemp / 10);
                MTemp = MTemp % 10;
            }
            else
                SetImage(MTen, 0);
        }

        if (MOne != null)
        {
            SetImage(MOne, MTemp);
        }
        if (STen != null)
        {
            if (STemp >= 10)
            {
                SetImage(STen, (STemp / 10));
                STemp = STemp % 10;
            }
            else
                SetImage(STen, 0);
        }
        SetImage(SOne, STemp);

    }

    public void MUIUpdate(Image hundredthousand, Image tenthousand, Image Thousand, Image Hundred, Image Ten, Image One, int Init)
    {
        int Temp = Init;
        if (hundredthousand != null)
        {
            MSetImage(hundredthousand, Init / 100000);
            Temp = Init % 100000;
        }

        if (tenthousand != null)
        {
            MSetImage(tenthousand, Temp / 10000);
            Temp = Init % 10000;
        }
        if (Thousand != null)
        {
            MSetImage(Thousand, Temp / 1000);
            Temp = Init % 1000;
        }

        if (Hundred != null)
        {
            MSetImage(Hundred, Temp / 100);
            Temp = Temp % 100;
        }
        if (Ten != null)
        {
            MSetImage(Ten, (Temp / 10));
            Temp = Temp % 10;
        }
        if (One != null)
        {
            MSetImage(One, Temp);
            Temp = Init;
        }
    }

    void MSetImage(Image Empty, int inum)
    {
        switch (inum)
        {
            case 1:
                Empty.GetComponent<Image>().sprite = Resources.Load("Gauge/Goal/1", typeof(Sprite)) as Sprite;
                break;
            case 2:
                Empty.GetComponent<Image>().sprite = Resources.Load("Gauge/Goal/2", typeof(Sprite)) as Sprite;
                break;
            case 3:
                Empty.GetComponent<Image>().sprite = Resources.Load("Gauge/Goal/3", typeof(Sprite)) as Sprite;
                break;
            case 4:
                Empty.GetComponent<Image>().sprite = Resources.Load("Gauge/Goal/4", typeof(Sprite)) as Sprite;
                break;
            case 5:
                Empty.GetComponent<Image>().sprite = Resources.Load("Gauge/Goal/5", typeof(Sprite)) as Sprite;
                break;
            case 6:
                Empty.GetComponent<Image>().sprite = Resources.Load("Gauge/Goal/6", typeof(Sprite)) as Sprite;
                break;
            case 7:
                Empty.GetComponent<Image>().sprite = Resources.Load("Gauge/Goal/7", typeof(Sprite)) as Sprite;
                break;
            case 8:
                Empty.GetComponent<Image>().sprite = Resources.Load("Gauge/Goal/8", typeof(Sprite)) as Sprite;
                break;
            case 9:
                Empty.GetComponent<Image>().sprite = Resources.Load("Gauge/Goal/9", typeof(Sprite)) as Sprite;
                break;
            case 0:
                Empty.GetComponent<Image>().sprite = Resources.Load("Gauge/Goal/0", typeof(Sprite)) as Sprite;
                break;
            default:
                Empty.GetComponent<Image>().sprite = Resources.Load("Gauge/Numbers/Number0", typeof(Sprite)) as Sprite;
                break;
        }
    }
    void SetImage(Image Empty, int inum)
    {
        switch (inum)
        {
            case 1:
                Empty.GetComponent<Image>().sprite = Resources.Load("Gauge/Numbers/Number1", typeof(Sprite)) as Sprite;
                break;
            case 2:
                Empty.GetComponent<Image>().sprite = Resources.Load("Gauge/Numbers/Number2", typeof(Sprite)) as Sprite;
                break;
            case 3:
                Empty.GetComponent<Image>().sprite = Resources.Load("Gauge/Numbers/Number3", typeof(Sprite)) as Sprite;
                break;
            case 4:
                Empty.GetComponent<Image>().sprite = Resources.Load("Gauge/Numbers/Number4", typeof(Sprite)) as Sprite;
                break;
            case 5:
                Empty.GetComponent<Image>().sprite = Resources.Load("Gauge/Numbers/Number5", typeof(Sprite)) as Sprite;
                break;
            case 6:
                Empty.GetComponent<Image>().sprite = Resources.Load("Gauge/Numbers/Number6", typeof(Sprite)) as Sprite;
                break;
            case 7:
                Empty.GetComponent<Image>().sprite = Resources.Load("Gauge/Numbers/Number7", typeof(Sprite)) as Sprite;
                break;
            case 8:
                Empty.GetComponent<Image>().sprite = Resources.Load("Gauge/Numbers/Number8", typeof(Sprite)) as Sprite;
                break;
            case 9:
                Empty.GetComponent<Image>().sprite = Resources.Load("Gauge/Numbers/Number9", typeof(Sprite)) as Sprite;
                break;
            case 0:
                Empty.GetComponent<Image>().sprite = Resources.Load("Gauge/Numbers/Number0", typeof(Sprite)) as Sprite;
                break;
            default:
                Empty.GetComponent<Image>().sprite = Resources.Load("Gauge/Numbers/Number0", typeof(Sprite)) as Sprite;
                break;
        }
    }
}


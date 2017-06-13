using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SResource
{
    public int TIME;
    public int Nmoney;
    public bool IsFali=true;

    public int Pmoney = 200000;

    private static SResource instance = null;
    public static SResource Instance
    {
        get
        {
            if (instance == null)
                instance = new SResource();

            return instance;
        }
    }
    private SResource()
    {

    }
}

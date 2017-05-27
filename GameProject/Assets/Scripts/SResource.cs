using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SResource
{
    public int TIME;
    public int Nmoney;


    public int Pmoney;

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

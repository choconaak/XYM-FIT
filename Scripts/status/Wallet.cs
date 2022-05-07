using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Wallet 
{
    static float XFP ;
    static int XFT;

    public static float GSXFP
    {
        get { return XFP; }
        set { XFP = value; }
    }

    public static int GSXFT
    {
        get { return XFT; }
        set { XFT = value; }
    }
}

using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class money : MonoBehaviour
{
    public Text XFP,XFT;

    // Update is called once per frame
    void Update()
    {
        XFP.text = ":" +Wallet.GSXFP.ToString("f2");
        XFT.text = ":" +Wallet.GSXFT.ToString("f0");
    }
}

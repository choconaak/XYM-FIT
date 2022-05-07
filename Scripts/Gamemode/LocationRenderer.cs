using UnityEngine;
using UnityEngine.UI;
using System;


public class LocationRenderer : MonoBehaviour
{
    public LocationUpdater updater;
    public Gamemanager GM;
    public Text text1,text2,text3,text4,text5,text6;
    string onoff;

    void Update()
    {
        if (GM.GetSwitch() == false)
        {
            onoff = "OFF";
        }
        else
        {
            onoff = "ON";
        }

        text1.text = onoff
                  + "\n" + updater.Status.ToString()
                  + "\n" + updater.GetdistanceAll().ToString("F2") + "km";

        text2.text = updater.GetSpeed60().ToString("F1") + "km/h";
        text3.text = GM.Gethour().ToString("F0") + ":" + GM.Getmin().ToString("00");
        text4.text = "Energy:" + GM.GetEnergy().ToString("F1");
        text5.text = "XFP:" + GM.GetXFP().ToString()
                    +"\n" + "XFT:"+GM.GetXFT().ToString("F0");
        text6.text = "ShoesHP:" + Shoesbox.GetShoesnow().GSRES.ToString("F0");
    }
}

using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class slider_XFP : MonoBehaviour
{
    Slider EnSlider;
    int Lv;
    int CapXFP;
    float XFP;


    Lv_chart_walk Lv_w = new Lv_chart_walk();
    Lv_chart_jog Lv_j = new Lv_chart_jog();
    public Text XFPtext;

    // Start is called before the first frame update
    void Start()
    {
        Lv = Shoesbox.GetShoesnow().GSLV;

        switch (Shoesbox.GetShoesnow().GSElement)
        {
            case Shoes.Elementenum.walk:
                if(Lv == 30)
                {
                    CapXFP = Lv_w.GetXFP_LF(Lv-1);
                }
                else
                {
                    CapXFP = Lv_w.GetXFP_LF(Lv);
                }
                
                if(Lv == 1)
                {
                    XFP = 0;
                }
                else
                {
                    XFP = Lv_w.GetXFP_LF(Lv - 1);
                }
                break;
            case Shoes.Elementenum.jog:
                if(Lv == 30)
                {
                    CapXFP = Lv_j.GetXFP_LF(Lv-1);
                }
                else
                {
                    CapXFP = Lv_j.GetXFP_LF(Lv);
                }
                
                if (Lv == 1)
                {
                    XFP = 0;
                }
                else
                {
                    XFP = Lv_j.GetXFP_LF(Lv - 1);
                }
                break;
        }

        EnSlider = GetComponent<Slider>();

        EnSlider.maxValue = CapXFP;
        XFP = (float)Wallet.GSXFP;
    }

    // Update is called once per frame
    void Update()
    {
        EnSlider.value = XFP;
        if(Lv == 30)
        {
            XFPtext.text ="Level MAX";
        }
        else
        {
            XFPtext.text = XFP.ToString("f2") + "/" + CapXFP.ToString("f0");
        }
        
        
    }
}


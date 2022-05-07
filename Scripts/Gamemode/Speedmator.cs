using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class Speedmator : MonoBehaviour
{
    public LocationUpdater LocationUpdater;
    public Image UIobj;
    double speed;
    int matorMAX;

    Lv_chart_walk Lv_w = new Lv_chart_walk();
    Lv_chart_jog Lv_j = new Lv_chart_jog();

    // Update is called once per frame
    void Update()
    {
        speed = LocationUpdater.GetSpeed60();
        //walk,jog,runでここもメーターの最大速度はlist化しておく
        
        switch (Shoesbox.GetShoesnow().GSElement)
        {
            case Shoes.Elementenum.walk:
                matorMAX = Lv_w.GetMatorMax();
                break;
            case Shoes.Elementenum.jog:
                matorMAX = Lv_j.GetMatorMax();
                break;

        }
                UIobj.fillAmount = (float)speed/matorMAX;
    }
}

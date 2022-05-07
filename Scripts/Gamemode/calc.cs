using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using System;
using UniRandom = UnityEngine.Random;

public class calc : MonoBehaviour
{
    double point;
    int XFT;

    int average;
    double stdv;

    Lv_chart LV = new Lv_chart();
    Lv_chart_walk Lv_w = new Lv_chart_walk();
    Lv_chart_jog Lv_j = new Lv_chart_jog();

    public float calcpoint(double speed,int REG, int REGLV)
    {
        switch(Shoesbox.GetShoesnow().GSElement)
        {
            case Shoes.Elementenum.walk:
                average = Lv_w.Getave();
                stdv = Lv_w.Getstdv(speed);
                point = NORMDIST(average, stdv, speed) / NORMDIST(4, 2, 4) * 0.96 * 1.05 / 4 * speed * LV.GetEFF(Shoesbox.GetShoesnow().GSEFFLV) * calcREG(REG, REGLV);
                //小数点以下2桁以下は丸め
                point = Math.Round(point, 2, MidpointRounding.AwayFromZero);

                break;
            case Shoes.Elementenum.jog:
                average = Lv_j.Getave();
                stdv = Lv_j.Getstdv(speed);
                point = NORMDIST(average, stdv, speed) / NORMDIST(4, 2, 4) * 0.96 * 1.05 / 4 * speed * LV.GetEFF(Shoesbox.GetShoesnow().GSEFFLV) * calcREG(REG, REGLV);
                //小数点以下2桁以下は丸め
                point = Math.Round(point, 2, MidpointRounding.AwayFromZero);
                break;
        }
        Debug.Log(point);
        return (float)point;
    }
    double calcREG(int REG, int REGLV)
    {

        double cor_REG = 1 / (0.1 / REGLV * Math.Exp((20 - REG) - (7 + REGLV/4)) + 1);
        cor_REG = Math.Round(cor_REG, 2, MidpointRounding.AwayFromZero);
        return cor_REG;
    }

    public int calcXFT()
    {
        //random.rangeの分母はレベルから参照
        int num = LV.GetLUC(Shoesbox.GetShoesnow().GSLUCLV);

        int rand = UniRandom.Range(0, num);

        //レベル1では1分当たり1/2500の確率で手に入る
        if(rand/(num-1) >= 1)
        {
            XFT = 20;
        }
        else
        {
            XFT = 0;
        }
        return XFT;
    }



    //正規分布
    double NORMDIST(double ave, double stdv, double x)
    {
        Double Dist = 1 / Math.Sqrt(2 * Math.PI * stdv * stdv) * Math.Exp(-1 * (x - ave) * (x - ave)/ (2 * stdv * stdv));
        
        return Dist;
    }

}

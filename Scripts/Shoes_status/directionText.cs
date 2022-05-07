using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class directionText : MonoBehaviour
{
    int num = 0;
    int point;
    double xfpnow;
    
    public Image direction;
    public Text directiontext;

    Lv_chart_walk Lv_w = new Lv_chart_walk();
    Lv_chart_jog Lv_j = new Lv_chart_jog();

    public void repairtext()
    {
        xfpnow = Wallet.GSXFP;
        switch (Gamemanager_Shoesstatus.GSShoesnum.GSElement)
        {
            case Shoes.Elementenum.walk:
                point = Lv_w.GetMEN(Gamemanager_Shoesstatus.GSShoesnum.GSMENLV);
                break;
            case Shoes.Elementenum.jog:
                point = Lv_j.GetMEN(Gamemanager_Shoesstatus.GSShoesnum.GSMENLV);
                break;
        }
        double after = xfpnow - point;
        direction.gameObject.SetActive(true);
        
        if (after >= 0)
            //足りてる
        {
            num = 2;
            directiontext.text = "YOU NEED" + point.ToString("F0") + "XFP"
                                + "\n" + "FOR REPAIR."
                                + "\n" + "\n" + "YOU HAVE" + xfpnow.ToString("F2") + "XFP"
                                + "\n" + "NOW."
                                + "\n" + "\n" + "XFP->" + after.ToString("F2") + "XFP";
        }
        else
            //不足
        {
            num = 0;
            directiontext.text = "YOU NEED" + point.ToString("F0") + "XFP"
                                + "\n" + "FOR REPAIR."
                                + "\n" + "\n" + "BUT YOU HAVE"
                                + "\n" + xfpnow.ToString("F2") + "XFP NOW."
                                +"\n" + "\n" + "LACKING " + (-1 * after).ToString("F2") + "XFP";
        }
        
    }

    public void Lvuptext()
    {
        xfpnow = Wallet.GSXFP;
        switch (Gamemanager_Shoesstatus.GSShoesnum.GSElement)
        {
            case Shoes.Elementenum.walk:
                point = Lv_w.GetXFP_LF(Gamemanager_Shoesstatus.GSShoesnum.GSLV);
                break;
            case Shoes.Elementenum.jog:
                point = Lv_j.GetXFP_LF(Gamemanager_Shoesstatus.GSShoesnum.GSLV);
                break;
        }
        double after = xfpnow - point;
        direction.gameObject.SetActive(true);
        if(Gamemanager_Shoesstatus.GSShoesnum.GSLV < 20)
        {
            if (after >= 0)
            //足りてる
            {
                num = 1;
                directiontext.text = "YOU NEED" + point.ToString("F0") + "XFP"
                                    + "\n" + "FOR LEVEL UP."
                                    + "\n" + "\n" + "YOU HAVE" + xfpnow.ToString("F2") + "XFP"
                                    + "\n" + "NOW."
                                    + "\n" + "\n" + "XFP->" + after.ToString("F2") + "XFP";
            }
            else
            //不足
            {
                num = 0;
                directiontext.text = "YOU NEED" + point.ToString("F0") + "XFP"
                                    + "\n" + "FOR LEVEL UP."
                                    + "\n" + "\n" + "BUT YOU HAVE"
                                    + "\n" + xfpnow.ToString("F2") + "XFP NOW."
                                    + "\n" + "\n" + "LACKING " + (-1 * after).ToString("F2") + "XFP";
            }
        }
        else
        //レベルMAXのとき
        {
            num = 0;
            directiontext.text = "THIS SHOES IS"
                                    + "\n" + "STRONG ENOUGH "
                                    +"\n" + "THAT YOU CAN'T"
                                    + "\n" + "LEVEL UP.";
        }
    }

    public void useXFP()
    {
        switch (num)
        {
            //足りてないもしくはレベルMAX
            case 0:
                direction.gameObject.SetActive(false);
                break;
            //レベルアップ
            case 1:
                Gamemanager_Shoesstatus.GSShoesnum.GSpoint= Gamemanager_Shoesstatus.GSShoesnum.GSpoint+1;
                Wallet.GSXFP = Wallet.GSXFP - point;
                direction.gameObject.SetActive(false);
                break;
            //補修
            case 2:
                Gamemanager_Shoesstatus.GSShoesnum.GSRES = 20;
                Wallet.GSXFP = Wallet.GSXFP - point;
                direction.gameObject.SetActive(false);
                break;

        }
    }

}

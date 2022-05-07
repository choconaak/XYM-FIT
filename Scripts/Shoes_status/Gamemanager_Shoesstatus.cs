using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.SceneManagement;

public class Gamemanager_Shoesstatus : MonoBehaviour
{
    
    static Shoes Shoesnum = new Shoes();
    public Text Shoesnumtext;
    public Text Status;
    public Text Rareitytext;
    public static Shoes GSShoesnum
    {
        get { return Shoesnum; }
        set { Shoesnum = value; }
    }


    private void Update()
    {
        int num = Shoesbox.GetShoescase().IndexOf(Shoesnum);
        
         num = num + 1;
         Shoesnumtext.text = "Shoes" + num.ToString("0");
         Rareitytext.text = Shoesnum.GSRareity.ToString();
        switch (Shoesnum.GSElement)
        {
            case Shoes.Elementenum.walk:
                Status.text = "For Walking" + "\n" + "2Å`6 km/h";
                break;
            case Shoes.Elementenum.jog:
                Status.text = "For Jogging" + "\n" + "4Å`10 km/h";
                break;
            default:
                Status.text = "No shoes";
                break;
        }

    }

    public void Back()
    {
        SceneManager.LoadScene("Shoes");
    }
}

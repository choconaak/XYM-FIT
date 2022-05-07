using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class Shoesname : MonoBehaviour
{

    int num;
    public Text Shoesnowtext;
    // Update is called once per frame
    void Update()
    {
        num = Shoesbox.GetShoescase().IndexOf(Shoesbox.GetShoesnow());

        if (num == -1)
        {
            Shoesnowtext.text = "No Shoes";
        }
        else
        {
            num = num + 1;
            Shoesnowtext.text = "Shoes" + num.ToString("0");
        }
    }
}

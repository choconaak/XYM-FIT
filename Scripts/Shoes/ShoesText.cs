using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class ShoesText : MonoBehaviour
{
    public ShoesButton SB;
    public Text Shoesnum;
    

    // Update is called once per frame
    void Update()
    {
        Shoesnum.text = "Shoes" + SB.GSnum.ToString("0");
    }
}

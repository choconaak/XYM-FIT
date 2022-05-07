using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class Slider_REGnum : MonoBehaviour
{
    Slider EnSlider;
    float RES;


    public Text REStext;

    // Start is called before the first frame update
    void Start()
    {
        EnSlider = GetComponent<Slider>();

        EnSlider.maxValue = 20;
        
    }

    void Update()
    {
        RES = Gamemanager_Shoesstatus.GSShoesnum.GSRES;
        EnSlider.value = RES;
        REStext.text = RES.ToString("0") + "/20";
    }
}

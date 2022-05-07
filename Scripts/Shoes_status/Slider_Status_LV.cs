using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
public class Slider_Status_LV : MonoBehaviour
{
    public Slider EnSlider_REGLV, EnSlider_MENLV, EnSlider_LUCLV, EnSlider_EFFLV;
    float RESLV,MENLV,LUCLV,EFFLV;
    public Gamemanager_Shoesstatus GM_SS;


    public Text REGLVtext, MENLVtext, LUCLVtext, EFFLVtext;

    // Start is called before the first frame update
    void Start()
    {

        EnSlider_REGLV.maxValue = 20;
        EnSlider_MENLV.maxValue = 20;
        EnSlider_LUCLV.maxValue = 20;
        EnSlider_EFFLV.maxValue = 20;

    }

    void Update()
    {
        RESLV = Gamemanager_Shoesstatus.GSShoesnum.GSRESLV;
        MENLV = Gamemanager_Shoesstatus.GSShoesnum.GSMENLV;
        LUCLV = Gamemanager_Shoesstatus.GSShoesnum.GSLUCLV;
        EFFLV = Gamemanager_Shoesstatus.GSShoesnum.GSEFFLV;
        EnSlider_REGLV.value = RESLV;
        EnSlider_MENLV.value = MENLV;
        EnSlider_LUCLV.value = LUCLV;
        EnSlider_EFFLV.value = EFFLV;


        REGLVtext.text = RESLV.ToString("0") + "/20";
        MENLVtext.text = MENLV.ToString("0") + "/20";
        LUCLVtext.text = LUCLV.ToString("0") + "/20";
        EFFLVtext.text = EFFLV.ToString("0") + "/20";
    }
}


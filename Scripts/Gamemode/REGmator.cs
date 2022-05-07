using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;


public class REGmator : MonoBehaviour
{
    public Gamemanager GM;
    Slider EnSlider;
    float  RES;

    // Start is called before the first frame update
    void Start()
    {
        EnSlider = GetComponent<Slider>();

        
        EnSlider.maxValue =20;
    }

    // Update is called once per frame
    void Update()
    {
        RES = Shoesbox.GetShoesnow().GSRES;
        EnSlider.value = RES;
    }
}

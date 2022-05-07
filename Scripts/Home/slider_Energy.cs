using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class slider_Energy : MonoBehaviour
{
    Slider EnSlider;
    float MaxEnergy, Energy;

    public Text EnMEn;

    // Start is called before the first frame update
    void Start()
    {
        EnSlider = GetComponent<Slider>();

        MaxEnergy = Gamemanager_home.GetMEnergy();
        EnSlider.maxValue = MaxEnergy;
        Energy = Gamemanager_home.GSEnergy;
    }

    void Update()
    {
        EnSlider.value = Energy;
        EnMEn.text = Energy.ToString("F1") + "/" + MaxEnergy.ToString("0");
    }
}

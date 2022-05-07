using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class Energymator : MonoBehaviour
{
    public Gamemanager GM;
    Slider EnSlider;
    float MaxEnergy, Energy;

    // Start is called before the first frame update
    void Start()
    {
        EnSlider = GetComponent<Slider>();

        MaxEnergy = GM.GetMEnergy();
        EnSlider.maxValue = MaxEnergy;
    }

    // Update is called once per frame
    void Update()
    {
        Energy = GM.GetEnergy();
        EnSlider.value = Energy;
    }
}

using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class changeimage : MonoBehaviour
{
    Image MainImage;

    bool ONOFF;
    public Gamemanager GM;
    public Sprite on, off;

    void Start()
    {
        // ‚±‚Ìobject‚ÌImage‚ðŽæ“¾
        MainImage = gameObject.GetComponent<Image>();
    }
    // Update is called once per frame
    void Update()
    {
        ONOFF = GM.GetSwitch();

        if (ONOFF == true)
        {
            MainImage.sprite = on;
        }
        else
        {
            MainImage.sprite = off;
        }
    }
}

using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class ERROR : MonoBehaviour
{
    public Button Endbutton;
    public Image ERRORtext;
    // Start is called before the first frame update
    public void OK()
    {
        Endbutton.gameObject.SetActive(false);
        ERRORtext.gameObject.SetActive(false);
    }
}

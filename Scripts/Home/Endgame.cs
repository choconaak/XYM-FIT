using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class Endgame : MonoBehaviour
{
    public Image direction;
    public Text endtext;
    public Button gameender;
    public Text nobuttontext;
    public void endgamedirection()
    {
        direction.gameObject.SetActive(true);
        gameender.gameObject.SetActive(true);
        endtext.text = "End Game ?";
        nobuttontext.text = "NO";
    }

    public void endgame()
    {
    #if UNITY_EDITOR
        UnityEditor.EditorApplication.isPlaying = false;
    #else
		Application.Quit();
    #endif
    }
}

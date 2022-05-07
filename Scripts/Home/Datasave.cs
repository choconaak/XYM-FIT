using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Datasave : MonoBehaviour
{
    // Start is called before the first frame update
    void Start()
    {
        save();
        
    }

    void save()
    {
        PlayerPrefs.SetFloat("XFP", Wallet.GSXFP);
        PlayerPrefs.SetInt("XFT", Wallet.GSXFT);
        PlayerPrefs.SetFloat("Energy", Gamemanager_home.GSEnergy);
        PlayerPrefs.SetInt("Shoes", Shoesbox.GetShoescase().Count);
        for(int i = 0; i <Shoesbox.GetShoescase().Count; i++)
        {
            PlayerPrefs.SetInt("LV"+i, Shoesbox.GetShoescase()[i].GSLV);
            PlayerPrefs.SetInt("REGLV" + i, Shoesbox.GetShoescase()[i].GSRESLV);
            PlayerPrefs.SetInt("MENLV" + i, Shoesbox.GetShoescase()[i].GSMENLV);
            PlayerPrefs.SetInt("LUCLV" + i, Shoesbox.GetShoescase()[i].GSLUCLV);
            PlayerPrefs.SetInt("EFFLV" + i, Shoesbox.GetShoescase()[i].GSEFFLV);
            PlayerPrefs.SetInt("RES" + i, Shoesbox.GetShoescase()[i].GSRES);
            PlayerPrefs.SetInt("point" + i, Shoesbox.GetShoescase()[i].GSpoint);
            PlayerPrefs.SetString("Element" + i, Shoesbox.GetShoescase()[i].GSElement.ToString());
            PlayerPrefs.SetString("Rareity" + i, Shoesbox.GetShoescase()[i].GSRareity.ToString());
        }

        PlayerPrefs.Save();
    }
    
}

using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class LoadStatus : MonoBehaviour
{
    // Start is called before the first frame update
    void Start()
    {
        Load();  
    }

    private void Load()
    {
        Wallet.GSXFP = PlayerPrefs.GetFloat("XFP");
        Wallet.GSXFT = PlayerPrefs.GetInt("XFT");
        Gamemanager_home.GSEnergy = PlayerPrefs.GetFloat("Energy", 12);
        int num = PlayerPrefs.GetInt("Shoes");
            for (int i = 0; i < num; i++)
            {
                Shoes Shoes = new Shoes();
                Shoes.GSLV = PlayerPrefs.GetInt("LV" + i);
                Shoes.GSRESLV = PlayerPrefs.GetInt("REGLV" + i);
                Shoes.GSMENLV = PlayerPrefs.GetInt("MENLV" + i);
                Shoes.GSLUCLV = PlayerPrefs.GetInt("LUCLV" + i);
                Shoes.GSEFFLV = PlayerPrefs.GetInt("EFFLV" + i);
                Shoes.GSRES = PlayerPrefs.GetInt("RES" + i);
                Shoes.GSpoint = PlayerPrefs.GetInt("point" + i);
                Shoes.GSElement = (Shoes.Elementenum)System.Enum.Parse(typeof(Shoes.Elementenum), PlayerPrefs.GetString("Element" + i));
                Shoes.GSRareity = (Shoes.Rareityenum)System.Enum.Parse(typeof(Shoes.Rareityenum), PlayerPrefs.GetString("Rareity" + i));
                Shoesbox.GetShoescase().Add(Shoes);
            }
    }
}

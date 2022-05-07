using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Gamemanager_home : MonoBehaviour
{
    public static float MaxEnergy =12f;
    static float Energy = 12f;
    static int Energyspan;


    //Energy‚Ì‰ñ•œ(gamemode‚Å‚àŽÀŽ{)
    private void Update()
    {
        if (Energy < MaxEnergy)
        {
            Energyspan++;
            //24ŽžŠÔ‚ÅMax‚Ü‚Å‰ñ•œi‚È‚Ì‚Å2/5ŽžŠÔ=2*60*60*20F‚Å0.2‰ñ•œj
            if (Energyspan == 86400)
            {
                Energyspan = 0;
                GSEnergy += 0.2f;
            }
        }
        
    }

    public static float GetMEnergy()
    {
        return MaxEnergy;
    }


    public static float GSEnergy
    {
        get { return Energy; }
        set { Energy = value; }
    }

    public static int GSEnergyspan
    {
        get { return Energyspan; }
        set { Energyspan = value; }
    }

}

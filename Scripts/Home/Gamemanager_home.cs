using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Gamemanager_home : MonoBehaviour
{
    public static float MaxEnergy =12f;
    static float Energy = 12f;
    static int Energyspan;


    //Energyの回復(gamemodeでも実施)
    private void Update()
    {
        if (Energy < MaxEnergy)
        {
            Energyspan++;
            //24時間でMaxまで回復（なので2/5時間=2*60*60*20Fで0.2回復）
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

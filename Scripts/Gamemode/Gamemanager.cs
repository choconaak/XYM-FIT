using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class Gamemanager : MonoBehaviour
{
    bool Switch;
    int timelog,min,hour;
    int waitsec = 1;
    double speed;

    float MaxEnergy;
    float Energy;

    float XFP;
    int XFT;

    int RES;
    int RESLV;

    int Energyspan;

    public Button End;

    public calc calc;
    public LocationUpdater updater;

    void Start()
    {
        
        MaxEnergy = Gamemanager_home.GetMEnergy();
        RES = Shoesbox.GetShoesnow().GSRES;
        RESLV = Shoesbox.GetShoesnow().GSRESLV;
        Energy = Gamemanager_home.GSEnergy;
        Switch = false;
        Energyspan = Gamemanager_home.GSEnergyspan;
        StartCoroutine("CheckTime");
        StartCoroutine("CheckEnergy");
        StartCoroutine("Point");
    }

    void Update()
    {
        speed = updater.GetSpeed60();
        if(Energy <= 0)
        {
            Switch = false;
        }

        if(Switch == false)
        {
            End.gameObject.SetActive(true);
        }
        else
        {
            End.gameObject.SetActive(false);
        }
        //Energyの回復
        if (Energy < MaxEnergy)
        {
            Energyspan++;
            //24時間でMaxまで回復（なので2/5時間=2*60*60*20Fで0.1回復）
            if (Energyspan == 86400)
            {
                Energyspan = 0;
                Gamemanager_home.GSEnergy += 0.1f;
            }
            Gamemanager_home.GSEnergyspan = Energyspan;
        }



        Gamemanager_home.GSEnergy = Energy;
    }
    public void ONOFF()
    {
        if(Energy > 0)
        {
            Switch = !Switch;
        }
        
    }

    public bool GetSwitch()
    {
        return Switch;
    }

    //累計秒を返す
    public int GetTime()
    {
        return timelog;
    }

    //分を返す
    public int Getmin()
    {
        return min;
    }
    //時を返す
    public int Gethour()
    {
        return hour;
    }

    public float GetMEnergy()
    {
        return MaxEnergy;
    }
    public float GetEnergy()
    {
        return Energy;
    }

    public float GetXFP()
    {
        return XFP;
    }

    public int GetXFT()
    {
        return XFT;
    }

    //秒針
    IEnumerator CheckTime()
    {
        while (true)
        {
            if (Switch == true)
            {
                timelog += 1;
            }
            else
            {
                timelog = 0;
            }
            if (min != 0 && min % 60 == 0)
            {
                hour = hour + 1;
                min = 0;
            }
            if (timelog != 0 && timelog % 60 == 0 && min !=60)
            {
                min = min + 1;
            }
            yield return new WaitForSeconds(waitsec);
        }
    }

    IEnumerator CheckEnergy()
    {
        while (Energy > 0)
        {
                if (timelog != 0 && timelog % 60 == 0)
                {
                    Energy = Energy - 0.2f;
                }
            yield return new WaitForSeconds(waitsec);
        }
        
    }

    IEnumerator Point()
    {
        while (true)
        {
            //60秒ごとに歩行ポイント（XFP）付与、ボーナスポイント（XFT）抽選
            //ここ同期しないので何とかならないか
            yield return new WaitForSeconds(60);
            XFP += calc.calcpoint(speed, RES,RESLV);
            XFT += calc.calcXFT();
        }
        
    }
}

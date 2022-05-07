using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class statusLVup : MonoBehaviour
{

    public Button Button_REG, Button_MEN, Button_LUC, Button_EFF;
    // Start is called before the first frame update
    void Update()
    {
        if(Gamemanager_Shoesstatus.GSShoesnum.GSpoint > 0)
        {
            Button_REG.gameObject.SetActive(true);
            Button_MEN.gameObject.SetActive(true);
            Button_LUC.gameObject.SetActive(true);
            Button_EFF.gameObject.SetActive(true);
        }

        if (Gamemanager_Shoesstatus.GSShoesnum.GSpoint <= 0)
        {
            Button_REG.gameObject.SetActive(false);
            Button_MEN.gameObject.SetActive(false);
            Button_LUC.gameObject.SetActive(false);
            Button_EFF.gameObject.SetActive(false);
        }

        if (Gamemanager_Shoesstatus.GSShoesnum.GSRESLV >= 20)
        {
            Button_REG.gameObject.SetActive(false);
        }

        if (Gamemanager_Shoesstatus.GSShoesnum.GSMENLV >= 20)
        {
            Button_MEN.gameObject.SetActive(false);
        }

        if (Gamemanager_Shoesstatus.GSShoesnum.GSLUCLV >= 20)
        {
            Button_LUC.gameObject.SetActive(false);
        }
        if (Gamemanager_Shoesstatus.GSShoesnum.GSEFFLV >= 20)
        {
            Button_EFF.gameObject.SetActive(false);
        }
    }

    // Update is called once per frame
    public void LVup_REG()
    {
        Gamemanager_Shoesstatus.GSShoesnum.GSpoint = Gamemanager_Shoesstatus.GSShoesnum.GSpoint - 1;
        Gamemanager_Shoesstatus.GSShoesnum.GSRESLV +=  1;
    }

    public void LVup_MEN()
    {
        Gamemanager_Shoesstatus.GSShoesnum.GSpoint = Gamemanager_Shoesstatus.GSShoesnum.GSpoint - 1;
        Gamemanager_Shoesstatus.GSShoesnum.GSMENLV +=  1;
    }

    public void LVup_LUC()
    {
        Gamemanager_Shoesstatus.GSShoesnum.GSpoint = Gamemanager_Shoesstatus.GSShoesnum.GSpoint - 1;
        Gamemanager_Shoesstatus.GSShoesnum.GSLUCLV += 1;
    }

    public void LVup_EFF()
    {
        Gamemanager_Shoesstatus.GSShoesnum.GSpoint = Gamemanager_Shoesstatus.GSShoesnum.GSpoint - 1;
        Gamemanager_Shoesstatus.GSShoesnum.GSEFFLV += 1;
    }
}

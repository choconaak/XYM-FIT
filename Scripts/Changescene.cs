using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.SceneManagement;

public class Changescene : MonoBehaviour
{
    

    bool Flag_iv;
    float interval;
    int REG;
    float XFP;
    int XFT;
    public Gamemanager GM;

    public Image ERRORdirection;
    public Text Errortext;
    public Text Buttontext;

    //maingame側
    void Update()
    {
        //ボタンを押している間はカウントして所定の時間を超えたらシーンチェンジ
        if (Flag_iv == true)
        {
            interval += Time.deltaTime;
        }
        else
        {
            interval = 0;
        }
        if (interval >= 2)
        {
            REG = Shoesbox.GetShoesnow().GSRES - 1;
            XFP = Wallet.GSXFP + GM.GetXFP();
            Wallet.GSXFP = XFP;
            XFT = Wallet.GSXFT + GM.GetXFT();
            Wallet.GSXFT = XFT;
            Shoesbox.GetShoesnow().GSRES=REG;
            SceneManager.LoadScene("Home");
        }

    }

    public void EndGame()
    {
        Flag_iv = true;
    }

    //ボタンを戻したときに実行
    public void Stop()
    {
        Flag_iv = false;
    }



    //Home側
    public void StartGame()
    {
        int num = Shoesbox.GetShoescase().IndexOf(Shoesbox.GetShoesnow());

        if (num == -1)
        {
            ERRORdirection.gameObject.SetActive(true);
            Errortext.text = "ERROR"
                              + "\n" 
                              + "\n" + "THERE IS NO"
                              + "\n" + "SHOES."
                              + "\n"
                              + "\n" + "CHECK SHOES"
                              + "\n" + "AND"
                              + "\n" + "SET SHOES.";
            Buttontext.text = "OK";
        }
        else
        {
            SceneManager.LoadScene("Gamemode");
        }
  
    }

    public void ChangeWallet()
    {
        SceneManager.LoadScene("Wallet");
    }

    public void ChangeShoes()
    {
        SceneManager.LoadScene("Shoes");
    }


    //Walletら側
    public void Home()
    {
        SceneManager.LoadScene("Home");
    }

}

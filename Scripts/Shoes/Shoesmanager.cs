using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class Shoesmanager : MonoBehaviour
{

    int num;


    public GameObject Content;
    public GameObject ButtonPrefab;

    ShoesButton ShoesButton;

    public Text Shoesnowtext;

    private void Start()
    {
        Content = GameObject.Find("Content");

        for (int i = 0; i < Shoesbox.GetShoescase().Count; i++)
        {
            ButtonPrefab = (GameObject)Instantiate(ButtonPrefab);
            ButtonPrefab.transform.SetParent(Content.transform, false);
            ShoesButton = ButtonPrefab.GetComponent<ShoesButton>();
            ShoesButton.GSnum = i + 1;
        }
    }

    private void Update()
    {
        num = Shoesbox.GetShoescase().IndexOf(Shoesbox.GetShoesnow());

        if(num == -1)
        {
            Shoesnowtext.text = "No Shoes";
        }
        else
        {
            num = num + 1;
            Shoesnowtext.text = "Shoes(Now:Shoes" + num.ToString("0") + ")";
        }
        

    }

    //Make Shoesボタンを押すと靴が作られる
    public void MakeShoes()
    {
        Shoes Shoes = new Shoes();
        Setstatus(Shoes);
        Shoesbox.AddShoescase(Shoes);

        ButtonPrefab = (GameObject)Instantiate(ButtonPrefab);
        ButtonPrefab.transform.SetParent(Content.transform, false);
        ShoesButton = ButtonPrefab.GetComponent<ShoesButton>();
        ShoesButton.GSnum = Shoesbox.GetShoescase().Count;
    }

    //初期ステータス設定
    void Setstatus(Shoes Shoes)
    {
        //walkかjogかrunか(選択制にするかランダムにするかは要調整)
        int randel = Random.Range(0, 100);
        int randrare = Random.Range(0, 100);
        //60%でwalk、40%でjog
        if (randel < 60)
        {
            Shoes.GSElement = Shoes.Elementenum.walk;
        }
        else
        {
            Shoes.GSElement = Shoes.Elementenum.jog;
        }

        //60%でコモン、35%でアンコモン、5%でレア

        if(randrare < 60)
        {
            Shoes.GSRareity = Shoes.Rareityenum.common;
        }
        else if(randrare > 60 && randrare < 94)
        {
            Shoes.GSRareity = Shoes.Rareityenum.uncommon;
            Shoes.GSpoint += 5;
        }
        else
        {
            Shoes.GSRareity = Shoes.Rareityenum.rare;
            Shoes.GSpoint += 10;
        }

        //10ポイント分
        for (int i =0; i<10; i++)
        {
            //0~99まで抽選で、割り振る
            int rand = Random.Range(0, 100);

            if(rand %4 == 0)
            {
                Shoes.GSRESLV = Shoes.GSRESLV + 1;
            }
            if (rand % 4 == 1)
            {
                Shoes.GSMENLV = Shoes.GSMENLV + 1;
            }
            if (rand % 4 == 2)
            {
                Shoes.GSLUCLV = Shoes.GSLUCLV + 1;
            }
            if (rand % 4 == 3)
            {
                Shoes.GSEFFLV = Shoes.GSEFFLV + 1;
            }
        }
    }
}

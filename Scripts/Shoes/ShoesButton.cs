using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class ShoesButton : MonoBehaviour
{
    int num;


    public void ChangeShoes()
    {
        Shoesbox.ChangeShoes(num);
    }

    public int GSnum
    {
        get 
        { return num; }
        set
        { num = value; }
    }
}

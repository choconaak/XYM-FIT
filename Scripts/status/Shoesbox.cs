using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Shoesbox
{
    static List<Shoes> Shoescase = new List<Shoes>();
    static Shoes Shoesnow = new Shoes();


    public static List<Shoes> GetShoescase()
    {
        return Shoescase;
    }

    public static Shoes GetShoesnow()
    {
        return Shoesnow;
    }

    //ŒC’Ç‰Á
    public static void AddShoescase(Shoes Shoes)
    {
        Shoescase.Add(Shoes);
    }


    //ŒC‘Ö‚¦
    public static void ChangeShoes(int num)
    {
        Shoesnow = Shoescase[num - 1];
    }

    public static int GSLV_now
    {
        get
        { return Shoesnow.GSLV; }
        set
        { Shoesnow.GSLV = value; }
    }
    public int GSRESLV_now
    {
        get
        { return Shoesnow.GSRESLV; }
        set
        { Shoesnow.GSRESLV = value; }
    }
    public int GSLUCLV_now
    {
        get
        { return Shoesnow.GSLUCLV; }
        set
        { Shoesnow.GSLUCLV = value; }
    }
    public int GSMENLV_now
    {
        get
        { return Shoesnow.GSMENLV; }
        set
        { Shoesnow.GSMENLV = value; }
    }

    public int GSRES_now
    {
        get
        { return Shoesnow.GSRES; }
        set
        { Shoesnow.GSRES = value; }
    }

}

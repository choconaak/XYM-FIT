using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Shoes { 
    
    //属性
    public enum Elementenum
    {
        walk,
        jog,
    }

    Elementenum Element;

    //レアリティ
    public enum Rareityenum
    {
        common,
        uncommon,
        rare
    }
    Rareityenum Rareity;


    //どっかでclampを入れたい
    int LV = 1;
    int RESLV = 1;
    int LUCLV = 1;
    int MENLV = 1;
    int EFFLV = 1;

    //レベル上げ用ポイント
    int point;

    int RES=20;

    public int GSLV
    {
        get
        { return LV; }
        set
        { LV = value; }
    }
    public int GSRESLV
    {
        get
        { return RESLV; }
        set
        { RESLV = value; }
    }
    public int GSLUCLV
    {
        get
        { return LUCLV; }
        set
        { LUCLV = value; }
    }
    public int GSMENLV
    {
        get
        { return MENLV; }
        set
        { MENLV = value; }
    }

    public int GSEFFLV
    {
        get
        { return EFFLV; }
        set
        { EFFLV = value; }
    }

    public int GSRES
    {
        get
        { return RES; }
        set
        { RES = value; }
    }

    public int GSpoint
    {
        get
        { return point; }
        set
        { point = value; }
    }

    public Elementenum GSElement
    {
        get
        { return Element; }
        set
        { Element = value; }
    }

    public Rareityenum GSRareity
    {
        get
        { return Rareity; }
        set
        { Rareity = value; }
    }
}

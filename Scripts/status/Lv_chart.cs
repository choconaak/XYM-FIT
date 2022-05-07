using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Lv_chart
    //
{
    
    //LUC”{—¦(ƒŒƒxƒ‹‚²‚Æ‚ÉŒˆ’è: 2105/LUC +396)
    int[] LUC = new int[] { 2501,1449,1098,922,817,747,697,659,630,607,587,571,558,546,536,528,520,513,507,501 };

    //EFF”{—¦(ƒŒƒxƒ‹‚²‚Æ‚ÉŒˆ’è: 1.04^(EFF-1))
    double[] EFF = new double[] {1.00, 1.04, 1.08, 1.12, 1.17, 1.22, 1.27, 1.32, 1.37, 1.42, 1.48, 1.54, 1.60, 1.67, 1.73, 1.80, 1.87, 1.95, 2.03, 2.11};
    public int GetLUC(int LUCLv)
    {
        return LUC[LUCLv -1];
    }

    public double GetEFF(int EFFLv)
    {
        return EFF[EFFLv - 1];
    }
    
}

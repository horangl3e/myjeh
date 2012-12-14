using UnityEngine;
using System.Collections;

public static class ResultData{

    static int gold;
    static float totalMeter; 

    public static int Gold
    {
        get { return gold; }
        set { gold = value; }
    }

    public static float TotalMeter
    {
        get { return totalMeter; }
        set { totalMeter = value; }
    }
	
	public static void Reset()
	{
		Gold = 0;
		TotalMeter = 0.0f;
	}
}

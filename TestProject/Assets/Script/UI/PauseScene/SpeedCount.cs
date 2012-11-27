using UnityEngine;
using System.Collections;

public class SpeedCount : MonoBehaviour {

    private int NumberCount = 1;
    private readonly int maxCount = 3;
    public int _NumberCount
    {
        get { return NumberCount; }
    }

    void OnClick()
    {
        if (NumberCount >= maxCount)
            NumberCount = 1;
        else
            NumberCount++;
    }
}

using UnityEngine;
using System.Collections;
using System.Collections.Generic;

[ExecuteInEditMode]
public class UIGear : MonoBehaviour {

    [System.Serializable]
    public class GearValueItem
    {
        public float gearValue = 0.0f;
    }

    public float MaxGearValue
    {
        get { return maxGearValue; }
    }

    [SerializeField]
    public float maxGearValue = 0.0f;
    public List<GearValueItem> Items = new List<GearValueItem>();

    public float getCurrentGearValue(int i)
    {
        return Items[i].gearValue;
    }
}

using UnityEngine;
using System.Collections;

public class OpenMessagePopup : MonoBehaviour {

    public GameObject parents;
    public GameObject PopUpPrefab;

    void OnClick()
    {
        if (PopUpPrefab && parents )
        {
            Debug.Log("OnClick Prefab MessagePopUp");
           //NGUITools.AddChild(parents, PopUpPrefab);

            GameObject go = (GameObject)Instantiate(PopUpPrefab);
        }
    }
}

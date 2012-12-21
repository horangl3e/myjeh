using UnityEngine;
using System.Collections;

public class ListVisibleFalse : MonoBehaviour {

	// Use this for initialization
	void Start () {

        int imax = gameObject.transform.childCount;

        for (int i = 0; i < imax; ++i)
            NGUITools.SetActive(gameObject.transform.GetChild(i).gameObject, false);

        NGUITools.SetActive(gameObject.transform.GetChild(0).gameObject, true);

        NGUITools.SetActive(gameObject.transform.GetChild(1).gameObject, true);
        NGUITools.SetActive(gameObject.transform.GetChild(2).gameObject, true);

        NGUITools.SetActive(gameObject.transform.GetChild(imax - 1).gameObject, true);
	}
	
	// Update is called once per frame
	void Update () {

        UIDraggablePanelCustom DraggablePanel = NGUITools.FindInParents<UIDraggablePanelCustom>(gameObject);
        if (DraggablePanel)
        {
           Transform transformObject = gameObject.transform.GetChild(DraggablePanel.ItemCurrentIndex);


            Debug.Log("DraggablePanel.CurrentIndex = " + DraggablePanel.ItemCurrentIndex);
        }
	
	}
}

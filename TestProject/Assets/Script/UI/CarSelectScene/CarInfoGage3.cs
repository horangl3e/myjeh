using UnityEngine;
using System.Collections;

public class CarInfoGage3 : MonoBehaviour {
	
	// Update is called once per frame
	void Update () {

        UIDraggablePanelCustom DraggablePanel = NGUITools.FindInParents<UIDraggablePanelCustom>(GameObject.Find("UIGrid"));
        if (DraggablePanel)
        {
            if (DraggablePanel.CurrentIndex == 1)
            {
                gameObject.GetComponent<UISlider>().sliderValue = 0.9f;
            }
            else if (DraggablePanel.CurrentIndex == 2)
            {
                gameObject.GetComponent<UISlider>().sliderValue = 0.2f;
            }
            else if (DraggablePanel.CurrentIndex == 3)
            {
                gameObject.GetComponent<UISlider>().sliderValue = 0.4f;
            }
        }
	
	}
}

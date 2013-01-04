using UnityEngine;
using System.Collections;

public class CarInfoGage2 : MonoBehaviour {

    float Pretemp;
    float Currenttemp;

	// Use this for initialization
	void Start () {

        //뭔가가 바뀌면 업데이트를 해준다.

	
	}
	
	// Update is called once per frame
	void Update () {

        UIDraggablePanelCustom DraggablePanel = NGUITools.FindInParents<UIDraggablePanelCustom>(GameObject.Find("UIGrid"));
        if (DraggablePanel)
        {
            if (DraggablePanel.CurrentIndex == 1)
            {
                gameObject.GetComponent<UISlider>().sliderValue = 0.2f;
            }
            else if (DraggablePanel.CurrentIndex == 2)
            {
                gameObject.GetComponent<UISlider>().sliderValue = 0.5f;
            }
            else if (DraggablePanel.CurrentIndex == 3)
            {
                gameObject.GetComponent<UISlider>().sliderValue = 0.9f;
            }
        }
	
	}
}

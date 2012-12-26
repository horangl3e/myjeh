using UnityEngine;
using System.Collections;

public class CarSelectButton : MonoBehaviour {
	
	void OnClick()
	{
		UIDraggablePanelCustom DraggablePanel = NGUITools.FindInParents<UIDraggablePanelCustom>( GameObject.Find("UIGrid") );
        if (DraggablePanel)
        {
			if( DraggablePanel.ItemCurrentIndex == 1 )
			{
				GameObject.Find("CarSelectData").GetComponent<CarSelectData>().Index = 0;
				Application.LoadLevel("GameScene");	
			}
			else if( DraggablePanel.ItemCurrentIndex == 2 )
			{
				GameObject.Find("CarSelectData").GetComponent<CarSelectData>().Index = 1;
				Application.LoadLevel("GameScene");	
			}
			else if( DraggablePanel.ItemCurrentIndex == 3 )
			{
				GameObject.Find("CarSelectData").GetComponent<CarSelectData>().Index = 2;
				Application.LoadLevel("GameScene");	
			}
			
			
        }
		
	}
}

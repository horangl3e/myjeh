using UnityEngine;
using System.Collections;

public class CarSelectData : MonoBehaviour {
	
	protected const string ON_CHANGE_DRAGGABLE_PANEL_INDEX = "OnChangeDraggablePanelIndex";
	
	ArrayList carAbility = new ArrayList();
	
	int index = 0;
	public int Index
	{
		get { return index; }
		private set {
			if (index != value) {
				index = value;
				NGUITools.Broadcast(ON_CHANGE_DRAGGABLE_PANEL_INDEX);
			}
		}
	}
	
	void Start()
	{
		UIDraggablePanelCustom DraggablePanel = NGUITools.FindInParents<UIDraggablePanelCustom>(GameObject.Find("UIGrid"));
		
        if (DraggablePanel) {
			DraggablePanel.OnChangedIndex = () => {
				Index = DraggablePanel.CurrentIndex - 1;
			};
		}
	}

	protected virtual void Init ()
	{
		DontDestroyOnLoad(this);
		
		//for(int i = 0; i < 3; i++ )
		//	carAbility.Add( new EditableStat());
	}

	void Awake()
	{
		Init ();
	}
	

}

//----------------------------------------------
//            NGUI: Next-Gen UI kit
// Copyright ?2011-2012 Tasharen Entertainment
//----------------------------------------------

using UnityEngine;
using System;

/// <summary>
/// This script, when attached to a panel allows dragging of the said panel's contents efficiently by using UIDragPanelContents.
/// </summary>

[ExecuteInEditMode]
[RequireComponent(typeof(UIPanel))]
[AddComponentMenu("NGUI/Interaction/Draggable PanelCustom")]
public class UIDraggablePanelCustom : UIDraggablePanel
{
	const float SNAP_SPEED = 0.01f;
	const float MAX_SCALE = 1.706f;
	const float MIN_SCALE = 1.0f;
	const float SELECTED_ITEM_SCALE = 1.7f;
	const float INTERPOLATION = 1.45f;
	
	public delegate void ProcChanged();
	ProcChanged onChangedIndex;
	public ProcChanged OnChangedIndex {
		private get { return onChangedIndex; }
		set { onChangedIndex = value; }
	}
	
	int currentIndex = 1;
	public int CurrentIndex
	{
		get { return currentIndex; }
		private set {
			if (currentIndex != value)
			{
				currentIndex = value;
				if (null != OnChangedIndex)
					OnChangedIndex();
			}
		}
	}
	
	int targetIndex = 1;
	
	delegate void update();
	update OnUpdate;
	
	void Start()
	{
		ClearOnUpdate();
	}
	
	void UpdateTargetIndex()
	{
		Transform gridTransform = gameObject.GetComponentInChildren<UIGridCustom>().transform;
		
		float tempValue = 0.0f;
		
		for (int i = 0; i < gridTransform.transform.childCount; ++i)
		{
			if (gridTransform.transform.GetChild(i).localScale.x == MIN_SCALE)
				continue;
			
			if (tempValue <= gridTransform.transform.GetChild(i).localScale.x)
			{
				tempValue = gridTransform.transform.GetChild(i).localScale.x;
				targetIndex = i;
			}
		}
	}
	
	void UpdateItemScale()
	{
		var uiGridCustomTrasform = gameObject.GetComponentInChildren<UIGridCustom>().transform;
		float SliderPosition = uiGridCustomTrasform.GetChild(targetIndex).position.x;
	
		float ox = Mathf.Lerp(MAX_SCALE, MIN_SCALE, -SliderPosition * INTERPOLATION);
		float ox2 = Mathf.Lerp(MIN_SCALE, MAX_SCALE, -SliderPosition * INTERPOLATION);
		float ox3 = Mathf.Lerp(MIN_SCALE, MAX_SCALE, SliderPosition * INTERPOLATION);
		float ox4 = Mathf.Lerp(MAX_SCALE, MIN_SCALE, SliderPosition * INTERPOLATION);
		
		if( targetIndex != 0 )
		{
			Transform t = uiGridCustomTrasform.GetChild(targetIndex);
			
			if (ox >= SELECTED_ITEM_SCALE)
				t.localScale = new Vector3(ox4, ox4, 1.0f);
			else if (ox4 >= SELECTED_ITEM_SCALE)
				t.localScale = new Vector3(ox, ox, 1.0f);
			
			uiGridCustomTrasform.GetChild(targetIndex + 1).localScale = new Vector3(ox2, ox2, 1.0f);
			uiGridCustomTrasform.GetChild(targetIndex - 1).localScale = new Vector3(ox3, ox3, 1.0f);
		}
	}
	
	public override void Drag (Vector2 delta)
	{
		base.Drag(delta);
		
		UpdateTargetIndex();
		UpdateItemScale();
	}
 
	public override void Press(bool pressed)
	{
		base.Press(pressed);
		
		if (!pressed)
			OnUpdate = SnapToTargetItem; 
	}

	void ClearOnUpdate ()
	{
		OnUpdate = () => {};
	}

	void SnapToTargetItem ()
	{
		var uiGridCustomTrasform = gameObject.GetComponentInChildren<UIGridCustom>().transform;

		if (uiGridCustomTrasform.GetChild(targetIndex).localScale.x <= SELECTED_ITEM_SCALE)
		{
			if (targetIndex != 0)
			{
				float SliderPositionRight = uiGridCustomTrasform.GetChild(targetIndex + 1).localScale.x;
				float SliderPositionLeft = uiGridCustomTrasform.GetChild(targetIndex - 1).localScale.x;
				
				if (SliderPositionRight >= SliderPositionLeft)
					MoveAbsolute(Vector3.right * SNAP_SPEED);
				else
					MoveAbsolute(Vector3.left * SNAP_SPEED);
				
				UpdateItemScale();
			}
		}
		else
		{
			CurrentIndex = targetIndex;
			ClearOnUpdate ();
		}
	}
	
	void Update()
	{
		if (null != OnUpdate) OnUpdate();
	}
}
using UnityEngine;
using System.Collections;

public class DisPlayValue : MonoBehaviour {
	
	private ImageFontControl imageFontControl;
	private int DefaultValue = 9999999;
	
	public int _Value
	{
		set{ DefaultValue = value; }	
	}
	
	void Update ()
	{
		imageFontControl = gameObject.GetComponent<ImageFontControl>();
		
		if( imageFontControl )
		{
			if( imageFontControl._ScoreValue != DefaultValue  )
				imageFontControl._ScoreValue = DefaultValue;	
		}
		
	}
}

using UnityEngine;
using System.Collections;
using System.Collections.Generic;

[System.Serializable]
public class K2DFrame
{
	public string name;
	public Vector2 vec2Offset;
	public Vector2 vec2Tex;
}

public class K2DSpriteAnimation : K2DSprite
{
	public K2DFrame[] freamList;
	
	
	
	// Update is called once per frame
	void Update () 
	{
	
	}
}

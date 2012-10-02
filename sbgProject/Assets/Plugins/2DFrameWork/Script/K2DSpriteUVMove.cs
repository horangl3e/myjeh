using UnityEngine;
using System.Collections;


public class K2DSpriteUVMove : K2DSprite
{	
	public Vector2 moveSpeed = Vector2.zero;
	
	private Vector2 m_vec2Temp = Vector2.zero;
	
	public override void InitStart()
	{
		
	}
	
	public void ResetTexOffset()
	{		
		if( null == spriteMaterial )
			return;
		
		if( moveSpeed == Vector2.zero )
			return;
		
		float dx = (1 / spriteMaterial.mainTextureScale.x) * moveSpeed.x * Time.deltaTime;
        float dy = (1 / spriteMaterial.mainTextureScale.y) * moveSpeed.y * Time.deltaTime;
		
		float nx = spriteMaterial.mainTextureOffset.x + dx;
        float ny = spriteMaterial.mainTextureOffset.y + dy;
		
		if (dx < 0 && nx < 0) nx += 1;
        if (dx > 0 && nx > 1) nx -= 1;
        if (dy < 0 && ny < 0) ny += 1;
        if (dy > 0 && ny > 1) ny -= 1;
		
		m_vec2Temp.x = nx;
		m_vec2Temp.y = ny; 
		
		spriteMaterial.mainTextureOffset = m_vec2Temp;		    
	}
	
	// Update is called once per frame
	void Update () 
	{
		ResetTexOffset();
	}
}

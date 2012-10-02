using UnityEngine;
using UnityEditor;
using System.Collections;


[CustomEditor( typeof( K2DSprite ) )]
public class K2DSpriteEdit : Editor  
{
	private K2DSprite m_target = null;	
	
	void OnEnable()
    {
		InitEnable();		
	}
	
	public virtual void InitEnable()
	{
		m_target = target as K2DSprite;
		m_target.CreateInEdit();
	}
	
	public override void OnInspectorGUI()
	{			
		EditorGUILayout.LabelField( "spriteTopLeft : " );
		m_target.SetSpriteTopLeft( EditUtil.DrawVector2( m_target.spriteTopLeft ) );			
		
		EditorGUILayout.LabelField( "spriteSize : " );
		m_target.SetSpriteSize( EditUtil.DrawVector2( m_target.spriteSize ) );				
		
		m_target.SetSpriteOrientation( (SpriteOrientation)EditorGUILayout.EnumPopup ("SpriteOrientation", m_target.spriteOrientation ) );
		m_target.SetSpriteUV( (SpriteUV)EditorGUILayout.EnumPopup ("SpriteUV", m_target.spriteUV ) );
		
		m_target.SetSpriteMaterial( EditorGUILayout.ObjectField("Material", m_target.spriteMaterial, typeof(Material), false) as Material );
	}
	
	public void OnSceneGUI()
	{
		
	}
}

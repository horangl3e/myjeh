using UnityEngine;
using UnityEditor;
using System.Collections;

[CustomEditor( typeof( K2DSpriteAnimation ) )]
public class K2DSpriteAnimationEdit : K2DSpriteEdit
{
	private K2DSpriteAnimation m_spriteAnimation = null;
	
	
	public override void InitEnable()
	{
		base.InitEnable();
		m_spriteAnimation = target as K2DSpriteAnimation;	
	}
	
	public override void OnInspectorGUI()
	{		
		base.OnInspectorGUI();
		
		GUILayoutOption opt = GUILayout.MinWidth(30f);
		
		
		EditorGUILayout.LabelField( "Img XY : " );		
		m_spriteAnimation.SetImgXY( EditUtil.DrawVector2( m_spriteAnimation.imgXY ) );
		
		EditorGUILayout.LabelField( "Frame List : " );
		if( null != m_spriteAnimation.frameList )
			m_spriteAnimation.SetFrameListCount( EditorGUILayout.IntField("Count : ", m_spriteAnimation.frameList.Length, opt) );
		else
			m_spriteAnimation.SetFrameListCount( EditorGUILayout.IntField("Count : ", 0, opt) );
		
		//int iIndex =0;
		//foreach( K2DFrame _data in m_spriteAnimation.frameList )			
		//{
		//	EditorGUILayout.LabelField( "data_" + iIndex );
			//DrawK2DFrame(_data); 
		//}
	}
	/*
	
	public K2DFrame DrawK2DFrame( K2DFrame _data )
	{
		EditorGUILayout.TextField("name : ", _data.name, opt);
		
		return _data;
	}*/
	
}
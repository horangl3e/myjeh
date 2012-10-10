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
		
		EditorGUILayout.LabelField( "Frame Speed : " );
		m_spriteAnimation.speed = EditorGUILayout.FloatField("speed : ", m_spriteAnimation.speed, opt);
		
		EditorGUILayout.LabelField( "Img XY : " );		
		m_spriteAnimation.SetImgXY( EditUtil.DrawVector2( m_spriteAnimation.imgXY ) );
		
		EditorGUILayout.LabelField( "Frame List : " );
		if( null != m_spriteAnimation.frameList )
			m_spriteAnimation.SetFrameListCount( EditorGUILayout.IntField("Count : ", m_spriteAnimation.frameList.Length, opt) );
		else
			m_spriteAnimation.SetFrameListCount( EditorGUILayout.IntField("Count : ", 0, opt) );
		
		if( null != m_spriteAnimation.frameList )
		{
			int iIndex =0;
			foreach( K2DFrame _data in m_spriteAnimation.frameList )			
			{				
				m_spriteAnimation.SetFrameData( iIndex++,  DrawK2DFrame(_data) ); 				
			}
		}
	}	
	
	public K2DFrame DrawK2DFrame( K2DFrame _data )
	{
		if( null == _data )
			return null;
		
		GUILayoutOption opt = GUILayout.MinWidth(30f);
		
		EditorGUILayout.LabelField( "	" + _data.name );
		_data.name = EditorGUILayout.TextField("		name : ", _data.name, opt);
		_data.startFrame = EditorGUILayout.IntField("		Start Index : ", _data.startFrame, opt);
		_data.endFrame = EditorGUILayout.IntField("		End Index : ", _data.endFrame, opt);	
		_data.loop = EditorGUILayout.Toggle("		loop : ", _data.loop);	
		return _data;
	}
	
}
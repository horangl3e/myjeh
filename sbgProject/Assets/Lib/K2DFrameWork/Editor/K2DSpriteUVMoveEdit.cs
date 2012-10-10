using UnityEngine;
using UnityEditor;
using System.Collections;


[CustomEditor( typeof( K2DSpriteUVMove ) )]
public class K2DSpriteUVMoveEdit : K2DSpriteEdit
{
	private K2DSpriteUVMove m_spriteUVtarget = null;
	
	
	public override void InitEnable()
	{
		base.InitEnable();
		m_spriteUVtarget = target as K2DSpriteUVMove;	
	}
	
	public override void OnInspectorGUI()
	{		
		base.OnInspectorGUI();
		
		EditorGUILayout.LabelField( "moveSpeed : " );
		m_spriteUVtarget.moveSpeed = EditUtil.DrawVector2( m_spriteUVtarget.moveSpeed );			
	}
}

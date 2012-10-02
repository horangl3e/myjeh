using UnityEngine;
using UnityEditor;
using System.Collections;

public class EditUtil
{

	public static Vector3 DrawVector2( Vector3 vec3Value )
	{
		GUILayoutOption opt = GUILayout.MinWidth(30f);
		vec3Value.x = EditorGUILayout.FloatField("X", vec3Value.x, opt);
		vec3Value.y = EditorGUILayout.FloatField("Y", vec3Value.y, opt);
		vec3Value.z = EditorGUILayout.FloatField("Z", vec3Value.z, opt);
		return vec3Value;
	}
	
	public static Vector2 DrawVector2( Vector2 vec2Value )
	{
		GUILayoutOption opt = GUILayout.MinWidth(30f);
		vec2Value.x = EditorGUILayout.FloatField("X", vec2Value.x, opt);
		vec2Value.y = EditorGUILayout.FloatField("Y", vec2Value.y, opt);		
		return vec2Value;
	}
}

using UnityEngine;
using UnityEditor;
using System.Collections.Generic;

class CustomTempClass
{
    public CustomTempClass()
    {

    }
}

[CustomEditor(typeof(InvDataBaseCustom))]
public class InvDataBaseInsPectorCustom : Editor {

    int mIndex = 0;
    private CustomTempClass test = new CustomTempClass();

	// Use this for initialization
	void Start () {
	
	}
	
	// Update is called once per frame
	void Update () {
	
	}

    public override void OnInspectorGUI()
    {
        EditorGUIUtility.LookLikeControls(80f);
        InvDataBaseCustom db = target as InvDataBaseCustom;
        NGUIEditorTools.DrawSeparator();


        GUILayout.Label("Test ");
        //이걸 하면 검정색 밑줄이 생긴다.
        NGUIEditorTools.DrawSeparator();

        GUILayout.BeginHorizontal();
        GUILayout.Button("Cancel");

        if (GUILayout.Button("Delete"))
        {
            Debug.Log("Delete Click");
        }

        GUILayout.EndHorizontal();

        NGUIEditorTools.DrawSeparator();


        test pp = EditorGUILayout.ObjectField("Test Field", null, typeof(test), false) as test;

        //////////////////int 관련 필드 추가 됨
        int DataInt = EditorGUILayout.IntField("DataBase ID", 1000);

        if (DataInt != 1000)
        {
            Debug.Log("값이 서로 달라요");
            NGUIEditorTools.RegisterUndo("Change", db);
        }


        NGUIEditorTools.DrawSeparator();

        // Navigation section
        GUILayout.BeginHorizontal();
        {
            if (mIndex == 0) GUI.color = Color.grey;
            if (GUILayout.Button("<<")) { --mIndex; }
            GUI.color = Color.white;
            mIndex = EditorGUILayout.IntField(mIndex + 1, GUILayout.Width(40f)) - 1;
            GUILayout.Label("/ " + 7 , GUILayout.Width(40f));

            //비활성화
            if (mIndex + 1 == 7) GUI.color = Color.grey;
            if (GUILayout.Button(">>")) { ++mIndex; }
            GUI.color = Color.white;
        }
        GUILayout.EndHorizontal();



    }
}

using UnityEngine;
using UnityEditor;
using System.Collections;

[CustomEditor(typeof(UIListViewControl))]
public class UIListViewControlEdit : Editor
{
    private UIListViewControl m_target = null;

    void OnEnable()
    {
        Debug.Log("OnEnable Call");
        InitEnable();
    }

    public virtual void InitEnable()
    {
        m_target = target as UIListViewControl;
        m_target.CreateItemforEdit();
        Debug.Log("InitEnable");
    }

    public override void OnInspectorGUI()
    {

    }

    public void OnSceneGUI()
    {
        Debug.Log("OnInspectorGUI");
    }
}

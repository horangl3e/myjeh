using UnityEngine;
using System.Collections;

namespace NGUISUB
{
    static public class NGUIToolsSubClass
    {
        static public GameObject AddChild(GameObject parent, GameObject prefab)
        {
            GameObject go = GameObject.Instantiate(prefab, prefab.transform.position, prefab.transform.rotation) as GameObject;

            if (go != null && parent != null)
            {
                Transform t = go.transform;
                t.parent = parent.transform;
                t.localPosition = go.transform.position;
                t.localRotation = go.transform.rotation;
                t.localScale = prefab.transform.localScale;
                go.layer = parent.layer;
            }
            return go;
        }

        static NGUIToolsSubClass() { }
    }
}


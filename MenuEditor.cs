using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEditor;
[CustomEditor(typeof(Menu))]
public class MenuEditor : Editor
{



    public override void OnInspectorGUI()
    {
        DrawDefaultInspector();
        Menu myScript = (Menu)target;
        if (GUILayout.Button("Build Object"))
        {
            myScript.drawRadialMenu();
        }
    }

}

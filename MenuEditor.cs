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



        myScript.setOffset(EditorGUILayout.FloatField("Offset", myScript.getOffset()));
        myScript.setMenuSize( EditorGUILayout.IntSlider( "Menu Size",myScript.getMenuSize(),  10,  50));
        myScript.setButtonCount(EditorGUILayout.IntField("Button Count", myScript.getButtonCount()));
        myScript.setInnerCircle(EditorGUILayout.Slider("Inner Radial Size", myScript.getInnerCircle(), 0f, 1f));
        myScript.setOuterCircle(EditorGUILayout.Slider("Outer Radial Size", myScript.getOuterCircle(), 0f, 1f));

        if (GUILayout.Button("Build Object"))
        {
            myScript.drawRadialMenu();
        }




    }

}



/*
/
//[CustomEditor] tells Unity to draw this instead of the default thing in the inspector when a PatternMaker is selected
[CustomEditor(typeof(Menu))]
public class PatternMakerEditor : Editor
{ //Editor is the super-type for all custom inspectors

    private PatternMaker script;

    private void OnEnable()
    {
        // target is the script selected in the editor. We cast it to PatternMaker
        // here so we don't have to do that in every OnInspectorGUI
        script = (PatternMaker)target;
    }

    //This method draws the inspector
    public override void OnInspectorGUI()
    {
        base.OnInspectorGUI(); //Draw all the fields we haven't hidden, and all the other default stuff

        // This both enables undo, and is neccessary for Unity to mark your object (and scene) as having changes
        // when you use the settings below
        Undo.RecordObject(script, "Change the color settings");

        // This defines a slider. All of the Layout methods work by receiving the field you want to change, and returning
        // the new value the user set it to.
        script.numberOfColours = EditorGUILayout.IntSlider("Number of colors", script.numberOfColours, 2, 10);

        //We need a null-check here, as when you create a PatternMaker, the script
        // won't get time to create the empty Color-array before this code is run
        if (script.colourSelection == null)
        {
            script.colourSelection = new Color[script.numberOfColours];
        }

        //If the number of colors was changed, we need to change the size of the array, and copy over the values
        else if (script.numberOfColours != script.colourSelection.Length)
        {
            var newSelection = new Color[script.numberOfColours];

            for (int i = 0; i < Mathf.Min(script.numberOfColours, script.colourSelection.Length); i++)
            {
                newSelection[i] = script.colourSelection[i];
            }
            script.colourSelection = newSelection;
        }

        for (int i = 0; i < script.colourSelection.Length; i++)
        {
            script.colourSelection[i] = EditorGUILayout.ColorField("Color " + i, script.colourSelection[i]);
        }
    }
}
*/
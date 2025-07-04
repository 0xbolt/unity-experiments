using UnityEditor;
using UnityEngine;

[CustomEditor(typeof(SumArrayMain))]
public class SumArrayMainEditor : Editor {
    SumArrayMain script;

    void OnEnable() {
        script = (SumArrayMain)target;
    }

    public override void OnInspectorGUI() {
        DrawDefaultInspector();

        if (GUILayout.Button("Sum Array")) {
            script.SumArray();
        }
    }
}

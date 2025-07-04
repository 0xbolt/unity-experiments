using UnityEditor;
using UnityEngine;

[CustomEditor(typeof(SumArrays))]
public class ComputeShadersMainEditor : Editor {
    SumArrays script;

    void OnEnable() {
        script = (SumArrays)target;
    }

    public override void OnInspectorGUI() {
        DrawDefaultInspector();

        if (GUILayout.Button("Execute")) {
            script.Execute();
        }
    }
}

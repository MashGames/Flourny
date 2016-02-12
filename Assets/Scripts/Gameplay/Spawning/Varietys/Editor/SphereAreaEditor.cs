using UnityEngine;
using System.Collections;
using UnityEditor;

[CustomEditor( typeof( SphereAreaSpawner ) )]
public class SphereAreaEditor : SpawnerEditor
{
    public override void OnInspectorGUI()
    {
        base.OnInspectorGUI();
        SphereAreaSpawner myTarget = (SphereAreaSpawner)target;
        myTarget.SetSphereRadius( myTarget.range );
        DrawDefaultInspector();
    }
}

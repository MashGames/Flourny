using UnityEngine;
using System.Collections;
using UnityEditor;

[CustomEditor( typeof( CubeAreaSpawner ) )]
public class BoxAreaEditor : SpawnerEditor
{
    public override void OnInspectorGUI()
    {
        base.OnInspectorGUI();
        CubeAreaSpawner myTarget = (CubeAreaSpawner)target;
        myTarget.SetArea( new Vector3( myTarget.rangeX,myTarget.rangeY,myTarget.rangeZ ));
        DrawDefaultInspector();
    }
}

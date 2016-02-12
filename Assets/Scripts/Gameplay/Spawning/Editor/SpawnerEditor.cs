using UnityEngine;
using System.Collections;
using UnityEditor;

[CustomEditor( typeof( Object_Spawner ) )]
public class SpawnerEditor : Editor
{
    public override void OnInspectorGUI()
    {
        Object_Spawner myTarget = (Object_Spawner)target;
        myTarget.SetMinMaxSpawnTime( myTarget.minSpawnTime, myTarget.maxSpawnTime );

        //if(!myTarget.HasObjects())
        //{
        //    myTarget.Initialize();
        //}
    }
}
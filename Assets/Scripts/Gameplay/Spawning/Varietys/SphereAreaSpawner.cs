using UnityEngine;
using System.Collections;


[RequireComponent( typeof( SphereCollider ) )]
[AddComponentMenu( "Flourny Tools/Spawner/Sphere Area Spawner" )]
[System.Serializable]
public class SphereAreaSpawner : Object_Spawner 
{
    [Range( 0.0f, 6.0f )]
    public float range = 10.0f; //distance from player

    SphereCollider spawnArea;

    void Start()
    {
        print( "Start Sphere spawn area" );
        spawnArea = GetComponent<SphereCollider>();
        spawnArea.isTrigger = true;
        base.Start();
    }
    void OnDsiable()
    {
        print( "Awake Sphere spawn area" );
        spawnArea = GetComponent<SphereCollider>();
        spawnArea.isTrigger = true;
        base.OnDisable();
    }
   
      
    public override Vector3 GetSpawnPos()
    {
        return Random.insideUnitSphere * spawnArea.radius;
    }
    public void SetSphereRadius(float rad)
    {
        if( spawnArea != null)
        {
            spawnArea.radius = rad;
        }
       else
       {
           print( "NO SPHERE COLLIDER FOR SPAWN AREA!" );
           print( "Update Sphere spawn area" );
           spawnArea = GetComponent<SphereCollider>();
           spawnArea.isTrigger = true;
       }
    }
}

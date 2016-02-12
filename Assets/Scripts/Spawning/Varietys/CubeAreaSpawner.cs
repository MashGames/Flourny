using UnityEngine;
using System.Collections;


[RequireComponent( typeof( BoxCollider ) )]
[AddComponentMenu( "Flourny Tools/Spawner/Box Area Spawner" )]
[System.Serializable]
public class CubeAreaSpawner : Object_Spawner
{
    BoxCollider spawnArea;

    [Range( 0.0f, 100.0f )]
    public float rangeX = 10.0f;

    [Range( 0.0f, 100.0f )]
    public float rangeY = 10.0f; //distance from player

    [Range( 0.0f, 100.0f )]
    public float rangeZ = 10.0f; //distance from player

    void Start()
    {
        print( "Start Box spawn area" );
        spawnArea = GetComponent<BoxCollider>();
        spawnArea.isTrigger = true;
        base.Start();
    }
    void OnDisable()
    {
        print( "Awake Box spawn area" );
        spawnArea = GetComponent<BoxCollider>();
        spawnArea.isTrigger = true;
        base.OnDisable();
    }
    public override Vector3 GetSpawnPos()
    {
        Vector3 randomPos = Vector3.one;

        float xMax = (transform.right * this.transform.localScale.x).x;
        float yMax = (transform.up * this.transform.localScale.y).y;
        float zMax = (transform.forward * this.transform.localScale.z).z;

        randomPos.x = Random.Range( xMax * 0.5f, -xMax * 0.5f );
        randomPos.y = Random.Range( yMax * 0.5f, -yMax * 0.5f );
        randomPos.z = Random.Range( zMax * 0.5f, -zMax * 0.5f );
                                                                    
        return randomPos;
    }
    public void SetArea(Vector3 area)
    {
        if( spawnArea != null )
        {
            this.transform.localScale = area;
            spawnArea.size = Vector3.one;
        }
        else
        {
            print( "NO BOX COLLIDER FOR SPAWN AREA!" );
            print( "Update BOX spawn area" );
            spawnArea = GetComponent<BoxCollider>();
            spawnArea.isTrigger = true;
        }
    }
}

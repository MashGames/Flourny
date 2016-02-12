using UnityEngine;

[AddComponentMenu( "Flourny Tools/Spawner/basic" )]
[System.Serializable]
public class Object_Spawner : MonoBehaviour
{
    public enum SpawnType
    {
        intoParent,
        intoWorld
    }
    public SpawnType spawnType;

    public GameObject[] obj;

    public Transform parentListToSpawnInto;

    [Range( 0.0f, 6.0f )]
    public float minSpawnTime = 3f;

    [Range( 0.0f, 12.0f )]
    public float maxSpawnTime = 3f;

    bool isRunning = false;
    float timeSinceLastSpawn = 0.0f;
    float timeTillNextSpawn = 0.0f;

    public void Initialize()
    {
      // obj = new GameObject[1];
      // obj[0] = Resources.Load("Spawning/SpawningExampleObj") as GameObject;
    }

    public void Start()
    {
        print( "Start from obj spawner base" );
        //RunSpawn();
    }
    public void OnDisable()
    {
       // TurnOff();
    }
    public void OnEnable()
    {
       //RunSpawn();
        isRunning = true;
    }
    void Update()
    {
        if( isRunning )
        {
            timeSinceLastSpawn += Time.deltaTime;

            if( timeSinceLastSpawn > timeTillNextSpawn )
            {
                if( spawnType  == SpawnType.intoParent)
                {
                    SpawnIntoList();
                }
                else
                {
                    Spawn();
                }
                timeSinceLastSpawn = 0.0f;
            }
        }
    }
    void Spawn()
    {
      print("spawnObject");
      Vector3 randomPos = GetSpawnPos();
      Instantiate( obj[GetRandFromObjList()], transform.position + randomPos, Quaternion.identity );
      timeTillNextSpawn = Random.Range( minSpawnTime, maxSpawnTime );
    }

    void SpawnIntoList()
    {
        print( "SpawnIntoList spawnObject" );
        Vector3 randomPos = GetSpawnPos();
        GameObject newObj =  (GameObject)Instantiate( obj[GetRandFromObjList()], transform.position + randomPos, Quaternion.identity );

        if( parentListToSpawnInto )
        newObj.transform.SetParent(parentListToSpawnInto);

        timeTillNextSpawn = Random.Range( minSpawnTime, maxSpawnTime );
    }


    public virtual Vector3 GetSpawnPos()
    {
        return Random.insideUnitSphere* 1.0f;
    }
    public void TurnOff()
    {
        if( isRunning )
        {
            isRunning = false;
            CancelInvoke( "Spawn" );
        }
    }
    public void RunSpawn()
    {
        isRunning = true;

    }
    int GetRandFromObjList()
    {
        return Random.Range(0, obj.Length);
    }
    public void SetMinMaxSpawnTime( float newMin,float newMax )
    {
        maxSpawnTime = newMax;
        minSpawnTime = newMin;
        if( minSpawnTime > maxSpawnTime )
        {
            minSpawnTime = (maxSpawnTime - .1f);
        }

        if( maxSpawnTime < minSpawnTime )
        {
            maxSpawnTime = (minSpawnTime + .1f);
        }
    }
    public bool HasObjects()
    {
        return (obj == null);
    }
}

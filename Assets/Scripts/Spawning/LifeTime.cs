using UnityEngine;
using System.Collections;

public class LifeTime : MonoBehaviour {

    [Range(0.0f,100.0f)]
    public float lifeTime = 2.0f;
	// Use this for initialization
	void Start () 
    {
        StartCoroutine( enumLifeTime() );
	}

    IEnumerator enumLifeTime()
    {
        yield return new WaitForSeconds( lifeTime );
        Destroy( this.gameObject );
    }
}

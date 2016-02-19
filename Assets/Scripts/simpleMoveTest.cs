using UnityEngine;
using System.Collections;

public class simpleMoveTest : MonoBehaviour 
{
    public float moveSpeed = 5.0f;
    public float spinSpeed = 5.0f;
    Transform myTransform;
    public Transform spinGyro;

    public float constantForce = 100.0f;
    public float rotateSpeed = 5.0f;

    [Range(0.0f,40.0f)]
    public float maxSpeed = 6.0f;

    Rigidbody myBody;
    float deltaTime;
	// Use this for initialization
	void Start () 
    {
        myBody = GetComponent<Rigidbody>();
        myTransform = this.transform;
	}
	
	// Update is called once per frame
	void FixedUpdate () 
    {
        deltaTime = Time.fixedDeltaTime;

        //Vector3 move = new Vector3( -Input.GetAxis( "Vertical" ) * moveSpeed  * deltaTime,
        //                            0.0f,
        //                            Input.GetAxis( "Horizontal" ) * moveSpeed * deltaTime );
        //

        //myTransform.Translate( move , Space.Self );

        spinGyro.Rotate( 0.0f, spinSpeed * deltaTime * Input.GetAxis( "Vertical" ), 0.0f, Space.Self );

        float playerVelMag = myBody.velocity.magnitude;

        if( playerVelMag < maxSpeed)
        myBody.AddRelativeForce( new Vector3(0.0f,0.0f,constantForce) );

        myBody.velocity = myTransform.forward * myBody.velocity.magnitude;

        myTransform.Rotate( Vector3.right * rotateSpeed * deltaTime * Input.GetAxis( "Horizontal" ), Space.Self );
	}
}

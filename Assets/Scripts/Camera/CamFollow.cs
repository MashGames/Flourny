using UnityEngine;
using System.Collections;

public class CamFollow : MonoBehaviour
{

	[Header("Dependancies")]
    public Transform target;
	public Rigidbody playerBody;

	[Header("Tunables")]

	[Range(0.0f,20.0f)]
    public float height = 5.0f;

	[Range(0.0f,20.0f)]
    public float heightDamping = 2.0f;

	[Range(0.0f,360.0f)]
	public float rotationYOffset = 0.0f;

	[Range(0.0f,50.0f)]
    public float rotationDamping = 3.0f;

	[Range(-5.0f,5.0f)]
    public float yLookOffset = 0.0f;

	[Range(-5.0f,5.0f)]
	public float lookYLerpSpeed = 6.0f;
	
	[Tooltip("curve X = player velocity, where Y = camera distance (used for moving camera farther while player speeds up) ")]
	public AnimationCurve distancePerVelMultiplyerCurve;
	[Range(0.0f,20.0f)]
	public float baseDistance = 5.0f;
	[Range(0.0f,20.0f)]
	public float distanceLerpSpeed = 6.0f;
	
    Transform myTransform;
	float distance = 5.0f;
	float actualRotdamp;
	float actualHeightDamping;
    float deltaTime;
    float wantedRotationAngle;
    float lookTargetY;

    void Awake()
    {

    }
    void Start()
    {
        myTransform = this.transform;
        //myTransform.position = target.position;
        actualRotdamp = rotationDamping;
        actualHeightDamping = heightDamping;
        lookTargetY = myTransform.position.y + yLookOffset;
        myTransform.position = target.position;
    }

    // Update is called once per frame
    void FixedUpdate()
    {
        deltaTime = Time.fixedDeltaTime;
        // Early out if we don't have a target
        if (!target)
            return;

        // Calculate the current rotation angles
		wantedRotationAngle = target.eulerAngles.y + rotationYOffset;

        float wantedHeight = target.position.y + height;

        float currentRotationAngle = transform.eulerAngles.y;


        float currentHeight = transform.position.y;

        // Damp the rotation around the y-axis
        currentRotationAngle = Mathf.LerpAngle(currentRotationAngle, wantedRotationAngle, actualRotdamp * deltaTime);

        // Convert the angle into a rotation
		Quaternion currentRotation = Quaternion.Euler(0.0f, currentRotationAngle, 0.0f);
        // Set the position of the camera on the x-z plane to:
        // distance meters behind the target
        myTransform.position = target.position;

        currentHeight = Mathf.Lerp(currentHeight, wantedHeight, actualHeightDamping * deltaTime);

		myTransform.rotation = currentRotation;

        myTransform.position -= -Vector3.forward * distance;

        // Set the height of the camera
        myTransform.position = new Vector3(myTransform.position.x, currentHeight, myTransform.position.z);

        // Always look at the target
        SetLookTarget();
        Vector3 lookTarget = new Vector3(target.position.x, lookTargetY, target.position.z);
        myTransform.LookAt(lookTarget);
    }
    void SetLookTarget()
    {
        lookTargetY = Mathf.Lerp(lookTargetY, target.position.y + yLookOffset, lookYLerpSpeed * deltaTime);
    }
    void LateUpdate()
    {
		float wantedDistance = baseDistance * distancePerVelMultiplyerCurve.Evaluate(playerBody.velocity.magnitude);
        distance = Mathf.Lerp(distance, wantedDistance, distanceLerpSpeed * Time.deltaTime);
    }
}

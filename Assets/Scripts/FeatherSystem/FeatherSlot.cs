using UnityEngine;
using System.Collections;


/// <summary>
/// requires feather slot manager as a parent
/// </summary>
public class FeatherSlot : MonoBehaviour 
{
    FeatherSlotManager manager; // reference to manager
    
    public bool isEmpty = true;
    public bool isMagneting = false;

    Transform myTransform;
	// Use this for initialization
	void Start ()
    {
        myTransform = this.transform;

        manager = GetComponentInParent<FeatherSlotManager>();

    }

    Transform GetTransform()
    {
        return myTransform;
    }
    void SetFilled(bool filled)
    {
        isEmpty = !filled;
    }
    public void AttractFeather(Transform feather)
    {
        if( !isMagneting )
        StartCoroutine(enumAttractFeather(feather));

    }
    IEnumerator enumAttractFeather(Transform feather)
    {
        isMagneting = true;
        float deltaTime = 0.0f;
        float distanceToSlotSqrd = (myTransform.position - feather.position).sqrMagnitude;
        float minDistToCompSqrd = (manager.minDistToCompleteMagnet * manager.minDistToCompleteMagnet);

        Vector3 dirToSlot = (myTransform.position - feather.position).normalized;

        while( distanceToSlotSqrd > minDistToCompSqrd ) /// make custon normalize!!!!!!!!!!!!!!
        {
            deltaTime = Time.deltaTime;

            distanceToSlotSqrd = (myTransform.position - feather.position).sqrMagnitude; /// make custon normalize!!!!!!!!!!!!!!
            dirToSlot = (myTransform.position - feather.position).normalized; /// make custon normalize!!!!!!!!!!!!!!


            feather.position += dirToSlot * manager.magnetSpeed * deltaTime;

            feather.rotation = Quaternion.Lerp( feather.rotation, myTransform.rotation, manager.rotationMagnetSpeed * deltaTime );

            yield return new WaitForEndOfFrame();
        }

        feather.rotation = myTransform.rotation;
        feather.position = myTransform.position;
        feather.SetParent(myTransform);

        isEmpty = false;
    }
    public bool IsFull()
    {
        return !isEmpty;
    }
    public bool CanAttractFeather()
    {
        return (isEmpty && !isMagneting);
    }
    public void DropFeather()
    {
        if( !isEmpty )
        {
            isEmpty = true;
            isMagneting = false;
            GetComponentInChildren<Feather>().Drop();
        }
    }
}

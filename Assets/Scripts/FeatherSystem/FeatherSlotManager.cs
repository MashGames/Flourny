using UnityEngine;
using System.Collections;

public class FeatherSlotManager : MonoBehaviour {


    [Range( 0.0f, 50.0f )]
    public float magnetSpeed = 6.0f;

    [Range( 0.0f, 50.0f )]
    public float rotationMagnetSpeed = 6.0f;


    [Range( 0.0f, 0.5f )]
    public float minDistToCompleteMagnet = .2f;

    FeatherSlot[] featherSlots;
    int numSlottedFeathers = 0;

    [Range( 1, 20 )]
    public int testDropNumFeathers;

	void Start () 
    {
        featherSlots = GetComponentsInChildren<FeatherSlot>();
	}
    void Update()
    {
        if(Input.GetKeyDown(KeyCode.Space))
        {
            DropFeathers(testDropNumFeathers);
        }
    }
    public void MagentFeather(Feather feather)
    {

        if( !IsFull())
        {
            featherSlots[numSlottedFeathers].AttractFeather(feather.transform);
            numSlottedFeathers++;
        }
        else
        {
            print("cancel magnet Feather");
            feather.Detatch();
        }
    }
    public bool IsFull()
    {
        return(numSlottedFeathers >= featherSlots.Length);
    }
    public void DropFeathers(int amount)
    {
        numSlottedFeathers--;
        print( "losing num feathers :" + amount );
        if(numSlottedFeathers < 0)
        {
            numSlottedFeathers = 0;
            return;
        }
        featherSlots[numSlottedFeathers].DropFeather();
    }
}

using UnityEngine;
using System.Collections;

public class FeatherMagnetTest : MonoBehaviour 
{
    public FeatherSlot targetSlot;
	// Use this for initialization
	void Start () {
	
	}
	
	// Update is called once per frame
	void Update () 
    {
	    if(Input.GetKeyDown(KeyCode.Space))
        {
            if(targetSlot.CanAttractFeather())
            {
                targetSlot.AttractFeather(this.transform);
            }
        }
	}
}

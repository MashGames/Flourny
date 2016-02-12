using UnityEngine;
using System.Collections;

public class FeatherManager : MonoBehaviour 
{
    public FeatherSlotManager featherSlotManager;
    Feather[] feathers;
    public Color color1;
    public Color color2;

    private Color currentFeatherColor;
    public Material featherMat;
    public float trasitionSpeed = 1.0f;
    float percent = 0.0f;

    bool incresing = true;
	// Use this for initialization
	void Start () 
    {
        currentFeatherColor = color1;
        feathers = GetComponentsInChildren<Feather>();
	}
    void Update()
    {
        percent += trasitionSpeed * Time.deltaTime;

        if( incresing )
        {
            currentFeatherColor = Color.Lerp( color1, color2, percent );
            if( percent >= 1.0f )
            {
                incresing = false;
                percent = 0.0f;
            }
        }
        else
        {
            currentFeatherColor = Color.Lerp( color2, color1, percent );
            if( percent >= 1.0f )
            {
                incresing = true;
                percent = 0.0f;
            }
        }
        featherMat.color = currentFeatherColor;
    }
	
}

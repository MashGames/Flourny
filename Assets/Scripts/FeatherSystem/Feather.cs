using UnityEngine;
using System.Collections;


[RequireComponent(typeof(SphereCollider))]
public class Feather : MonoBehaviour 
{
    FeatherManager manager;
    public FeatherSlotManager slotManager;
    SphereCollider collider;
    Rigidbody myBody;
    public LayerMask inactiveFeatherLayer;
    bool isAttached = false;
    void Awake()
    {
        collider = GetComponent<SphereCollider>();
        collider.isTrigger = true;
        myBody = GetComponent<Rigidbody>();

    }
    void Start()
    {
        manager = GetComponentInParent<FeatherManager>();
    }
    void OnTriggerEnter()
    {
        if( !slotManager.IsFull())
        if(!isAttached)
        {
            this.gameObject.layer = inactiveFeatherLayer;
            print("AddFeather");
            manager.featherSlotManager.MagentFeather(this);
            isAttached = true;
        }

    }
    public bool IsAttached()
    {
        return isAttached;
    }
    public void Detatch()
    {
        isAttached = false;
    }
    public void Drop()
    {
        myBody.useGravity = true;
        this.transform.SetParent( null );
    }
}

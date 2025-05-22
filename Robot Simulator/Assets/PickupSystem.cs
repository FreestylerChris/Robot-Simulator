using UnityEngine;

public class PickupSystem : MonoBehaviour
{
    public Transform holdPoint;
    public GameObject heldObject;

    public Transform rayOrigin;
    public MeshFilter filter;
    public Mesh Pickup;
    public Mesh DropIt;


    private void Start()
    {
        filter = gameObject.GetComponent<MeshFilter>();
    }

    void Update()
    {
        if (Input.GetKeyDown(KeyCode.E))
        {
            if (heldObject == null)
            {
                Debug.Log("Input in");
                TryPickup();
            }
            else
            {
                Debug.Log("Input out");
                Drop();
            }
        }
    }

    void TryPickup()
    {
 // lower the ray origin a bit
        Debug.DrawRay(rayOrigin.position, rayOrigin.forward * 20f, Color.red, 2f);
        if (Physics.Raycast(rayOrigin.position, rayOrigin.forward, out RaycastHit hit, 20f))
        {
            Debug.Log("object found");
            if (hit.collider.CompareTag("Box"))
            {

                heldObject = hit.collider.gameObject;
                heldObject.GetComponent<Rigidbody>().isKinematic = true;
                heldObject.transform.position = holdPoint.position;
                heldObject.transform.SetParent(holdPoint);
                Debug.Log("box found");
                filter.mesh = Pickup;
            }
            else
            {
                Debug.Log("Tag is not Box, it's: " + hit.collider.tag);
            }
        }
        {
            Debug.Log("Raycast hit nothing");
        }
    }

    void Drop()
    {
        heldObject.GetComponent<Rigidbody>().isKinematic = false;
        heldObject.transform.SetParent(null);
        heldObject = null;
        Debug.Log("box dropped");
        filter.mesh = Pickup;
    }
}


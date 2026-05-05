using UnityEngine;

public class PickupItem : MonoBehaviour
{
    [SerializeField]
    private float pickupRange = 2.6f;
    public PickupBehaviour pickupBehaviour;

    void Update()
    {
        RaycastHit hit;
        if(Physics.Raycast(transform.position, transform.forward, out hit, pickupRange))
        {
            if(hit.collider.CompareTag("Item"))
            {
                Debug.Log("There is an item in front of us");
                if(Input.GetKeyDown(KeyCode.E))
                {
                    pickupBehaviour.DoPickup(hit.transform.gameObject.GetComponent<Item>());
                }
            }
        }
    }
}

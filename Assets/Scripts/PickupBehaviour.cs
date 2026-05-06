using UnityEngine;

public class PickupBehaviour : MonoBehaviour
{
    [SerializeField]
    private MoveBehaviour moveBehaviour;
    [SerializeField]
    private Animator playerAnimator;

    [SerializeField]
    private Inventory inventory;

    private Item currentItem;
    public void DoPickup(Item item)
    {
        if(inventory.IsFull())
        {
            Debug.Log("Inventory is full, cannot pick up : " + item.itemData.name);
            return;
        }

        currentItem = item;
        // Jouer l'animation du personnage pour ramasser l'objet
        playerAnimator.SetTrigger("Pickup");
        // Bloquer le déplacement du joueur pendant qu'on ramasse un objet
        moveBehaviour.canMove = false;

    }

    public void AddItemToInventory()
    {
        inventory.AddItem(currentItem.itemData);
        Destroy(currentItem.gameObject);
        currentItem = null;
    }

    public void ReEnablePlayerMovement()
    {
        moveBehaviour.canMove = true;
    }
}

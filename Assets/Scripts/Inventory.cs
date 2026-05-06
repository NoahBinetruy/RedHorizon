using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class Inventory : MonoBehaviour
{
    [SerializeField]
    private List<ItemData> content = new List<ItemData>();

    [SerializeField]
    private GameObject inventoryUI;

    [SerializeField]
    private Transform inventorySlotsParent;

    const int INVENTORY_SIZE = 24;

    private void Start()
    {
        RefreshContent();
    }

    private void Update()
    {
        if (Input.GetKeyDown(KeyCode.I))
        {
            inventoryUI.SetActive(!inventoryUI.activeSelf);
        }
    }


    public void AddItem(ItemData item)
    {
        content.Add(item);
        RefreshContent();
    }


    public void CloseInventory()
    {
        inventoryUI.SetActive(false);
    }
    
    private void RefreshContent()
    {
        for (int i = 0; i < content.Count; i++)
        {
            inventorySlotsParent.GetChild(i).GetChild(0).GetComponent<Image>().sprite = content[i].visual;
        }
    }

    public bool IsFull()
    {
        return content.Count == INVENTORY_SIZE;
    }
}



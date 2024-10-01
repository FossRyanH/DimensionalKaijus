using UnityEngine;
using System;
using System.Collections.Generic;
using Unity.Mathematics;

public class InventoryPageUI : MonoBehaviour
{
    [SerializeField] InventoryItem itemPrefab;
    [SerializeField] RectTransform contentPanel;
    [SerializeField] InventoryItemDesc itemDesc;

    public Sprite Sprite;
    public int Quantity;
    public string Title, ItemDesc;

    List<InventoryItem> itemList = new List<InventoryItem>();

    public void InitInventory(int inventorySize)
    {
        for (int i = 0; i < inventorySize; i++)
        {
            InventoryItem itemUI = Instantiate(itemPrefab, Vector3.zero, quaternion.identity);
            itemUI.transform.SetParent(contentPanel);
            itemList.Add(itemUI);
            itemUI.ItemClicked += HandleItemSelection;
            itemUI.ItemBeginDrag += HandleBeginDrag;
            itemUI.ItemEndDrag += HandleBeginDrag;
            itemUI.ItemDroppedOn += HandleItemDroppedOn;
            itemUI.RMBClicked += HandleShowItemActions;
        }
    }

    void Awake()
    {
        itemDesc.ResetDescription();
    }

    private void HandleShowItemActions(InventoryItem item)
    {
        // 
    }

    private void HandleItemDroppedOn(InventoryItem item)
    {
        // 
    }

    private void HandleBeginDrag(InventoryItem item)
    {
        // 
    }

    private void HandleItemSelection(InventoryItem item)
    {
        itemDesc.SetDescription(Sprite, Title, ItemDesc);
    }

    public void HideMenu()
    {
        this.gameObject.SetActive(false);
    }

    public void ShowMenu()
    {
        this.gameObject.SetActive(true);
        itemDesc.ResetDescription();
    }
}
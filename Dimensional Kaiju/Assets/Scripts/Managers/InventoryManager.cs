using UnityEngine;

public class InventoryManager : Singleton<InventoryManager>
{
    [SerializeField] InventoryPageUI playerInventoryUI;
    int _inventorySize = 48;

    protected override void Initialize()
    {
        playerInventoryUI.InitInventory(_inventorySize);
    }
}

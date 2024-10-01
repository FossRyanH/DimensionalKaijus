using Unity.VisualScripting;
using UnityEngine;

public class MenuController : MonoBehaviour, IMenuControlListener
{
    [SerializeField] MenuControlChannelSO menuControlChannel;
    [SerializeField] GameObject inventoryObject;

    void Awake()
    {
        menuControlChannel.CloseMenu += CloseMenu;
    }

    void Start()
    {
        inventoryObject.SetActive(false);
    }

    void OnDisable()
    {
        menuControlChannel.CloseMenu -= CloseMenu;
    }

    public void Move(Vector2 movement) {}

    public void Accept() {}

    public void Cancel() {}

    public void CloseMenu()
    {
        GameManager.Instance.CurrentGameState = GameState.OverWorld;
        inventoryObject.GetComponent<InventoryPageUI>().HideMenu();
    }

    public void ShowMenu()
    {
        GameManager.Instance.CurrentGameState = GameState.Menu;
        inventoryObject.GetComponent<InventoryPageUI>().ShowMenu();
    }
}

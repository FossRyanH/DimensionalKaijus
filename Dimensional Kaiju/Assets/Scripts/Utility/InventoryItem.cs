using TMPro;
using UnityEngine;
using UnityEngine.UI;
using System;
using Unity.VisualScripting;
using UnityEngine.EventSystems;

public class InventoryItem : MonoBehaviour
{
    [SerializeField] Image itemImage;
    [SerializeField] TMP_Text quantityText;
    [SerializeField] Image borderImage;

    public event Action<InventoryItem> ItemClicked, ItemDroppedOn, ItemBeginDrag, ItemEndDrag, RMBClicked;

    bool _emptyGridSquare = true;

    void Awake()
    {
        ResetData();
        OnDeselect();
    }

    public void ResetData()
    {
        this.itemImage.gameObject.SetActive(false);
        this.itemImage.enabled =  false;
        _emptyGridSquare = true;
    }

    public void OnDeselect()
    {
        borderImage.enabled = false;
    }

    public void SetData(Sprite sprite, int quantity)
    {
        this.itemImage.gameObject.SetActive(true);
        this.itemImage.enabled = true;
        this.itemImage.sprite = sprite;
        this.itemImage.preserveAspect = true;
        this.quantityText.text = $"{quantity}";
        _emptyGridSquare = false;
    }

    public void Select()
    {
        borderImage.enabled = true;
    }

    public void BeginDrag()
    {
        if (_emptyGridSquare)
            return;
        ItemBeginDrag?.Invoke(this);
    }

    public void DropOnGrid()
    {
        ItemDroppedOn?.Invoke(this);
    }

    public void EndDrag()
    {
        ItemEndDrag?.Invoke(this);
    }

    public void OnPointerClick(BaseEventData data)
    {
        PointerEventData clickData = (PointerEventData)data;

        if (clickData.button == PointerEventData.InputButton.Right)
        {
            RMBClicked?.Invoke(this);
        }
        else
        {
            ItemClicked?.Invoke(this);
        }
    }
}
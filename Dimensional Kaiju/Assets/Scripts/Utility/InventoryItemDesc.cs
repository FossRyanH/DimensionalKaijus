using UnityEngine;
using UnityEngine.UI;
using TMPro;
using System;

public class InventoryItemDesc : MonoBehaviour
{
    [SerializeField] Image itemImage;
    [SerializeField] TMP_Text titleText;
    [SerializeField] TMP_Text descText;

    void Awake()
    {
        ResetDescription();
    }

    public void ResetDescription()
    {
        this.itemImage.gameObject.SetActive(false);
        this.itemImage.enabled = false;
        this.itemImage.preserveAspect = true;
        this.titleText.text = "";
        this.descText.text = "";
    }

    public void SetDescription(Sprite sprite, string itemName, string itemDesc)
    {
        this.itemImage.gameObject.SetActive(true);
        this.itemImage.enabled = true;
        this.itemImage.preserveAspect = true;
        this.itemImage.sprite = sprite;
        this.itemImage.preserveAspect = true;
        this.titleText.text = itemName;
        this.descText.text = itemDesc;
    }
}
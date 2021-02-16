using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using TMPro;

public class Ui_Inventory : MonoBehaviour
{
    private Inventory inventory;
    private Transform itemSlotContainer;
    private Transform itemSlotTemplate;

    private void Awake()
    {
        itemSlotContainer = transform.Find("ItemSlotContainer");
        itemSlotTemplate = itemSlotContainer.Find("ItemSlotTemplate");
    }

    public void SetInventory(Inventory inventory)
    {
        this.inventory = inventory;
        inventory.OnItemListChanged += InventoryItemChanged;
        RefreshInventoryUI();
    }
    private void InventoryItemChanged(object sender, System.EventArgs e)
    {
        RefreshInventoryUI();
    }
    private void RefreshInventoryUI()
    {
        foreach(Transform child in itemSlotContainer)
        {
            if (child == itemSlotTemplate) continue;
            Destroy(child.gameObject);
        }
        
        int x = 0;
        float itemSlotCellSize = 40f;
        foreach(ConsumableItem item in inventory.GetConsumableItems())    //this system works well if the sprites are the same size
        {
            RectTransform itemTransform = Instantiate(itemSlotTemplate, itemSlotContainer).GetComponent<RectTransform>();
            itemTransform.gameObject.SetActive(true);
            itemTransform.anchoredPosition = new Vector2(x * itemSlotCellSize, 0);
            itemTransform.Find("image").GetComponent<Image>().sprite = item.GetSprite();
            itemTransform.Find("amount").GetComponent<TextMeshProUGUI>().SetText(item.amount > 1 ? item.amount.ToString() : "");

            x++;
        }
    }
}

using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using TMPro;
using System;

public class Ui_Inventory : MonoBehaviour
{
    private Inventory inventory;
    private Transform itemSlotContainer;
    private Transform itemSlotTemplate;
    private RectTransform greyBackground;
    private RectTransform darkGreyBackground;
    private float defaultGreySize;
    private float defaultDarkGreySize;
    private Func<IEnumerable> getItemsDelegate;
    bool flag = false;
    private GameManager gameManager;
    private void Awake()
    {
        itemSlotContainer = transform.Find("ItemSlotContainer");
        itemSlotTemplate = itemSlotContainer.Find("ItemSlotTemplate");
        greyBackground = transform.Find("GreyBackground").GetComponent<RectTransform>();
        darkGreyBackground = greyBackground.Find("DarkGreyBackground").GetComponent<RectTransform>();
        defaultGreySize = greyBackground.sizeDelta.x;
        defaultDarkGreySize = darkGreyBackground.sizeDelta.x;
    }
    public void Start()
    {
        gameManager = GameManager.instance;
        gameManager.combatState.OnCombatStateTurnOff += IsNotCombatState;
        gameManager.combatState.OnCombatStateTurnOn += IsInCombatState;
    }
    public void SetInventory(Inventory inventory)
    {
        this.inventory = inventory;
        inventory.OnItemListChanged += InventoryItemChanged;
        getItemsDelegate = inventory.GetCombatItems;
    }
    private void InventoryItemChanged(object sender, System.EventArgs e)
    {
        RefreshInventoryUI();
    }
    private void IsInCombatState(object sender, System.EventArgs e)
    {
        getItemsDelegate = inventory.GetCombatItems;
    }
    private void IsNotCombatState(object sender, System.EventArgs e)
    {
        getItemsDelegate = inventory.GetConsumableItems;
    }

    private void RefreshInventoryUI()
    {
        foreach(Transform child in itemSlotContainer)
        {
            if (child == itemSlotTemplate) continue;
            Destroy(child.gameObject);
        }
        
        int x = 0;
        float itemSlotCellSize = 30f;
        foreach(ConsumableItemA item in getItemsDelegate())    //this system works well if the sprites are the same size
        {
            RectTransform itemTransform = Instantiate(itemSlotTemplate, itemSlotContainer).GetComponent<RectTransform>();
            itemTransform.gameObject.SetActive(true);
            itemTransform.anchoredPosition = new Vector2(x * itemSlotCellSize, 0);
            itemTransform.Find("image").GetComponent<Image>().sprite = item.GetSprite();
            itemTransform.Find("amount").GetComponent<TextMeshProUGUI>().SetText(item.amount > 1 ? item.amount.ToString() : "");
            itemTransform.GetComponentInChildren<UseItemClick>().useitem = item.OnConsumed;
            greyBackground.sizeDelta = new Vector2(defaultGreySize + itemSlotCellSize * x, 50);
            darkGreyBackground.sizeDelta = new Vector2(defaultDarkGreySize + itemSlotCellSize * x, 40);
            x++;
        }
        
    }
}

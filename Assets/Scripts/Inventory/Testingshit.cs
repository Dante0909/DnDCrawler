using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Testingshit : MonoBehaviour
{
    private Inventory inventory;
    [SerializeField] private Ui_Inventory uiInventory;

    private void Awake()
    {
        
    }

    // Start is called before the first frame update
    void Start()
    {
        inventory = new Inventory();
        uiInventory.SetInventory(inventory);
    }

    // Update is called once per frame
    void Update()
    {
        if (Input.GetKeyDown(KeyCode.I)) inventory.AddItem(new HealthPotion());
        if (Input.GetKeyDown(KeyCode.O)) inventory.AddItem(new ManaPotion());
        if (Input.GetKeyDown(KeyCode.P)) inventory.AddItem(new Lockpick());
    }
}

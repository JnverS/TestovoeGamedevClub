using System;
using System.Collections;
using System.Collections.Generic;
using System.Xml;
using UnityEngine;

public class Inventory : MonoBehaviour
{
    public static Inventory instance;
    public List<ItemSlot> itemSlots;

    [SerializeField] private GameObject inventoryPanel;

    void Awake()
    {
        instance = this;
        string savePath = "inventory.json"; // Путь к файлу сохранения

        List<ItemSlot> loadedInventory = InventorySaveManager.LoadInventory(savePath);

        itemSlots = loadedInventory;

    }

    public void AddItem(Item item)
    {
        bool isAdded = false;
        foreach (var slot in itemSlots)
        {
            if (slot.item == item && slot.count < 128)
            {
                slot.count++;
                isAdded = true;
                break;
            }
            else if (slot.item == item && slot.count > 128)
            {
                continue;
            }

        }
        if (!isAdded)
        {
            if (itemSlots.Count == 0)
            {
                var newItemSlot = new ItemSlot(0, item, 1);
                itemSlots.Add(newItemSlot);
            }
            else
            {
                var newItemSlot = new ItemSlot(itemSlots.Count + 1, item, 1);
                itemSlots.Add(newItemSlot);
            }

        }
        InventorySaveManager.SaveInventory(itemSlots, "inventory.json");
        GameEvents.Instance.InvokeInventoryChange();
    }
    // Update is called once per frame
    void Update()
    {

    }
    public void OpenClose()
    {
        inventoryPanel.SetActive(!inventoryPanel.activeSelf);
    }
    public void RemoveItem(ItemSlot itemSlot)
    {
        for (int i = 0; i < itemSlots.Count; i++)
        {
            if (itemSlots[i] == itemSlot)
            {
                itemSlots[i].count--;
                if (itemSlots[i].count == 0)
                {
                    itemSlots.Remove(itemSlots[i]);
                }
            }
        }
        GameEvents.Instance.InvokeInventoryChange();
        InventorySaveManager.SaveInventory(itemSlots, "inventory.json");
    }
}

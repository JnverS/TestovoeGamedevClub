using System;
using System.Collections;
using System.Collections.Generic;
using System.Xml;
using UnityEngine;

public class Inventory : MonoBehaviour
{
    public static Inventory instance;
    [SerializeField] private GameObject inventoryPanel;
    [SerializeField] List<Item> StartItems = new List<Item>();

    public Dictionary<Item, int> ItemsDic = new Dictionary<Item, int>();
    

    void Awake()
    {
        instance = this;
        for (var i = 0 ; i < StartItems.Count; i++)
        {
            AddItem(StartItems[i]);
        }
    }

    public void AddItem(Item item)
    {
        if (ItemsDic.ContainsKey(item))
        {
            ItemsDic[item]++;
        }
        else
        {
            ItemsDic[item] = 1;
        }
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
    public void RemoveItem(Item item)
    {
        if (ItemsDic.ContainsKey(item))
        {
            ItemsDic[item]--;
            if (ItemsDic[item] == 0)
            {
                ItemsDic.Remove(item);
                GameEvents.Instance.InvokeInventoryChange();
            }
        }
    }
}

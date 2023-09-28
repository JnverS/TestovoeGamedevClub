using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Inventory : MonoBehaviour
{
    [SerializeField] private GameObject inventoryPanel;
    [SerializeField] List<Item> StartItems = new List<Item>();
    public List<Item> Items = new List<Item>();
    void Start()
    {
        for (var i = 0 ; i < StartItems.Count; i++)
        {
            AddItem(StartItems[i]);
        }
    }

    public void AddItem(Item item)
    {
       Items.Add(item);
    }

    // Update is called once per frame
    void Update()
    {
        
    }
    public void OpenClose()
    {
        inventoryPanel.SetActive(!inventoryPanel.activeSelf);
    }
    public void RemoveItem(int index)
    {
        Debug.Log(index);
        Items.RemoveAt(index);
    }
}

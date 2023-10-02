using System.Collections;
using System.Collections.Generic;
using TMPro;
using UnityEngine;
using UnityEngine.UI;

public class InventoryButton : MonoBehaviour
{
    public ItemSlot itemSlot;
    [SerializeField] GameObject delete;
    public int count;
    TMP_Text countText;
    private void Awake()
    {
        countText = GetComponentInChildren<TMP_Text>();
        if (count > 1)
            countText.text = count.ToString();
    }
    private void Update()
    {
        if (count > 1)
            countText.text = count.ToString();
        else
            countText.text = "";
    }
    public void OnInventoryButtonClick()
    {
        delete.SetActive(true);
    }
    public void OnDeleteButtonClick()
    {
        Inventory.instance.RemoveItem(itemSlot);
        delete.SetActive(false);
    }
}

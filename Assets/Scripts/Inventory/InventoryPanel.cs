using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class InventoryPanel : MonoBehaviour
{
    [SerializeField] RectTransform itemsPanel;
    [SerializeField] GameObject InventoryPrafeb;

    List<GameObject> drawnButtons = new List<GameObject>();
    void Start()
    {
        Redraw();
    }
    private void OnEnable()
    {
        GameEvents.Instance.OnItemAdded += Redraw;
    }
   
    public void Redraw()
    {
        ClearDrawn();
        foreach (var i in Inventory.instance.itemSlots)
        {
            var itemSlot = i;
            var buttonItem = Instantiate(InventoryPrafeb, itemsPanel);
            buttonItem.transform.SetParent(itemsPanel);
            buttonItem.GetComponent<Image>().sprite = itemSlot.item.icon;
            buttonItem.GetComponent<InventoryButton>().itemSlot = itemSlot;
            buttonItem.GetComponent<InventoryButton>().count = itemSlot.count;
            drawnButtons.Add(buttonItem);
        }
    }
   
    void ClearDrawn()
    {
        for (var i = 0;i < drawnButtons.Count;i++)
        {
            Destroy(drawnButtons[i]);
        }
        drawnButtons.Clear();
    }

}


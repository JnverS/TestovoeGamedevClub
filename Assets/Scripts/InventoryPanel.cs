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
    // Update is called once per frame
    public void Redraw()
    {
        ClearDrawn();
        foreach (var i in Inventory.instance.ItemsDic)
        {
           
           /*
            var buttonItem = new GameObject();
            Button buttonComponent = buttonItem.AddComponent<Button>();
            buttonItem.AddComponent<Image>().sprite = item.icon;
            */
            var item = i;
            var buttonItem = Instantiate(InventoryPrafeb, itemsPanel);
            buttonItem.transform.SetParent(itemsPanel);
            buttonItem.GetComponent<Image>().sprite = item.Key.icon;
            buttonItem.GetComponent<InventoryButton>().item = item.Key;
            buttonItem.GetComponent<InventoryButton>().count = item.Value;
           // buttonComponent.onClick.AddListener(() => OnInventoryButtonClick(index, buttonItem));
            drawnButtons.Add(buttonItem);
        }
    }
    // �����-���������� ������� OnClick
    public void OnInventoryButtonClick(int index, GameObject button)
    {
        /*GameObject buttonGameObject = new GameObject("MyButton");

        Button buttonComponent = buttonGameObject.AddComponent<Button>();

        buttonGameObject.transform.SetParent(button.transform, false);

        // �������� ��������� ��������� ��� ����������� ������ �� ������
        GameObject textGameObject = new GameObject("ButtonText");
        Text textComponent = textGameObject.AddComponent<Text>();
        textComponent.text = "Delete"; // ���������� ����� �� ������
        textComponent.font = Resources.GetBuiltinResource<Font>("Arial.ttf"); // ���������� �����
        textComponent.fontSize = 24; // ���������� ������ ������
        textComponent.alignment = TextAnchor.MiddleCenter; // ������������ ������

        // ���������� ������������ ������ ��� ������, ����� �� ����������� �� ������
        textGameObject.transform.SetParent(buttonGameObject.transform, false);

        // �������� ���������� ������� OnClick ��� ������
        //buttonComponent.onClick.AddListener(() => OnDeleteButtonClick(index));*/
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


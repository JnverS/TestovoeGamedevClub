using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class InventoryPanel : MonoBehaviour
{
    [SerializeField] Inventory targetInventory;
    [SerializeField] RectTransform itemsPanel;

    List<GameObject> drawnButtons = new List<GameObject>();
    void Start()
    {
        Redraw();
    }

    // Update is called once per frame
    void Redraw()
    {
        ClearDrawn();
        for (var i = 0; i < targetInventory.Items.Count; i++)
        {
            int index = i;
            var item = targetInventory.Items[i];
            var buttonItem = new GameObject(item.name);
            Button buttonComponent = buttonItem.AddComponent<Button>();
            buttonItem.AddComponent<Image>().sprite = item.icon;
            buttonItem.transform.SetParent(itemsPanel);
            buttonComponent.onClick.AddListener(() => OnClickHandler(index, buttonItem));
            drawnButtons.Add(buttonItem);
        }
    }
    // �����-���������� ������� OnClick
    void OnClickHandler(int index, GameObject button)
    {
        GameObject buttonGameObject = new GameObject("MyButton");

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
        buttonComponent.onClick.AddListener(() => OnClickHandler2(index));
    }
    void OnClickHandler2(int index)
    {
        targetInventory.RemoveItem(index);
        Redraw();
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


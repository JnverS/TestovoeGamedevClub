using System.Collections;
using System.Collections.Generic;
using TMPro;
using UnityEngine;
using UnityEngine.UI;

public class InventoryButton : MonoBehaviour
{
    public Item item;
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
        delete.SetActive(true);
    }
    public void OnDeleteButtonClick()
    {
        Inventory.instance.RemoveItem(item);
    }
}

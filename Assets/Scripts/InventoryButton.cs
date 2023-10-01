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

        // Создайте текстовый компонент для отображения текста на кнопке
        GameObject textGameObject = new GameObject("ButtonText");
        Text textComponent = textGameObject.AddComponent<Text>();
        textComponent.text = "Delete"; // Установите текст на кнопке
        textComponent.font = Resources.GetBuiltinResource<Font>("Arial.ttf"); // Установите шрифт
        textComponent.fontSize = 24; // Установите размер шрифта
        textComponent.alignment = TextAnchor.MiddleCenter; // Выравнивание текста

        // Установите родительский объект для текста, чтобы он отобразился на кнопке
        textGameObject.transform.SetParent(buttonGameObject.transform, false);

        // Добавьте обработчик события OnClick для кнопки
        //buttonComponent.onClick.AddListener(() => OnDeleteButtonClick(index));*/
        delete.SetActive(true);
    }
    public void OnDeleteButtonClick()
    {
        Inventory.instance.RemoveItem(item);
    }
}

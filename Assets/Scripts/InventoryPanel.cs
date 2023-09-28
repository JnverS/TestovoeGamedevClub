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
    // Метод-обработчик события OnClick
    void OnClickHandler(int index, GameObject button)
    {
        GameObject buttonGameObject = new GameObject("MyButton");

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


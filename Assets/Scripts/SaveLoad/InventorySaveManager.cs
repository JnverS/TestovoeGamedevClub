using System;
using System.Collections;
using System.Collections.Generic;
using System.IO;
using System.Text;
using UnityEngine;

public class InventorySaveManager : MonoBehaviour
{
    public static void SaveInventory(List<ItemSlot> inventory, string savePath)
    {

        try
        {
            StringBuilder stringBuilder = new StringBuilder();



            // Преобразуем StringBuilder в строку
            string result = stringBuilder.ToString();

            foreach (ItemSlot slot in inventory)
            {
                string json = JsonUtility.ToJson(slot);
                stringBuilder.AppendLine(json);
            }

            File.WriteAllText(savePath, stringBuilder.ToString());

        }
        catch (Exception e)
        {
            Debug.LogError("Ошибка при сохранении в JSON: " + e.Message);
        }
    }

    public static List<ItemSlot> LoadInventory(string savePath)
    {
        List<ItemSlot> loadedItemList = new List<ItemSlot>();
        if (File.Exists(savePath))
        {
            StringBuilder sb = new StringBuilder();
            var json = File.ReadAllText(savePath);
            StringReader reader = new StringReader(json);
            while (true)
            {
                var line = reader.ReadLine();
                if (line == null) break;
                loadedItemList.Add(JsonUtility.FromJson<ItemSlot>(line));
            }
        }
        return loadedItemList;
    }
}

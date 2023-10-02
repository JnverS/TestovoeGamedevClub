using System.Collections;
using System.Collections.Generic;
using Unity.VisualScripting;
using UnityEngine;

public class LootSystem : MonoBehaviour
{
    [SerializeField] private List<Item> Bonuses = new List<Item>();
    [SerializeField] GameObject ItemPrefab;
    public void GiveLoot(Transform position)
    {
        int index = Random.Range(0, Bonuses.Count);
        if (Bonuses[index] != null && position != null)
        {
            GameObject instantiatedObject = Instantiate(ItemPrefab, transform);
            instantiatedObject.GetComponent<SpriteRenderer>().sprite = Bonuses[index].icon;
            instantiatedObject.GetComponent<SpriteRenderer>().sortingLayerName = "Objects";
            instantiatedObject.transform.position = position.position;
            instantiatedObject.AddComponent<BoxCollider2D>();
            instantiatedObject.GetComponent<BoxCollider2D>().isTrigger = true;
            instantiatedObject.GetComponent<PickUpObject>().item = Bonuses[index];
        }
    }
}

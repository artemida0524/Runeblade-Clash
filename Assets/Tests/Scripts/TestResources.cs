using Game.Core.ResourceItem.Card;
using Game.Core.ResourceItem.InventoryItem;
using Game.Core.ResourceItem.Item;
using System.Collections.Generic;
using System.Linq;
using UnityEngine;


public class TestResources : MonoBehaviour
{
    private Dictionary<InventoryItemType, List<IInventoryItemData>> _inventoryItems = new Dictionary<InventoryItemType, List<IInventoryItemData>>();

    private void Start()
    {
        AddInventoryItem(new InventoryItemData("BrrBrrPatapim", InventoryItemType.Rune, 234));
        AddInventoryItem(new InventoryItemData("BrrBrrPatapif", InventoryItemType.Rune, 234));
        AddInventoryItem(new SomeInventoryItemData("BrrBrrPatapim", InventoryItemType.Rune, 234));


        if (TryGetPrimitiveInventoryItem(out IEnumerable<SomeInventoryItemData> runes))
        {
            foreach (var rune in runes)
            {
                Debug.Log($"Rune Name: {rune.Name}, Amount: {rune.Amount}");
            }
        }
    }


    public void AddInventoryItem(IInventoryItemData item)
    {
        if (!_inventoryItems.ContainsKey(item.InventoryItemType))
        {
            _inventoryItems[item.InventoryItemType] = new List<IInventoryItemData>();
        }
        _inventoryItems[item.InventoryItemType].Add(item);
    }


    public bool TryGetInventoryItems(InventoryItemType type, out IEnumerable<IInventoryItemData> collection)
    {
        if (_inventoryItems.ContainsKey(type))
        {
            collection = _inventoryItems[type];
            return true;
        }
        collection = null;
        return false;
    }

    public bool TryGetPrimitiveInventoryItem<T>(out IEnumerable<T> collection) where T : IInventoryItemData
    {
        
        collection = _inventoryItems.Values
            .SelectMany(items => items.OfType<T>())
            .ToList();
        return collection.Any();
    }
}


public class SomeInventoryItemData : InventoryItemData
{
    public SomeInventoryItemData(string name, InventoryItemType type, int amount) : base(name, type, amount)
    {
    }
}
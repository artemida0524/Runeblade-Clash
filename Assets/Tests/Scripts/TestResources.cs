using Game.Core.ResourceItem.InventoryItem;
using Game.Core.ResourceItem.Provider;
using System.Collections.Generic;
using UnityEngine;


public class TestResources : MonoBehaviour
{
    private IInventoryItemsProvider _inventoryItemsProvider = new InventoryItemsProvider();

    private void Start()
    {
        _inventoryItemsProvider.AddItem(new InventoryItemData("BrrBrrPatapim", InventoryItemType.Rune, 234));
        _inventoryItemsProvider.AddItem(new InventoryItemData("BrrBrrPatapim2", InventoryItemType.Rune, 123));
        _inventoryItemsProvider.AddItem(new SomeInventoryItemData("BrrBrrPatapim3", InventoryItemType.Rune, 456));
        _inventoryItemsProvider.AddItem(new SomeInventoryItemData("BrrBrrPatapim3", InventoryItemType.Rune, 456));


        if (_inventoryItemsProvider.TryGetItemsByType(InventoryItemType.Rune, out IEnumerable<InventoryItemData> runes))
        {
            foreach (var rune in runes)
            {
                Debug.Log($"Rune Name: {rune.Name}, Amount: {rune.Amount}");
            }
        }
    }
}


public class SomeInventoryItemData : InventoryItemData
{
    public SomeInventoryItemData(string name, InventoryItemType type, int amount) : base(name, type, amount)
    {
    }
}
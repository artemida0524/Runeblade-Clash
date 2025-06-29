using Game.Core.ResourceItem.InventoryItem;
using System;
using System.Collections.Generic;
using System.Linq;
using UnityEngine;

namespace Game.Core.ResourceItem.Provider
{
    public class InventoryItemsDataProvider : IInventoryItemsDataProvider
    {
        public IEnumerable<IInventoryItemData> Items => _items.Values.SelectMany(itemList => itemList);

        private Dictionary<InventoryItemType, List<IInventoryItemData>> _items = new Dictionary<InventoryItemType, List<IInventoryItemData>>();

        public event Action<IInventoryItemData> OnItemUpdated;
        public event Action<IInventoryItemData> OnItemAdded;
        public event Action<IInventoryItemData> OnItemRemoved;

        public void AddItem(IInventoryItemData itemData)
        {
            if (!_items.ContainsKey(itemData.InventoryItemType))
            {
                _items[itemData.InventoryItemType] = new List<IInventoryItemData> { itemData };
                itemData.OnItemOver += OnItemOverHandler;
                OnItemAdded?.Invoke(itemData);
            }
            else
            {
                var existingItem = _items[itemData.InventoryItemType]
                    .FirstOrDefault(i => i.Name == itemData.Name);

                if (existingItem != null)
                {
                    existingItem.Add(itemData.Amount);
                    OnItemUpdated?.Invoke(existingItem);
                }
                else
                {
                    _items[itemData.InventoryItemType].Add(itemData);
                    itemData.OnItemOver += OnItemOverHandler;
                    OnItemAdded?.Invoke(itemData);
                }
            }
        }

        private void OnItemOverHandler(IInventoryItemData item)
        {
            foreach (var inventoryItem in _items[item.InventoryItemType])
            {
                if(inventoryItem == item)
                {
                    inventoryItem.OnItemOver -= OnItemOverHandler;
                    _items[item.InventoryItemType].Remove(inventoryItem);
                    break;
                }
            }

            OnItemRemoved?.Invoke(item);
            Debug.Log(item + "Removed");
        }

        public bool TryGetItemsByType(InventoryItemType itemType, out IEnumerable<IInventoryItemData> collection)
        {

            if (_items.ContainsKey(itemType))
            {
                collection = _items[itemType];
                return true;
            }
            collection = null;
            return false;
        }

        public bool TryGetItemsByType<T>(InventoryItemType itemType, out IEnumerable<T> collection) where T : IInventoryItemData
        {

            if (_items.ContainsKey(itemType))
            {
                collection = _items[itemType].OfType<T>();
                return collection.Any();
            }
            collection = null;
            return false;
        }
    }
}

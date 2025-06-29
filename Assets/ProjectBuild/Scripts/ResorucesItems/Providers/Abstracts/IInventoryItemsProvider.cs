using Game.Core.ResourceItem.InventoryItem;
using System;
using System.Collections.Generic;

namespace Game.Core.ResourceItem.Provider
{
	public interface IInventoryItemsProvider
	{
		IEnumerable<IInventoryItemData> Items { get; }

		event Action<IInventoryItemData> OnItemAdded;
		event Action<IInventoryItemData> OnItemUpdated;
		event Action<IInventoryItemData> OnItemRemoved;


        void AddItem(IInventoryItemData itemData);
        bool TryGetItemsByType(InventoryItemType itemType, out IEnumerable<IInventoryItemData> collection);
		bool TryGetItemsByType<T>(InventoryItemType itemType, out IEnumerable<T> collection) where T : IInventoryItemData;
	}
}
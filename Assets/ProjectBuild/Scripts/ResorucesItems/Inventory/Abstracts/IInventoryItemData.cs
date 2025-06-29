using Game.Core.ResourceItem.Item;
using System;

namespace Game.Core.ResourceItem.InventoryItem
{
    public interface IInventoryItemData : IItemData, IStat
    {
        new string Name { get; }
        public InventoryItemType InventoryItemType { get; }

        event Action<IInventoryItemData> OnItemOver;

        void Add(int amount);
        bool Spend(int amount);
        int SpendAll();
    }
}

using Game.Core.ResourceItem.Item;

namespace Game.Core.ResourceItem.InventoryItem
{
    public interface IInventoryItemData : IItemData
    {
        int Amount { get; }
        public InventoryItemType InventoryItemType { get; }
    }
}

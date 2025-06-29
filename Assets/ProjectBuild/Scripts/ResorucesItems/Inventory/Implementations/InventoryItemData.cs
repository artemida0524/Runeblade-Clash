using Game.Core.ResourceItem.Item;
using System;

namespace Game.Core.ResourceItem.InventoryItem
{
    public class InventoryItemData : IInventoryItemData
    {
        public string Name { get; protected set; }
        public int Amount { get; protected set; }
        public InventoryItemType InventoryItemType { get; protected set; }

        public event EventHandler OnValueChange;
        public event Action<IInventoryItemData> OnItemOver;

        public InventoryItemData(string name, InventoryItemType type, int amount)
        {
            Name = name;
            Amount = amount;
            InventoryItemType = type;
        }

        public void Add(int amount)
        {
            Amount += amount;
            OnValueChange?.Invoke(this, EventArgs.Empty);
        }

        public bool Spend(int amount)
        {
            if (Amount >= amount)
            {
                Amount -= amount;
                OnValueChange?.Invoke(this, EventArgs.Empty);
                if (Amount <= 0)
                {
                    OnItemOver?.Invoke(this);
                }
                return true;
            }
            return false;

        }

        public int SpendAll()
        {
            int spentAmount = Amount;
            Amount = 0;
            OnValueChange?.Invoke(this, EventArgs.Empty);
            OnItemOver?.Invoke(this);
            return spentAmount;
        }
    }
}
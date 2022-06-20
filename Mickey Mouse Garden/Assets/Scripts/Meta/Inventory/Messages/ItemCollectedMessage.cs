using Meta.Interfaces;

namespace Meta.Inventory {
    public class ItemCollectedMessage<T> : IMessage where T : IInventoryItem {
        public T InventoryItem { get; }

        public ItemCollectedMessage(T item) {
            InventoryItem = item;
        }
    }
}
using Meta.Interfaces;

namespace Meta.Inventory {
    public class ItemCollectedMessage<T> : IMessage where T : IInventoryItem {
        public T Item { get; }

        public ItemCollectedMessage(T item) {
            Item = item;
        }
    }
}
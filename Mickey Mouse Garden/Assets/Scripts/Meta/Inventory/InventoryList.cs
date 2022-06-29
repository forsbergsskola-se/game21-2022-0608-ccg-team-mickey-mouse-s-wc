using System.Collections.Generic;
using Meta.Interfaces;

namespace Meta.Inventory {
    public abstract class InventoryList<T> : ISaveData where T : IInventoryItem {
        public List<T> Items { get; set; }
        public StringGUID ID { get; }
        public void TryLoadData() {
            throw new System.NotImplementedException();
        }

        public void Save() {
            throw new System.NotImplementedException();
        }
    }
}
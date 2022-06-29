using System.Collections;
using System.Collections.Generic;
using Meta.Interfaces;
using Newtonsoft.Json;

namespace Meta.Inventory {
    [System.Serializable]
    [JsonObject]
    public class InventoryList<T> : ISaveData, IEnumerable where T : IInventoryItem {
        public List<T> Items { get; set; } = new List<T>();
        public StringGUID ID { get; }
        
        public async void TryLoadData() {
            await SaveManager.Load<InventoryList<T>>(ID);
        }

        public void Save() {
            SaveManager.Save(this);
        }

        public IEnumerator GetEnumerator() {
            throw new System.NotImplementedException();
        }
    }
}
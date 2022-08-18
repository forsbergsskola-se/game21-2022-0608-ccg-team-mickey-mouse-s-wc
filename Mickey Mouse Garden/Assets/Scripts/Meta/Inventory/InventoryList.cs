using System.Collections.Generic;
using Meta.Interfaces;
using Newtonsoft.Json;

namespace Meta.Inventory {
    [System.Serializable]
    [JsonObject]
    public class InventoryList<T> : ISaveData where T : IInventoryItem {
        public List<T> Items { get; set; } = new List<T>();
        public StringGUID ID { get; }
        
        public InventoryList(StringGUID id) {
            ID =  id;
        }
        
        public async void TryLoadData() {
            var loadedList = await SaveManager.Load<InventoryList<T>>(ID);
            if (loadedList == null){
                return;
            }
            
            Items = loadedList.Items;
        }

        public void Save() {
            SaveManager.Save(this);
        }
    }
}
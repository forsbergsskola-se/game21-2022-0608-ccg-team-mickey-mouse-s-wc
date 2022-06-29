using System;
using System.Collections;
using System.Collections.Generic;
using Meta.Interfaces;
using Newtonsoft.Json;

namespace Meta.Inventory {
    [System.Serializable]
    [JsonObject]
    public abstract class InventoryList<T> : ISaveData, IEnumerable where T : IInventoryItem {
        public List<T> Items { get; set; }
        public StringGUID ID { get; }
        public void TryLoadData() {
            throw new System.NotImplementedException();
        }

        public void Save() {
            throw new System.NotImplementedException();
        }

        public IEnumerator GetEnumerator() {
            throw new System.NotImplementedException();
        }
    }
}
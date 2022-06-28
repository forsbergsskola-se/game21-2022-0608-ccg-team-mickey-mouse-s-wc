using System;
using System.Collections.Generic;
using Meta.Interfaces;
using UnityEngine;

namespace Meta.Inventory {
    public abstract class Inventory<T> : MonoBehaviour where T : IInventoryItem {
        public abstract List<T> Items { get; set; }

        protected void InitBase() {
            Broker.Subscribe<ItemCollectedMessage<T>>(OnItemCollected);
        }

        public void OnItemCollected(ItemCollectedMessage<T> obj) {
            Add(obj.Item);
            CollectOperations(obj.Item);
        }
        
        //Onitemremoved
            // RemoveOperations
        
        public abstract void CollectOperations(T addedItem);         //TODO: Change name to something better

        public void Add(T item) {
            Items.Add(item);
        }

        public void Remove(T item) {
            Items.Remove(item);
        }
        
        private void OnDestroy() {
            Broker.Unsubscribe<ItemCollectedMessage<T>>(OnItemCollected);
        }
    }
}
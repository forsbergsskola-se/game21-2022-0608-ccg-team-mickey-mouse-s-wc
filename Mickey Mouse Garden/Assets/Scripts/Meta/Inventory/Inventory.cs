using System;
using System.Collections.Generic;
using Meta.Interfaces;
using Meta.Inventory.NewSeedInventory;
using UnityEngine;

namespace Meta.Inventory {
    public abstract class Inventory<T> : MonoBehaviour where T : IInventoryItem {
        public abstract InventoryList<T> InventoryList { get; set; }

        protected void InitBase() {
            Broker.Subscribe<AddItemToInventoryMessage<T>>(OnItemCollected);
        }

        private void OnItemCollected(AddItemToInventoryMessage<T> obj) {
            Add(obj.item);
            CollectOperations(obj.item);
        }

        public abstract void CollectOperations(T addedItem);         //TODO: Change name to something better

        public virtual void Add(T item) {
            InventoryList.Items.Add(item);
        }

        public virtual void Remove(T item) {
            InventoryList.Items.Remove(item);
        }
        
        private void OnDestroy() {
            Broker.Unsubscribe<AddItemToInventoryMessage<T>>(OnItemCollected);
        }
    }
}
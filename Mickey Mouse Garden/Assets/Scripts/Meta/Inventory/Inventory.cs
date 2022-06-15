using System;
using System.Collections.Generic;
using Meta.Interfaces;
using UnityEngine;

namespace Meta.Inventory {
    public abstract class Inventory<T> : MonoBehaviour where T : IInventoryItem {
        public abstract List<T> inventory { get; set; }

        protected void InitBase() {
            SubscribeToBrokerMessage();
        }

        public void SubscribeToBrokerMessage() {
            Broker.Subscribe<ItemCollectedMessage<T>>(OnItemCollected);
            //TODO: Subscribe to sold item
        }

        public void OnItemCollected(ItemCollectedMessage<T> obj) {
            Add(obj.InventoryItem);
            CollectOperations(obj.InventoryItem);
        }
        
        public abstract void CollectOperations(T objInventoryItem);         //TODO: Change name to something better

        public void Add(T item) {
            inventory.Add(item);
        }

        public void Remove(T item) {
            inventory.Remove(item);
        }
        
        private void OnDestroy() {
            Broker.Unsubscribe<ItemCollectedMessage<T>>(OnItemCollected);
        }
    }
}
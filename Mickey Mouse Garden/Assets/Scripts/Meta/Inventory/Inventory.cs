using System;
using System.Collections.Generic;
using Meta.Interfaces;
using UnityEngine;

namespace Meta.Inventory {
    public abstract class Inventory<T> : MonoBehaviour where T : IInventoryItem {
        public abstract List<T> inventory { get; set; }
        //Title
        //Inventory pace??

        protected void Init() {
            SubscribeToBrokerMessage();
        }

        /*public void Start() {
            Debug.Log("In inventory start");
            SubscribeToBrokerMessage();
        }*/

        public void SubscribeToBrokerMessage() {
            Broker.Subscribe<ItemCollectedMessage<T>>(OnItemCollected);
        }

        public void OnItemCollected(ItemCollectedMessage<T> obj) {
            Add(obj.InventoryItem);
        }
        
        public void Add(T item) {
            inventory.Add(item);
        }

        public void Remove(T item) {
            inventory.Remove(item);
        }

        //TODO: Ask if this is correct way to unsubscribe
        /*
        private void OnDestroy() {
            Broker.Unsubscribe<ItemCollectedMessage<T>>(OnItemCollected);
        }
        */
    }
}
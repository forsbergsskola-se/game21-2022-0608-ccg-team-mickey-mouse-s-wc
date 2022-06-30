using System;
using Meta.Interfaces;
using UnityEngine;

namespace Meta.Inventory {
    public abstract class Inventory<T> : MonoBehaviour where T : IInventoryItem {
        public abstract InventoryList<T> InventoryList { get; set; }

        void InitBase(){
            LoadList();
            Broker.Subscribe<AddItemToInventoryMessage<T>>(OnItemCollected);
        }

        public virtual void Start(){
            InitBase();
        }

        private void OnItemCollected(AddItemToInventoryMessage<T> obj) {
            Add(obj.item);
            CollectOperations(obj.item);
        }

        public virtual void CollectOperations(T addedItem){}    //TODO: Change name to something better

        public virtual void RemoveOperations(T removedItem){} // Suggestion would be to have this method being called In Remove(); and it would only server
        //As a way for us to expand Remove(); Without any risk at all of removing the base function of it, aka removing from list.

        public void Add(T item) {
            InventoryList.Items.Add(item);
            Debug.Log(item.libraryID + " added to inventory");
            SaveManager.Save(InventoryList);
            
        }

        public void Remove(T item) {
            InventoryList.Items.Remove(item);
            Debug.Log(item.libraryID + " removed from inventory");
            SaveManager.Save(InventoryList);
        }

        public async void LoadList(){
            var loadedInventoryList = await SaveManager.Load<InventoryList<T>>(InventoryList.ID);
            if (loadedInventoryList != null) {
                InventoryList = loadedInventoryList;
            }
        }
        
        private void OnDestroy() {
            Broker.Unsubscribe<AddItemToInventoryMessage<T>>(OnItemCollected);
        }
    }
}
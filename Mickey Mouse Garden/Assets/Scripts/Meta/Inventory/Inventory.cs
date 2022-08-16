using System;
using System.Linq;
using Meta.Interfaces;
using UnityEngine;

namespace Meta.Inventory {
    public abstract class Inventory<T> : MonoBehaviour where T : IInventoryItem {
        public abstract InventoryList<T> InventoryList { get; set; }
        
        public virtual void Awake(){
            LoadList();
        }

        public virtual void Start(){
            InitBase();
        }
        public virtual void OnDisable() {
            Broker.Unsubscribe<AddItemToInventoryMessage<T>>(OnItemCollected);
            Broker.Unsubscribe<RemoveInventoryItemMessage<T>>(OnRemoveInventoryItemMessageReceived);
            Broker.Unsubscribe<AskForUIUpdateMessage<T>>(OnAskForUIUpdateMessageReceived);
        }

        private async void LoadList(){
            var loadedInventoryList = await SaveManager.Load<InventoryList<T>>(InventoryList.ID);
            if (loadedInventoryList != null) {
                InventoryList = loadedInventoryList;
            }
        }

        private void InitBase(){
            Broker.Subscribe<AddItemToInventoryMessage<T>>(OnItemCollected);
            Broker.Subscribe<RemoveInventoryItemMessage<T>>(OnRemoveInventoryItemMessageReceived);
            Broker.Subscribe<AskForUIUpdateMessage<T>>(OnAskForUIUpdateMessageReceived);
        }

        private void OnAskForUIUpdateMessageReceived(AskForUIUpdateMessage<T> obj){
            SendUIUpdateMessage();
        }

        private void SendUIUpdateMessage(){
            Broker.InvokeSubscribers(typeof(UpdateUIMessage<T>), new UpdateUIMessage<T>(InventoryList.Items));
        }

        public virtual void OnRemoveInventoryItemMessageReceived(RemoveInventoryItemMessage<T> message){
            if(message.StringGuid == null){
                //Remove first item by type
                InventoryList.Items.Remove(InventoryList.Items.First(x=> x.libraryID== message.PathID));
                Save();
                return;
            }
            //Remove specific item by string guid
            InventoryList.Items.Remove(InventoryList.Items.Find(x=> x.ID == message.StringGuid));
            Save();
        }
        
        private void OnItemCollected(AddItemToInventoryMessage<T> obj) {
            Add(obj.item);
            CollectOperations(obj.item);
        }

        public virtual void CollectOperations(T addedItem){}    //TODO: Change Name to something better

        public virtual void RemoveOperations(T removedItem){} // Suggestion would be to have this method being called In Remove(); and it would only server
        //As a way for us to expand Remove(); Without any risk at all of removing the base function of it, aka removing from list.

        public void Add(T item) {
            InventoryList.Items.Add(item);
            Save();
        }

        public void Remove(T item) {
            InventoryList.Items.Remove(item);
            Save();
        }

        private void Save(){
            SaveManager.Save(InventoryList);
            SendUIUpdateMessage();
        }
    }
}
using System;
using Meta.Inventory.NewSeedInventory;
using UnityEngine;

namespace Meta.ShoppingSystem{
    [CreateAssetMenu(fileName = "New Seed Config", menuName = "Configs/Seed")]

    public class SeedConfig : ShopItemConfig{
    
        public Rarity rarity;
        public ConfigLibrary<SeedConfig> library;
        
        void OnEnable(){
            AddToLibrary();
        }
        public override void SendCreateItemMessage(string pathID){
            Debug.Log("Invoking Seed Create Message" + " " + pathID);
            var message = new CreateNewInventoryItemMessage<Seed>(pathID);
            Broker.InvokeSubscribers(message.GetType(), message);
        }
        public override void SendRemoveItemMessage(string pathID){
            Debug.Log("Invoking Seed Remove Message" + " " + pathID);
            var message = new RemoveInventoryItemMessage<Seed>(pathID);
            Broker.InvokeSubscribers(message.GetType(), message);
        }

        public override void AddToLibrary(){
            library.AddItemConfig(this);
        }
    }
}







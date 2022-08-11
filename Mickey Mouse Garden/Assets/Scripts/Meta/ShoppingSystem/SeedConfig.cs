using System;
using Meta.Inventory.NewSeedInventory;
using UnityEngine;

namespace Meta.ShoppingSystem{
    [CreateAssetMenu(fileName = "New Seed Config", menuName = "Configs/Seed")]

    public class SeedConfig : ShopItemConfig{
    
        public Rarity rarity;
        public ConfigLibrary<SeedConfig> library;
        
        void OnEnable(){
            TryAddToLibrary();
        }
        public override void SendCreateItemMessage(short libraryID){
            Debug.Log("Invoking Seed Create Message" + " " + libraryID);
            var message = new CreateNewInventoryItemMessage<Seed>(libraryID);
            Broker.InvokeSubscribers(message.GetType(), message);
        }
        public override void SendRemoveItemMessage(short libraryID){
            Debug.Log("Invoking Seed Remove Message" + " " + libraryID);
            var message = new RemoveInventoryItemMessage<Seed>(libraryID);
            Broker.InvokeSubscribers(message.GetType(), message);
        }

        public override void TryAddToLibrary(){
            library.AddItemConfigToLibrary(this);
        }
    }
}







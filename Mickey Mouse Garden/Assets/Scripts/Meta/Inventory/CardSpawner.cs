using UnityEngine;
using Meta.Inventory.FighterInventory;
using Meta.Seeds;

namespace Meta.Inventory {
    public static class CardSpawner {
        public static void SpawnFromSeed(Rarity rarity) {
            //TODO: Based on seed rarity, random chance to spawn card of rarity x
            //Method that does calculation and returns a card should be here

            Card testCard = new Card(new StringGUID(), "Leona", Alignment.Paper, "123", Rarity.Common, 1, 2f, 100f, 2f);
            
            var cardCollectedMessage = new ItemCollectedMessage<Card>(testCard);
            Broker.InvokeSubscribers(cardCollectedMessage.GetType(), cardCollectedMessage);
        }
    }
}
using UnityEngine;
using Meta.Inventory.FighterInventory;
using Meta.Seeds;

namespace Meta.Inventory {
    public static class CardSpawner {
        public static void SpawnCard(Rarity seedRarity) {
            //TODO: Based on seed rarity, random chance to spawn card of rarity x
            //Take from pool of possible champions
            Debug.Log("In card spawner");
            Card testCard = new Card(new StringGUID(), "Leona", Alignment.Paper, "123", Rarity.Common, 1, 2f, 100f, 2f);
            var cardCollectedMessage = new ItemCollectedMessage<Card>(testCard);
            Broker.InvokeSubscribers(cardCollectedMessage.GetType(), cardCollectedMessage);
            Debug.Log("Spawned card invoked");

        }
    }
}
using Meta.Cards;
using UnityEngine;
using Meta.Inventory.FighterInventory;
using Random = UnityEngine.Random;

namespace Meta.Inventory {
    public class CardSpawner : MonoBehaviour{
        public CardLibraryConfig cardLibrary;
        private bool rarityIncrease;

        private void OnEnable(){
            Broker.Subscribe<SpawnCardFromSeed>(CollectRandomCard);
        }

        private void OnDisable(){
            Broker.Unsubscribe<SpawnCardFromSeed>(CollectRandomCard);
        }

        private void CollectRandomCard(SpawnCardFromSeed spawnCardFromSeed){
            //TODO: Based on seed Rarity, random chance to spawn card of Rarity x
            //Method that does calculation and returns a card should be here
            var randomInt = Random.Range(0, cardLibrary.cards.Length);
            var libraryCardConfig = cardLibrary.cards[randomInt];

            var card = new Card(libraryCardConfig.Id){
                ID = new StringGUID().NewGuid(),
                MaxHealth = libraryCardConfig.MaxHealth,
                Attack = libraryCardConfig.Attack,
                Speed = libraryCardConfig.Speed,
                Level = libraryCardConfig.Level,
                Rarity = libraryCardConfig.Rarity,
                Name = libraryCardConfig.Name,
                Alignment = libraryCardConfig.Alignment,
                SpriteIndex = libraryCardConfig.spriteIndex
            };

            var cardCollectedMessage = new AddItemToInventoryMessage<Card>(card, 1);

            Broker.InvokeSubscribers(cardCollectedMessage.GetType(), cardCollectedMessage);
        }
    }
}
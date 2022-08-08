using System.Linq;
using Meta.Cards;
using UnityEngine;
using Meta.Inventory.FighterInventory;
using Random = UnityEngine.Random;

namespace Meta.Inventory {
    public class CardSpawner : MonoBehaviour {
        public CardLibraryConfig cardLibrary;

        private void Awake() {
            Broker.Subscribe<SpawnCardFromSeed>(CollectRandomCard);
        }
        
        private void CollectRandomCard(SpawnCardFromSeed spawnCardFromSeed) {
            //TODO: Based on seed rarity, random chance to spawn card of rarity x
            //Method that does calculation and returns a card should be here
            var randomInt = Random.Range(0, cardLibrary.cards.Length);
            var libraryID = cardLibrary.cards[randomInt].id;
            
            var card = new Card(libraryID);
            
            var cardType = card.GetType();
            
            var propertyInfos =cardType.GetProperties().Where(x => x.Name != "ID" && x.Name != "LibraryID").ToArray(); //Adds all properties of card to array
        
            //Copies values from config to card
            for (int i = 0; i < propertyInfos.Length; i++){
                var propertyName = propertyInfos[i].Name;
                cardType.GetProperty(propertyName)?.SetValue(card,cardLibrary.cards[randomInt].GetType().GetProperty(propertyName));
                Debug.Log("Card property: " + propertyName + " value: " + cardType.GetProperty(propertyName)?.GetValue(card));
            }
            ;
            var cardCollectedMessage = new AddItemToInventoryMessage<Card>(card,1);

            Broker.InvokeSubscribers(cardCollectedMessage.GetType(), cardCollectedMessage);
        }
    }
}
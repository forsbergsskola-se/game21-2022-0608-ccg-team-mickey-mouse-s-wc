using System;
using System.Linq;
using Meta.Cards;
using UnityEngine;
using Meta.Inventory.FighterInventory;

namespace Meta.Inventory {
    public class CardFuser : MonoBehaviour {
        public CardLibraryConfig cardLibrary;
        private bool rarityIncrease;

        private void OnEnable() {
            Broker.Subscribe<CardSacrificedMessage>(OnCardSacrificedMessageReceived);
        }
        private void OnDisable(){
            Broker.Unsubscribe<CardSacrificedMessage>(OnCardSacrificedMessageReceived);
        }
        
        private Card CreateNewCard(CardConfig libraryCardConfig){
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
            
            return card;
        }

        private void SacrificeCards(Card card){
            var removeInventoryItemMessage = new RemoveInventoryItemMessage<Card>(card.libraryID, card.ID);
            Broker.InvokeSubscribers(removeInventoryItemMessage.GetType(), removeInventoryItemMessage);
        }
        
        private void OnCardSacrificedMessageReceived(CardSacrificedMessage obj){
            FuseCards(obj.Card1, obj.Card2);
        }
        private void FuseCards(Card card1, Card card2){
            SpawnFusedCard(card1, card2);
            SacrificeCards(card1);
            SacrificeCards(card2);
        }

        private void SpawnFusedCard(Card card1, Card card2){
            var fusedCard = CreateNewCard(cardLibrary.cards.First(x => x.Id == card1.libraryID));
            var cardConfig = cardLibrary.cards[fusedCard.SpriteIndex];

            fusedCard.ID = new StringGUID().NewGuid();
            fusedCard.Level = IncreaseCardLevel(card1, card2); 
            fusedCard.Rarity = CheckForRarityIncrease(card1);

            // Takes base stats adds additional stats
            fusedCard.MaxHealth = GenerateNewStats(fusedCard, cardConfig.HealthMultiplier, fusedCard.MaxHealth, cardConfig.Rarity);
            fusedCard.Attack = GenerateNewStats(fusedCard, cardConfig.AttackMultiplier, fusedCard.Attack, cardConfig.Rarity);
            fusedCard.Speed = GenerateNewStats(fusedCard, cardConfig.SpeedMultiplier, fusedCard.Speed, cardConfig.Rarity);
            
            fusedCard.Name = card1.Name;
            fusedCard.Alignment = card1.Alignment;
            fusedCard.SpriteIndex = card1.SpriteIndex;
            
            rarityIncrease = false;

            var cardCollectedMessage = new AddItemToInventoryMessage<Card>(fusedCard,1);
            Broker.InvokeSubscribers(cardCollectedMessage.GetType(), cardCollectedMessage);	
        }

        private short IncreaseCardLevel(Card card1, Card card2){
            var newLevel = (short) (card1.Level + card2.Level);
            if (newLevel > 10) {
                newLevel = 1;
                rarityIncrease = true;
                
                return newLevel;
            }
            
            return newLevel;
        }

        private Rarity CheckForRarityIncrease(Card card1){
            if (!rarityIncrease){
                return card1.Rarity;
            }
            return card1.Rarity switch {
                Rarity.Common => Rarity.Rare,
                Rarity.Rare => Rarity.Epic,
                Rarity.Epic => Rarity.Legendary,
                Rarity.Legendary => Rarity.Legendary,
                _ => throw new ArgumentOutOfRangeException()
            };
        }
        
        private float GenerateNewStats(Card fusedCard, float statsMultiplier, float statComponent, Rarity cardConfigRarity){
            // Get commonBase stats.
            var commonBaseComponent = statComponent - (int)cardConfigRarity * statsMultiplier;
            // Return the difference from common rarity to current rarity and level.
            var newStats = commonBaseComponent + (fusedCard.Level - 1 + (int)fusedCard.Rarity) * statsMultiplier;
            
            return MathF.Floor(newStats);
        }
    }
}
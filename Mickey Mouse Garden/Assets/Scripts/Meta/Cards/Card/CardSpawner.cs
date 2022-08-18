using System;
using System.Collections.Generic;
using System.Linq;
using Meta.Cards;
using UnityEngine;
using Meta.Inventory.FighterInventory;
using Random = UnityEngine.Random;

namespace Meta.Inventory {
    public class CardSpawner : MonoBehaviour{
        public CardLibraryConfig cardLibrary;

        [Tooltip("Enter chance in decimals")]
        [SerializeField] private float commonChanceToSpawnHigher;
        [SerializeField] private float rareChanceToSpawnHigher;
        [SerializeField] private float epicChanceToSpawnHigher;

        private bool rarityIncrease;

        private void OnEnable(){
            Broker.Subscribe<SpawnCardFromSeed>(CollectRandomCard);
        }

        private void OnDisable(){
            Broker.Unsubscribe<SpawnCardFromSeed>(CollectRandomCard);
        }

        private void CollectRandomCard(SpawnCardFromSeed seed) {
            Rarity rarityToSpawn = CalcRarityByChance(seed);

            var cardsOfRarity = cardLibrary.cards.Where(libraryCard => libraryCard.Rarity == rarityToSpawn).ToList();
            var randomSpawnCard = cardsOfRarity.GetRandom();

            var card = new Card(randomSpawnCard.Id){
                ID = new StringGUID().NewGuid(),
                MaxHealth = randomSpawnCard.MaxHealth,
                Attack = randomSpawnCard.Attack,
                Speed = randomSpawnCard.Speed,
                Level = randomSpawnCard.Level,
                Rarity = randomSpawnCard.Rarity,
                Name = randomSpawnCard.Name,
                Alignment = randomSpawnCard.Alignment,
                SpriteIndex = randomSpawnCard.spriteIndex
            };

            var cardCollectedMessage = new AddItemToInventoryMessage<Card>(card, 1);

            Broker.InvokeSubscribers(cardCollectedMessage.GetType(), cardCollectedMessage);
        }

        private Rarity CalcRarityByChance(SpawnCardFromSeed spawnCardFromSeed) {
            float randomNumber = Random.Range(0f, 1f);
            float chance;
            Rarity rarityToSpawn;

            switch (spawnCardFromSeed.Rarity) {
                case Rarity.Common:
                    rarityToSpawn = Rarity.Common;
                    chance = 1 - commonChanceToSpawnHigher;
                    if (randomNumber > chance) {
                        rarityToSpawn = Rarity.Rare;
                    }

                    break;
                case Rarity.Rare:
                    rarityToSpawn = Rarity.Rare;
                    chance = 1 - rareChanceToSpawnHigher;
                    if (randomNumber > chance) {
                        rarityToSpawn = Rarity.Epic;
                    }

                    break;
                case Rarity.Epic:
                    rarityToSpawn = Rarity.Epic;
                    chance = 1 - epicChanceToSpawnHigher;
                    if (randomNumber > chance) {
                        rarityToSpawn = Rarity.Legendary;
                    }

                    break;
                case Rarity.Legendary:
                    rarityToSpawn = Rarity.Legendary;
                    break;
                default:
                    throw new ArgumentOutOfRangeException();
            }

            return rarityToSpawn;
        }
    }
}
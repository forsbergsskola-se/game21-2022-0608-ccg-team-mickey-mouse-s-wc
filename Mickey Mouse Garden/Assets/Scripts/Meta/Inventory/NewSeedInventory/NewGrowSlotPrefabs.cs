using System;
using Meta.Inventory.NewSeedInventory.Messages;
using Meta.Seeds;
using TMPro;
using UnityEngine;
using UnityEngine.UI;

namespace Meta.Inventory.NewSeedInventory {
    public class NewGrowSlotPrefabs : MonoBehaviour {
        public Rarity rarity;
        [SerializeField] private float growthTimeInSeconds;
        
        public bool readyToHarvest;
        
        [SerializeField] private Slider timeSlider;
        [SerializeField] private TextMeshProUGUI growthTimerText;

        private NewSeed seed;
        private string rarityText;

        private float TimeUntilHarvest {
            get {
                TimeSpan timeSpanRemaining = seed.HarvestTime.Subtract(DateTime.Now);
                float secondsRemaining = (float)timeSpanRemaining.TotalSeconds; //TODO: Might need to be changed to other than seconds
                return Mathf.Max(secondsRemaining, 0);
            }
        }

        //TODO: Make slider not clickable

        public void SetUp(NewSeed seedInSlot) {
            if (seedInSlot.HarvestTime == DateTime.MinValue) {
                seedInSlot.HarvestTime = DateTime.Now + TimeSpan.FromSeconds(growthTimeInSeconds);
            }

            seed = seedInSlot;
            rarityText = rarity.ToString();
            timeSlider.maxValue = growthTimeInSeconds;
            timeSlider.value = growthTimeInSeconds;
        }

        private void Update() {
            if (readyToHarvest) return;
            
            if (DateTime.Now > seed.HarvestTime) {
                readyToHarvest = true;
                SendReadyToHarvestMessage();
            }
            
            UpdateTimerText(TimeUntilHarvest);
            timeSlider.value = TimeUntilHarvest;
        }

        private void UpdateTimerText(float timeLeft) {
            growthTimerText.text = $"{rarityText} - {timeLeft.ToString("0")}"; //TODO: Talk w designers for the format
        }

        private void SendReadyToHarvestMessage() {
            var readyToHarvestMessage = new GrowSlotReadyToHarvestMessage(this);
            Broker.InvokeSubscribers(readyToHarvestMessage.GetType(), readyToHarvestMessage);
        }

        //OnClick
        public void RequestHarvest() {
            if (readyToHarvest) {
                var harvestMessage = new HarvestSlotMessage(this);
                Broker.InvokeSubscribers(harvestMessage.GetType(), harvestMessage);
            } else {
                Debug.Log("Not yet ready to be harvested!");
            }
        }

        public void Destroy() {
            Destroy(gameObject);
        }
    }
}
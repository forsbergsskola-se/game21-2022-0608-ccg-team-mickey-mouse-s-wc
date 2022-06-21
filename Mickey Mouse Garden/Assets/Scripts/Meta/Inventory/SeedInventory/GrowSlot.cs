using System;
using Meta.Seeds;
using TMPro;
using UnityEngine;
using UnityEngine.UIElements;
using Slider = UnityEngine.UI.Slider;

namespace Meta.Inventory {
    public class GrowSlot : MonoBehaviour {
        public Rarity rarityType;
        public bool readyToHarvest;

        [SerializeField] private float growTime;
        [SerializeField] private Slider timeSlider;
        [SerializeField] private TextMeshProUGUI growthTimerText;
        [SerializeField] private Sprite seedSprite;

        private string rarityText;
        private float timeUntilToHarvest;

        //TODO: Make slider not clickable
        private void Awake() {
            rarityText = rarityType.ToString();
            timeSlider.maxValue = growTime;
            timeSlider.value = growTime;
            timeUntilToHarvest = growTime;
        }

        private void Update() {
            if (readyToHarvest) return;
            
            if (timeUntilToHarvest > 0) {
                timeUntilToHarvest -= Time.deltaTime;
            } else {
                readyToHarvest = true;
                timeUntilToHarvest = 0;
                timeSlider.value = timeUntilToHarvest;
                SendReadyToHarvestMessage();
            }

            UpdateTimerText(timeUntilToHarvest);
            timeSlider.value = timeUntilToHarvest;
        }

        private void UpdateTimerText(float timeLeft) {
            growthTimerText.text = $"{rarityText} - {timeLeft.ToString()}";
        }

        private void SendReadyToHarvestMessage() {
            var harvestMessage = new ReadyToHarvestMessage(this);
            Broker.InvokeSubscribers(harvestMessage.GetType(), harvestMessage);
        }

        //OnClick
        public void RequestHarvest() {
            if (readyToHarvest) {
                var requestHarvestMessage = new RequestHarvestMessage(this);
                Broker.InvokeSubscribers(requestHarvestMessage.GetType(), requestHarvestMessage);
            } else {
                Debug.Log("Not yet ready to be harvested!");
            }
        }

        public void RemoveEmpty() {
            Destroy(gameObject);
        }
    }
}
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

        private DateTime plantTime;
        private DateTime HarvestTime => plantTime.Add(new TimeSpan(0, 0, Mathf.RoundToInt(growTime)));

        private float TimeUntilHarvest {
            get {
                TimeSpan timeSpanRemaining = HarvestTime.Subtract(DateTime.Now);
                float secondsRemaining = (float)timeSpanRemaining.TotalSeconds;
                return Mathf.Max(secondsRemaining, 0);
            }
        }
        
        private string rarityText;

        //TODO: Make slider not clickable
        private void Awake() {
            plantTime = DateTime.Now;
            rarityText = rarityType.ToString();
            timeSlider.maxValue = growTime;
            timeSlider.value = growTime;
        }

        private void Update() {
            if (readyToHarvest) return;
            
            if (DateTime.Now > HarvestTime) {
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
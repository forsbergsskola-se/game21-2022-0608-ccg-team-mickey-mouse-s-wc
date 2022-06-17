using System;
using Meta.Seeds;
using TMPro;
using UnityEngine;
using UnityEngine.UIElements;
using Slider = UnityEngine.UI.Slider;

namespace Meta.Inventory {
    public class GrowSlot : MonoBehaviour {
        public Rarity rarityType;
        
        [SerializeField] private float growTime;
        [SerializeField] private Slider timeSlider;
        [SerializeField] private TextMeshProUGUI growthTimerText;
        [SerializeField] private Sprite seedSprite;
        
        private bool readyToHarvest;
        private float timeUntilToHarvest;

        //TODO: Make slider not clickable
        private void Awake() {
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
            }

            UpdateTimerText(timeUntilToHarvest);
            timeSlider.value = timeUntilToHarvest;
        }

        private void UpdateTimerText(float timeLeft) {
            growthTimerText.text = timeLeft.ToString();
        }

        public void Harvest() {
            if (readyToHarvest) {
                Debug.Log("Harvest event");
                Destroy(gameObject);
            } else {
                Debug.Log("Not yet ready to be harvested!");
            }
        }
    }
}
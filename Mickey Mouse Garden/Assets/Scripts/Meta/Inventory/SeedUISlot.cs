using System;
using TMPro;
using UnityEngine;

namespace Meta.Inventory {
    public class SeedUISlot : MonoBehaviour {
        public Rarity Rarity;
        [SerializeField] private TextMeshProUGUI countText;

        public void PlantSeedOfRarityType() {
            var plantSeedMessage = new PlantSeedMessage(Rarity);
            Broker.InvokeSubscribers(plantSeedMessage.GetType(), plantSeedMessage);
            Debug.Log(Rarity + ": seed was requested to be planted");
        }

        public void UpdateCountText(int count) {
            countText.text = "x" + count;
        }
    }
}
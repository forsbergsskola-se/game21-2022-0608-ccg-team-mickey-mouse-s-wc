using System;
using TMPro;
using UnityEngine;

namespace Meta.Inventory {
    public class SeedSlot : MonoBehaviour {
        public Rarity Rarity;
        [SerializeField] private TextMeshProUGUI countText;

        public void PlantSeed() {
            var plantSeedMessage = new PlantSeedMessage(Rarity);
            Broker.InvokeSubscribers(plantSeedMessage.GetType(), plantSeedMessage);
        }

        public void UpdateCountText(int count) {
            countText.text = "x" + count;
        }
    }
}
using TMPro;
using UnityEngine;

namespace Meta.Inventory {
    public class SeedSlotContainer : MonoBehaviour {
        public Rarity Rarity;
        [SerializeField] private TextMeshProUGUI rarityText;
        [SerializeField] private TextMeshProUGUI countText;

        private void Awake() {
            rarityText.text = Rarity.ToString();
        }

        public void PlantSeed() {
            var plantSeedMessage = new PlantSeedMessage(Rarity);
            Broker.InvokeSubscribers(plantSeedMessage.GetType(), plantSeedMessage);
        }

        public void UpdateCountText(int count) {
            countText.text = "x" + count;
        }
    }
}
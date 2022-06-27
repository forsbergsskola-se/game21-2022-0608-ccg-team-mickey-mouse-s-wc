using Meta.Inventory.FighterInventory;
using TMPro;
using UnityEngine;
using UnityEngine.UI;

namespace Meta.Cards {
    /// <summary>
    /// The view that's visible on a prefab and makes cards interactable (input and output)
    /// </summary>
    public class CardView : MonoBehaviour {
        public Image image;
        public TextMeshProUGUI name;
        public TextMeshProUGUI maxHealth;
        public TextMeshProUGUI attack;
        public TextMeshProUGUI speed;
        public TextMeshProUGUI alignment;
        public TextMeshProUGUI rarity;
        //TODO: Add level

        public void Configure(CardConfig cardConfig) {
            image.sprite = cardConfig.image;
            name.text = cardConfig.name;
            maxHealth.text = "Health: " + cardConfig.maxHealth.ToString();
            attack.text = "Attack: " + cardConfig.attack.ToString();
            speed.text = "Speed: " + cardConfig.speed.ToString();
            alignment.text = "Alignment: " + cardConfig.alignment.ToString();
            rarity.text = "Rarity: " + cardConfig.rarity.ToString();
            //TODO: Subscribe to level changed message
            //TODO: And save after changed value (or just save on closing the game)
        }
    }
}
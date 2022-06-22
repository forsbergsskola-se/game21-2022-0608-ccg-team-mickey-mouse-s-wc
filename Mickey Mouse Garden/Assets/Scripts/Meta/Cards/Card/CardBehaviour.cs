using Meta.Inventory.FighterInventory;
using TMPro;
using UnityEngine;
using UnityEngine.UI;

namespace Meta.Cards {
    /// <summary>
    /// The view that's visible on a prefab and makes cards interactable (input and output)
    /// </summary>
    public class CardBehaviour : MonoBehaviour {
        public Sprite image;
        public TextMeshProUGUI name;
        public TextMeshProUGUI maxHealth;
        public TextMeshProUGUI attack;
        public TextMeshProUGUI speed;
        public TextMeshProUGUI alignment;
        public TextMeshProUGUI rarity;
        //TODO: Add level

        public void Configure(Card card, CardValues cardValues) {
            name.text = cardValues.name;
            maxHealth.text = "Health: " + cardValues.maxHealth.ToString();
            attack.text = "Attack: " + cardValues.attack.ToString();
            speed.text = "Speed: " + cardValues.speed.ToString();
            alignment.text = "Alignment: " + cardValues.alignment.ToString();
            rarity.text = "Rarity: " + cardValues.rarity.ToString();
            //TODO: Subscribe to level changed message
            //TODO: And save after changed value (or just save on closing the game)
        }
    }
}
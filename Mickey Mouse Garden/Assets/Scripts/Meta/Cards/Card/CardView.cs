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
        public TextMeshProUGUI level;
        [HideInInspector] public string id;

        public void Configure(CardConfig cardConfig) {
            image.sprite = cardConfig.image;
            name.text = cardConfig.name;
            id = cardConfig.id;
            maxHealth.text = $"Health: {cardConfig.maxHealth}";
            attack.text = $"Attack: {cardConfig.attack}";
            speed.text = $"Speed: {cardConfig.speed}";
            alignment.text = $"Alignment: {cardConfig.alignment}";
            rarity.text = $"Rarity: {cardConfig.rarity}";
            //level.text = $"level: {cardConfig.level}"; //TODO: implement when not null
            //TODO: Subscribe to level changed message
            //TODO: And save after changed value (or just save on closing the game)
        }
    }
}
using System.Linq;
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
        [SerializeField] public SpriteLibrarySO spriteLibrary;
        public TextMeshProUGUI name;
        public TextMeshProUGUI maxHealth;
        public TextMeshProUGUI attack;
        public TextMeshProUGUI speed;
        public TextMeshProUGUI alignment;
        public TextMeshProUGUI rarity;
        public TextMeshProUGUI level;
         [HideInInspector] public StringGUID id;

        public void Configure(Card card) {
            // image.sprite = Resources.Load<Sprite>($"Art/CardArt/{card.SpriteName}");
            image.sprite = spriteLibrary.sprites[card.SpriteIndex];
            name.text = card.Name;
            id = card.ID;
            maxHealth.text = $"Health: {card.MaxHealth}";
            attack.text = $"Attack: {card.Attack}";
            speed.text = $"Speed: {card.Speed}";
            alignment.text = $"Alignment: {card.Alignment}";
            rarity.text = $"Rarity: {card.Rarity}";
            level.text = $"Level: {card.Level}"; //TODO: implement when not null
            //TODO: Subscribe to Level changed message
            //TODO: And save after changed value (or just save on closing the game)
        }
        public void Configure(CardConfig card) {
            // image.sprite = Resources.Load<Sprite>($"Art/CardArt/{card.SpriteName}");
            image.sprite = spriteLibrary.sprites[card.spriteIndex];
            name.text = card.Name;
            id = new StringGUID().NewGuid();
            maxHealth.text = $"Health: {card.MaxHealth}";
            attack.text = $"Attack: {card.Attack}";
            speed.text = $"Speed: {card.Speed}";
            alignment.text = $"Alignment: {card.Alignment}";
            rarity.text = $"Rarity: {card.Rarity}";
            level.text = $"Level: {card.Level}"; //TODO: implement when not null
            //TODO: Subscribe to Level changed message
            //TODO: And save after changed value (or just save on closing the game)
        }
    }
}
using UnityEngine;
using UnityEngine.UI;

namespace Meta.Cards {
    /// <summary>
    /// Class for designers to configure values for a kind of card.
    /// </summary>
    [CreateAssetMenu]
    public class CardConfig : ScriptableObject {
        public Sprite image;
        public string name;
        public string id;
        public float maxHealth;
        public float attack;
        public float speed;
        public Alignment alignment;
        public Rarity rarity;
    }
}
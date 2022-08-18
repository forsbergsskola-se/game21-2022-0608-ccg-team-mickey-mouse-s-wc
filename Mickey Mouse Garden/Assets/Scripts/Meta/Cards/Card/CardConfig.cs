using UnityEngine;
using UnityEngine.UI;

namespace Meta.Cards {
    /// <summary>
    /// Class for designers to configure values for a kind of card.
    /// </summary>
    [CreateAssetMenu]
    public class CardConfig : ScriptableObject {
        [Tooltip("Only used for to see correct sprite name")]public Sprite Image;
        public short spriteIndex;
        public string Name;
        public string id;
        public float maxHealth;
        public float attack;
        public float speed;
        public Alignment alignment;
        public Rarity rarity;
        public short level;
        public float healthMultiplier, attackMultiplier, speedMultiplier;
    }
}
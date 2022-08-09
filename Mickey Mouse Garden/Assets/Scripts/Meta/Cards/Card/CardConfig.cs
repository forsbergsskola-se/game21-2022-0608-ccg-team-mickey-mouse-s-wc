using UnityEngine;
using UnityEngine.UI;

namespace Meta.Cards {
    /// <summary>
    /// Class for designers to configure values for a kind of card.
    /// </summary>
    [CreateAssetMenu]
    public class CardConfig : ScriptableObject {
        //TODO: Properties should have capital
        public Sprite Image;
        public string Name;
        public string Id;
        public float MaxHealth;
        public float Attack;
        public float Speed;
        public Alignment Alignment;
        public Rarity Rarity;
        public short Level;
    }
}
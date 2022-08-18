using UnityEngine;

namespace Meta.Cards {
    [CreateAssetMenu(fileName = "New Card Library", menuName = "Library/Card Library")]
    public class CardLibraryConfig : ScriptableObject {
        public CardConfig[] cards;
    }
}
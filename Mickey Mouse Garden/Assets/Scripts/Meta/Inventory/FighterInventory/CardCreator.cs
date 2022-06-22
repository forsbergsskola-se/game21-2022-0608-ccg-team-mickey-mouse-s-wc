using System;
using System.Collections.Generic;
using UnityEditor;
using UnityEngine;

namespace Meta.Inventory.FighterInventory {
    [System.Serializable]
    public class CardCreator : MonoBehaviour {
        public Card[] AllCards = new Card[13];
    }
}
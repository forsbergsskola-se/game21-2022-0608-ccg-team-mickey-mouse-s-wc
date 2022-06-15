using System;
using Meta.Seeds;
using TMPro;
using UnityEngine;

namespace Meta.Inventory {
    public class SeedInventoryUI : MonoBehaviour {
        private SeedSlot[] seedSlots;
        private GrowSlot[] growSlots;
        [SerializeField] private GameObject growSlotPrefab;
        
        private void Start() {
            seedSlots = GetComponentsInChildren<SeedSlot>();
        }

        public void UpdateSeedCount(int count, Rarity rarity) {
            SeedSlot slotToUpdate = null;

            for (int i = 0; i < seedSlots.Length; i++) {
                if (seedSlots[i].Rarity == rarity) {
                    slotToUpdate = seedSlots[i];
                    break;
                }
            }
            
            slotToUpdate.UpdateCountText(count);
        }

        //TODO: Set up icon correctly in inspector
    }
}
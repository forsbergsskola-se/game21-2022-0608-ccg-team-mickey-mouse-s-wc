using System;
using Meta.Seeds;
using TMPro;
using UnityEngine;

namespace Meta.Inventory {
    public class SeedInventoryUI : MonoBehaviour {
        private SeedSlot[] UISlots;
        
        private void Start() {
            UISlots = GetComponentsInChildren<SeedSlot>();
            Debug.Log("UI slots count " + UISlots.Length);
        }

        public void UpdateUISlotCount(int count, Rarity rarity) {
            SeedSlot slotToUpdate = null;
            
            for (int i = 0; i < UISlots.Length; i++) {
                if (UISlots[i].Rarity == rarity) {
                    slotToUpdate = UISlots[i];
                    break;
                }
            }
            
            slotToUpdate.UpdateCountText(count);
        }
        
        //TODO: Set up icon correctly in inspector
    }
}
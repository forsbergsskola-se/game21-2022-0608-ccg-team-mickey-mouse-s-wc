using System;
using Meta.Seeds;
using TMPro;
using UnityEngine;

namespace Meta.Inventory {
    public class UISeedInventory : MonoBehaviour {
        private SeedUISlot[] UISlots;
        
        private void Start() {
            UISlots = GetComponentsInChildren<SeedUISlot>();
            Debug.Log("UI slots count " + UISlots.Length);
        }

        public void UpdateUISlotCount(int count, Rarity rarity) {
            SeedUISlot slotToUpdate = null;
            
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
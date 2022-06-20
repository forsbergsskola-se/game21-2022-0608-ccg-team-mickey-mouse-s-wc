using System;
using System.Linq;
using Meta.Seeds;
using TMPro;
using UnityEngine;

namespace Meta.Inventory {
    public class SeedInventoryUI : MonoBehaviour {
        [SerializeField] private GameObject growSlotItemParent;
        [SerializeField] private GameObject[] growSlotPrefabs;
        
        private SeedSlot[] seedSlots;
        private GrowSlot[] growSlots;
        
        private void Start() {
            seedSlots = GetComponentsInChildren<SeedSlot>();
        }

        public void UpdateSeedCount(int count, Rarity rarity) {
            SeedSlot slotToUpdate = seedSlots.FirstOrDefault(slot => slot.Rarity == rarity);
            slotToUpdate.UpdateCountText(count);
        }

        public void PlantSeedOfType(Rarity rarity) {
            var slotToInstantiate = growSlotPrefabs.First(prefab => prefab.GetComponent<GrowSlot>().rarityType == rarity);
            Instantiate(slotToInstantiate, growSlotItemParent.transform, false);
        }
    }
}
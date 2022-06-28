using System;
using System.Linq;
using Meta.Seeds;
using TMPro;
using UnityEngine;

namespace Meta.Inventory {
    public class SeedInventoryUI : MonoBehaviour {
        [SerializeField] private GameObject growSlotItemParent;
        [SerializeField] private GameObject[] growSlotPrefabs;
        
        private SeedInventorySlotPrefabs[] seedSlots;
        private GrowSlot[] growSlots;
        
        private void Start() {
            seedSlots = GetComponentsInChildren<SeedInventorySlotPrefabs>();
        }

        public void UpdateSeedCount(int count, Rarity rarity) {
            SeedInventorySlotPrefabs inventorySlotPrefabsToUpdate = seedSlots.FirstOrDefault(slot => slot.Rarity == rarity);
            Debug.Log(inventorySlotPrefabsToUpdate.Rarity);
            inventorySlotPrefabsToUpdate.UpdateCountText(count);
        }

        public void PlantSeedOfType(Rarity rarity) {
            var slotToInstantiate = growSlotPrefabs.First(prefab => prefab.GetComponent<GrowSlot>().rarityType == rarity);
            Instantiate(slotToInstantiate, growSlotItemParent.transform, false);
        }
    }
}
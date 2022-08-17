using UnityEngine;
using UnityEngine.UI;

namespace Sound.Scripts {
    public class SoundSettings : MonoBehaviour {
        [SerializeField] private Toggle[] soundToggles;

        public void MuteAll() {
            foreach (var toggle in soundToggles) {
                toggle.isOn = !toggle.isOn;
                toggle.interactable = toggle.isOn;
            }
        }
    }
}
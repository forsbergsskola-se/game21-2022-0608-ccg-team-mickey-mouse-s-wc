using System;
using UnityEngine;
using UnityEngine.UI;

namespace Sound.Scripts {
    public class SoundSettings : MonoBehaviour {
        [SerializeField] private Toggle[] soundToggles;
        private bool muteLock = true;
        private void OnEnable(){
            Broker.Subscribe<SoundToggleMessage>(OnSoundToggleMessageReceived);
        }

        private void OnDisable(){
            Broker.Unsubscribe<SoundToggleMessage>(OnSoundToggleMessageReceived);
        }
        private void OnSoundToggleMessageReceived(SoundToggleMessage obj){
            // Turns Music and SFX off when MuteAll is selected.
            if (obj.Option is 2 && obj.Toggle){
                soundToggles[0].isOn = false;
                soundToggles[1].isOn = false;            
            }
            // Turns Music and SFX on when MuteAll is selected.
            if (obj.Option is 2 && !obj.Toggle){
                soundToggles[0].isOn = true;
                soundToggles[1].isOn = true;
            }
            // Turns MuteAll off when Music is selected.
            if (soundToggles[2].isOn && obj.Toggle && obj.Option is 0){
                soundToggles[2].isOn = false;
                soundToggles[1].isOn = false;
            }
            // Turns MuteAll of when SFX is selected.
            if (soundToggles[2].isOn && obj.Toggle && obj.Option is 1){
                soundToggles[2].isOn = false;
                soundToggles[0].isOn = false;
            }
            // Turns MuteAll on if both Music and SFX are deselected.
            if (!soundToggles[2].isOn && (!soundToggles[0].isOn && obj.Option is 1 && !obj.Toggle || !soundToggles[1].isOn && obj.Option is 0 && !obj.Toggle)){
                soundToggles[2].isOn = true;
            }
        }
    }
}
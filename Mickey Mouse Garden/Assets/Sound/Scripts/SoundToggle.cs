using System;
using UnityEngine;
using UnityEngine.UI;

namespace Sound.Scripts {
    public class SoundToggle : MonoBehaviour {
        [SerializeField] private int toggleIndex;


        public void SendSoundToggleMessage() {
            SoundToggleMessage message = new() {
                Toggle = GetComponent<Toggle>().isOn,
                Option = toggleIndex
            };
            Broker.InvokeSubscribers(typeof(SoundToggleMessage), message);
        }
    }
}
using System.Collections;
using System.Collections.Generic;
using TMPro;
using UnityEngine;
using UnityEngine.UI;

namespace Mickey{
    

    [CustomComponent("Display Reward", "Will be used to display a currency reward to the player", "WIP")]
    public class DisplayReward : MonoBehaviour //TODO: Not Even close to ready, faulty Set Currency method.
    {
        [SerializeField] List<GameObject> AmountFieldObjects;
        [SerializeField] List<GameObject> ImageObjects;
        List<TextMeshProUGUI> textMeshPros;
        List<Image> images;


        void Awake(){
            foreach (var gameObject in AmountFieldObjects){
                textMeshPros.Add(gameObject.GetComponentInChildren<TextMeshProUGUI>());
            }
            foreach (var gameObject in ImageObjects){
                images.Add(gameObject.GetComponentInChildren<Image>());
            }
       
            Broker.Subscribe<CurrencyRewardMessage>(SetCurrency);
        }

        void OnDisable(){
            Broker.Unsubscribe<CurrencyRewardMessage>(SetCurrency);
        }
        public void SetCurrency(CurrencyRewardMessage message){
            for (int i = 0; i < textMeshPros.Count; i++){
                var currentMessageCurrency = message.Currencies[i];
                textMeshPros[i].text = currentMessageCurrency?.Amount.ToString();
                images[i].sprite = currentMessageCurrency?.Sprite;
            }
        }
    }
}
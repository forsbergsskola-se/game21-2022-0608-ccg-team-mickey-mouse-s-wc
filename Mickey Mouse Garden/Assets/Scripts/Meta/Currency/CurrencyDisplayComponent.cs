using System;
using System.Collections;
using System.Collections.Generic;
using TMPro;
using UnityEngine;
using UnityEngine.UI;

public class CurrencyDisplayComponent : MonoBehaviour{
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
       
       Broker.Subscribe<DisplayPlayerCurrencyMessage>(SetCurrency);
   }

   void OnDisable(){
       Broker.Unsubscribe<DisplayPlayerCurrencyMessage>(SetCurrency);
   }
   void Start(){
       Broker.InvokeSubscribers(typeof(AskForPlayerCurrencyMessage),new AskForPlayerCurrencyMessage());
   }

   public void SetCurrency(DisplayPlayerCurrencyMessage message){
       for (int i = 0; i < textMeshPros.Count; i++){
           var currentMessageCurrency = message.Currencies[i];
           textMeshPros[i].text = currentMessageCurrency?.Amount.ToString();
           images[i].sprite = currentMessageCurrency?.Sprite;
       }
   }
}

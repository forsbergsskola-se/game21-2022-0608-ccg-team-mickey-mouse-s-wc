using System;
using System.Collections;
using System.Collections.Generic;
using TMPro;
using UnityEngine;
using UnityEngine.UI;
[CustomComponent("Player Currencies Display Component", "Used to Display Player Currencies.","Finished")]
public class PlayerCurrenciesDisplayComponent : MonoBehaviour{
    [SerializeField]GameObject[] AmountFieldObjects;
    TextMeshProUGUI[] textMeshPros;


    void Awake(){
        Debug.Log(AmountFieldObjects.Length);
        textMeshPros = new TextMeshProUGUI[AmountFieldObjects.Length];

        for (int i = 0; i < AmountFieldObjects.Length; i++){
            textMeshPros[i] = AmountFieldObjects[i].GetComponent<TextMeshProUGUI>();
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
        Debug.Log(message.Currencies.Count);
        for (int i = 0; i < textMeshPros.Length; i++){
            var currentMessageCurrency = message.Currencies[i];
            textMeshPros[i].text = $@"{currentMessageCurrency?.Amount.ToString()} {currentMessageCurrency?.Name}";
        }
    }

    [ContextMenu("TestSendDisplayPlayerCurrencyMessage")]
    public void TestSendDisplayPlayerCurrencyMessage(){
        var currencies = new List<ICurrency>();
        var moneh = new Money();
        moneh.AddAmount(150);
        currencies.Add(moneh);
        var fert = new Fertilizer();
        fert.AddAmount(150);
        currencies.Add(fert);
        var message = new DisplayPlayerCurrencyMessage();
        message.Currencies = currencies;

        Broker.InvokeSubscribers(typeof(DisplayPlayerCurrencyMessage), message);
    }
}

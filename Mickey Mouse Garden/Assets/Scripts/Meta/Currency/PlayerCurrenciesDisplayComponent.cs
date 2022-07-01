using System;
using System.Collections;
using System.Collections.Generic;
using TMPro;
using UnityEngine;
using UnityEngine.UI;
[CustomComponent("Player Currencies Display Component", "Used to Display Player Currencies.",CustomComponentAttributeType.Finished)]
public class PlayerCurrenciesDisplayComponent : MonoBehaviour{
    [SerializeField]GameObject moneyAmountFieldObjects;
    [SerializeField]GameObject fertilizerAmountFieldObjects;
    TextMeshProUGUI moneyTextMeshProUGUI;
    TextMeshProUGUI fertilizerTextMeshProUGUI;

    void Awake(){
        moneyTextMeshProUGUI = moneyAmountFieldObjects.GetComponent<TextMeshProUGUI>();
        fertilizerTextMeshProUGUI =  fertilizerAmountFieldObjects.GetComponent<TextMeshProUGUI>();
        Broker.Subscribe<DisplayPlayerCurrencyMessage>(SetCurrency);
    }
    void OnDisable(){
        Broker.Unsubscribe<DisplayPlayerCurrencyMessage>(SetCurrency);
    }
    void Start(){
        Debug.Log("Invoking AskForPlayerCurrencyMessage");
        Broker.InvokeSubscribers(typeof(AskForPlayerCurrencyMessage),new AskForPlayerCurrencyMessage());
    }

    public void SetCurrency(DisplayPlayerCurrencyMessage message){
        if (message.money != null)
            moneyTextMeshProUGUI.text = $@"{message?.money?.Amount.ToString()} {message?.money?.Name}";
        if (message.fertilizer != null)
            fertilizerTextMeshProUGUI.text = $@"{message?.fertilizer?.Amount.ToString()} {message?.fertilizer?.Name}";
    }

    // [ContextMenu("TestSendDisplayPlayerCurrencyMessage")]
    // public void TestSendDisplayPlayerCurrencyMessage(){
    //     var currencies = new List<ICurrency>();
    //     var moneh = new Money();
    //     moneh.AddAmount(150);
    //     currencies.Add(moneh);
    //     var fert = new Fertilizer();
    //     fert.AddAmount(150);
    //     currencies.Add(fert);
    //     var message = new DisplayPlayerCurrencyMessage();
    //     message.Currencies = currencies;
    //
    //     Broker.InvokeSubscribers(typeof(DisplayPlayerCurrencyMessage), message);
    // }
}

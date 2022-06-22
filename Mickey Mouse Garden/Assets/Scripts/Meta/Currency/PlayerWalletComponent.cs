using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using Color = System.Drawing.Color;


namespace Experiment{
    [CustomComponent("Player Wallet Component", "Will be used to store player currencies.",CustomComponentAttributeType.Experimental)]
    public class PlayerWalletComponent : MonoBehaviour{
        public PlayerWallet wallet;

        void Awake(){
            var Money = new Money();
            var Fertilizer = new Fertilizer();
            List<ICurrency> currencies = new List<ICurrency>();
            currencies.Add(Money);
            currencies.Add(Fertilizer);
        
            wallet = new PlayerWallet(currencies);
        
            Broker.Subscribe<AskForPlayerCurrencyMessage>(SendDisplayInfo);
            Broker.Subscribe<AddPlayerCurrencyMessage>(ChangeCurrencies);
            Broker.Subscribe<CurrencyRewardMessage>(ChangeCurrencies);
        }

        

        void OnDisable(){
            Broker.Unsubscribe<AskForPlayerCurrencyMessage>(SendDisplayInfo);
            Broker.Unsubscribe<AddPlayerCurrencyMessage>(ChangeCurrencies);
            Broker.Unsubscribe<CurrencyRewardMessage>(ChangeCurrencies);
        }
        void UpdateDisplayCurrencies(){
            var displayMessage = new DisplayPlayerCurrencyMessage();
            displayMessage.Currencies = wallet.Currencies;
            Broker.InvokeSubscribers(typeof(DisplayPlayerCurrencyMessage), displayMessage);
        }
        public void SendDisplayInfo(AskForPlayerCurrencyMessage message){
            UpdateDisplayCurrencies();
        }
        
        public void ChangeCurrencies(AddPlayerCurrencyMessage message){ //Doesnt work if not in right order..
            for (int i = 0; i < message.Currencies.Count; i++){
                var walletCurrency = wallet?.Currencies[i];
                var messageCurrency = message.Currencies[i];
                if (walletCurrency?.Name == messageCurrency.Name){
                    walletCurrency?.AddAmount(messageCurrency.Amount);
                    UpdateDisplayCurrencies();
                }
            }
        }
        void ChangeCurrencies(CurrencyRewardMessage message){
            var messageCurrency = message.Currency;
            foreach (var currency in wallet.Currencies){
                if (currency.Name == messageCurrency.Name){
                    currency.AddAmount(messageCurrency.Amount);
                    UpdateDisplayCurrencies();
                    break;
                }
            }
        }
    }
}
using System;
using System.Collections;
using System.Collections.Generic;
using Meta.Currency;
using UnityEngine;
using Color = System.Drawing.Color;


namespace Experiment{
    [CustomComponent("Player Wallet Component", "Will be used to store player currencies.",CustomComponentAttributeType.Almost_Finished)]
    public class PlayerWalletComponent : MonoBehaviour{
        public PlayerWallet wallet;
        public PlayerWalletSO playerWalletSO;

        void Awake(){
            var walletID = new StringGUID().CreateStringGuid(13);
            wallet = new PlayerWallet(walletID);
            
            wallet.TryLoadData();
            wallet.Save();
            wallet.Fertilizer.LoadSprite();
            wallet.Money.LoadSprite();
            playerWalletSO.playerWallet = wallet;
            
        }

        void OnEnable(){
            Debug.Log("Subscribing to AskForPlayerCurrencyMessage",this);
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
            displayMessage.money = wallet.Money;
            displayMessage.fertilizer = wallet.Fertilizer;
            Debug.Log("Invoking DisplayPlayerCurrencyMessage",this);
            Broker.InvokeSubscribers(typeof(DisplayPlayerCurrencyMessage), displayMessage);
        }
        public void SendDisplayInfo(AskForPlayerCurrencyMessage message){
            UpdateDisplayCurrencies();
        }
        
        public void ChangeCurrencies(AddPlayerCurrencyMessage message){
            if (message.money != null) wallet?.Money.AddAmount(message.money.Amount);
            if (message.fertilizer != null) wallet?.Fertilizer.AddAmount(message.fertilizer.Amount);
            wallet?.Save();
            playerWalletSO.playerWallet = wallet;
            UpdateDisplayCurrencies();
        }
        void ChangeCurrencies(CurrencyRewardMessage message){
            if (message.money != null) wallet?.Money.AddAmount(message.money.Amount);
            if (message.fertilizer != null) wallet?.Fertilizer.AddAmount(message.fertilizer.Amount);
            wallet?.Save();
            playerWalletSO.playerWallet = wallet;
            UpdateDisplayCurrencies();
        }
        [ContextMenu("TestAddCurrency")]
        public void TestAddCurrency(){
            var money = new Money();
            money.Amount = 20;
            var fertilizer = new Fertilizer();
            fertilizer.Amount = 20;
            var message = new AddPlayerCurrencyMessage();
            message.money = money;
            message.fertilizer = fertilizer;
            Broker.InvokeSubscribers(typeof(AddPlayerCurrencyMessage), message);
        }
    }
}
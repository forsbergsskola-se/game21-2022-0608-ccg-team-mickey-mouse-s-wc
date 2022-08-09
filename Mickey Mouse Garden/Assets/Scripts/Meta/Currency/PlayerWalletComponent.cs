using System;
using System.Collections;
using System.Collections.Generic;
using Meta.Cards;
using Meta.Currency;
using UnityEngine;
using Color = System.Drawing.Color;


namespace Experiment{
    [CustomComponent("Player Wallet Component", "Will be used to store player currencies.",CustomComponentAttributeType.Almost_Finished)]
    public class PlayerWalletComponent : MonoBehaviour{
        public PlayerWallet wallet;
        public PlayerWalletSO playerWalletSO;


        Money attemptedCombatLedger;

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
            Broker.Subscribe<EnterLevelMessage>(OnLevelMessageReceived);
            Broker.Subscribe<PostCombatStateMessage>(OnPostCombatStateMessageReceived);
        }
        void OnDisable(){
            Broker.Unsubscribe<AskForPlayerCurrencyMessage>(SendDisplayInfo);
            Broker.Unsubscribe<AddPlayerCurrencyMessage>(ChangeCurrencies);
            Broker.Unsubscribe<EnterLevelMessage>(OnLevelMessageReceived);
            Broker.Unsubscribe<PostCombatStateMessage>(OnPostCombatStateMessageReceived);
        }

        void OnLevelMessageReceived(EnterLevelMessage message){
            attemptedCombatLedger = message.Reward;
        }

        void OnPostCombatStateMessageReceived(PostCombatStateMessage message){
            if(message.State == PostCombatState.Victory){
                wallet.Money.AddAmount(attemptedCombatLedger.Amount);
                wallet?.Save();
                playerWalletSO.playerWallet = wallet;
                UpdateDisplayCurrencies();
                
                CurrencyRewardMessage currencyRewardMessage = new(){
                    money = attemptedCombatLedger
                };
                Broker.InvokeSubscribers(typeof(CurrencyRewardMessage), currencyRewardMessage);
            }
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
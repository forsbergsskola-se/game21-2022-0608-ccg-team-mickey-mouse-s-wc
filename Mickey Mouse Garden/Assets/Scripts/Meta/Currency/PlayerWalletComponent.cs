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

        private Money attemptedCombatLedger;

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
                
                playerWalletSO.playerWallet = wallet;
                wallet?.Save();
                UpdateDisplayCurrencies();

                StartCoroutine(DelayCurrencyDisplay());
            }
        }
        
        void UpdateDisplayCurrencies(){
            var displayMessage = new DisplayPlayerCurrencyMessage();
            displayMessage.money = wallet.Money;
            displayMessage.fertilizer = wallet.Fertilizer;
            Broker.InvokeSubscribers(typeof(DisplayPlayerCurrencyMessage), displayMessage);
        }
        
        public void SendDisplayInfo(AskForPlayerCurrencyMessage message){
            UpdateDisplayCurrencies();
        }
        
        public void ChangeCurrencies(AddPlayerCurrencyMessage message){
            if (message.money != null) wallet?.Money.AddAmount(message.money.Amount);
            if (message.fertilizer != null) wallet?.Fertilizer.AddAmount(message.fertilizer.Amount);
            playerWalletSO.playerWallet = wallet;
            wallet?.Save();
            UpdateDisplayCurrencies();
        }

        private IEnumerator DelayCurrencyDisplay(){
            yield return new WaitForSeconds(2.1f);
            CurrencyRewardMessage currencyRewardMessage = new(){
                money = attemptedCombatLedger
            };
            Broker.InvokeSubscribers(typeof(CurrencyRewardMessage), currencyRewardMessage);
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
        
        [ContextMenu("TestAddALotOfCurrency")]
        public void TestAddMegaCurrency(){
            var money = new Money();
            money.Amount = 600;
            var fertilizer = new Fertilizer();
            fertilizer.Amount = 600;
            var message = new AddPlayerCurrencyMessage();
            message.money = money;
            message.fertilizer = fertilizer;
            Broker.InvokeSubscribers(typeof(AddPlayerCurrencyMessage), message);
        }
    }
}
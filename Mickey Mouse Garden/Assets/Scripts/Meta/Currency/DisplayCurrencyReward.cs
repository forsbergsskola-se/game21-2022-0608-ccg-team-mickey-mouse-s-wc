using System.Collections;
using System.Collections.Generic;
using TMPro;
using UnityEngine;
using UnityEngine.UI;

namespace Mickey{
    

    [CustomComponent("Display Currency Reward", "Will be used to display a currency reward to the player",CustomComponentAttributeType.Finished)]
    public class DisplayCurrencyReward : MonoBehaviour 
    {
        [SerializeField]GameObject amountFieldObject;
        TextMeshProUGUI textMeshPro;
        void Awake(){
            textMeshPro = amountFieldObject.GetComponent<TextMeshProUGUI>();
            Broker.Subscribe<CurrencyRewardMessage>(SetCurrency);
        }

        void OnDisable(){
            Broker.Unsubscribe<CurrencyRewardMessage>(SetCurrency);
        }
        public void SetCurrency(CurrencyRewardMessage message){
            textMeshPro.text = $@"{message?.Currency.Amount.ToString()} {message?.Currency.Name}";
        }
        [ContextMenu("TestSendDisplayPlayerCurrencyMessage")]
        public void TestSendCurrencyRewardMessage(){
            var moneh = new Money();
            moneh.AddAmount(150);
            var message = new CurrencyRewardMessage();
            message.Currency = moneh;

            Broker.InvokeSubscribers(typeof(CurrencyRewardMessage), message);
        }
    }
}
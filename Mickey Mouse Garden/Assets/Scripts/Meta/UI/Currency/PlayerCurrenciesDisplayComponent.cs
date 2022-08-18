using TMPro;
using UnityEngine;

[CustomComponent("Player Currencies Display Component", "Used to Display Player Currencies.",CustomComponentAttributeType.Finished)]
public class PlayerCurrenciesDisplayComponent : MonoBehaviour{
    [SerializeField] private GameObject moneyAmountFieldObjects;
    [SerializeField] private GameObject fertilizerAmountFieldObjects;
    private TextMeshProUGUI moneyTextMeshProUGUI;
    private TextMeshProUGUI fertilizerTextMeshProUGUI;

    private void Awake(){
        moneyTextMeshProUGUI = moneyAmountFieldObjects.GetComponent<TextMeshProUGUI>();
        fertilizerTextMeshProUGUI = fertilizerAmountFieldObjects.GetComponent<TextMeshProUGUI>();
        Broker.Subscribe<DisplayPlayerCurrencyMessage>(SetCurrency);
    }

    private void OnEnable(){
        Broker.InvokeSubscribers(typeof(AskForPlayerCurrencyMessage),new AskForPlayerCurrencyMessage());
    }

    private void OnDestroy(){
        Broker.Unsubscribe<DisplayPlayerCurrencyMessage>(SetCurrency);
    }
    
    private void SetCurrency(DisplayPlayerCurrencyMessage message){
        if (message.money != null)
            moneyTextMeshProUGUI.text = $@"{message.money?.Amount.ToString()} {message.money?.Name}";
        if (message.fertilizer != null)
            fertilizerTextMeshProUGUI.text = $@"{message.fertilizer?.Amount.ToString()} {message.fertilizer?.Name}";
    }
}

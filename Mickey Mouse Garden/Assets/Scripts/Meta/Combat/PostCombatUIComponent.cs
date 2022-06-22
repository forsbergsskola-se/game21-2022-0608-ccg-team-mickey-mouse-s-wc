using System;
using System.Collections;
using System.Collections.Generic;
using TMPro;
using UnityEngine;
[CustomComponent("Post Combat UI Component","Small manager to control what UI elements shows up after combat",CustomComponentAttributeType.WIP)]
public class PostCombatUIComponent : MonoBehaviour{
    [SerializeField] GameObject rewardUI;
    [SerializeField] GameObject rewardAmountFieldObject;
    [SerializeField] GameObject stateText;

    TextMeshProUGUI stateUITextMeshProUgui;
    TextMeshProUGUI amountFieldObjecttextMeshPro;
    void Awake(){
        stateUITextMeshProUgui = stateText.GetComponent<TextMeshProUGUI>();
        amountFieldObjecttextMeshPro = rewardAmountFieldObject.GetComponent<TextMeshProUGUI>();
        Broker.Subscribe<PostCombatStateMessage>(ToggleCorrectUI);
        Broker.Subscribe<CurrencyRewardMessage>(SetCurrency);
    }

    void OnDisable(){
        Broker.Unsubscribe<PostCombatStateMessage>(ToggleCorrectUI);
        Broker.Unsubscribe<CurrencyRewardMessage>(SetCurrency);
    }

    void ToggleCorrectUI(PostCombatStateMessage message){
        if (message.State == PostCombatState.Defeat){
            stateUITextMeshProUgui.text = "Defeat";
        }
        else{
            stateUITextMeshProUgui.text = "Victory";
            rewardUI.SetActive(true);
        }
    }
    
    public void SetCurrency(CurrencyRewardMessage message){
        amountFieldObjecttextMeshPro.text = $@"{message?.Currency.Amount.ToString()} {message?.Currency.Name}";
    }

    #region Tests
#if UNITY_EDITOR
    [ContextMenu("TestPostCombatStateMessage")]
    public void TestPostCombatStateMessage(){
        
        var message = new PostCombatStateMessage();
        message.State = PostCombatState.Victory;

        Broker.InvokeSubscribers(typeof(PostCombatStateMessage), message);
    }
    
    [ContextMenu("TestSendDisplayPlayerCurrencyMessage")]
    public void TestSendCurrencyRewardMessage(){
        var moneh = new Money();
        moneh.AddAmount(150);
        var message = new CurrencyRewardMessage();
        message.Currency = moneh;

        Broker.InvokeSubscribers(typeof(CurrencyRewardMessage), message);
    }
#endif

    #endregion
}
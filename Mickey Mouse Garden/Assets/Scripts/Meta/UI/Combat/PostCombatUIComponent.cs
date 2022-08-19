using TMPro;
using UnityEngine;
[CustomComponent("Post Combat UI Component","Small manager to control what UI elements shows up after combat",CustomComponentAttributeType.WIP)]
public class PostCombatUIComponent : MonoBehaviour{
    [SerializeField] GameObject rewardUI;
    [SerializeField] GameObject rewardAmountFieldObject;
    [SerializeField] GameObject stateText;

    TextMeshProUGUI stateUITextMeshProUgui;
    TextMeshProUGUI amountFieldObjecttextMeshPro;
    void OnEnable(){
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
            rewardUI.SetActive(false);
        }
        else{
            stateUITextMeshProUgui.text = "Victory";
            rewardUI.SetActive(true);
        }
    }
    
    public void SetCurrency(CurrencyRewardMessage message){
        if (message?.money?.Amount != 0 ){
            rewardUI.SetActive(true);
            amountFieldObjecttextMeshPro.text = $@"{message?.money?.Amount.ToString()} {message?.money?.Name}";
            return;
        }
        rewardUI.SetActive(false);
    }
}
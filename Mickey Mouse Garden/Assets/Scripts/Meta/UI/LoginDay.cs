using System;
using System.Collections;
using System.Collections.Generic;
using TMPro;
using UnityEngine;
using UnityEngine.UI;

public class LoginDay : MonoBehaviour{
     DateTime date;
    [SerializeField] TextMeshProUGUI rewardText;
    [SerializeField] int amountMoney;
    [SerializeField] GameObject claimedSymbol;
    [SerializeField] int dayNumber;
    [SerializeField] GameObject grayPanel;

    CurrentDay currentDay;
    

    void OnEnable(){
        date = DateTime.Today;
        currentDay = GetComponentInParent<CurrentDay>();
        SetRewardText();
        ActivateClaimedSymbol(false);
    }

    private void SetRewardText(){
        rewardText.text = $"{amountMoney} Money";
    }

    public void OnClick(){
        Money money = new Money();
        money.Amount = amountMoney;
        Broker.InvokeSubscribers(typeof(AddPlayerCurrencyMessage), new AddPlayerCurrencyMessage{money = money});
        ActivateClaimedSymbol(false);
        currentDay.day.claimableDay++;
    }

    void ActivateClaimedSymbol(bool buul){
        claimedSymbol.SetActive(buul);
    }

    void CheckRewardValidity(){
        //Checkmarks previous claimed days
        if(dayNumber < currentDay.day.claimableDay){
            ActivateClaimedSymbol(true);
        }
        //Grays out future days.
        if(dayNumber > currentDay.day.claimableDay ){
            grayPanel.SetActive(true);
        }
        if(date == currentDay.day.dateOfClaim){
           ActivateClaimedSymbol(true);
        }
    }
}

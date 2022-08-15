using System;
using System.Collections;
using System.Collections.Generic;
using TMPro;
using UnityEngine;

public class LoginDay : MonoBehaviour{
     DateTime date;
    [SerializeField] TextMeshProUGUI rewardText;
    [SerializeField] int amountMoney;
    [SerializeField] GameObject claimedSymbol;
    [SerializeField] int dayNumber;

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
    }

    void ActivateClaimedSymbol(bool buul){
        claimedSymbol.SetActive(buul);
    }

    void CheckRewardValidity(){
        if(dayNumber <= currentDay.day.claimedDay){
            ActivateClaimedSymbol(true);
        }
        if(date.Date == currentDay.day.dateOfClaim){
            ActivateClaimedSymbol(false);
        }
    }
}

using System;
using System.Collections;
using System.Collections.Generic;
using TMPro;
using UnityEditor.UI;
using UnityEngine;
using UnityEngine.UI;
using Button = UnityEngine.UIElements.Button;

public class LoginDay : MonoBehaviour{ 
    private DateTime date;
    [SerializeField] TextMeshProUGUI rewardText, dayText;
    [SerializeField] int amountMoney, dayNumber;
    [SerializeField] GameObject claimedSymbol, grayPanel;
    CurrentDay currentDay;
    

    void OnEnable(){
        date = DateTime.Today;
        currentDay = GetComponentInParent<CurrentDay>();
        StartCoroutine(LoadDisplay());
    }

    private void SetText(){
        dayText.text = $"Day {dayNumber}";
        rewardText.text = $"{amountMoney} Money";
    }

    public void OnClick(){
        Money money = new Money{Amount = amountMoney};
        Broker.InvokeSubscribers(typeof(AddPlayerCurrencyMessage), new AddPlayerCurrencyMessage{money = money});
        claimedSymbol.SetActive(true);
        // Glamorify Reward
    }

    void ShowValidReward(){
        // Checkmarks previous claimed days
        Debug.Log(currentDay.day.claimableDay);
        if(dayNumber < currentDay.day.claimableDay){
            claimedSymbol.SetActive(true);
        }
        // Grays out future days.
        if(dayNumber > currentDay.day.claimableDay){
            grayPanel.SetActive(true);
        }
        // Grays out current day if claimed.
        if(dayNumber == currentDay.day.claimableDay && date == currentDay.day.dateOfClaim){
            claimedSymbol.SetActive(true);
        }
    }
    private IEnumerator LoadDisplay(){
        yield return new WaitForSeconds(0.21f);
        SetText();
        ShowValidReward();
    }
}
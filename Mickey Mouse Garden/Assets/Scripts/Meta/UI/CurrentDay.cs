using System;
using System.Collections;
using UnityEngine;

public class CurrentDay : MonoBehaviour{
    public Day day;
    
    void OnEnable(){
        Broker.Subscribe<AddPlayerCurrencyMessage>(OnCurrencyRewardMessageReceived);
        day = new Day();
        day.TryLoadData();
        StartCoroutine(SetClaimableDay());
    }
    
    private void OnCurrencyRewardMessageReceived(AddPlayerCurrencyMessage obj){
        day.dateOfClaim = DateTime.Today;
        day.Save();
    }

    private void OnDisable(){
        Broker.Unsubscribe<AddPlayerCurrencyMessage>(OnCurrencyRewardMessageReceived);
    }
    private IEnumerator SetClaimableDay(){
        yield return new WaitForSeconds(0.1f);

        // If you claimed at least 1 day before
        if (day.dateOfClaim < DateTime.Today){
            day.claimableDay++;
            if (day.claimableDay == 8){
                day.claimableDay = 1;
            }
        }
    }
}
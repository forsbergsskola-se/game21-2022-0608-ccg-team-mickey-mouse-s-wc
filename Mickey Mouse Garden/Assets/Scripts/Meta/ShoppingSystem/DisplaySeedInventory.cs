using System;
using System.Collections;
using System.Collections.Generic;
using Meta.Inventory;
using TMPro;
using UnityEngine;

public class DisplaySeedInventory : MonoBehaviour{
    [SerializeField] private TextMeshProUGUI seedDisplayText;
    int commonSeed = 0;
    int rareSeed = 0;
    int epicSeed = 0;
    int legendarySeed = 0;


    private void Awake(){
        Broker.Subscribe<UpdateSeedUi>(UpdateUi);
    }

    private void Start(){
        Broker.InvokeSubscribers(typeof(AskForUpdateSeedUi), new AskForUpdateSeedUi());
    }

    private void OnDisable(){
        Broker.Unsubscribe<UpdateSeedUi>(UpdateUi);
    }

    private void UpdateUi(UpdateSeedUi message){
        
        
        foreach (var seed in message.Seeds) {
            switch (seed.Rarity) {
                case Rarity.Common:
                    commonSeed++;
                    continue;
                case Rarity.Rare :
                    rareSeed++;
                    continue;
                case Rarity.Epic:
                    epicSeed++;
                    continue;
                case Rarity.Legendary:
                    legendarySeed++;
                    continue;
            }
        }
        DisplayUi();
    }
    
    private void DisplayUi(){
            seedDisplayText.text = "Common: " + commonSeed + " | Rare: " + rareSeed + " | Epic: " + epicSeed + " | Legendary: " + legendarySeed;
        }
    }



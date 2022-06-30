using System;
using System.Collections;
using System.Collections.Generic;
using Meta.Inventory;
using TMPro;
using UnityEngine;

public class DisplaySeedInventory : MonoBehaviour{
    [SerializeField] private TextMeshProUGUI seedDisplayText;


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
        int commonSeed = 0;
        int rareSeed = 0;
        int epicSeed = 0;
        int legendarySeed = 0;
        
        foreach (var seed in message.Seeds) {
            switch (seed.Rarity) {
                case Rarity.Common:
                    commonSeed++;
                    break;
                case Rarity.Rare :
                    rareSeed++;
                    break;
                case Rarity.Epic:
                    epicSeed++;
                    break;
                case Rarity.Legendary:
                    legendarySeed++;
                    break;
            }
        }
        DisplayUi(commonSeed, rareSeed, epicSeed, legendarySeed);
    }
    
    private void DisplayUi(int commonSeed, int rareSeed, int epicSeed, int legendarySeed){
            seedDisplayText.text = @"Seeds:
Common: " + commonSeed + " | Rare: " + rareSeed + " | Epic: " + epicSeed + " | Legendary: " + legendarySeed;
        }
    }



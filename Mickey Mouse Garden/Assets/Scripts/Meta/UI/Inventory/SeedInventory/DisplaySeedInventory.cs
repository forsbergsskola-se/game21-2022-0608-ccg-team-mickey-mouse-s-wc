using Meta.Inventory.SeedInventory;
using TMPro;
using UnityEngine;

public class DisplaySeedInventory : MonoBehaviour{
    [SerializeField] private TextMeshProUGUI seedDisplayText;

    private void Awake(){
        Broker.Subscribe<UpdateUIMessage<Seed>>(UpdateUI);
    }

    private void OnEnable(){
        Broker.InvokeSubscribers(typeof(AskForUIUpdateMessage<Seed>), new AskForUIUpdateMessage<Seed>());
    }
    private void OnDestroy(){
        Broker.Unsubscribe<UpdateUIMessage<Seed>>(UpdateUI);
    }

    /// <summary>
    /// Takes in a list of seeds and displays them in the UI.
    /// Resets the UI on messageReceived and displays the new list of seeds.
    /// </summary>
    /// <param name="message"></param>
    private void UpdateUI(UpdateUIMessage<Seed> message){
        var commonSeed = 0;
        var rareSeed = 0;
        var epicSeed = 0;
        var legendarySeed = 0;
        
        if (message.Content == null){
            DisplayUi(commonSeed, rareSeed, epicSeed, legendarySeed);
            return;
        }
        foreach (var seed in message.Content) {
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
            seedDisplayText.text = @"Your Seeds:
Common: " + commonSeed + " | Rare: " + rareSeed + " | Epic: " + epicSeed + " | Legendary: " + legendarySeed;
        }
    }



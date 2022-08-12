using System;
using System.Collections;
using Meta.Inventory;
using Meta.Inventory.NewSeedInventory.Messages;
using UnityEngine;

public class MainSceneMessageListener : MonoBehaviour{
    private MainSceneSoundManager mainSceneSoundManager;
    private void Awake(){
        mainSceneSoundManager = GetComponent<MainSceneSoundManager>();
        Broker.Subscribe<UIChangedMessage>(OnUIChangedMessageReceived);
        Broker.Subscribe<CreatePostCombatUIMessage>(OnPostCombatUIMessageReceived);
        Broker.Subscribe<SelectedFighterTeamMessage>(OnFighterTeamMessageReceived);
        Broker.Subscribe<PlantSeedMessage>(OnPlantSeedMessageReceived);
        Broker.Subscribe<CamPositionMessage>(OnCamPositionMessageReceived);
        // Fusion to be implemented
        mainSceneSoundManager.PlayMusic();
    }

    private void OnDisable(){
        Broker.Unsubscribe<UIChangedMessage>(OnUIChangedMessageReceived);
        Broker.Unsubscribe<CreatePostCombatUIMessage>(OnPostCombatUIMessageReceived);
        Broker.Unsubscribe<SelectedFighterTeamMessage>(OnFighterTeamMessageReceived);
        Broker.Unsubscribe<PlantSeedMessage>(OnPlantSeedMessageReceived);
        Broker.Unsubscribe<CamPositionMessage>(OnCamPositionMessageReceived);

    }

    private void OnPlantSeedMessageReceived(PlantSeedMessage obj){
        mainSceneSoundManager.PlantSeed();
    }
    
    private void OnFighterTeamMessageReceived(SelectedFighterTeamMessage obj){
        if (!obj.IsPlayerTeam){
            mainSceneSoundManager.StopPreCombatMusic();
        }
    }
    private void OnPostCombatUIMessageReceived(CreatePostCombatUIMessage obj){
        StartCoroutine(DelaySound());
    }
    
    private IEnumerator DelaySound(){
        yield return new WaitForSeconds(2f);
        mainSceneSoundManager.UnPauseMusic();
    }
    
    private void OnCamPositionMessageReceived(CamPositionMessage obj){
        mainSceneSoundManager.ModulateMusic(obj.Distance);
    }


    private void OnUIChangedMessageReceived(UIChangedMessage obj){
        mainSceneSoundManager.MainClick();
        mainSceneSoundManager.StopPreCombatMusic();

        if (obj.ObjectTag == "Arena"){
            mainSceneSoundManager.PauseMusic();
            mainSceneSoundManager.PlayPreCombatMusic();
        }
    }
}

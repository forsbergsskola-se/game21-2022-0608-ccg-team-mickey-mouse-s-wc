using System;
using System.Collections;
using UnityEngine;

public class MainSceneMessageListener : MonoBehaviour{
    private MainSceneSoundManager mainSceneSoundManager;
    private void Awake(){
        mainSceneSoundManager = GetComponent<MainSceneSoundManager>();
        Broker.Subscribe<UIChangedMessage>(OnUIChangedMessageReceived);
        Broker.Subscribe<CreatePostCombatUIMessage>(OnPostCombatUIMessageReceived);
        Broker.Subscribe<SelectedFighterTeamMessage>(OnFighterTeamMessageReceived);
        mainSceneSoundManager.PlayMusic();
    }

    private void OnDisable(){
        Broker.Unsubscribe<UIChangedMessage>(OnUIChangedMessageReceived);
        Broker.Unsubscribe<CreatePostCombatUIMessage>(OnPostCombatUIMessageReceived);
        Broker.Unsubscribe<SelectedFighterTeamMessage>(OnFighterTeamMessageReceived);    
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
    private void OnUIChangedMessageReceived(UIChangedMessage obj){
        mainSceneSoundManager.MainClick();
        switch (obj.ObjectTag){
            // pShop
            case "PShop":
                mainSceneSoundManager.ModulateMusic(4);
                break;
            // shop
            case "Shop":
                mainSceneSoundManager.ModulateMusic(3);
                break;
            // shed
            case "Shed":
                mainSceneSoundManager.ModulateMusic(2);
                break;
            // greenhouse
            
            case "Garden":
                mainSceneSoundManager.ModulateMusic(1);
                break;

            // arena
            case "Arena":
                mainSceneSoundManager.PauseMusic();
                mainSceneSoundManager.PlayPreCombatMusic();
                break;
        }
    }
    
}

using System.Collections;
using Meta.Inventory;
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
        Broker.Subscribe<CardSacrificedMessage>(OnCardSacrificedMessageReceived);
        Broker.Subscribe<AddPlayerCurrencyMessage>(OnAddPlayerCurrencyMessageReceived);
        mainSceneSoundManager.PlayMusic();
    }

    private void OnDisable(){
        Broker.Unsubscribe<UIChangedMessage>(OnUIChangedMessageReceived);
        Broker.Unsubscribe<CreatePostCombatUIMessage>(OnPostCombatUIMessageReceived);
        Broker.Unsubscribe<SelectedFighterTeamMessage>(OnFighterTeamMessageReceived);
        Broker.Unsubscribe<PlantSeedMessage>(OnPlantSeedMessageReceived);
        Broker.Unsubscribe<CamPositionMessage>(OnCamPositionMessageReceived);
        Broker.Unsubscribe<CardSacrificedMessage>(OnCardSacrificedMessageReceived);
        Broker.Unsubscribe<AddPlayerCurrencyMessage>(OnAddPlayerCurrencyMessageReceived);

    }
    private void OnAddPlayerCurrencyMessageReceived(AddPlayerCurrencyMessage obj){
        if (obj.money.Amount <= 0){
            mainSceneSoundManager.Purchase();
        }
        else{
            mainSceneSoundManager.Sell();
        }
    }
    private void OnCardSacrificedMessageReceived(CardSacrificedMessage obj){
        mainSceneSoundManager.Fusion();
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

        if (obj.ObjectTag != "Arena") return;
        mainSceneSoundManager.PauseMusic();
        mainSceneSoundManager.PlayPreCombatMusic();
    }
}

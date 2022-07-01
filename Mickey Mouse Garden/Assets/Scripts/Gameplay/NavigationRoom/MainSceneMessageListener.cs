using UnityEngine;

public class MainSceneMessageListener : MonoBehaviour{
    private MainSceneSoundManager mainSceneSoundManager;
    private void Awake(){
        mainSceneSoundManager = GetComponent<MainSceneSoundManager>();
        Broker.Subscribe<UIChangedMessage>(OnUIChangedMessageReceived);
        mainSceneSoundManager.PlayMusic();
    }
    private void OnUIChangedMessageReceived(UIChangedMessage obj){
        mainSceneSoundManager.StopPreCombatMusic();
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
                mainSceneSoundManager.StopMusic();
                mainSceneSoundManager.PlayPreCombatMusic();
                break;

            // arena2
            case "Arena2":
                mainSceneSoundManager.StopMusic();
                // mainSceneSoundManager.PlayPreCombatMusic();
                break;
        }
    }
    
}

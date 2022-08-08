using System;
using Meta.Cards;
using UnityEngine;
[CustomComponent("Player","Makes player dont destroy on load, also has to be loaded first!")]
public class Player : MonoBehaviour{

    public PlayerLevel playerLevel;
    int attemptedCombatLevel;
    void Awake(){
        DontDestroyOnLoad(this.gameObject);
        playerLevel = new PlayerLevel();
        playerLevel.TryLoadData();
        Broker.Subscribe<LevelMessage>(OnCombatLevelMessageReceived);
        Broker.Subscribe<PostCombatStateMessage>(OnPostCombatStateMessageReceived);
    }

    

    void OnDisable(){
        Broker.Unsubscribe<LevelMessage>(OnCombatLevelMessageReceived);
        Broker.Unsubscribe<PostCombatStateMessage>(OnPostCombatStateMessageReceived);
    }


    private void OnCombatLevelMessageReceived(LevelMessage message){
        attemptedCombatLevel = message.Level;
    }

    void OnPostCombatStateMessageReceived(PostCombatStateMessage message){
        if (message.State == PostCombatState.Victory){
            playerLevel.CheckLevelUp(attemptedCombatLevel);
        }
    }

#if UNITY_EDITOR
    [ContextMenu("TESTINGDeleteAllSaves")]
    public void TestingDeleteAllSaves(){
        SaveManager.DeleteAllSaves();
    }
#endif

   
}

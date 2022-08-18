using System;
using Meta.Cards;
using UnityEngine;
[CustomComponent("Player","Makes player dont destroy on load, also has to be loaded first!")]
public class Player : MonoBehaviour{
    public PlayerLevel playerLevel;
    int attemptedCombatLevel;
    
    void Awake(){
        DontDestroyOnLoad(this.gameObject);
        
        Broker.Subscribe<EnterLevelMessage>(OnCombatLevelMessageReceived);
        Broker.Subscribe<PostCombatStateMessage>(OnPostCombatStateMessageReceived);
    }

    void Start(){
        playerLevel = new PlayerLevel();
        playerLevel.TryLoadData();
    }

    void OnDisable(){
        Broker.Unsubscribe<EnterLevelMessage>(OnCombatLevelMessageReceived);
        Broker.Unsubscribe<PostCombatStateMessage>(OnPostCombatStateMessageReceived);
    }

    private void OnCombatLevelMessageReceived(EnterLevelMessage message){
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

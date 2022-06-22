using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CreatePostCombatUI : MonoBehaviour{
    [SerializeField] GameObject PostCombatUIPrefab;

    void Awake(){
        Broker.Subscribe<CreatePostCombatUIMessage>(CreateUI);
    }

    void OnDisable(){
        Broker.Unsubscribe<CreatePostCombatUIMessage>(CreateUI);
    }

    void CreateUI(CreatePostCombatUIMessage message){
        Instantiate(PostCombatUIPrefab, this.transform);
    }
   
   
    #region Tests
#if UNITY_EDITOR
    [ContextMenu("TestCreatePostCombatUIMessage")]
    public void TestCreatePostCombatUIMessage(){
        var message = new CreatePostCombatUIMessage();
        Broker.InvokeSubscribers(typeof(CreatePostCombatUIMessage), message);
    }
    
  
#endif

    #endregion
}
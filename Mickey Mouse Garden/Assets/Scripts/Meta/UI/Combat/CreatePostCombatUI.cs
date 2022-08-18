using System.Collections;
using UnityEngine;
[CustomComponent("Create Post Combat UI", "Listens to CreatePostCombatUIMessage and creates UI when invoked.", CustomComponentAttributeType.Finished)]
public class CreatePostCombatUI : MonoBehaviour{
    [SerializeField] GameObject PostCombatUICanvas;

    void Awake(){
        Broker.Subscribe<CreatePostCombatUIMessage>(CreateUI);
    }

    void OnDisable(){
        Broker.Unsubscribe<CreatePostCombatUIMessage>(CreateUI);
    }

    void CreateUI(CreatePostCombatUIMessage message){
        StartCoroutine(DelayUI());
    }
    private IEnumerator DelayUI(){
        yield return new WaitForSeconds(1f);
        PostCombatUICanvas.GetComponent<Canvas>().enabled = true;
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
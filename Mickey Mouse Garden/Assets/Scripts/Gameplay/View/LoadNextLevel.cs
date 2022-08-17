using UnityEngine;
using UnityEngine.SceneManagement;

public class LoadNextLevel : MonoBehaviour
{
   public void Continue(){
      SceneManager.UnloadSceneAsync("Arena");
      var msg = new UIChangedMessage{ObjectTag = gameObject.tag, TaskToDo = 2};
      Broker.InvokeSubscribers(typeof(UIChangedMessage),msg);
   }
}

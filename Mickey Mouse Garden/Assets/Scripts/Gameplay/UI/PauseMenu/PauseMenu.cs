using UnityEngine;
using UnityEngine.SceneManagement;

public class PauseMenu : MonoBehaviour{
    [SerializeField] Canvas pauseMenu, pauseButton;
    [SerializeField] private GameObject loginBonusCanvas;
    private GameObject loginBonusButton;

    private void LockClicks(){
        ClickBlockerMessage clickBlockerMessage = new(){UIActive = true};
        Broker.InvokeSubscribers(typeof(ClickBlockerMessage), clickBlockerMessage);
    }

    private void UnLockClicks(){
        ClickBlockerMessage clickBlockerMessage = new(){UIActive = false};
        Broker.InvokeSubscribers(typeof(ClickBlockerMessage), clickBlockerMessage);
    }
    
    public void Start(){
        pauseMenu.enabled = false;
        loginBonusButton = GameObject.FindWithTag("DailyLogin");
        UnLockClicks();
        Broker.Subscribe<UIChangedMessage>(OnUIChangedMessageReceived);
    }

    private void OnDisable(){
        Broker.Unsubscribe<UIChangedMessage>(OnUIChangedMessageReceived);

    }
    private void OnUIChangedMessageReceived(UIChangedMessage obj){
        switch (obj.TaskToDo){
            case 1:
                loginBonusButton.SetActive(false);
                break;
            case 2:
                loginBonusButton.SetActive(true);
                break;
        }
    }
    public void Pause(){
        pauseMenu.enabled = true;
        pauseButton.enabled = false;
        LockClicks();
    }
    public void UnPause(){
        pauseButton.enabled = true;
        pauseMenu.enabled = false;
        UnLockClicks();
    }

    public void MainMenu(){
        SceneManager.UnloadSceneAsync("Arena");
    }
    public void QuitNow(){
        Application.Quit();
    }
    
    public void LaunchBonus(){
        LockClicks();
        loginBonusCanvas.SetActive(true);
        loginBonusButton.SetActive(false);
    }
    public void UnlaunchBonus(){
        UnLockClicks();
        loginBonusCanvas.SetActive(false);
        loginBonusButton.SetActive(true);
    }
}

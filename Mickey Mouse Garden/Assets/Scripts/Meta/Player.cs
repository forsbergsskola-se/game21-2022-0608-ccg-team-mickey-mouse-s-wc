using UnityEngine;
[CustomComponent("Player","Makes player dont destroy on load, also has to be loaded first!")]
public class Player : MonoBehaviour{

    PlayerLevel playerLevel;
    void Awake(){
        DontDestroyOnLoad(this.gameObject);
        playerLevel = new PlayerLevel();
    }

#if UNITY_EDITOR
    [ContextMenu("TESTINGDeleteAllSaves")]
    public void TestingDeleteAllSaves(){
        SaveManager.DeleteAllSaves();
    }
#endif

   
}

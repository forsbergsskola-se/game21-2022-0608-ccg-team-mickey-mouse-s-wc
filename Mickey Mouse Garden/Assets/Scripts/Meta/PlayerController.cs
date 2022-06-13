using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerController : MonoBehaviour, IController{
    [SerializeField] public PlayerSaveData playerModel;
    public void SaveData(){
       // SavingLoading<PlayerSaveData>.Save(playerModel);
    }
    public void LoadData(){
      //  SavingLoading<PlayerSaveData>.Load(playerModel.ID);
    }
}

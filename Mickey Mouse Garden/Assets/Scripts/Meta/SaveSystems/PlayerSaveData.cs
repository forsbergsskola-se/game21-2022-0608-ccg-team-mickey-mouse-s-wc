using System;
using System.Collections;
using System.Collections.Generic;
using System.Threading.Tasks;
using UnityEngine;
[CreateAssetMenu(fileName = "New Player Save Data", menuName = "Player/Player Save Data")]
public class PlayerSaveData : ScriptableObject,ISaveData{
     public int ID{ get; }
     public Task TryLoadData(){
         throw new NotImplementedException();
     }

     public void Save(){
         throw new NotImplementedException();
     }

     public event Action<Guid> saveData;


     public List<FighterSO> fighters;
    //SoftCurrency
    //Fertalizer
    //Seeds;
    //Stamina
    public GameObject prefab;
}

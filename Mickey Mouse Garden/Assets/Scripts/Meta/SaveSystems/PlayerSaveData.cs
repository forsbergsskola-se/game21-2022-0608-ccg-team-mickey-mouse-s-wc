using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
[CreateAssetMenu(fileName = "New Player Save Data", menuName = "Player/Player Save Data")]
public class PlayerSaveData : ScriptableObject,ISaveData{
     public Guid ID{ get; }
     public event Action<Guid> saveData;


     public List<FighterSO> fighters;
    //SoftCurrency
    //Fertalizer
    //Seeds;
    //Stamina
    public GameObject prefab;
}

using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SavableEntity : MonoBehaviour{
    
    [SerializeField] private string id = string.Empty;

    public string Id => id;

    [ContextMenu("Generate Id")]
    private void GenerateId() => id = Guid.NewGuid().ToString();

    //Saving
    public object CaptureState(){
        var state = new Dictionary<string, object>();

        foreach (var savable in GetComponents<ISavable>()){
            state[savable.GetType().ToString()] = savable.CaptureState();
        }

        return state;
    }
    
    //Loading
    public void RestoreState(object state){

        var stateDictionary = (Dictionary<string, object>) state;
        foreach (var savable in GetComponents<ISavable>()){
            string typeName = savable.GetType().ToString();
            if (stateDictionary.TryGetValue(typeName, out object value)){
                savable.RestoreState(value);
            }
        }
    }
}

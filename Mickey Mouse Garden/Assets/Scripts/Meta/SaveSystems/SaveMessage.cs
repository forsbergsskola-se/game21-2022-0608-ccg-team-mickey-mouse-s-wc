using System;
using System.Collections;
using System.Collections.Generic;
using UnityEditor;
using UnityEngine;

public class SaveMessage : IMessage{
    public ISaveData saveData;
    public SaveMessage(ISaveData _saveData){
        saveData = _saveData;
    }
}

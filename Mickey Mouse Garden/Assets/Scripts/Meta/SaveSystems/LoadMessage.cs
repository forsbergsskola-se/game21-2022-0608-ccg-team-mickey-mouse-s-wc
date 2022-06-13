using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class LoadMessage : IMessage{
    public ISaveData saveData;
    public LoadMessage(ISaveData _saveData){
        saveData = _saveData;
    }
}

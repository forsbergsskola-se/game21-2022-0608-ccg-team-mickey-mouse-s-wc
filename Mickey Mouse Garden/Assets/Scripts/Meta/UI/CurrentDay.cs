using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CurrentDay : MonoBehaviour{
    public Day day;

    void OnEnable(){
        day = new Day();
        day.TryLoadData();
    }
}

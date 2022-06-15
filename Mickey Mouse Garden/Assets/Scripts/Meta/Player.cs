using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Player : MonoBehaviour{
    public CardCollection cardCollection = new CardCollection();
    void Awake(){
        DontDestroyOnLoad(this.gameObject);
    }

    void LoadAllData(){
        cardCollection.TryLoadData();
    }
}

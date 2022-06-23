using System;
using System.Collections;
using System.Collections.Generic;
using System.Threading.Tasks;
using UnityEngine;

public class Player : MonoBehaviour{
    void Awake(){
        DontDestroyOnLoad(this.gameObject);
    }
    
}

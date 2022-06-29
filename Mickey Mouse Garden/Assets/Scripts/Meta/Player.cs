using System;
using System.Collections;
using System.Collections.Generic;
using System.Threading.Tasks;
using UnityEngine;
[CustomComponent("Player","Makes player dont destroy on load, also has to be loaded first!")]
public class Player : MonoBehaviour{
    void Awake(){
        DontDestroyOnLoad(this.gameObject);
    }
    
}

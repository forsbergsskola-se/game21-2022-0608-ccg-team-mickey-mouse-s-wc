using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ToggleDropDown : MonoBehaviour{
    public GameObject[] buttons;
    
    public void ToggleDropDownMenu(){
        for(int i = 0; i < buttons.Length; i++){
            if(buttons[i].activeSelf){
                buttons[i].SetActive(false);
            }else{
                buttons[i].SetActive(true);
            }
        }
    }
}

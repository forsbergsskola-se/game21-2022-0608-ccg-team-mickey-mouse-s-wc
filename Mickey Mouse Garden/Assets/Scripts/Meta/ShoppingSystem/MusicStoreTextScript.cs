using System.Collections;
using System.Collections.Generic;
using TMPro;
using UnityEngine;

public class MusicStoreTextScript : MonoBehaviour{
    [SerializeField] private TextMeshProUGUI song1;
    [SerializeField] private TextMeshProUGUI song2;
    [SerializeField] private TextMeshProUGUI song3;
    [SerializeField] private TextMeshProUGUI song4;
    
    public void ChangeSong1TextToOutOfStock(){
        song1.text = "Out of Stock";
    }
    public void ChangeSong2TextToOutOfStock(){
        song2.text = "Out of Stock";
    }
    public void ChangeSong3TextToOutOfStock(){
        song3.text = "Out of Stock";
    }
    public void ChangeSong4TextToOutOfStock(){
        song4.text = "Out of Stock";
    }
}

using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ShopUITextUpdate : MonoBehaviour
{
    public TextMesh text;
    public string textToDisplay; 
    public bool isPurchased;

// Start is called before the first frame update
    void Start(){
        text = GetComponent<TextMesh>();
        textToDisplay = text.text;
        isPurchased = PlayerPrefs.GetInt(textToDisplay) == 1;
    }
}

using System.Collections;
using System.Collections.Generic;
using Unity.VisualScripting;
using UnityEngine;

public class SendSacrificeMessage : MonoBehaviour
{
    public void OnClick(){
        FindObjectOfType<CompleteFusionButton>().OnClick();
    }
}

using UnityEngine;

public class FusionClickableCard : MonoBehaviour{
    
    public void Clicked(){
        transform.parent.transform.parent.gameObject.SetActive(false);
        //I DID IT AGAIN
    }
}

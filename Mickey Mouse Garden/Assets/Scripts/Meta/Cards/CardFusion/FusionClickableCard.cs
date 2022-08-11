using UnityEngine;

public class FusionClickableCard : MonoBehaviour{
    private bool isInspected;
    public void Clicked(){
        
        var inspectCardMessage = new InspectCardMessage(){card = GetComponent<ASelectedCard>().FindCardData()}; 
        Broker.InvokeSubscribers(typeof(InspectCardMessage), inspectCardMessage);
        if (!isInspected){
            transform.parent.transform.parent.gameObject.SetActive(false);
        }
    }
}
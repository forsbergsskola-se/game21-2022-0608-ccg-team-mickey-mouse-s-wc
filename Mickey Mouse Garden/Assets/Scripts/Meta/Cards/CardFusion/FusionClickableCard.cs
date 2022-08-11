using UnityEngine;

public class FusionClickableCard : MonoBehaviour{
    
    public void Clicked(){
        var inspectCardMessage = new InspectCardMessage(){card = GetComponent<ASelectedCard>().FindCardData()}; 
        Broker.InvokeSubscribers(typeof(InspectCardMessage), inspectCardMessage);
        transform.parent.transform.parent.gameObject.SetActive(false);
    }
}
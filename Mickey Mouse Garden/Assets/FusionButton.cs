using UnityEngine;

public class FusionButton : MonoBehaviour{
    public void OnClick(){
        var cardSacrificedMessage = new InspectCardMessage(){card = GetComponent<ASelectedCard>().FindCardData()}; 
        Broker.InvokeSubscribers(typeof(CardSacrificedMessage), cardSacrificedMessage);
    }
}
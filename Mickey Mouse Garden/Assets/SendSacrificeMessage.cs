using UnityEngine;

public class SendSacrificeMessage : MonoBehaviour
{
    public void OnClick(){
        Broker.InvokeSubscribers(typeof(FusionEndMessage), new FusionEndMessage{fusionCard = GetComponent<ASelectedCard>().FindCardData()});
        FindObjectOfType<CompleteFusionButton>().OnClick();
    }
}

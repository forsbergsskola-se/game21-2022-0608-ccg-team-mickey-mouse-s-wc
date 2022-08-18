using UnityEngine;

public class OpenSelectionPanel : MonoBehaviour {
    public GameObject selectionPanel;
    public int position;

    public void OpenPanel() {
        selectionPanel.SetActive(true);
        var card = GetComponentInChildren<ASelectedCard>().FindCardData();
        var msg = new CardSelectionMessage{Card = card , Position = position};
        Broker.InvokeSubscribers(typeof(CardSelectionMessage), msg);
    }
}

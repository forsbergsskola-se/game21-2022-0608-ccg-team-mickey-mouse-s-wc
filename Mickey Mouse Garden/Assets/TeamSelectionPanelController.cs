using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class TeamSelectionPanelController : MonoBehaviour
{
    private void Start() {
        Broker.Subscribe<CardSelectionMessage>(PanelControl);
    }

    private void PanelControl(CardSelectionMessage cardSelectionMessage) {
        
    }
}

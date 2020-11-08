using UnityEngine;
using System.Collections.Generic;

public class PlayerHandUIController : MonoBehaviour
{
    public List<ActionCardView> handCards;

    private void Start()
    {
        for (int i = 0; i < handCards.Count; i++)
        {
            ActionCardView handCard = handCards[i];

            handCard.SetSlot(i);

            handCard.gameObject.SetActive(false);
        }
    }
}

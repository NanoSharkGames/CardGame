using UnityEngine;
using UnityEngine.UI;
using System.Collections.Generic;

public class PlayerHandUIController : MonoBehaviour
{
    [SerializeField] DeckTester deckTester;
    public List<ActionCardView> handCards;

    private void Start()
    {
        for (int i = 0; i < handCards.Count; i++)
        {
            ActionCardView handCard = handCards[i];

            handCard.deckTester = deckTester;

            handCard.SetSlot(i);

            handCard.gameObject.SetActive(false);
        }
    }
}

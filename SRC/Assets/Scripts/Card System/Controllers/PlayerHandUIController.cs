using UnityEngine;
using System.Collections.Generic;

public class PlayerHandUIController : MonoBehaviour
{
    [SerializeField] List<ActionCardView> handCards;

    private void Start()
    {
        for (int i = 0; i < handCards.Count; i++)
        {
            ActionCardView handCard = handCards[i];

            handCard.SetSlot(i);

            handCard.gameObject.SetActive(false);
        }
    }

    public ActionCardView GetHandSlot(int slot)
    {
        return handCards[slot];
    }

    public void HideHand()
    {
        for (int i = 0; i < handCards.Count; i++)
        {
            ActionCardView slot = GetHandSlot(i);
            slot.Hide();
        }
    }
}
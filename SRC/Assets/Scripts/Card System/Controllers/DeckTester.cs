using System.Collections.Generic;
using UnityEngine;

public class DeckTester : MonoBehaviour
{
    [SerializeField] List<ActionCardData> _actionDeckConfig = new List<ActionCardData>();
    [SerializeField] PlayerHandUIController _playerHandUI;

    Deck<ActionCard> _actionDeck = new Deck<ActionCard>();
    Deck<ActionCard> _actionDiscard = new Deck<ActionCard>();

    Deck<ActionCard> _playerHand = new Deck<ActionCard>();

    int _maxPlayerHandCards = 4;
    int _currentPlayerHandCardCount = 0;

    private void Start()
    {
        SetupActionDeck();
    }

    private void SetupActionDeck()
    {
        foreach (ActionCardData actionData in _actionDeckConfig)
        {
            ActionCard newActionCard = new ActionCard(actionData);
            _actionDeck.Add(newActionCard);
        }

        _actionDeck.Shuffle();
    }

    public void Draw()
    {
        while (_currentPlayerHandCardCount < _maxPlayerHandCards)
        {
            ActionCard newCard = _actionDeck.Draw(DeckPosition.Top);

            if (newCard != null)
            {
                Debug.Log("Drew card: " + newCard.Name);
                _playerHand.Add(newCard, DeckPosition.Top);

                _currentPlayerHandCardCount++;
            }
            else
            {
                PutDiscardPileBackInDeck();
            }
        }

        ResetPlayerHandUI();
    }

    private void PutDiscardPileBackInDeck()
    {
        while (!_actionDiscard.IsEmpty)
        {
            ActionCard discardedCard = _actionDiscard.Draw(DeckPosition.Top);
            _actionDeck.Add(discardedCard);
        }

        _actionDeck.Shuffle();
    }

    private void ResetPlayerHandUI()
    {
        for (int i = 0; i < _maxPlayerHandCards; i++)
        {
            ActionCard card = _playerHand.GetCard(i);

            if (card != null)
            {
                _playerHandUI.handCards[i].AssignCardSlot(card);
            }
            else
            {
                _playerHandUI.handCards[i].EmptySlot();
            }
        }
    }

    public void PlayCard(ActionCard targetCard, int slot)
    {
        targetCard.Play();
        // TODO consider expanding Remove to accept a deck position
        _playerHand.Remove(slot);
        _actionDiscard.Add(targetCard);
        Debug.Log("Card added to discard: " + targetCard.Name);

        _currentPlayerHandCardCount--;

        ResetPlayerHandUI();
    }
}

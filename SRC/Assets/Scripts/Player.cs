using System.Collections.Generic;
using UnityEngine;

public class Player : MonoBehaviour, ITargetable, IDamageable, IPlayer
{
    [SerializeField] List<ActionCardData> _actionDeckConfig = new List<ActionCardData>();
    [SerializeField] PlayerHandUIController _playerHandUI;

    Deck<ActionCard> _actionDeck = new Deck<ActionCard>();
    Deck<ActionCard> _actionDiscard = new Deck<ActionCard>();

    Deck<ActionCard> _playerHand = new Deck<ActionCard>();

    [SerializeField] PlayerStatsUIController _uiController;

    int _maxPlayerHandCards = 4;

    [SerializeField] int _curHP = 10;
    [SerializeField] int _maxHP = 10;

    [SerializeField] int _maxAP = 4;
    int _curAP = 4;

    int _damageBonus = 0;

    private void Start()
    {
        SetupActionDeck();
        FillStatsUI();
    }

    public void Target()
    {
        Debug.Log("Player has been targeted");
    }

    public void Kill()
    {
        Debug.Log("Kill the player!");
        gameObject.SetActive(false);
    }

    public void TakeDamage(int damage)
    {
        _curHP -= damage;
        Debug.Log("Took damage. Remaining health: " + _curHP);

        if (_curHP <= 0)
        {
            Kill();
        }
    }

    public void GetControl()
    {
        Debug.Log("Control goes to player!");
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


    public void BeginTurn()
    {
        _curAP = _maxAP;
        Draw();
    }

    public void Draw()
    {
        while (_playerHand.Count < _maxPlayerHandCards)
        {
            ActionCard newCard = _actionDeck.Draw(DeckPosition.Top);

            if (newCard != null)
            {
                Debug.Log("Drew card: " + newCard.Name);
                _playerHand.Add(newCard, DeckPosition.Top);
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

    public void ResetPlayerHandUI()
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

    public void UseAP(int ap)
    {
        _curAP -= ap;

        FillStatsUI();
    }

    public void PlayCard(ActionCard cardToPlay, int slot)
    {
        if (_curAP >= cardToPlay.ActionPointCost)
        {
            UseAP(cardToPlay.ActionPointCost);

            cardToPlay.Play();

            // TODO consider expanding Remove to accept a deck position
            _playerHand.Remove(slot);
            _actionDiscard.Add(cardToPlay);
            Debug.Log("Card added to discard: " + cardToPlay.Name);

            ResetPlayerHandUI();
        }
    }

    public int GetMaxHP()
    {
        return _maxHP;
    }

    public int GetHP()
    {
        return _curHP;
    }

    public int GetMaxAP()
    {
        return _maxAP;
    }

    public int GetAP()
    {
        return _curAP;
    }

    public int GetDamageBonus()
    {
        return _damageBonus;
    }

    void FillStatsUI()
    {
        _uiController.FillUIStats();
    }
}

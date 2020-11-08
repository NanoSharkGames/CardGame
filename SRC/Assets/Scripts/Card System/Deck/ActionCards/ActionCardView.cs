using UnityEngine;
using UnityEngine.UI;

public class ActionCardView : MonoBehaviour
{
    ActionCard card = null;
    [SerializeField] Text _nameTextUI = null;
    [SerializeField] Text _descTextUI = null;
    [SerializeField] Text _costTextUI = null;
    [SerializeField] Image _graphicUI = null;

    int slot = -1;

    public void SetSlot(int newSlot)
    {
        slot = newSlot;
    }

    public void Display()
    {
        _nameTextUI.text = card.Name;
        _descTextUI.text = card.ActionDesc;
        _costTextUI.text = card.ActionPointCost.ToString();
        _graphicUI.sprite = card.Graphic;
    }

    public void AssignCardSlot(ActionCard newCard)
    {
        card = newCard;
        gameObject.SetActive(true);
        Display();
    }

    public void EmptySlot()
    {
        card = null;
        gameObject.SetActive(false);
    }

    public void PlayCard()
    {
        TargetController.CurrentPlayer.PlayCard(card, slot);
    }
}

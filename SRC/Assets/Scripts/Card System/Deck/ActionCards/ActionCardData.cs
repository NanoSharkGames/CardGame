using UnityEngine;

[CreateAssetMenu(fileName = "NewActionCard", menuName = "CardData/ActionCard")]
public class ActionCardData : ScriptableObject
{
    [SerializeField] string _name = "...";
    public string Name => _name;

    [SerializeField] int _cost = 1;
    public int Cost => _cost;

    [SerializeField] Sprite _graphic = null;
    public Sprite Graphic => _graphic;

    [SerializeField] CardPlayEffect _playEffect = null;
    public CardPlayEffect PlayEffect => _playEffect;

    [SerializeField] string _description = "Description";
    public string Description => _description;

    [SerializeField] int _actionPointCost = 1;
    public int ActionPointCost => _actionPointCost;
}
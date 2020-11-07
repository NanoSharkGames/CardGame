using UnityEngine;

public class ActionCard : Card
{
    public int Cost { get; protected set; }
    public Sprite Graphic { get; protected set; }
    public CardPlayEffect PlayEffect { get; protected set; }
    public string ActionDesc { get; protected set; }
    public int ActionPointCost { get; protected set; }

    public ActionCard(ActionCardData Data)
    {
        Name = Data.Name;
        Cost = Data.Cost;
        Graphic = Data.Graphic;
        PlayEffect = Data.PlayEffect;
        ActionDesc = Data.Description;
        ActionPointCost = Data.ActionPointCost;
    }

    public override void Play()
    {
        ITargetable target = TargetController.CurrentTarget;
        Debug.Log("Playing " + Name + " on target.");

        if (PlayEffect != null)
        {
            PlayEffect.Activate(target);
        }
    }
}

using UnityEngine;

public class AbilityCard : Card
{
    public int Cost { get; protected set; }
    public Sprite Graphic { get; protected set; }
    public CardPlayEffect PlayEffect { get; protected set; }

    public AbilityCard(AbilityCardData Data)
    {
        Name = Data.Name;
        Cost = Data.Cost;
        Graphic = Data.Graphic;
        PlayEffect = Data.PlayEffect;
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
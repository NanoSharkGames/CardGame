using UnityEngine;

public class AbilityCard : Card
{
    public int Cost { get; private set; }
    public Sprite Graphic { get; private set; }
    public CardPlayEffect PlayEffect { get; private set; }

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
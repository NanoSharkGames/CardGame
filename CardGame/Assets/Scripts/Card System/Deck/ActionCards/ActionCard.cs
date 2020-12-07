using UnityEngine;

public class ActionCard : Card
{
    public int Cost { get; protected set; }
    public Sprite Graphic { get; protected set; }
    public CardPlayEffect PlayEffect { get; protected set; }
    public string ActionDesc { get; protected set; }
    public int ActionPointCost { get; protected set; }
    public bool TargetsEnemies { get; protected set; }
    public AudioClip SoundToPlay { get; protected set; }

    public ActionCard(ActionCardData Data)
    {
        Name = Data.Name;
        Cost = Data.Cost;
        Graphic = Data.Graphic;
        PlayEffect = Data.PlayEffect;
        ActionDesc = Data.Description;
        ActionPointCost = Data.ActionPointCost;
        TargetsEnemies = Data.TargetsEnemies;
        SoundToPlay = Data.SoundToPlay;
    }

    public override void Play()
    {
        AudioManager.audioInstance.PlaySound(SoundToPlay);

        if (TargetsEnemies)
        {
            ITargetable target = TargetController.CurrentTarget;

            Debug.Log("Playing " + Name + " on target.");

            if (PlayEffect != null)
            {
                PlayEffect.Activate(target);
            }
        }
        else
        {
            IPlayer player = TargetController.CurrentPlayer;

            ITargetable target = player as ITargetable;

            Debug.Log("Playing " + Name + " on target.");

            if (PlayEffect != null)
            {
                PlayEffect.Activate(target);
            }
        }
    }
}

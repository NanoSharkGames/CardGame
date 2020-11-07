using UnityEngine;

[CreateAssetMenu(fileName = "NewAttackDamageBoostEffect", menuName = "CardData/PlayEffects/Ability/AttackDamageBoost")]
public class AttackDamageBoostPlayEffect : CardPlayEffect
{
    [SerializeField] int _damageAmount = 1;

    public override void Activate(ITargetable booster)
    {
        // Damage boost to all allies of this booster
    }
}

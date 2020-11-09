using UnityEngine;

[CreateAssetMenu(fileName = "NewAttackDamageBoostEffect", menuName = "CardData/PlayEffects/Ability/AttackDamageBoost")]
public class AttackDamageBoostPlayEffect : CardPlayEffect
{
    [SerializeField] int _damageAmount = 1;

    public override void Activate(ITargetable target)
    {
        // Test to see if the target is damageable
        IBuffable objectToBuff = target as IBuffable;

        // If it is, apply damage
        if (objectToBuff != null)
        {
            Debug.Log("Increase damage from target");
            objectToBuff.IncreaseDamage(_damageAmount);
        }
        else
        {
            Debug.Log("Target is not buffable...");
        }
    }
}

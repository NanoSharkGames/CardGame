using UnityEngine;

[CreateAssetMenu(fileName = "NewAttackPlayEffect", menuName = "CardData/PlayEffects/Attack")]
public class AttackPlayEffect : CardPlayEffect
{
    [SerializeField] int _damageAmount = 1;
    [SerializeField] int _attackRange = 1;
    [SerializeField] AttackStatusEffect _effectToInflict = AttackStatusEffect.None;

    public override void Activate(ITargetable target)
    {
        // Test to see if the target is damageable
        IDamageable objectToDamage = target as IDamageable;

        // If it is, apply damage
        if (objectToDamage != null)
        {
            objectToDamage.TakeDamage(_damageAmount);
            Debug.Log("Add damage to the target");
        }
        else
        {
            Debug.Log("Target is not damageable...");
        }
    }
}

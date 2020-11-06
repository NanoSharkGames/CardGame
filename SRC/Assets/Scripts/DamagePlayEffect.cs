using UnityEngine;

[CreateAssetMenu(fileName = "NewDamagePlayEffect", menuName = "CardData/PlayEffects/Damage")]
public class DamagePlayEffect : CardPlayEffect
{
    [SerializeField] int _damageAmount = 1;

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

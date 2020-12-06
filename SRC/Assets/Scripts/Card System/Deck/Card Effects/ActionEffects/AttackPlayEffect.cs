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

        IPlayer player = TargetController.CurrentPlayer;
        Player playerObj = player as Player;

        // If it is, apply damage
        if (objectToDamage != null)
        {
            Debug.Log("Add damage to the target");

            int _damageBonus = 0;

            if (playerObj != null)
            {
                _damageBonus = playerObj.GetDamageBonus();

                Debug.Log("Bonus of attack: " + _damageBonus.ToString());
            }

            objectToDamage.TakeDamage(_damageAmount + _damageBonus);
        }
        else
        {
            Debug.Log("Target is not damageable...");
        }
    }
}

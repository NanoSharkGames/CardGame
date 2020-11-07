using UnityEngine;

[CreateAssetMenu(fileName = "NewMovePlayEffect", menuName = "CardData/PlayEffects/Move")]
public class MovePlayEffect : CardPlayEffect
{
    [SerializeField] int _moveRange = 2;

    [SerializeField] int _moveDamageToSelf = 0;

    [SerializeField] bool _teleportEnabled = false;

    public override void Activate(ITargetable mover)
    {

        if (_moveDamageToSelf != 0)
        {
            // Test to see if mover is damageable
            IDamageable moverToDamage = mover as IDamageable;

            // If it is, apply damage
            if (moverToDamage != null)
            {
                moverToDamage.TakeDamage(_moveDamageToSelf);
                Debug.Log("Mover took damage");
            }
            else
            {
                Debug.Log("Mover is not damageable...");
            }
        }

        // Move target:
        // TODO Assign move controller's current mover to mover
        // TODO Assign move range to this moveRange
    }
}

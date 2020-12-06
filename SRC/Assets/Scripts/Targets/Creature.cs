using UnityEngine;
using System;

public class Creature : MonoBehaviour, ITargetable, IDamageable
{
    int _curHP = 25;

    public static event Action Died;

    public void Kill()
    {
        Debug.Log("Kill the creature!");
        gameObject.SetActive(false);

        Died?.Invoke();

    }

    public void TakeDamage(int damage)
    {
        _curHP -= damage;
        Debug.Log("Took damage. Remaining health: " + _curHP);

        if (_curHP <= 0)
        {
            Kill();
        }
    }

    public void Target()
    {
        Debug.Log("Creature has been targeted");
    }
}

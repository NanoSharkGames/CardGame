using UnityEngine;
using System;
using System.Collections;

public class EnemyTurnCardGameState : CardGameState
{
    public static event Action EnemyTurnBegan;
    public static event Action EnemyTurnEnded;

    private void OnEnable()
    {
        Creature.Died += OnEnemyDie;
        Player.Died += OnPlayerDie;
    }

    private void OnDisable()
    {
        Creature.Died -= OnEnemyDie;
        Player.Died -= OnPlayerDie;
    }

    [SerializeField] float _pauseDuration = 1.5f;

    [SerializeField] Player _target;

    [SerializeField] int _damageAmount = 1;

    public override void Enter()
    {
        Debug.Log("Enemy Turn: ...Entering");
        EnemyTurnBegan?.Invoke();

        StartCoroutine(EnemyThinkingRoutine(_pauseDuration));
    }

    public override void Exit()
    {
        Debug.Log("Enemy Turn: Exiting...");
    }

    IEnumerator EnemyThinkingRoutine(float pauseDuration)
    {
        Debug.Log("Enemy attacking...");

        yield return new WaitForSeconds(pauseDuration);

        _target.GetComponent<IDamageable>().TakeDamage(_damageAmount);

        EnemyTurnEnded?.Invoke();

        // Turn over. Go back to player
        if (_target.GetHP() > 0)
        {
            StateMachine.ChangeState<PlayerTurnCardGameState>();
        }
    }

    void OnEnemyDie()
    {
        StateMachine.ChangeState<WinState>();
    }

    void OnPlayerDie()
    {
        StateMachine.ChangeState<LoseState>();
    }
}

using UnityEngine;

public abstract class StateMachine : MonoBehaviour
{
    public State CurrentState => _currentState;
    protected bool InTransition { get; private set; }

    State _currentState;
    protected State _previousState;

    public void ChangeState<T>() where T : State
    {
        T targetState = GetComponent<T>();

        if (targetState == null)
        {
            Debug.LogWarning("Cannot change to state, as it does not exist " +
                "on the State Machine object. Make sure you have the desired" +
                " State attached to the State Machine");
            return;
        }

        InitiateStateChange(targetState);
    }

    public void RevertState()
    {
        if (_previousState != null)
        {
            InitiateStateChange(_previousState);
        }
    }

    void InitiateStateChange(State targetState)
    {
        // If our new state is different and we're not transitioning, proceed
        if (_currentState != targetState && !InTransition)
        {
            Transition(targetState);
        }
    }

    void Transition(State newState)
    {
        // Start transition
        InTransition = true;

        // Transitioning
        _currentState?.Exit();
        _currentState = newState;
        _currentState?.Enter();

        // End transition
        InTransition = false;
    }

    private void Update()
    {
        // Simulate update in states with 'tick'
        if (CurrentState != null && !InTransition)
        {
            CurrentState.Tick();
        }
    }
}

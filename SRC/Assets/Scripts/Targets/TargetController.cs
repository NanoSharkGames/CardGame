using UnityEngine;

public class TargetController : MonoBehaviour
{
    // TODO build a more structured connection
    public static ITargetable CurrentTarget;
    public static IPlayer CurrentPlayer;
    // Interfaces don't serialize, so need class reference
    [SerializeField] Creature _objectToTarget = null;
    [SerializeField] Player _player = null;

    private void Start()
    {
        // Target the object if it is targetable
        IPlayer possiblePlayer = _player.GetComponent<IPlayer>();
        if (possiblePlayer != null)
        {
            Debug.Log("New player in control!");
            CurrentPlayer = possiblePlayer;
            _player.GetControl();
        }

        // Target the object if it is targetable
        ITargetable possibleTarget = _objectToTarget.GetComponent<ITargetable>();
        if (possibleTarget != null)
        {
            Debug.Log("New target acquired!");
            CurrentTarget = possibleTarget;
            _objectToTarget.Target();
        }
    }
}

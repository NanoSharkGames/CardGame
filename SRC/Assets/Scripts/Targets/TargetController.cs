﻿using UnityEngine;

public class TargetController : MonoBehaviour
{
    // TODO build a more structured connection
    public static ITargetable CurrentTarget;
    // Interfaces don't serialize, so need class reference
    [SerializeField] Creature _objectToTarget = null;

    private void Update()
    {
        // Target the object when '1' is pressed
        if (Input.GetKeyDown(KeyCode.Alpha1))
        {
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
}

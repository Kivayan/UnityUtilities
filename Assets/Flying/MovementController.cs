using UnityEngine;

[RequireComponent(typeof(Flying))]
[RequireComponent(typeof(Walk))]
[RequireComponent(typeof(CharacterController))]
public class MovementController : MonoBehaviour
{
    private IMovement currentMovement;
    private IMovement walk;
    private IMovement fly;

    private void Start()
    {
        walk = GetComponent<Walk>();
        fly = GetComponent<Flying>();
        currentMovement = walk;
        currentMovement.SetCurrentRotation(new Vector3(0, 0, 0));
    }

    private void Update()
    {
        SwitchMovementType();
        currentMovement.Move();

        DebugInfo();
        
    }

    private void SwitchMovementType()
    {
        Vector3 startingRotation;

        if (Input.GetKeyDown(KeyCode.Alpha1))
        {
            startingRotation = currentMovement.GetCurrentRotation();
            walk.SetCurrentRotation(startingRotation);
            currentMovement = walk;
        }

        if (Input.GetKeyDown(KeyCode.Alpha2))
        {
            startingRotation = currentMovement.GetCurrentRotation();
            fly.SetCurrentRotation(startingRotation);
            //fly.SetCurrentRotation(walk.GetCurrentRotation());
            currentMovement = fly;
        }
    }

    private void DebugInfo()
    {
        DebugPanel.Log("Engine", "MoveEngineInfo", currentMovement);
        DebugPanel.Log("Walk", "MoveEngineInfo", walk);
        DebugPanel.Log("Fly", "MoveEngineInfo", fly);
    }
}
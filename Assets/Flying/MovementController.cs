using UnityEngine;

[RequireComponent(typeof(Flying))]
[RequireComponent(typeof(Walk))]
[RequireComponent(typeof(CharacterController))]
public class MovementController : MonoBehaviour
{
    private IMovement currentMovement;
    private IMovement walk;
    private IMovement fly;

    private Vector3 startingRotation;


    [Range(0.2f, 4f)] public float awaitSecondSpaceTime;
    private float flyTriggerTimer = 0f;
    private bool awaitingSecondSpace = false;
    private bool startCount = false;

    private void Start()
    {
        walk = GetComponent<Walk>();
        fly = GetComponent<Flying>();
        currentMovement = walk;
        currentMovement.SetCurrentRotation(new Vector3(0, 0, 0));
    }

    private void Update()
    {
        MonitorFly();
        SwitchMovementType();
        currentMovement.Move();
        DebugInfo();
    }

    private void SwitchMovementType()
    {
        if (Input.GetKeyDown(KeyCode.Alpha1))
            SwitchOnWalk();

        if (Input.GetKeyDown(KeyCode.Alpha2))
            SwitchOnFly();
    }

    private void MonitorFly()
    {
        if (Input.GetKeyDown(KeyCode.Space))
            startCount = true;

        if (flyTriggerTimer < awaitSecondSpaceTime & flyTriggerTimer > 0.3f)
            awaitingSecondSpace = true;

        if (flyTriggerTimer >= awaitSecondSpaceTime)
        {
            awaitingSecondSpace = false;
            startCount = false;
            awaitingSecondSpace = false;
            flyTriggerTimer = 0;
        }

        if (awaitingSecondSpace && Input.GetKeyDown(KeyCode.Space))
        {
            SwitchOnFly();
            startCount = false;
            awaitingSecondSpace = false;
            flyTriggerTimer = 0;
        }

        if (startCount == true)
            flyTriggerTimer += Time.deltaTime;
    }

    private void SwitchOnWalk()
    {
        startingRotation = currentMovement.GetCurrentRotation();
        walk.SetCurrentRotation(startingRotation);
        currentMovement = walk;
    }

    private void SwitchOnFly()
    {
        startingRotation = currentMovement.GetCurrentRotation();
        fly.SetCurrentRotation(startingRotation);
        currentMovement = fly;
    }

    private void DebugInfo()
    {
        DebugPanel.Log("Engine", "MoveEngineInfo", currentMovement);
        //DebugPanel.Log("Walk", "MoveEngineInfo", walk);
        //DebugPanel.Log("Fly", "MoveEngineInfo", fly);
        DebugPanel.Log("flyTriggerTimer", "MoveEngineInfo", flyTriggerTimer);
        DebugPanel.Log("awaitingSecondSpace", "MoveEngineInfo", awaitingSecondSpace);
        DebugPanel.Log("startCount", "MoveEngineInfo", startCount);
    }
}
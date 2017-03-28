using System;
using UnityEngine;

public class Flying : MonoBehaviour, IMovement
{
    private float currentSpeed;
    public float speed = 6.0F;
    public float shiftSpeed = 12f;
    public float riseSpeed = 8.0F;
    public float descentSpeed = -8.0F;
    public float gravity = 0;
    private Vector3 moveDirection = Vector3.zero;
    private DistanceTracker distTrack;
    private float distanceFromGround;

    [Range(20, 150)] public float mouseYSpeed = 50;
    [Range(20, 150)] public float mouseXSpeed = 50;

    private float YRotate = 0;
    private float XRotate = 0;

    private void Start()
    {
        distTrack = new DistanceTracker(transform.position, Vector3.down);
    }

    void IMovement.Move()
    {
        Move();
        Rotate();
        DebugInfo();
        distanceFromGround = distTrack.CalculateDist();
        distTrack.DebugRay();
        
    }

    private void Move()
    {
        CharacterController controller = GetComponent<CharacterController>();

        moveDirection = new Vector3(Input.GetAxis("Horizontal"), 0, Input.GetAxis("Vertical"));
        moveDirection = transform.TransformDirection(moveDirection);
        moveDirection *= currentSpeed;

        RiseAndDescend();
        Accelerate();

        moveDirection.y -= gravity * Time.deltaTime;
        controller.Move(moveDirection * Time.deltaTime);
    }

    private void Rotate()
    {
        XRotate += -(Input.GetAxis("Mouse Y") * mouseYSpeed * Time.deltaTime);
        YRotate += Input.GetAxis("Mouse X") * mouseXSpeed * Time.deltaTime;

        transform.rotation = Quaternion.Euler(new Vector3(XRotate, YRotate, 0));
    }

    private void RiseAndDescend()
    {
        if (Input.GetKey(KeyCode.Space))
            moveDirection.y = riseSpeed;
        if (Input.GetKey(KeyCode.LeftControl))
            moveDirection.y = descentSpeed;
    }

    private void Accelerate()
    {
        if (Input.GetKey(KeyCode.LeftShift))
            currentSpeed = shiftSpeed;
        else
            currentSpeed = speed;
    }

    private void DebugInfo()
    {
        DebugPanel.Log("Mouse Y", "Input", YRotate);
        DebugPanel.Log("Mouse X", "Input", XRotate);
        DebugPanel.Log("FlySpeed", "Movement", currentSpeed);
        DebugPanel.Log("distanceFromGround", "distanceFromGround", distanceFromGround);
    }

    
    void IMovement.SetCurrentRotation(Vector3 startingRotation)
    {
        XRotate = startingRotation.x;
        YRotate = startingRotation.y;
    }

    Vector3 IMovement.GetCurrentRotation()
    {
        return new Vector3(XRotate, YRotate, transform.rotation.z);
    }
}
using UnityEngine;

public class Walk : MonoBehaviour
{
    private float currentSpeed;
    public float speed = 6.0F;
    public float shiftSpeed = 12f;
    public float riseSpeed = 8.0F;
    public float descentSpeed = -8.0F;
    public float gravity = 20.0F;
    private Vector3 moveDirection = Vector3.zero;

    public float mouseYSpeed = 2;
    public float mouseXSpeed = 2;

    private float Yrotate = 0;
    private float Xrotate = 0;

    private void Update()
    {
        Move();
        Rotate();
        Debug();
    }

    private void Move()
    {
        CharacterController controller = GetComponent<CharacterController>();
        if (true)//controller.isGrounded)
        {
            moveDirection = new Vector3(Input.GetAxis("Horizontal"), 0, Input.GetAxis("Vertical"));
            moveDirection = transform.TransformDirection(moveDirection);
            moveDirection *= currentSpeed;
            if (Input.GetKey(KeyCode.Space))
                moveDirection.y = riseSpeed;
            if (Input.GetKey(KeyCode.LeftControl))
                moveDirection.y = descentSpeed;
            if (Input.GetKey(KeyCode.LeftShift))
                currentSpeed = shiftSpeed;
            else
                currentSpeed = speed;
        }
        moveDirection.y -= gravity * Time.deltaTime;
        controller.Move(moveDirection * Time.deltaTime);
    }

    private void Rotate()
    {
        Yrotate += -(Input.GetAxis("Mouse Y") * mouseYSpeed * Time.deltaTime);
        Xrotate += Input.GetAxis("Mouse X") * mouseYSpeed * Time.deltaTime;

        transform.rotation = Quaternion.Euler(new Vector3(Yrotate, Xrotate, 0));
    }

    private void Debug()
    {
        DebugPanel.Log("Mouse Y", "Input", Yrotate);
        DebugPanel.Log("Mouse X", "Input", Xrotate);
        DebugPanel.Log("CurrentSpeed", "Movement", currentSpeed);
    }
}
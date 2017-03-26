using UnityEngine;

public class Walk : MonoBehaviour, IMovement
{
    public float speed = 6.0F;
    public float jumpSpeed = 8.0F;
    public float gravity = 20.0F;
    private Vector3 moveDirection = Vector3.zero;
    private float timer = 0;

    private Transform camTrans;

    [Range(00, 150)] public float mouseXSpeed = 50;
    [Range(20, 150)] public float mouseYSpeed = 50;

    private float YRotate = 0;
    private float XRotate = 0;

    public void Start()
    {
        camTrans = GetComponentInChildren<Camera>().GetComponent<Transform>();
    }

    public void Move()
    {
        Walking();
        Rotate();
        Debugging();
    }

    private void Walking()
    {
        CharacterController controller = GetComponent<CharacterController>();
        if (controller.isGrounded)
        {
            moveDirection = new Vector3(Input.GetAxis("Horizontal"), 0, Input.GetAxis("Vertical"));
            moveDirection = transform.TransformDirection(moveDirection);
            moveDirection *= speed;
            if (Input.GetButton("Jump"))
                moveDirection.y = jumpSpeed;
        }
        moveDirection.y -= gravity * Time.deltaTime;
        controller.Move(moveDirection * Time.deltaTime);
    }

    private void Rotate()
    {
        XRotate += -(Input.GetAxis("Mouse Y") * mouseXSpeed * Time.deltaTime);
        YRotate += Input.GetAxis("Mouse X") * mouseYSpeed * Time.deltaTime;

        transform.rotation = Quaternion.Euler(new Vector3(0, YRotate, 0));


        if (camTrans.eulerAngles.x <= 10 && camTrans.eulerAngles.x >= -10)
        {
            camTrans.Rotate(new Vector3(XRotate, 0, 0));
        }


        /*
    if (transform.rotation.x != 0)
        ResetXRotation();
    else
        transform.rotation = Quaternion.Euler(new Vector3(0, YRotate, 0));

    */
    }

    private void Debugging()
    {
        DebugPanel.Log("WalkSpeed", "Movement", speed);
        DebugPanel.Log("XRotate", "InputWalk", XRotate);
        DebugPanel.Log("YRotate", "InputWalk", YRotate);
        DebugPanel.Log("CamRotX", "Cam", camTrans.eulerAngles.x);
        
    }

    private void ResetXRotation()
    {
        timer += 0.2f * Time.deltaTime;
        Debug.Log("dupakwas = " + timer);
        transform.rotation = Quaternion.Euler(new Vector3(Mathf.Lerp(transform.rotation.x, 0, timer), YRotate, 0));
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
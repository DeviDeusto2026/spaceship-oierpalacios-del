using UnityEngine;

public class playerMovement : MonoBehaviour
{
    public float speed;

    public Transform cameraTransform; // <-- arrastra la cámara aquí en el Inspector

    void Start()
    {
        speed = 50f;
    }

    void Update()
    {
        manageInput();
    }

    private void manageInput()
    {
        float h = Input.GetAxis("Horizontal");
        float v = Input.GetAxis("Vertical");

        Vector3 forward = cameraTransform.forward;
        Vector3 right = cameraTransform.right;
        forward.y = 0f;
        right.y = 0f;
        forward.Normalize();
        right.Normalize();

        Vector3 moveDir = (forward * v + right * h);

        transform.position += moveDir * speed * Time.deltaTime;

        if (Input.GetKey(KeyCode.Space))
            transform.position += Vector3.up * speed * Time.deltaTime;

        if (Input.GetKey(KeyCode.LeftShift))
            transform.position += Vector3.down * speed * Time.deltaTime;
    }
}



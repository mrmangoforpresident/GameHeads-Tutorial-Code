using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Move : MonoBehaviour
{
    public float speed;
    public float jumpForce;
    public float rotationSpeed = 10.0f;
    Rigidbody rb;

    private Vector2 lastMousePosition;
    private Vector3 movementDir;

    // Start is called before the first frame update
    void Start()
    {
        rb = GetComponent<Rigidbody>();
        lastMousePosition = Input.mousePosition;
    }
    private void FixedUpdate()
    {

        Vector3 moveRight = transform.right * movementDir.x;
        Vector3 moveForward = transform.forward * movementDir.z;

        Vector2 mousePosition = new Vector2(Input.mousePosition.x, Input.mousePosition.y);
        Vector2 rotationAmount = mousePosition - lastMousePosition;

        Vector3 newPosition = transform.position + ( (moveRight + moveForward) * speed * Time.deltaTime); 
        //multiplying speed by delta time (AKA the amount of time that's passed since the last frame we called)
        rb.MovePosition(newPosition);

        if (Input.GetKey(KeyCode.Space))
        {
            Vector3 force = new Vector3(0.0f, jumpForce, 0.0f);
            rb.AddForce(force, ForceMode.Impulse);
        }

        Vector3 capsuleRotate = new Vector3(0.0f, rotationAmount.x * rotationSpeed * Time.deltaTime, 0.0f);
        transform.Rotate(capsuleRotate);

        movementDir = Vector3.zero;

        if(Input.GetKey(KeyCode.W))
        {
            movementDir.z = 1.0f;
        }
        if (Input.GetKey(KeyCode.S))
        {
            movementDir.z = -1.0f;
        }
        if (Input.GetKey(KeyCode.A))
        {
            movementDir.x = -1.0f;
        }
        if (Input.GetKey(KeyCode.D))
        {
            movementDir.x = 1.0f;
        }
    }


    // Update is called once per frame
    void Update()
    {
    }
}

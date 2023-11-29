using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MouseMovement : MonoBehaviour
{
    public float mouseSensitivity = 100f;
    private Camera camera;
    float xRotation = 0f;
    float yRotation = 0f;

    // Start is called before the first frame update
    void Start()
    {
        //Locking the cursor to the middle of the screen and making it invisble
        Cursor.lockState = CursorLockMode.Locked;
        camera = Camera.main;
    }

    // Update is called once per frame
    void Update()
    {
        float mouseX = Input.GetAxis("Mouse X") * mouseSensitivity * Time.deltaTime;
        float mouseY = Input.GetAxis("Mouse Y") * mouseSensitivity * Time.deltaTime;

        //control rotation around x axis (Look up and down)
        xRotation -= mouseY;

        //we clamp the rotation so we cant Over-rotate(like in real life)
        xRotation = Mathf.Clamp(xRotation, -25f, 25f);

        //control rotation around y axis (Look up and down)
        yRotation += mouseX;

        //applying both rotations
        transform.localRotation = Quaternion.Euler(0f, 
            Mathf.Lerp(transform.localRotation.y, yRotation, 1.0f), 0f);
        camera.transform.localRotation = Quaternion.Euler(xRotation, 0f, 0f);
    }
}

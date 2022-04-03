using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MouseLook : MonoBehaviour
{
    // Start is called before the first frame update
    void Start()
    {
        Cursor.lockState= CursorLockMode.Locked;
    }

    [SerializeField] private float mouseSensitivity = 100f;
    //[SerializeField] private bool invertX = false;
    //[SerializeField] private bool invertY = false;
    [SerializeField] Transform playerBody;

    float vertRotation = 0f; //Along X-Axis

    // Update is called once per frame
    void Update()
    {
        float mouseX = Input.GetAxis("Mouse X") * mouseSensitivity * Time.deltaTime;
        float mouseY = Input.GetAxis("Mouse Y") * mouseSensitivity * Time.deltaTime;

        vertRotation -= mouseY;
        vertRotation = Mathf.Clamp(vertRotation, -90f, 90f);

        playerBody.Rotate(Vector3.up * mouseX);

        transform.localRotation = Quaternion.Euler(vertRotation, 0, 0);

    }
}

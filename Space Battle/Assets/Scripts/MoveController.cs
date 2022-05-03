using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MoveController : MonoBehaviour
{
    public float speed;
    public float mouseSpeed;
    float mouseX, mouseY;
    float yRotation = 0f;
    public Transform cam;


    void Start()
    {
        Cursor.lockState = CursorLockMode.Locked;
    }


    void Update()
    {
        transform.Translate(0, 0, Input.GetAxis("Vertical") * speed * Time.deltaTime);
        transform.Translate(0, Input.GetAxis ("Horizontal")*speed*Time.deltaTime, 0);
        mouseX = Input.GetAxis("Mouse X") * mouseSpeed * Time.deltaTime;
        mouseY = Input.GetAxis("Mouse Y") * mouseSpeed * Time.deltaTime;

        yRotation -= mouseY;

        yRotation = Mathf.Clamp(yRotation, -90f, 90f);


        cam.localRotation= Quaternion.Euler(yRotation, 0, 0);
        transform.Rotate(Vector3.up * mouseX);

           
    }
}

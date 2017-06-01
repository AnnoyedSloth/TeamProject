using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Husband : MonoBehaviour
{
    public int Speed = 6;

    public Transform PlayerTr;

    private float rotLeftRight;
    private float rotUpDown;
    private float verticalRotation = 0f;

    private float verticalVelocity = 0f;
    public float mouseSensitivity = 2f;
    public float upDownRange = 90;


    void Start()
    {
        PlayerTr = this.gameObject.GetComponent<Transform>();
        Cursor.lockState = CursorLockMode.None;

    }

    // Update is called once per frame
    void Update()
    {
        if (Input.GetKey(KeyCode.Space))
        {
            PlayerTr.transform.Translate(Vector3.zero);
        }
        else
        {
            if (Input.GetKey(KeyCode.W) == true)
            {
                PlayerTr.transform.Translate(Vector3.forward * Speed * Time.deltaTime);
            }
            if (Input.GetKey(KeyCode.S) == true)
            {
                PlayerTr.transform.Translate(-Vector3.forward * Speed * Time.deltaTime);
            }
            if (Input.GetKey(KeyCode.A) == true)
            {
                PlayerTr.transform.Translate(Vector3.left * Speed * Time.deltaTime);
            }
            if (Input.GetKey(KeyCode.D) == true)
            {
                PlayerTr.transform.Translate(-Vector3.left * Speed * Time.deltaTime);
            }
        }
        if (Input.GetKeyDown(KeyCode.LeftAlt) == true)
        {
            if (Cursor.lockState == CursorLockMode.Locked)
            {
                Cursor.lockState = CursorLockMode.None;
            }
            else Cursor.lockState = CursorLockMode.Locked;
        }
        if (Cursor.lockState == CursorLockMode.Locked) FPRotate();



    }

    void FPRotate()
    {
        //좌우 회전
        rotLeftRight = Input.GetAxis("Mouse X") * mouseSensitivity;
        transform.Rotate(0f, rotLeftRight, 0f);

        //상하 회전
        verticalRotation -= Input.GetAxis("Mouse Y") * mouseSensitivity;
        verticalRotation = Mathf.Clamp(verticalRotation, -upDownRange, upDownRange);
        Camera.main.transform.localRotation = Quaternion.Euler(verticalRotation, 0f, 0f);
    }
}
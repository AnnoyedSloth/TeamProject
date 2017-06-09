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
    public Animator mAnimator = null; //애니메이터 컨트롤

    Vector3 Bending = new Vector3(0.0f, 0.3f, 1.3f);
    Vector3 Standing = new Vector3(0.0f, 2.0f, 0.5f);
    Vector3 CurBending;
    Vector3 CurStanding;

    public float LerpVal;

    private bool hidingMode;

    void Start()
    {
        PlayerTr = this.gameObject.GetComponent<Transform>();
        Cursor.lockState = CursorLockMode.None;
        mAnimator = gameObject.GetComponent<Animator>(); //애니메이션할 객체 얻기
        hidingMode = false;
    }

    // Update is called once per frame
    void Update()
    {
        if (Input.GetKey(KeyCode.Space) || Input.GetKey(KeyCode.LeftControl))
        {
            PlayerTr.transform.Translate(Vector3.zero);
            mAnimator.SetBool("IsWalk", false);
            mAnimator.SetBool("IsIdle", true);
        }
        else
        {
            if (Input.GetKey(KeyCode.W) == true)
            {
                PlayerTr.transform.Translate(Vector3.forward * Speed * Time.deltaTime);
                mAnimator.SetBool("IsWalk", true);
                mAnimator.SetBool("IsIdle", false);
            }
            else if (Input.GetKey(KeyCode.S) == true)
            {
                PlayerTr.transform.Translate(Vector3.back * Speed * Time.deltaTime);
                mAnimator.SetBool("IsWalk", true);
                mAnimator.SetBool("IsIdle", false);
            }
            else if (Input.GetKey(KeyCode.A) == true)
            {
                PlayerTr.transform.Translate(Vector3.left * Speed * Time.deltaTime);
                mAnimator.SetBool("IsWalk", true);
                mAnimator.SetBool("IsIdle", false);
            }
            else if (Input.GetKey(KeyCode.D) == true)
            {
                PlayerTr.transform.Translate(-Vector3.left * Speed * Time.deltaTime);
                mAnimator.SetBool("IsWalk", true);
                mAnimator.SetBool("IsIdle", false);
            }
            else
            {
                mAnimator.SetBool("IsWalk", false);
                mAnimator.SetBool("IsIdle", true);
            }

        }

        if (Input.GetKey(KeyCode.LeftControl) == true)
        {
            mAnimator.SetBool("Ishide", true);
            mAnimator.SetBool("IsWalk", false);
            mAnimator.SetBool("IsIdle", false);
            hidingMode = false;
            Camera.main.transform.localPosition = Vector3.Lerp(Bending, Standing, Time.deltaTime);
        }
        else
        {
            mAnimator.SetBool("Ishide", false);
            Camera.main.transform.localPosition = Vector3.Lerp(Standing, Bending, Time.deltaTime);
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

    //void SetCameraPosition(float howMuch)
    //{
    //    Camera.main.transform.Translate(Vector3.down * howMuch);
    //    Camera.main.transform.Translate(Vector3.forward * howMuch);
    //}

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
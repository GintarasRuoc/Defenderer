using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerController : MonoBehaviour
{
    private string currentWeapon = "Pistol";
    private Animator anim;

    private string animation;
    // false - walking(idle), true - running
    private string lastAnimation = "IdlePistol";

    // Judėjimas
    public string mFrontBack = "Vertical";
    public string mLeftRight = "Horizontal";
    public string mRunning = "Shift";

    public float speed = 5f;
    public float runSpeed = 10f;

    private float _xMovement;
    private float _zMovement;

    private Vector3 _transform;
    private Vector3 _velocity;

    // Pasisukimas
    public string mMouseX = "Mouse X";

    public float rotationSpeed = 5f;

    private Vector3 _rotation;

    // Pavertimas
    public string mMouseY = "Mouse Y";

    private float _tilt;

    public float maxTilt = 1f;

    private Quaternion center;

    // Player body
    private Rigidbody rb;
    public Camera cam;

    // Pašokimas
    public string jump = "Jump";

    public float jumpVelocity = 2f;

    private bool grounded = true;


    private bool inShop = false;

    private void Start()
    {
        rb = GetComponent<Rigidbody>();
        center = cam.transform.rotation;
        anim = GetComponentInChildren<Animator>();
    }

    void Update()
    {
        if (Input.GetKeyDown(KeyCode.I))
        {
            inShop = !inShop;
        }
        if (inShop)
            return;
        
        if(grounded == false && rb.velocity.y == 0)
            grounded = true;
        
        PerformTransform();

        if (grounded == true && Input.GetButtonDown(jump))
        {
            rb.AddForce(Vector3.up * jumpVelocity);
            grounded = false;
        }

        
    }

    private void PerformTransform()
    {
        // Judėjimas
        _transform = (transform.right * Input.GetAxisRaw(mLeftRight) + transform.forward * Input.GetAxisRaw(mFrontBack)).normalized;

        if (Input.GetButton(mRunning))
        {
            _velocity = _transform * runSpeed;
            animation = "Run" + currentWeapon;
        }
        else
        {
            _velocity = _transform * speed;
            animation = "Idle" + currentWeapon;
        }

        // Pasukimas
        _rotation = new Vector3(0f, Input.GetAxisRaw(mMouseX), 0f) * rotationSpeed;

        // Pavertimas
        _tilt = Input.GetAxisRaw(mMouseY) * rotationSpeed;
        

        if(_velocity != Vector3.zero)
            rb.MovePosition(rb.position + _velocity * Time.fixedDeltaTime);
        if(anim.GetCurrentAnimatorStateInfo(0).IsName("IdlePistol") || anim.GetCurrentAnimatorStateInfo(0).IsName("RunPistol") || anim.GetCurrentAnimatorStateInfo(0).IsName("IdleRifle") || anim.GetCurrentAnimatorStateInfo(0).IsName("RunRifle"))
        {
            if (lastAnimation != animation)
            {
                anim.Play(animation);
                lastAnimation = animation;
            }
        }
        
        if(_rotation != Vector3.zero)
            rb.MoveRotation(rb.rotation * Quaternion.Euler(_rotation));

        if(_tilt != 0)  
            if(cam != null)
            {
                Quaternion yQuaternion = Quaternion.AngleAxis(_tilt, -Vector3.right);
                Quaternion temp = cam.transform.localRotation * yQuaternion;
                if (Quaternion.Angle(center, temp) < maxTilt)
                    cam.transform.localRotation = temp;
            }
    }

    public void ChangeWeapon(int number)
    {
        if (number <= 1)
            currentWeapon = "Pistol";
        else currentWeapon = "Rifle";
    }
}

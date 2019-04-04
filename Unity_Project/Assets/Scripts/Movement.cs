using System.Collections;
using System.Collections.Generic;
using UnityEngine;


public class Movement : MonoBehaviour {

    public class MoveSettings
    {
        public float forwardVel = 15;
        public float roatationVel = 100f;
        public float jumpVel = 5;
        public float disToGround = 0.1f;
        public bool ground = true;
        public float velocityY;
    }

    public class PhysSettings
    {
        public float downAccel = -0.78f;
        public float gravity = -9f;
    }

    public class InputSettings
    {
        public float inputDelay = 0.09f;
        public string FORWARD_AXIS = "Vertical";
        public string TURN_AXIS = "Horizontal";
        public string JUMP_AXIS = "Jump";
    }


    //reture value from -1 to 1
    float forwardInput, turnInput;
    float jumpInput;//reture value only -1,0,1

    public float currentVelocity, rotationSmooth=0.3f;

    Vector3 velocity = Vector3.zero;
    private Quaternion m_rotation;//Quaterenion used for rotation
    private CharacterController controller;
    //private Rigidbody m_rigidbody;
    private Animator m_animator;
    private AnimatorStateInfo animSta;
    private Transform camera_transform;


    public MoveSettings moveSettings = new MoveSettings();
    public PhysSettings physSettings = new PhysSettings();
    public InputSettings inputSettings = new InputSettings();

    private void Start()
    {
        forwardInput = 0;
        turnInput = 0;
        jumpInput = 0;
        moveSettings.ground = true;
        moveSettings.velocityY = 0;
        m_rotation = transform.rotation;//initial the rotation
        controller = GetComponent<CharacterController>();
        //m_rigidbody = GetComponent<Rigidbody>();
        m_animator = GetComponent<Animator>();
        camera_transform = Camera.main.transform;

    }

    private void Update()
    {
        if (m_animator.GetBool("k_death") == false)
        {
            GetInput();
            if (forwardInput != 0 || turnInput != 0 || jumpInput != 0)
            {
                transform.eulerAngles = Vector3.up * Mathf.SmoothDampAngle(transform.eulerAngles.y, camera_transform.eulerAngles.y, ref currentVelocity, rotationSmooth);
                //transform.eulerAngles = new Vector3(0, camera_transform.eulerAngles.y, 0);
            }
        }

    }

    private void FixedUpdate()
    {
        if (m_animator.GetBool("k_death") == false)
        {
            Run();
            Jump();

            moveSettings.velocityY += Time.deltaTime * physSettings.gravity;

            velocity.y = moveSettings.velocityY;
            velocity = transform.TransformDirection(velocity);
            controller.Move(velocity * Time.deltaTime);

            if (controller.isGrounded)
            {
                m_animator.SetBool("k_jump", false);
                moveSettings.velocityY = 0;
            }
        }

    }
    
    public Quaternion Rotation_value
    {
        get { return m_rotation; }
    }


    void GetInput()
    {
        forwardInput = Input.GetAxis(inputSettings.FORWARD_AXIS);
        turnInput = Input.GetAxis(inputSettings.TURN_AXIS);
        jumpInput = Input.GetAxis(inputSettings.JUMP_AXIS);
        //jumpInput = 0;

        m_animator.SetFloat("BlendY", forwardInput);//***
        m_animator.SetFloat("BlendX", turnInput);
        //m_animator.SetBool("k_death", false);

    }
    /// <summary>
    /// character move
    /// </summary>
    void Run()
    {
        if (Mathf.Abs(forwardInput) > inputSettings.inputDelay && transform.gameObject.GetComponent<Attack>().GetHit()==0 && m_animator.GetBool("k_death")!=true)
        {
            velocity.z = moveSettings.forwardVel * forwardInput;
        }
        else if (Mathf.Abs(forwardInput) < inputSettings.inputDelay && transform.gameObject.GetComponent<Attack>().GetHit() == 0 && m_animator.GetBool("k_death") != true)
        {
            velocity.z = 0;
        }


        if (Mathf.Abs(turnInput) > inputSettings.inputDelay && transform.gameObject.GetComponent<Attack>().GetHit() == 0 && m_animator.GetBool("k_death") != true)
        {
            velocity.x = moveSettings.forwardVel * turnInput;
        }
        else if (Mathf.Abs(turnInput) < inputSettings.inputDelay && transform.gameObject.GetComponent<Attack>().GetHit() == 0 && m_animator.GetBool("k_death") != true)
        {
            velocity.x = 0;
        }
        else
        {
            velocity.x = 0;
            velocity.z = 0;
        }
    }

    void Jump()
    {
        if (Mathf.Abs(jumpInput) > inputSettings.inputDelay && transform.gameObject.GetComponent<Attack>().GetHit() == 0 && m_animator.GetBool("k_death") != true)
        {
            if (controller.isGrounded)
            {
                m_animator.SetBool("k_jump", true);
                moveSettings.velocityY = Mathf.Sqrt(-2*physSettings.gravity*1);
            }
        }
    }

    private void OnCollisionEnter(Collision collision)
    {
        moveSettings.ground = true;
    }
}

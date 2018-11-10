using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Movement : MonoBehaviour {

    public class MoveSettings
    {
        public float forwardVel = 3;
        public float roatationVel = 100f;
        public float jumpVel = 12;
        //public float disToGround = 0.1f;
        public bool ground = true;
    }

    public class PhysSettings
    {
        public float downAccel = 0.78f;
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

    Vector3 velocity = Vector3.zero;
    private Quaternion m_rotation;//Quaterenion used for rotation
    private Rigidbody m_rigidbody;
    private Animator m_animator;
    private AnimatorStateInfo animSta;
    private Transform camera_transform;

    /*
    private const string BLENDTREE = "Blend Tree";
    private const string ATTACK1 = "attack1";
    private const string ATTACK2 = "attack2";
    private const string ATTACK3 = "attack3";
    private int hitCount = 0;*/


    public MoveSettings moveSettings = new MoveSettings();
    public PhysSettings physSettings = new PhysSettings();
    public InputSettings inputSettings = new InputSettings();

    private void Start()
    {
        forwardInput = 0;
        turnInput = 0;
        jumpInput = 0;
        moveSettings.ground = true;
        m_rotation = transform.rotation;//initial the rotation
        m_rigidbody = GetComponent<Rigidbody>();
        m_animator = GetComponent<Animator>();
        camera_transform = Camera.main.transform;

    }

    private void Update()
    {
        GetInput();

        transform.eulerAngles = new Vector3(0, camera_transform.eulerAngles.y, 0); 
        /*
        animSta = m_animator.GetCurrentAnimatorStateInfo(0);

        if (!animSta.IsName(BLENDTREE) && animSta.normalizedTime > 1f)
        {
            m_animator.SetInteger("attack_level", 0);
            hitCount = 0;
        }

        if (Input.GetMouseButton(0))
        {
            Attack();
        }*/
        MouseControll();
    }

    private void FixedUpdate()
    {
        Run();
        m_rigidbody.velocity = transform.TransformDirection(velocity);
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

        m_animator.SetFloat("BlendY", forwardInput);//***
        m_animator.SetFloat("BlendX", turnInput);
        m_animator.SetBool("k_death", false);

    }
    /// <summary>
    /// character move
    /// </summary>
    void Run()
    {
        if (Mathf.Abs(forwardInput) > inputSettings.inputDelay && transform.gameObject.GetComponent<Attack>().GetHit()==0 && m_animator.GetBool("k_death")!=true)
        {
            //m_animator.SetBool("run", true);
            velocity.z = moveSettings.forwardVel * forwardInput;
        }
        else if (Mathf.Abs(forwardInput) < inputSettings.inputDelay && transform.gameObject.GetComponent<Attack>().GetHit() == 0 && m_animator.GetBool("k_death") != true)
        {
            //m_animator.SetBool("run", false);
            // m_animator.SetBool("fight", true);
            velocity.z = 0;
        }


        if (Mathf.Abs(turnInput) > inputSettings.inputDelay && transform.gameObject.GetComponent<Attack>().GetHit() == 0 && m_animator.GetBool("k_death") != true)
        {
            //m_animator.SetBool("run", false);
            // m_animator.SetBool("fight", true);
            velocity.x = moveSettings.forwardVel * turnInput;
        }
        else if (Mathf.Abs(turnInput) < inputSettings.inputDelay && transform.gameObject.GetComponent<Attack>().GetHit() == 0 && m_animator.GetBool("k_death") != true)
        {
            //m_animator.SetBool("run", false);
            // m_animator.SetBool("fight", true);
            velocity.x = 0;
        }
        else
        {
            //m_animator.SetBool("run", false);
            velocity.x = 0;
            velocity.z = 0;
        }
    }
    /*
    void Attack()
    {
        if (animSta.IsName(BLENDTREE) && hitCount == 0 && animSta.normalizedTime > 0.5f)
        {
            m_animator.SetInteger("attack_level", 1);
            hitCount = 1;
        }
        else if (animSta.IsName(ATTACK1) && hitCount == 1 && animSta.normalizedTime > 0.6f)
        {
            m_animator.SetInteger("attack_level", 2);
            hitCount = 2;
        }
        else if (animSta.IsName(ATTACK2) && hitCount == 2 && animSta.normalizedTime > 0.8f)
        {
            m_animator.SetInteger("attack_level", 3);
            hitCount = 3;
        }
    }*/

    
    private void MouseControll()
    {/*
        float xPosition = Input.mousePosition.x / Screen.width;
        //float yPosition = Input.mousePosition.y / Screen.height;

        float yAngle = Mathf.Clamp(xPosition * 720, 30, 360);
        this.gameObject.transform.eulerAngles = new Vector3(0, yAngle, 0);*/

    }

    private void OnCollisionEnter(Collision collision)
    {
        moveSettings.ground = true;
    }
}

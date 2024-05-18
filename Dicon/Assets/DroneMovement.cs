using Cinemachine;
using Fusion;
using Fusion.Sockets;
using System.Collections;
using UnityEngine;


public class DronerController : MonoBehaviour
{
    float gravity = 20.0f;
    Animator m_animator;
    Vector3 m_velocity;
    CharacterController controller;

    private bool m_isGrounded = true;
    private bool m_jumpOn = false;

    public Joystick sJoystick;
    public float m_moveSpeed = 2.0f;
    public float m_jumpForce = 5.0f;

    public GameObject attackRangeCheckObj_1;
    public GameObject attackRangeCheckObj_2;
    public GameObject attackRangeCheckObj_3;

    public Camera Camera;

    public AttackController attackController;

    bool isAttacking;
    bool isMoving;

    void Awake()
    {
        m_animator = GetComponent<Animator>();
        controller = GetComponent<CharacterController>();
        attackController = GetComponent<AttackController>();

    }

    void Update()
    {
        if (controller.isGrounded)
        {
            float h = sJoystick.GetHorizontalValue();
            float v = sJoystick.GetVerticalValue();
            m_velocity = new Vector3(h, 0, v);
            m_velocity = m_velocity.normalized;

            //m_animator.SetFloat("Move", m_velocity.magnitude);

            if (m_velocity.magnitude > 0.5)
            {
                transform.LookAt(transform.position + m_velocity);
                isMoving = true;
            }
            else isMoving = false;
        }

        m_velocity.y -= gravity * Time.deltaTime;
        controller.Move(m_velocity * m_moveSpeed * Time.deltaTime);

        m_isGrounded = controller.isGrounded;
    }
}


using Cinemachine;
using Fusion;
using Fusion.Sockets;
using System.Collections;
using UnityEngine;


public class PlayerController : NetworkBehaviour
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

    public override void Spawned()
    {
        if (HasStateAuthority)
        {
            //Camera = Camera.main;
            //Camera.GetComponent<CinemachineBrain>()= transform;
            //Camera.GetComponent<CinemachineVirtualCamera>().LookAt = transform;
            CinemachineCore.Instance.GetActiveBrain(0).ActiveVirtualCamera.Follow = transform;
        }
    }

    public override void FixedUpdateNetwork()
    {
        if (HasStateAuthority == false)
        {
            return;
        }

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
    public override void Render()
    {
        if (isAttacking)
        {
            m_animator.SetTrigger("Attack");
            isAttacking = false;
        }

        if (isMoving)
        {
            m_animator.SetFloat("Move", m_velocity.magnitude);
        }
        else
        {
            m_animator.SetFloat("Move", 0);
        }
    }
    public void OnVirtualPadJump()
    {

        if (this == null) { return; }
        const float rayDistance = 0.2f;
        var ray = new Ray(transform.localPosition + new Vector3(0.0f, 0.1f, 0.0f), Vector3.down);
        if (Physics.Raycast(ray, rayDistance))
        {
            m_jumpOn = true;
        }
    }

    public void PlayerAttack()
    {
        isAttacking = true;
        attackController.AttackButtonClick();
    }

    public void PlayerSkill()
    {

    }
    public void PlayerUlt()
    {

    }

    public void PlayerDie()
    {

    }

}

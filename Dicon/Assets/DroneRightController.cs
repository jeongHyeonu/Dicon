using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.EventSystems;
using UnityEngine.UIElements;

public class DroneRightController : MonoBehaviour
{
    Rigidbody rb;
    CharacterController controller;

    public Joystick sJoystick;
    public float moveSpeed = 6.0f;
    public Vector3 m_velocity;
    public Vector3 movement;
    public float tiltAmount = 10.0f; // ����� ���� ����

    bool isAttacking;
    bool isMoving;

    void Awake()
    {
        rb = GetComponent<Rigidbody>();
        controller = GetComponent<CharacterController>();
    }

    void Update()
    {
        float h = sJoystick.GetHorizontalValue();
        float v = sJoystick.GetVerticalValue();

        // ����� �����¿� �̵�
        movement = new Vector3(h, 0, v) * moveSpeed * Time.deltaTime;
        //transform.Translate(movement,Space.World);
        movement = transform.TransformDirection(movement); // ����->���� ��ǥ��� ��ȯ
        controller.Move(movement);

        // ����� ���� ���
        float tiltX = h * tiltAmount;
        float tiltZ = v * tiltAmount;

        // ����� ȸ���� ���� ����
        Quaternion targetRotation = Quaternion.Euler(tiltZ, transform.eulerAngles.y, -tiltX);
        transform.rotation = Quaternion.Slerp(transform.rotation, targetRotation, Time.deltaTime * 2.0f); // �ε巴�� ���� ����
    }
}

using Cinemachine;
using System.Collections;
using UnityEngine;


public class DroneLeftController : MonoBehaviour
{
    CharacterController controller;

    public Joystick sJoystick;
    public float moveSpeed = 6.0f;
    public float rotationSpeed = 150.0f;

    bool isAttacking;
    bool isMoving;

    void Awake()
    {
        controller = GetComponent<CharacterController>();
    }

    void Update()
    {
        float h = sJoystick.GetHorizontalValue();
        float v = sJoystick.GetVerticalValue();

        // ����� ȸ��
        float rotationAmount = h * rotationSpeed * Time.deltaTime;
        transform.Rotate(0, rotationAmount, 0);

        // ����� ���� �̵�
        Vector3 verticalMovement = Vector3.up * v * moveSpeed * Time.deltaTime;
        controller.Move(verticalMovement);//.Translate(verticalMovement);
    }
}


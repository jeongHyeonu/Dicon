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
    public float tiltAmount = 10.0f; // 드론의 기울기 정도

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

        // 드론의 상하좌우 이동
        movement = new Vector3(h, 0, v) * moveSpeed * Time.deltaTime;
        //transform.Translate(movement,Space.World);
        movement = transform.TransformDirection(movement); // 로컬->월드 좌표계로 변환
        controller.Move(movement);

        // 드론의 기울기 계산
        float tiltX = h * tiltAmount;
        float tiltZ = v * tiltAmount;

        // 드론의 회전과 기울기 적용
        Quaternion targetRotation = Quaternion.Euler(tiltZ, transform.eulerAngles.y, -tiltX);
        transform.rotation = Quaternion.Slerp(transform.rotation, targetRotation, Time.deltaTime * 2.0f); // 부드럽게 기울기 적용
    }
}

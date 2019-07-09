using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Rotation_MouseClick : CameraSystem
{
    public enum MouseInput
    {
        LeftClick,
        RightClick,
        WheelClick
    }
    [Header("마우스 클릭으로 움직이게 할것인지 결정")]
    public bool requireClick = true;
    [Header("마우스 입력키")]
    public MouseInput mouseInput = MouseInput.RightClick;
    [Header("속도")]
    public float rotSpeed = 250.0f;
    public float smoothness = 5.0f;
    [Header("각도 한도")]
    public int yMinLimit = -80;
    public int yMaxLimit = 80;

    private float xDeg = 0.0f;                   // 회전 각도X
    private float yDeg = 0.0f;                   // 회전 각도Y
    private Quaternion currentRotation;          // 현재 회전값
    private Quaternion desiredRotation;          // 원하는 회전값

    /// <summary>
    /// CameraController에서 실행할 공통된 스타트 부분
    /// </summary>
    public override void CommonStart()
    {
        currentRotation = transform.rotation;
        desiredRotation = transform.rotation;

        xDeg = Vector3.Angle(Vector3.right, transform.right);
        yDeg = Vector3.Angle(Vector3.up, transform.up);
    }

    /// <summary>
    /// CameraController에서 실행할 공통된 업데이트 부분
    /// </summary>
    public override void CommonUpdate()
    {
        if (isActive)
            Rotation();
    }

    void Rotation()
    {
        if (Input.GetMouseButton((int)mouseInput) || !requireClick)
        {
            xDeg += Input.GetAxis("Mouse X") * rotSpeed * 0.02f;
            yDeg -= Input.GetAxis("Mouse Y") * rotSpeed * 0.02f;

            // 위아래 각도제한 Clamp
            yDeg = ClampAngle(yDeg, yMinLimit, yMaxLimit);
            // 원하는 각도와 현재 각도
            desiredRotation = Quaternion.Euler(yDeg, xDeg, 0);
            currentRotation = transform.rotation;

            // 현재 각도 --> 원하는 각도 회전
            transform.rotation = Quaternion.Lerp(currentRotation, desiredRotation, Time.deltaTime * smoothness);
        }
    }
}

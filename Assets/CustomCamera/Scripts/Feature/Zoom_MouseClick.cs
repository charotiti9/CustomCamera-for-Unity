using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Zoom_MouseClick : CameraSystem
{
    public enum MouseInput
    {
        LeftClick,
        RightClick,
        WheelClick
    }
    [Header("마우스 입력키")]
    public MouseInput mouseInput = MouseInput.LeftClick;
    [Header("거리 한도")]
    public float maxWheelDis = 20;
    public float minWheelDis = 0.6f;
    [Header("속도")]
    public float smoothness = 5.0f;

    private float currentDistance;               // 현재 거리값
    private float desiredDistance;               // 원하는 거리값
    private float xAdj = 0.0f;                   // X 보정값
    private float yAdj = 0.0f;                   // Y 보정값

    /// <summary>
    /// CameraController에서 실행할 공통된 스타트 부분
    /// </summary>
    public override void CommonStart()
    {
        // 초기화
        currentDistance = camManager.distance;
        desiredDistance = camManager.distance;
    }

    /// <summary>
    /// CameraController에서 실행할 공통된 업데이트 부분
    /// </summary>
    public override void CommonUpdate()
    {
        if (isActive)
            Zoom();
    }

    private void Zoom()
    {
        xAdj = Input.GetAxis("Mouse X");
        yAdj = Input.GetAxis("Mouse Y");
        if (Input.GetMouseButton((int)mouseInput))
        {
            // 원하는 거리 설정
            desiredDistance -= xAdj + yAdj * Time.deltaTime * Mathf.Abs(desiredDistance);
            // Zoom 한도 보정
            desiredDistance = Mathf.Clamp(desiredDistance, minWheelDis, maxWheelDis);
            // 현재 거리 설정
            currentDistance = Mathf.Lerp(currentDistance, desiredDistance, Time.deltaTime * smoothness);
        }  
    }
}

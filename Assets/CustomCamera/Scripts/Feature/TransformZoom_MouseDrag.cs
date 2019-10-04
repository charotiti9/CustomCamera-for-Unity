using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class TransformZoom_MouseDrag : CameraSystem
{
    public enum MouseInput
    {
        LeftClick,
        RightClick,
        WheelClick
    }
    [Header("마우스 클릭 여부")]
    public bool requireClick = true;
    [Header("마우스 입력키")]
    public MouseInput mouseInput = MouseInput.LeftClick;
    [Header("거리 한도")]
    public float maxWheelDis = 20;
    public float minWheelDis = 0.6f;
    [Header("속도")]
    public float speed = 5.0f;

    private float xAdj = 0.0f;                   // X 보정값
    private float yAdj = 0.0f;                   // Y 보정값

    /// <summary>
    /// CameraController에서 실행할 공통된 스타트 부분
    /// </summary>
    public override void CommonStart()
    {

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

        if (Input.GetMouseButton((int)mouseInput) || !requireClick)
        {
            // 원하는 거리 설정
            camManager.wantedDistance -= xAdj + yAdj * Time.deltaTime * Mathf.Abs(camManager.wantedDistance);
            // Zoom 한도 보정
            camManager.wantedDistance = Mathf.Clamp(camManager.wantedDistance, minWheelDis, maxWheelDis);
            // 현재 거리 설정
            camManager.currentDistance = Mathf.Lerp(camManager.currentDistance, camManager.wantedDistance, Time.deltaTime * speed);
        }
    }
}
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class FovZoom_MouseClick : CameraSystem
{
    public enum MouseInput
    {
        LeftClick,
        RightClick,
        WheelClick
    }

    [Header("마우스 입력키")]
    public MouseInput mouseInput = MouseInput.WheelClick;
    [Header("거리")]
    public float settingFov = 20;
    public float initialFov = 60;
    [Header("속도")]
    public float speed = 10.0f;

    /// <summary>
    /// CameraController에서 실행할 공통된 스타트 부분
    /// </summary>
    public override void CommonStart()
    {
        initialFov = camManager.currentFov;
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
        // 원하는 값으로 설정
        if (Input.GetMouseButton((int)mouseInput))
            camManager.wantedFov = settingFov;
        else
            camManager.wantedFov = initialFov;

        // 현재 거리 설정
        camManager.currentFov = Mathf.Lerp(camManager.currentFov, camManager.wantedFov, Time.deltaTime * speed);
    }
}
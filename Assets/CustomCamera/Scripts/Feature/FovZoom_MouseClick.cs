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

    public override void CommonStart()
    {
        initialFov = camManager.currentFov;
    }

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
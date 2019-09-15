using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class TranformZoom_MouseClick : CameraSystem
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
    public float settingDis = 0.6f;
    public float initialDis = 20f;
    [Header("속도")]
    public float speed = 5.0f;

    /// <summary>
    /// CameraController에서 실행할 공통된 스타트 부분
    /// </summary>
    public override void CommonStart()
    {
        initialDis = camManager.currentDistance;
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
        // 원하는 거리 설정
        if (Input.GetMouseButton((int)mouseInput))
            camManager.wantedDistance = settingDis;
        else
            camManager.wantedDistance = initialDis;

        // 현재 거리 설정
        camManager.currentDistance = Mathf.Lerp(camManager.currentDistance, camManager.wantedDistance, Time.deltaTime * speed);
    }
}

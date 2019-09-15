using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class TransformZoom_Wheel : CameraSystem
{
    [Header("거리 한도")]
    public float maxWheelDis = 20;
    public float minWheelDis = 0.6f;
    [Header("비율")]
    public int zoomRate = 40;
    [Header("속도")]
    public float speed = 5.0f;

    private bool isCoroutine;                    // 항상 실행되지 않게 하기 위해

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
        if (Input.GetAxis("Mouse ScrollWheel") != 0 && !isCoroutine)
        {
            StartCoroutine("ZoomCoroutine");
        }

    }

    IEnumerator ZoomCoroutine()
    {
        isCoroutine = true;
        camManager.wantedDistance = camManager.currentDistance;
        do
        {
            // 원하는 거리 설정
            camManager.wantedDistance -= Input.GetAxis("Mouse ScrollWheel") * Time.deltaTime * zoomRate * Mathf.Abs(camManager.wantedDistance);
            // Zoom 한도 보정
            camManager.wantedDistance = Mathf.Clamp(camManager.wantedDistance, minWheelDis, maxWheelDis);
            // 현재 거리 설정
            camManager.currentDistance = Mathf.Lerp(camManager.currentDistance, camManager.wantedDistance, Time.deltaTime * speed);

            yield return null;
        } while (camManager.currentDistance - camManager.wantedDistance > 0.1f || camManager.currentDistance - camManager.wantedDistance < -0.1f);
        isCoroutine = false;
    }
}

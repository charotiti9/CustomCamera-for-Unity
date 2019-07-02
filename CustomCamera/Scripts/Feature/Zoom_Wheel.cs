using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Zoom_Wheel : CameraSystem
{
    [Header("거리 한도")]
    public float maxWheelDis = 20;
    public float minWheelDis = 0.6f;
    [Header("비율")]
    public int zoomRate = 40;
    [Header("속도")]
    public float smoothness = 5.0f;

    private float currentDistance;               // 현재 거리값
    private float desiredDistance;               // 원하는 거리값
    private bool isCoroutine;                    // 항상 실행되지 않게 하기 위해

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
        if (Input.GetAxis("Mouse ScrollWheel") != 0 && !isCoroutine)
        {
            StartCoroutine("ZoomCoroutine");
        }

    }

    IEnumerator ZoomCoroutine()
    {
        isCoroutine = true;
        do
        {
            // 원하는 거리 설정
            desiredDistance -= Input.GetAxis("Mouse ScrollWheel") * Time.deltaTime * zoomRate * Mathf.Abs(desiredDistance);
            // Zoom 한도 보정
            desiredDistance = Mathf.Clamp(desiredDistance, minWheelDis, maxWheelDis);
            // 현재 거리 설정
            currentDistance = Mathf.Lerp(currentDistance, desiredDistance, Time.deltaTime * smoothness);

            // 매니저에 갱신
            camManager.distance = currentDistance;

            yield return null;
        } while (currentDistance - desiredDistance > 0.1f || currentDistance - desiredDistance < -0.1f);
        isCoroutine = false;
    }
}

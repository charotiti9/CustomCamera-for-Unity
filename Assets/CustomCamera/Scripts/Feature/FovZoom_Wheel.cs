using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class FovZoom_Wheel : CameraSystem
{
    [Header("거리 한도")]
    public float maxWheelDis = 60;
    public float minWheelDis = 20;
    [Header("비율")]
    public int zoomRate = 40;
    [Header("속도")]
    public float speed = 5.0f;

    private bool isCoroutine;                    // 항상 실행되지 않게 하기 위해
    

    public override void CommonStart()
    {

    }

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
        camManager.wantedFov = camManager.currentFov;
        do
        {
            // 원하는 거리 설정
            camManager.wantedFov -= Input.GetAxis("Mouse ScrollWheel") * Time.deltaTime * zoomRate * Mathf.Abs(camManager.wantedFov);
            // Zoom 한도 보정
            camManager.wantedFov = Mathf.Clamp(camManager.wantedFov, minWheelDis, maxWheelDis);
            // 현재 거리 설정
            camManager.currentFov = Mathf.Lerp(camManager.currentFov, camManager.wantedFov, Time.deltaTime * speed);

            yield return null;

        } while (camManager.currentFov - camManager.wantedFov > 0.1f || camManager.currentFov - camManager.wantedFov < -0.1f);
        isCoroutine = false;
    }
}

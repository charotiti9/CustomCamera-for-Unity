using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public abstract class CameraSystem : MonoBehaviour
{
    internal CameraManager camManager;
    private void Awake()
    {
        // 매니저 찾기
        camManager = GetComponent<CameraManager>();
    }

    /// <summary>
    /// 각도를 자른다
    /// </summary>
    /// <param name="angle">자르고 싶은 앵글</param>
    /// <param name="min">최소앵글</param>
    /// <param name="max">최대앵글</param>
    /// <returns></returns>
    public float ClampAngle(float angle, float min, float max)
    {
        if (angle < -360)
            angle += 360;
        if (angle > 360)
            angle -= 360;
        return Mathf.Clamp(angle, min, max);
    }

    public abstract void CommonStart();
    public abstract void CommonUpdate();
}
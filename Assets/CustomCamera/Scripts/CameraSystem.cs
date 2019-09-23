using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[RequireComponent(typeof(CameraManager))]
public class CameraSystem : MonoBehaviour
{
    public bool isActive = true;
    internal CameraManager camManager;


    private void Awake()
    {
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

    public virtual void CommonStart() { }
    public virtual void CommonUpdate() { }
}
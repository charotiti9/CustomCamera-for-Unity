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

    public abstract void CommonStart();
    public abstract void CommonUpdate();
}
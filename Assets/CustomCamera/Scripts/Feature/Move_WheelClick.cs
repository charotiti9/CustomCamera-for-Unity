using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Move_WheelClick : CameraSystem
{
    [Header("움직임 속도")]
    [Range(0,1)]
    public float moveSpeed = 0.3f;

    private Transform target;

    /// <summary>
    /// CameraController에서 실행할 공통된 스타트 부분
    /// </summary>
    public override void CommonStart()
    {
        target = camManager.target;
    }

    /// <summary>
    /// CameraController에서 실행할 공통된 업데이트 부분
    /// </summary>
    public override void CommonUpdate()
    {
        CameraWheelMove();
    }



    void CameraWheelMove()
    {
        if (Input.GetMouseButton(2))
        {
            // Y는 World 공간에서 
            target.rotation = transform.rotation;
            target.Translate(Vector3.right * -Input.GetAxis("Mouse X") * moveSpeed);
            target.Translate(transform.up * -Input.GetAxis("Mouse Y") * moveSpeed, Space.World);
        }
    }
}
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Move_MouseClick : CameraSystem
{
    public enum MouseInput
    {
        LeftClick,
        RightClick,
        WheelClick
    }
    [Header("마우스 클릭으로 움직이게 할것인지 결정")]
    public bool requireClick = true;
    [Header("마우스 입력키")]
    public MouseInput mouseInput = MouseInput.WheelClick;
    [Header("움직임 속도")]
    [Range(0,1)]
    public float moveSpeed = 0.3f;

    public override void CommonStart()
    {

    }

    public override void CommonUpdate()
    {
        if (isActive)
            Move();
    }

    void Move()
    {
        if (Input.GetMouseButton((int)mouseInput) || !requireClick)
        {
            // Y는 World 공간에서 
            camManager.target.rotation = transform.rotation;
            camManager.target.Translate(Vector3.right * -Input.GetAxis("Mouse X") * moveSpeed);
            camManager.target.Translate(transform.up * -Input.GetAxis("Mouse Y") * moveSpeed, Space.World);
        }
    }
}
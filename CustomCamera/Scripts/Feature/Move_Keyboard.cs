using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Move_Keyboard : CameraSystem
{
    [Header("키보드 입력키")]
    public KeyCode fowardKey = KeyCode.W;
    public KeyCode LeftKey = KeyCode.A;
    public KeyCode BackKey = KeyCode.S;
    public KeyCode RightKey = KeyCode.D;
    [Header("움직임 속도")]
    public float moveSpeed = 3f;

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
        if (isActive)
            Move();
    }

    void Move()
    {
        if (Input.GetKey(fowardKey))
        {
            target.position += transform.up * moveSpeed * Time.deltaTime;
        }
        if (Input.GetKey(LeftKey))
        {
            target.position += -transform.right * moveSpeed * Time.deltaTime;
        }
        if (Input.GetKey(BackKey))
        {
            target.position += -transform.up * moveSpeed * Time.deltaTime;
        }
        if (Input.GetKey(RightKey))
        {
            target.position += transform.right * moveSpeed * Time.deltaTime;
        }
    }
}

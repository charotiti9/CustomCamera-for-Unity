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
        if (Input.GetKey(fowardKey))
        {
            camManager.target.position += transform.up * moveSpeed * Time.deltaTime;
        }
        if (Input.GetKey(LeftKey))
        {
            camManager.target.position += -transform.right * moveSpeed * Time.deltaTime;
        }
        if (Input.GetKey(BackKey))
        {
            camManager.target.position += -transform.up * moveSpeed * Time.deltaTime;
        }
        if (Input.GetKey(RightKey))
        {
            camManager.target.position += transform.right * moveSpeed * Time.deltaTime;
        }
    }
}

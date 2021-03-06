﻿using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Move_MouseBorder : CameraSystem
{
    [Header("경계선 offset")]
    public float borderOffset = 10.0f;
    [Header("움직임 속도")]
    public float moveSpeed = 3.0f;

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
        if (Input.mousePosition.x >= Screen.width - borderOffset)
        {
            camManager.target.position += transform.right * Time.deltaTime * moveSpeed;
        }
        if (Input.mousePosition.x <= 0 + borderOffset)
        {
            camManager.target.position -= transform.right * Time.deltaTime * moveSpeed;
        }
        if (Input.mousePosition.y >= Screen.height - borderOffset)
        {
            camManager.target.position += transform.up * Time.deltaTime * moveSpeed;
        }
        if (Input.mousePosition.y <= 0 + borderOffset)
        {
            camManager.target.position -= transform.up * Time.deltaTime * moveSpeed;
        }
    }
}

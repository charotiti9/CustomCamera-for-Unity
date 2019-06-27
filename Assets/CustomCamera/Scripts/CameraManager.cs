using System.Collections;
using System.Collections.Generic;
using UnityEngine;

/// <summary>
/// 카메라의 초기위치를 설정하고, 타겟을 가지고 있음
/// 각 카메라 시스템들의 함수를 호출하고 일괄처리
/// </summary>
public class CameraManager : MonoBehaviour
{
    #region 전역변수
    [Header("카메라의 가상타겟")]
    public Transform target;
    [Header("타겟 위치 오프셋")]
    public Vector3 targetOffset;
    [Header("카메라와 디폴트 타겟 거리")]
    public float distance = 5.0f;

    private CameraSystem[] camSystems;          // 카메라 시스템들
    #endregion

    private void Awake()
    {
        camSystems = GetComponents<CameraSystem>();
        Init();
    }

    private void Start()
    {
        for (int i = 0; i < camSystems.Length; i++)
        {
            camSystems[i].CommonStart();
        }
    }

    private void OnEnable() { Init(); }

    private void LateUpdate()
    {
        for (int i = 0; i < camSystems.Length; i++)
        {
            camSystems[i].CommonUpdate();
        }
    }


    /// <summary>
    /// 타겟 위치 초기화
    /// </summary>
    public void Init()
    {
        if (!GetComponent<Camera>())
            throw new System.Exception("카메라가 없습니다. 컴포넌트를 카메라 객체에 붙여주세요.");

        //타겟이 없다면 타겟을 만들고 타겟의 위치를 default위치로 설정한다.
        if (!target)
        {
            Debug.Log("타겟이 설정되지 않았습니다. 임의의 타겟을 만듭니다.");
            GameObject tempTarget = new GameObject("EyeTarget");
            tempTarget.transform.position = transform.position + (transform.forward * distance);
            target = tempTarget.transform;
        }
        // 타겟이 있다면 타겟 자리에 가상의 오브젝트를 생성하여 기준으로 삼는다.
        else
        {
            if (!GameObject.Find("EyeTarget"))
            {
                GameObject tempTarget = new GameObject("EyeTarget");
                tempTarget.transform.position = target.position;
                target = tempTarget.transform;
            }
            else
                target = GameObject.Find("EyeTarget").transform;
        }

        // 거리설정
        distance = Vector3.Distance(transform.position, target.position);

    }

    /// <summary>
    /// 시스템을 활성/비활성
    /// </summary>
    /// <param name="isOn">true: 활성화 / false: 비활성화</param>
    void SetAllSystemActivate(bool isOn = true)
    {
        for (int i = 0; i < camSystems.Length; i++)
        {
            SetSystemActivate(i, isOn);
        }
    }
    /// <summary>
    /// 개별 시스템 활성/비활성
    /// </summary>
    /// <param name="num">활성/비활성화 할 기능 번호</param>
    /// <param name="isOn">true: 활성화 / false: 비활성화</param>
    void SetSystemActivate(int num, bool isOn = true)
    {
        camSystems[num].isActive = isOn;
    }

    /// <summary>
    /// 최종 카메라와 아이타겟의 위치/회전값
    /// </summary>
    void PostTransform()
    {
        //// 최종 위치 설정
        //transform.position = target.position - (transform.rotation * Vector3.forward * currentDistance + targetOffset);

        //// 현재 각도 --> 원하는 각도 회전
        //transform.rotation = Quaternion.Lerp(currentRotation, desiredRotation, Time.deltaTime * smoothness);
    }
}

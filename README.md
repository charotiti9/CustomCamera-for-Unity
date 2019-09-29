# README

# CustomCamera for Unity

> Drag & Drop을 이용하여 카메라를 손쉽게 조작할 수 있다.  
You can easily handle the camera using Drag & Drop.

주변에 아트나 기획자들이 유니티는 어느정도 다룰 줄 알지만, 가장 기본적인 카메라 조작이나 캐릭터 조작에 어려움을 겪는 사람들이 많았다. 그들을 위해 손쉽게 커스터마이징 할 수 있는 카메라 프로젝트를 제작하였다.  
Art and designers know how to deal with Unity, but many have had trouble with the most basic camera and character manipulations. I created a camera project that I could easily customize for them.

---

## 설치 방법 (How to install)

1. Download `Master` Branch
2. Open the Unity -> Open File

---

## 사용 방법 (How to use)

컴포넌트를 메인카메라에 드래그 합니다.  
Just Drag Component in your main camera.

<img src="https://vo.la/Phox" width="60%">

컴포넌트의 위치는 `CustomCamera/Scripts/Feature`입니다.  
기능을 드래그하면 자동으로 `CameraManager.cs`가 생성됩니다.

### CameraManager.cs

- 기본 제어를 위한 컴포넌트
- 카메라의 오프셋을 설정

### Features

- Move_ : 상하좌우로 평행이동
- Rotate_: 회전
    - `CameraManager.cs`에서 Distance를 0으로 설정할 시 1인칭 시점 회전
    - 그 외엔 Orbit 회전
- TransformZoom_: Z축 거리를 이동
- FovZoom_: 카메라 field of view를 조절(망원경)
- 추가예정...

---

## 업데이트 (Update)

- 0.1.0
    - Add Fov feature
- 0.1.1
    - Add Prefabs

---

## 정보(Info)

Yong HyeonJeong
- [@Charo_999](https://twitter.com/charo_999)
- [charotiti9@gmail.com](mailto:charotiti9@gmail.com)

[MIT 라이센스](https://github.com/charotiti9/CustomCamera-for-Unity/blob/master/LICENSE)를 준수하며 `LICENSE`에서 자세한 정보를 확인할 수 있습니다.  

---

## 기여 방법

1. ([https://github.com/charotiti9/CustomCamera-for-Unity/fork](https://github.com/charotiti9/CustomCamera-for-Unity/fork))을 포크합니다.
2. (`git checkout -b feature/'your name'`) 명령어로 새 브랜치를 만드세요.
3. (`git commit -am 'What you added'`) 명령어로 커밋하세요.
4. (`git push origin feature/'your name'`) 명령어로 브랜치에 푸시하세요.
5. 풀리퀘스트를 보내주세요.

OR

1. `Issues`에 의견을 올려주세요!

검토 후 반영하겠습니다!  
감사합니다.

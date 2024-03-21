using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Shield : MonoBehaviour
{
    void Update()
    {
        // 스크린 상의 마우스 좌표를 카메라가 찍고 있는 월드 좌표로 바꿔준다.
        Vector2 mousePos = Camera.main.ScreenToWorldPoint(Input.mousePosition);

        // 게임 오브젝트 (shield) 의 위치로 설정
        transform.position = mousePos;
    }
}

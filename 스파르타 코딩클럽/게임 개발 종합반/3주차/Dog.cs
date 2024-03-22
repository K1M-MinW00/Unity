using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Dog : MonoBehaviour
{

    public GameObject food; // Food 오브젝트

    void Start()
    {
        // MakeFood() 함수를 0초부터 0.2초 간격으로 반복
        InvokeRepeating("MakeFood", 0.0f, 0.2f);
    }

    void Update()
    {
        // 스크린 상의 마우스 좌표를 카메라가 찍고 있는 월드 좌표로 바꿔준다.
        Vector3 mousePos = Camera.main.ScreenToWorldPoint(Input.mousePosition);

        float x = mousePos.x;

        // FishShop 의 범위를 벗어나지 않게 설정
        if (x > 8.5f)
            x = 8.5f;
        else if (x < -8.5f)
            x = -8.5f;

        // Dog Pos = FishShop 범위 안의 마우스 x 좌표 , Dog 의 y 좌표 로 지정
        transform.position = new Vector2(x, transform.position.y);
    }

    void MakeFood()
    {
        // Dog 의 x 좌표와 y + 2 좌표
        float x = transform.position.x;
        float y = transform.position.y + 2.0f;

        // 새로운 food 오브젝트를 (x,y) 좌표에 생성 -> 오브젝트 스포닝
        Instantiate(food, new Vector2(x, y), Quaternion.identity); // Quaternion.identity : 회전 없음
    }
}

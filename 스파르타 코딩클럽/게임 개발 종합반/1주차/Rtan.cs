using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Rtan : MonoBehaviour
{

    float direction = 0.05f;

    SpriteRenderer renderer; // SpriteRenderer 컴포넌트를 담아줄 변수 renderer

    void Start()
    {
        // 기기 성능과 관계 없이 프레임을 고정하는 코드
        Application.targetFrameRate = 60;

        // Rtan 오브젝트에 붙어 있는 SpriteRenderer 컴포넌트 사용
        renderer = GetComponent<SpriteRenderer>();
    }

    void Update()
    {
        // 1) 마우스 왼쪽 클릭 -> 현재 방향에 반대
        if (Input.GetMouseButtonDown(0)) // 0 : 왼쪽 버튼, 1 : 오른쪽 버튼, 2 : 휠 버튼
        {
            direction *= -1;
            renderer.flipX = !renderer.flipX;

        }

        // 2-1) 르탄이가 오른쪽 벽에 닿을 때 -> 왼쪽 방향으로
        if (transform.position.x > 2.6f)
        {
            renderer.flipX = true;
            direction = -0.05f;
        }

        // 2-2) 르탄이가 왼쪽 벽에 닿을 때 -> 오른쪽 방향으로
        else if (transform.position.x < -2.6f)
        {
            renderer.flipX = false;
            direction = 0.05f;
        }

        transform.position += Vector3.right * direction;
    }
}

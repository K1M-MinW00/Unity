using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Food : MonoBehaviour
{
    void Update()
    {
        // 위 방향으로 0.5f 만큼 이동
        transform.position += Vector3.up * 0.5f;

        // Food 의 y 좌표가 26.0f 초과일 때
        if (transform.position.y > 26.0f)
            Destroy(gameObject); // Food 오브젝트 제거
    }
}

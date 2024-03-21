using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Square : MonoBehaviour
{
    void Start()
    {
        // square 이 생성될 좌표를 랜덤으로 설정
        float x = Random.Range(-3.0f, 3.0f);
        float y = Random.Range(3.0f, 5.0f);

        // 랜덤한 좌표에 오브젝트 위치 지정
        transform.position = new Vector2(x, y);

        // square 의 크기를 랜덤으로 설정
        float size = Random.Range(0.5f, 1.5f);
        transform.localScale = new Vector2(size, size);
    }

    void Update()
    {
        // square 의 y 좌표가 -5.0f 미만일 때
        if (transform.position.y < -5.0f)
            Destroy(gameObject); // square 오브젝트 제거
    }

    private void OnCollisionEnter2D(Collision2D collision)
    {
        // 충돌한 오브젝트의 태그 == Player
        if (collision.gameObject.CompareTag("Player"))
        {
            // GameManager 를 통해 GameOver() 함수를 호출
            GameManager.Instance.GameOver();
        }
    }
}

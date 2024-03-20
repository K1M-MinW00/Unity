using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Rain : MonoBehaviour
{
    float size = 1.0f;
    int score = 1;

    SpriteRenderer renderer; // 컴포넌트를 담아줄 변수 renderer

    void Start()
    {
        // Rain 오브젝트에 붙어 있는 SpriteRenderer 컴포넌트 사용
        renderer = GetComponent<SpriteRenderer>();

        // Rain 이 생성될 좌표를 랜덤으로 설정
        float x = Random.Range(-2.4f, 2.4f);
        float y = Random.Range(3.0f, 5.0f);

        // 랜덤한 좌표에 오브젝트 위치 지정
        transform.position = new Vector3(x, y, 0);

        // Rain 의 타입 랜덤 설정
        int type = Random.Range(1, 5);

        // 타입에 따라 Rain 의 크기와 점수, 색상 지정
        if (type == 1)
        {
            size = 0.8f;
            score = 1;
            renderer.color = new Color(100 / 255f, 100 / 255f, 1f, 1f);
        }
        else if (type == 2)
        {
            size = 1.0f;
            score = 2;
            renderer.color = new Color(130 / 255f, 130 / 255f, 1f, 1f);
        }
        else if (type == 3)
        {
            size = 1.2f;
            score = 3;
            renderer.color = new Color(150 / 255f, 150 / 255f, 1f, 1f);
        }
        else
        {
            size = 0.8f;
            score = -5;
            renderer.color = new Color(255 / 255f, 100 / 255f, 100 / 255f, 1f);
        }

        transform.localScale = new Vector3(size, size, 0);
    }

    // Rain 오브젝트의 Collider 2D 가 다른 오브젝트의 Collider 2D와 닿을 때 호출
    private void OnCollisionEnter2D(Collision2D collision)
    {
        // 충돌한 오브젝트의 태그 == "Ground"
        if (collision.gameObject.CompareTag("Ground"))
        {
            // Ground 와 충돌한 Rain 오브젝트 제거
            Destroy(this.gameObject);
        }

        // 충돌한 오브젝트의 태그 == "Player"
        if (collision.gameObject.CompareTag("Player"))
        {
            // Rain 오브젝트의 score 를 전달하는 Addscore 함수 호출
            GameManager.Instance.AddScore(score);

            // Player 와 충돌한 Rain 오브젝트 제거
            Destroy(this.gameObject);
        }
    }
}

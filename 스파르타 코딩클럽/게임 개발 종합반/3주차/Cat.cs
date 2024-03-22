using System.Collections;
using System.Collections.Generic;
using UnityEditor;
using UnityEngine;

public class Cat : MonoBehaviour
{
    public RectTransform front; // RectTransform 컴포넌트를 받을 변수 front (HP 바의 front)

    public GameObject hungryCat; // 포만감이 차기 전 hungryCat 오브젝트
    public GameObject fullCat; // 포만감이 찬 fullCat 오브젝트

    public int type; // 고양이 타입 , 1 - normal cat , 2 - fat cat , 3 - pirate cat

    float full = 5f;
    float energy = 0f;
    float speed = 0.05f;

    bool isFull = false;

    void Start()
    {
        // Cat 이 생성될 좌표를 랜덤으로 설정
        float x = Random.Range(-9.0f, 9.0f);
        float y = 30.0f;

        // 랜덤한 좌표에 Cat 오브젝트 위치 지정
        transform.position = new Vector2(x, y);

        // 타입에 따라 Cat 의 속도와 최대 포만감 지정
        if (type == 1)
        {
            speed = 0.05f;
            full = 5.0f;
        }
        else if (type == 2)
        {
            speed = 0.02f;
            full = 10f;
        }
        else if (type == 3)
        {
            speed = 0.1f;
        }
    }

    void Update()
    {
        // 포만감이 덜 찼을 때
        if (energy < full)
        {
            // Cat 이 계속 아래로 이동
            transform.position += Vector3.down * speed;

            // y 좌표가 -16.0 미만이면
            if (transform.position.y < -16.0f)
            {
                // GameManager 를 통해 GameOver() 함수를 호출
                GameManager.Instance.GameOver();
            }
        }

        // 포만감이 다 찼을 때
        else
        {
            // Cat 이 중앙보다 오른쪽에 위치한다면
            if (transform.position.x > 0)
                transform.position += Vector3.right * speed; // 더 이상 앞으로 다가오지 않고, 화면의 오른쪽으로 이동

            // Cat 이 중앙보다 왼쪽에 위치한다면
            else
                transform.position += Vector3.left * speed; // 더 이상 앞으로 다가오지 않고, 화면의 왼쪽으로 이동
        }
    }


    private void OnTriggerEnter2D(Collider2D collision)
    {
        // 충돌한 오브젝트의 태그 == Food
        if (collision.CompareTag("Food"))
        {
            // 포만감이 덜 찼다면
            if (energy < full)
            {
                energy += 1.0f;
                front.localScale = new Vector3(energy / full, 1f, 1f);
                Destroy(collision.gameObject); // 충돌한 물체인 Food 오브젝트 제거

                // 포만감이 다 찼다면
                if (energy == full)
                {
                    // 상태를 관리하여 AddScore() 함수가 한 번만 호출되게 설정
                    if (!isFull)
                    {
                        isFull = true;

                        hungryCat.SetActive(false);
                        fullCat.SetActive(true);

                        Destroy(gameObject, 3.0f); // Cat 오브젝트를 3초 뒤에 제거
                        GameManager.Instance.AddScore(); // GameManager 를 통해 AddScore( ) 함수를 호출
                    }

                }
            }
        }
    }
}

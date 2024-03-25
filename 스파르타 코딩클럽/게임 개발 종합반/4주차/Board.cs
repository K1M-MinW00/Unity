using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using System.Linq;

public class Board : MonoBehaviour
{
    public GameObject card; // card 오브젝트

    void Start()
    {
        int[] arr = { 0, 0, 1, 1, 2, 2, 3, 3, 4, 4, 5, 5, 6, 6, 7, 7 };
        arr = arr.OrderBy(x => Random.Range(0f, 7f)).ToArray();

        for (int i = 0; i < 16; i++)
        {
            // 새로운 게임 오브젝트 인스턴스 card 를 생성
            GameObject go = Instantiate(card);

            // 카드를 적절한 위치에 배치
            float x = (i % 4) * 1.4f - 2.1f;
            float y = (i / 4) * 1.4f - 3.0f;
            go.transform.position = new Vector2(x, y);

            // Card.cs 의 컴포넌트 안에 있는 Setting 이라는 함수를 불러온다.
            go.GetComponent<Card>().Setting(arr[i]);
        }

        // GameManager 에게 card 의 개수를 전달
        GameManager.instance.cardCount = arr.Length;
    }

}

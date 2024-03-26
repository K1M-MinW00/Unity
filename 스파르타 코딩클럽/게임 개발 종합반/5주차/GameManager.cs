using System.Collections;
using System.Collections.Generic;
using Unity.Collections.LowLevel.Unsafe;
using UnityEngine;
using UnityEngine.UI;

public class GameManager : MonoBehaviour
{
    // 싱글톤 : 어떤 프로젝트가 프로그램에 단 하나만 존재하며, 어느 곳에서도 쉽게 접근 가능해야 할 때 사용
    public static GameManager instance;

    public Text TimeTxt; // 시간을 표시하는 UI
    public GameObject EndTxt; // 게임 종료 시 표시하는 UI

    public Card firstCard; // 첫번째로 뒤집는 카드
    public Card secondCard; // 두번째로 뒤집는 카드

    AudioSource audioSource; // 카드 맞췄을 때 재생할 AudioSource 컴포넌트를 받을 변수 audioSource
    public AudioClip clip; // 카드 맞췄을 때 재생할 Audioclip

    float time = 0.0f;
    public int cardCount = 0;

    private void Awake()
    {
        // 인스턴스 초기화
        if (instance == null)
        {
            instance = this;
        }
    }

    void Start()
    {
        // 타이머 시작
        Time.timeScale = 1.0f;

        audioSource = GetComponent<AudioSource>();
    }

    void Update()
    {
        // 플레이 시간을 30초로 설정
        if (time < 30.0f)
        {
            time += Time.deltaTime; // 시간이 흘러감
            TimeTxt.text = time.ToString("N2");
        }

        // 30초가 지나면
        else
        {
            EndTxt.SetActive(true); // 게임 종료 UI 표시
            Time.timeScale = 0f; // 더 이상 시간이 흐르지 않음
        }
    }

    public void Matched()
    {
        // 첫번째 카드와 두번째 카드의 정보가 같다면
        if (firstCard.idx == secondCard.idx)
        {
            audioSource.PlayOneShot(clip);

            // Card.cs 의 DestroyCard() 함수를 호출
            firstCard.DestroyCard();
            secondCard.DestroyCard();

            // 남은 카드 개수 -= 2
            cardCount -= 2;

            if (cardCount == 0) // 카드를 모두 지웠으면
            {
                Time.timeScale = 0.0f; // 더 이상 시간이 흐르지 않음
                EndTxt.SetActive(true); // 게임 종료 UI 표시
            }
        }

        // 첫번째 카드와 두번째 카드의 정보가 다르다면
        else
        {
            // Card.cs 의 CloseCard() 함수를 호출
            firstCard.CloseCard();
            secondCard.CloseCard();
        }

        // 카드 정보 초기화
        firstCard = null;
        secondCard = null;
    }
}

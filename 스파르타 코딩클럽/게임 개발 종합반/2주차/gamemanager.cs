using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;


public class GameManager : MonoBehaviour
{
    // 싱글톤 : 어떤 프로젝트가 프로그램에 단 하나만 존재하며, 어느 곳에서도 쉽게 접근 가능해야 할 때 사용
    public static GameManager Instance;


    public GameObject square; // 하늘에서 떨어지는 square 오브젝트
    public GameObject EndPanel; // 게임 종료 시 나타날 UI

    public Text timeTxt; // 남은 시간을 표시하는 UI
    public Text NowScore; // 점수를 표시하는 UI
    public Text BestScore; // 최고 점수를 표시하는 UI

    public Animator anim; // Ballon 의 애니메이터 컴포넌트를 담아줄 변수 anim


    float time = 0.0f;
    bool isPlay = true;
    string key = "BestScore";

    private void Awake()
    {
        // 인스턴스 초기화
        if (Instance == null)
            Instance = this;
    }

    void Start()
    {
        // 타이머 시작
        Time.timeScale = 1.0f;

        // MakeSqaure 함수를 0초부터 1초 간격으로 반복
        InvokeRepeating("MakeSquare", 0f, 1f);
    }

    void Update()
    {
        // 게임이 진행 중일 때
        if (isPlay)
        {
            time += Time.deltaTime; // 시간이 흐름
            timeTxt.text = time.ToString("N2"); // 남은 시간을 표시
        }
    }

    void MakeSquare()
    {
        Instantiate(square); // 새로운 square 오브젝트를 생성 -> 오브젝트 스포닝
    }

    public void GameOver()
    {
        isPlay = false; // Update( ) 에서 더 이상 time 에 시간이 증가되지 않게 하기 위해

        anim.SetBool("isDie", true); // Ballon 애니메이터의 isDie 매개변수를 true 로 변경 -> 조건을 만족하게 되어 Ballon_Die 애니메이션이 실행

        // TimeStop( ) 함수를 0.5초 뒤에 호출 -> 풍선이 터지는 애니메이션을 위해
        Invoke("TimeStop", 0.5f);

        // 현재 점수를 표시
        NowScore.text = time.ToString("N2"); // N2 : 소수점 2번째 자리까지만 표시

        // key (BestScore) 가 있다면
        if (PlayerPrefs.HasKey(key))
        {
            float best = PlayerPrefs.GetFloat(key);
            // 최고 점수 < 현재 점수
            if (best < time)
            {
                PlayerPrefs.SetFloat(key, time);
                BestScore.text = time.ToString("N2");
            }

            // 최고 점수 >= 현재 점수
            else
                BestScore.text = best.ToString("N2");
        }

        // key (BestScore) 가 없다면
        else
        {
            PlayerPrefs.SetFloat(key, time);
            BestScore.text = time.ToString("N2");
        }

        EndPanel.SetActive(true);

    }

    void TimeStop()
    {
        Time.timeScale = 0.0f; // 더 이상 시간이 흐르지 않음
    }
}

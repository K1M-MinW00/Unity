using JetBrains.Annotations;
using System.Collections;
using System.Collections.Generic;
using UnityEditor.Experimental.GraphView;
using UnityEngine;
using UnityEngine.UI;

public class GameManager : MonoBehaviour
{
    // 싱글톤 : 어떤 프로젝트가 프로그램에 단 하나만 존재하며, 어느 곳에서도 쉽게 접근 가능해야 할 때 사용
    public static GameManager Instance;

    public GameObject rain; // Rain 오브젝트
    public GameObject EndPanel; // 게임 종료 시 나타날 UI

    public Text totalScoreTxt; // 점수를 표시하는 UI
    public Text timeTxt; // 남은 시간을 표시하는 UI

    int totalScore = 0;
    float totalTime = 30.0f;

    private void Awake()
    {
        // 인스턴스 초기화
        Instance = this;

        // 타이머 시작
        Time.timeScale = 1f;
    }
    void Start()
    {
        // MakeRain() 함수를,  0초부터, 1초 간격으로 반복
        InvokeRepeating("MakeRain", 0f, 1f);
    }

    void Update()
    {
        // 1) 남은 시간이 0f 보다 클 때
        if (totalTime > 0f)
            totalTime -= Time.deltaTime; // 시간이 흐름

        // 2) 남은 시간이 0f 이하일 때
        else
        {
            totalTime = 0f;
            EndPanel.SetActive(true); // EndPanel 을 활성화

            Time.timeScale = 0f; // 더 이상 시간이 흐르지 않음
        }

        // 3) 남은 시간을 표시
        timeTxt.text = totalTime.ToString("N2"); // N2 : 소수점 2번째 자리까지만 표시
    }

    void MakeRain()
    {
        Instantiate(rain); // 새로운 rain 오브젝트를 생성 -> 오브젝트 스포닝
    }

    public void AddScore(int score)
    {
        // 점수 관리
        totalScore += score;

        // 점수를 표시
        totalScoreTxt.text = totalScore.ToString();
    }
}

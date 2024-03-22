using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class GameManager : MonoBehaviour
{
    // 싱글톤 : 어떤 프로젝트가 프로그램에 단 하나만 존재하며, 어느 곳에서도 쉽게 접근 가능해야 할 때 사용
    public static GameManager Instance;

    public GameObject NormalCat; // Type 1 일반 고양이
    public GameObject FatCat; // Type 2 뚱뚱한 고양이
    public GameObject PirateCat; // Type 3 해적 고양이

    public GameObject RetryBtn;

    public RectTransform levelFront; // RectTransform 컴포넌트를 받을 변수 levelfront (Level 경험치 바의 front)

    public Text levelTxt; // 레벨을 표시하는 Text

    int level = 0;
    int score = 0;

    private void Awake()
    {
        // 인스턴스 초기화
        if (Instance == null)
            Instance = this;

        // 기기에 관계없이 프레임을 고정
        Application.targetFrameRate = 60;

        // 타이머 시작
        Time.timeScale = 1.0f;
    }

    void Start()
    {
        // MakeCat() 함수를 0초부터 1초간격으로 반복
        InvokeRepeating("MakeCat", 0f, 1f);
    }


    void MakeCat()
    {
        // 새로운 NormalCat 오브젝트를 생성
        Instantiate(NormalCat);


        if (level == 1) // Lv.1 20% 확률로 고양이를 더 생성
        {
            int p = Random.Range(0, 10);
            if (p < 2)
                Instantiate(NormalCat);
        }
        else if (level == 2)// Lv.2 50% 확률로 고양이를 더 생성
        {
            int p = Random.Range(0, 10);
            if (p < 5)
                Instantiate(NormalCat);
        }
        else if (level == 3)// Lv.3 50% 확률로 뚱뚱한 고양이를 더 생성
        {
            int p = Random.Range(0, 10);
            if (p < 5)
                Instantiate(FatCat);
        }
        else if (level >= 4) // Lv.4 50% 확률로 고양이를 더 생성 , 뚱뚱한 고양이와 해적 고양이 생성
        {
            int p = Random.Range(0, 10);
            if (p < 5)
                Instantiate(NormalCat);
            Instantiate(FatCat);
            Instantiate(PirateCat);
        }

    }

    public void GameOver()
    {
        Time.timeScale = 0f; // 더 이상 시간이 흐르지 않음

        RetryBtn.SetActive(true); // RetryBtn 을 활성화
    }

    public void AddScore()
    {
        score++; // 점수 관리
        level = score / 5; // 레벨 관리

        levelTxt.text = level.ToString(); // 레벨을 표시
        levelFront.localScale = new Vector2((score - level * 5) / 5.0f, 1f); // 레벨 경험치 바를 표시
    }
}

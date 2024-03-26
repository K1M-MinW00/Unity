using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class AudioManager : MonoBehaviour
{
    // 싱글톤 : 어떤 프로젝트가 프로그램에 단 하나만 존재하며, 어느 곳에서도 쉽게 접근 가능해야 할 때 사용
    public static AudioManager instance;

    AudioSource audioSource; // 배경음악을 실행할 AudioSource 컴포넌트를 받을 변수 audioSource
    public AudioClip clip; // 배경음악을 받을 AudioClip

    private void Awake()
    {
        // 인스턴스 초기화
        if (instance == null)
        {
            instance = this;
            DontDestroyOnLoad(gameObject); // Scene 을 이동해도 Audio Manager 게임 오브젝트가 파괴되지 않음
        }
        // 기존에 인스턴스가 있다면, 새로 생성하지 않고 기존의 인스턴스 사용
        else
        {
            Destroy(gameObject);
        }
    }

    void Start()
    {
        audioSource = GetComponent<AudioSource>(); // AudioManager 오브젝트에 붙어 있는 AudioSource 컴포넌트 사용
        audioSource.clip = this.clip;
        audioSource.Play();
    }
}

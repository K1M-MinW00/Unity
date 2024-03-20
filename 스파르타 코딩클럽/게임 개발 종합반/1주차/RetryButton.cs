using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class RetryBtn : MonoBehaviour
{
    public void Retry()
    {
        // SceneManager 를 통해 MainScene 을 로드
        SceneManager.LoadScene("MainScene");
    }

}

using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Card : MonoBehaviour
{
    public SpriteRenderer frontImage; // SpriteRenderer 컴포넌트를 받을 변수 frontImage (카드의 그림 이미지)

    public GameObject front; // 카드의 앞면 front 오브젝트
    public GameObject back; // 카드의 뒷면 back 오브젝트

    public Animator anim; // 카드의 animator 컴포넌트를 받을 변수 anim 

    public int idx = 0; // 카드의 그림 정보를 저장할 변수 idx

    public void Setting(int num)
    {
        idx = num; // Board.cs 에서 전달해준 num 을 Card 에 저장
        frontImage.sprite = Resources.Load<Sprite>($"rtan{idx}"); // Resources 폴더에 있는 rtan 이미지를 가져오기
    }

    public void OpenCard()
    {
        anim.SetBool("isOpen", true);
        front.SetActive(true);
        back.SetActive(false);

        if (GameManager.instance.firstCard == null) // firstCard 가 비었다면
        {
            GameManager.instance.firstCard = this; // firstCard 에 카드 정보를 넘겨준다.
        }
        else //secondCard 가 비었다면
        {
            GameManager.instance.secondCard = this; // secondCard 에 카드 정보를 넘겨준다.
            GameManager.instance.Matched(); // Matched() 함수를 호출
        }
    }

    public void DestroyCard()
    {
        // DestroycardInvoke 함수를 1초 뒤에 실행
        Invoke("DestroyCardInvoke", 1.0f);
    }

    void DestroyCardInvoke()
    {
        // card 게임 오브젝트 삭제
        Destroy(gameObject);
    }

    public void CloseCard()
    {
        // CloseCardInvoke 함수를 1초 뒤에 실행
        Invoke("CloseCardInvoke", 1.0f);
    }

    void CloseCardInvoke()
    {
        anim.SetBool("isOpen", false);
        front.SetActive(false);
        back.SetActive(true);
    }
}

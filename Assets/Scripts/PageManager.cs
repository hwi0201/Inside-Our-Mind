using UnityEngine;

public class PageManager : MonoBehaviour
{
    public GameObject[] pages; // 페이지들 (Page1, Page2, Page3...)
    private int currentIndex = 0; // 현재 몇 번째 페이지인지

    void Start()
    {
        UpdatePages(); // 시작하자마자 1페이지만 보여줘!
    }

    // ★ 버튼이 누를 함수
    public void NextPage()
    {
        // 다음 장이 남아있으면 넘김
        if (currentIndex < pages.Length - 1)
        {
            currentIndex++;
            UpdatePages();
        }
        else
        {
            Debug.Log("마지막 페이지입니다. (창을 끄거나 게임 시작)");
            // 원하면 여기서 창을 닫게 할 수도 있음:
            // gameObject.SetActive(false);
        }
    }

    // 화면 갱신 함수 (현재 페이지만 켜고 나머지는 끔)
    void UpdatePages()
    {
        for (int i = 0; i < pages.Length; i++)
        {
            if (i == currentIndex)
                pages[i].SetActive(true);  // 너만 켜져
            else
                pages[i].SetActive(false); // 넌 꺼져
        }
    }
}
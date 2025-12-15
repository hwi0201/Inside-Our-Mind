using UnityEngine;
using TMPro;

public class IntegrationManager : MonoBehaviour
{
    [Header("엔딩 연출")]
    public GameObject memoryScreens; // 벽면에 띄울 기억 영상들 (또는 파티클)
    public GameObject finalLight;    // 마지막에 쏴올릴 하이라이트 조명
    public AudioSource climaxMusic;  // 감동적인 엔딩 BGM
    
    [Header("UI 연결")]
    public TextMeshProUGUI centerPanelText; // 중앙 안내 패널

    // 소켓에 구슬 놓으면 실행
    public void OnOrbPlaced()
    {
        Debug.Log("진 엔딩 시작!");

        // 1. 기억의 스크린들 켜기 (파노라마 연출)
        if (memoryScreens != null) memoryScreens.SetActive(true);

        // 2. 조명 켜기
        if (finalLight != null) finalLight.SetActive(true);

        // 3. 클라이막스 음악 재생
        if (climaxMusic != null) climaxMusic.Play();

        // 4. 마지막 메시지 출력
        if (centerPanelText != null)
        {
            centerPanelText.text = "<b><color=cyan>[ SYSTEM RESTORED ]</color></b>\n\n" +
                                    "Core Memory: <color=yellow>INTEGRATED</color>\n\n" +
                                    "<size=80%>You have harmonized all emotions.\n" +
                                    "The brain is now awake.</size>";
        }
        
        // (선택사항) 5초 뒤에 게임 끄기나 크레딧 씬으로 넘기기 기능도 추가 가능
    }
}
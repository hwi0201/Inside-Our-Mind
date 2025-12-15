using UnityEngine;
using TMPro; // 텍스트 쓰려면 필수

public class SadnessRoomManager : MonoBehaviour
{
    [Header("설정")]
    public int targetScore = 3; // 그림 3개
    private int currentScore = 0;

    [Header("연결")]
    public GameObject sadRain; // 비 파티클 (RainZone, Puddle 포함)
    public TextMeshProUGUI scoreText; // 방 안쪽 패널 (Page 3)
    public TextMeshProUGUI doorStatusText; // 문 앞 패널

    void Start()
    {
        UpdateScoreUI();
    }

    public void AddCleanScore()
    {
        currentScore++;
        UpdateScoreUI(); // 점수판 갱신

        if (currentScore >= targetScore)
        {
            RoomClear();
        }
    }

    // 방 안쪽 패널 (0 / 3) 업데이트
    void UpdateScoreUI()
    {
        if (scoreText != null)
        {
                scoreText.text = "<color=blue>[ CLEANING... ]\n\n" 
                            + currentScore + " / " + targetScore 
                            + "\n</color>\n"
                            + "(When the RAIN starts,\nfind the PUDDLE on the floor)";
        }
    }

    void RoomClear()
    {
        Debug.Log("청소 끝! 비가 내립니다.");
        
        // 1. 비 내리기
        if (sadRain != null) sadRain.SetActive(true);

        // 2. 문 앞 패널 'STABLE'로 변경
        if (doorStatusText != null)
        {
                doorStatusText.text = "<b><color=blue>[ Sector 02] </color></b>\n" +
                                    "<b>AMYGDALA\n(Emotion Processing Unit)</b>\n\n" +
                                    "Target: <color=#87CEEB>Sadness (Serotonin)</color>\n" +
                                    "Status: <color=blue>STABLE</color>\n\n" +
                                    "Purification Complete.";
        }
    }
}
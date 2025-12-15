using UnityEngine;
using TMPro; // 텍스트 쓰려면 필수

public class DisgustRoomManager : MonoBehaviour
{
    [Header("설정")]
    public int targetScore = 3; 
    private int currentScore = 0;

    [Header("연결")]
    public OrbColorManager myOrb; // 구슬 (클리어 시 감정 주입)
    public TextMeshProUGUI scoreText; // 방 안쪽 패널 (Page 3)
    public TextMeshProUGUI doorStatusText; // 문 앞 패널

    void Start()
    {
        UpdateScoreUI();
    }

    public void AddScore()
    {
        currentScore++;
        UpdateScoreUI(); // 점수판 갱신

        // 목표 개수만큼 다 버렸으면 클리어!
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
            scoreText.text = "<color=green>[ FILTERING... ]\n\n" 
                           + currentScore + " / " + targetScore 
                           + "\n</color>\n"
                           + "(Throw 'Bad' items\ninto the Bin)";
        }
    }

    void RoomClear()
        {
            Debug.Log("까칠의 방 클리어!");

            // 1. 구슬에 감정 추가
            if (myOrb != null)
            {
                myOrb.AddEmotion("Disgust");
            }

            // 2. 문 앞 패널 텍스트 전체 교체 (디자인 유지하면서 내용만 변경)
            if (doorStatusText != null)
            {
                doorStatusText.text = "<b><color=green>[ Sector 03 ] </color> </b>\n" +
                                    "INSULAR CORTEX\n" +
                                    "(The Safety Filter)</b>\n\n" +
                                    "Target: <color=#bdecb6>Disgust (Protection) </color>\n" +
                                    "Status: <color=green>STABLE</color>\n\n" +
                                    "Filtration Complete.";
            }
        }
}
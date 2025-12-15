using UnityEngine;
using TMPro; 

public class JoyRoomManager : MonoBehaviour
{
    [Header("설정")]
    public int targetScore = 8; 
    private int currentScore = 0;

    [Header("연결")]
    public GameObject joyWater; 
    public GameObject joyParticleEffect; 
    public TextMeshProUGUI scoreText; // 방 안쪽 점수판 (0/8)
    public TextMeshProUGUI doorStatusText; 

    void Start()
    {
        UpdateScoreUI(); 
    }

    public void AddScore()
    {
        currentScore++;
        UpdateScoreUI(); 

        if (currentScore >= targetScore)
        {
            RoomClear();
        }
    }

    void UpdateScoreUI()
    {
        if (scoreText != null)
        {
            scoreText.text = "<color=blue>[ PROGRESS ]\n\n" 
                            + currentScore + " / " + targetScore 
                            + "\n</color>\n"
                            + "(After clearing, DIP the Orb\ninto the fountain)";
        }
    }

    void RoomClear()
        {
            Debug.Log("Mission Clear!");
            
            // 1. 물이랑 폭죽 켜기 (기존 기능)
            if (joyWater != null) joyWater.SetActive(true);
            if (joyParticleEffect != null) joyParticleEffect.SetActive(true);

            if (doorStatusText != null)
            {
                doorStatusText.text = "<b><color=yellow>[ Sector 01 ]</color></b>\n" +
                                    "<b>THE REWARD CENTER</b>\n\n" +  // 여기 앞에 <b> 추가함
                                    "Target: <color=yellow>Joy (Dopamine)</color>\n" +
                                    "Status: <color=blue>STABLE</color>\n\n" + // 보통 안정(Stable)은 초록색을 많이 써서 바꿔둠 (파랑 원하면 blue로 변경)
                                    "Extraction Complete.";
            }
        }
}
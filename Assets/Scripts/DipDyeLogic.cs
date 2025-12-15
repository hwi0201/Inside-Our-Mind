using UnityEngine;

public class DipDyeLogic : MonoBehaviour
{
    // 인스펙터에서 "Joy" 또는 "Sadness"라고 적어주세요!
    public string emotionName = "Joy"; 

    private void OnTriggerEnter(Collider other)
    {
        OrbColorManager orb = other.GetComponent<OrbColorManager>();

        if (orb != null)
        {
            Debug.Log(emotionName + " 감정 획득!");
            // 색깔 대신 이름을 보냅니다.
            orb.AddEmotion(emotionName);
        }
    }
}